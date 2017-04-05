using System;
using System.Collections.Generic;

namespace Compression
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var compressionTypes = new List<CompressionType>() { CompressionType.Snappy, CompressionType.LZ4, CompressionType.SharpZipLib, CompressionType.Zip, CompressionType.GZip };

            foreach (var compressionType in compressionTypes)
            {
                var summary = CompressionManager.Compress(compressionType, @"TestFile100MB.txt", $@"TestFileCompressed.{compressionType}");

                Console.WriteLine($"{compressionType}:\t\t{summary.OriginalFileSize}\t{summary.CompressionRatio}%\t{summary.Duration.TotalMilliseconds}\t{Math.Round((summary.Speed / (double)1024 / (double)1024), 1)} MB/Sec");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Comparation complete. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
