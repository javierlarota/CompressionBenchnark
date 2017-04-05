using Compression.CompressionAlgorithm;
using System;
using System.Diagnostics;
using System.IO;

namespace Compression
{
    public class CompressionManager
    {
        public static CompressionSummary Compress(CompressionType compressionType, string sourceFile, string compressedFile)
        {
            Stopwatch stopWatch = new Stopwatch();

            var compressor = CompressionFactory.GetCompressionAlgorithm(compressionType);
            stopWatch.Start();
            compressor.Compress(sourceFile, compressedFile);
            stopWatch.Stop();

            long originalFileSize = new FileInfo(sourceFile).Length;
            long compressedFileSize = new FileInfo(compressedFile).Length;

            return new CompressionSummary()
            {
                OriginalFileSize = originalFileSize,
                CompressedFileSize = compressedFileSize,
                CompressionRatio = Math.Round(100 - ((double)compressedFileSize / (double)originalFileSize) * (double)100, 2),
                Duration = stopWatch.Elapsed,
                Speed = ((double)originalFileSize / (double)stopWatch.Elapsed.TotalMilliseconds) * (double)1000
            };
        }

        public void Uncompress()
        {
            var compressor = CompressionFactory.GetCompressionAlgorithm(CompressionType.Snappy);
        }
    }
}
