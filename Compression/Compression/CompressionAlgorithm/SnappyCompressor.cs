using Snappy;
using System.IO;
using System.IO.Compression;

namespace Compression.CompressionAlgorithm
{
    public class SnappyCompressor : ICompressionAlgorithm
    {
        public void Compress(string sourceFile, string compressedFile)
        {
            using (Stream source = File.OpenRead(sourceFile))
            {
                using (var file = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
                {
                    using (var compressor = new SnappyStream(file, CompressionMode.Compress))
                    {
                        source.CopyTo(compressor);
                    }
                }
            }
        }

        public void UnCompress(string compressedFile, string destinationFile)
        {
            using (Stream source = File.OpenRead(compressedFile))
            {
                using (var decoder = new SnappyStream(source, CompressionMode.Decompress))
                {
                    using (var file = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                    {
                        decoder.CopyTo(file);
                    }
                }
            }
        }
    }
}
