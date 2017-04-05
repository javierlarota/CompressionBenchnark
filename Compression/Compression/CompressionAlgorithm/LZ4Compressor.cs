using LZ4;
using System.IO;
using System.IO.Compression;

namespace Compression.CompressionAlgorithm
{
    class LZ4Compressor : ICompressionAlgorithm
    {
        public void Compress(string sourceFile, string compressedFile)
        {
            using (Stream source = File.OpenRead(sourceFile))
            {
                using (var file = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
                {
                    using (var compressor = new LZ4Stream(file, CompressionMode.Compress))
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
                using (var decoder = new LZ4Stream(source, CompressionMode.Decompress))
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
