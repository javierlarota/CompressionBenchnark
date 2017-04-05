using System;
using System.IO;
using System.IO.Compression;

namespace Compression.CompressionAlgorithm
{
    public class ZipCompressor : ICompressionAlgorithm
    {
        public void Compress(string sourceFile, string compressedFile)
        {
            using (var source = File.OpenRead(sourceFile))
            {
                using (var file = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
                {
                    using (var zipArchive = new ZipArchive(file, ZipArchiveMode.Create, true))
                    {
                        var demoFile = zipArchive.CreateEntry(Path.GetFileName(sourceFile));

                        using (Stream entryStream = demoFile.Open())
                        {
                            source.CopyTo(entryStream);
                        }
                    }
                }
            }
        }

        public void UnCompress(string compressedFile, string destinationFile)
        {
            throw new NotImplementedException();
        }
    }
}
