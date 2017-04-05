using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace Compression.CompressionAlgorithm
{
    public class SharpZipLibCompressor : ICompressionAlgorithm
    {
        public void Compress(string sourceFile, string compressedFile)
        {
            using (Stream source = File.OpenRead(sourceFile))
            {
                using (var file = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
                {
                    using (ZipOutputStream zip = new ZipOutputStream(file))
                    {
                        zip.SetLevel(1);   // 0..9.

                        ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));
                        entry.DateTime = DateTime.Now;
                        entry.Size = source.Length;

                        zip.PutNextEntry(entry);
                        source.CopyTo(zip);
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
