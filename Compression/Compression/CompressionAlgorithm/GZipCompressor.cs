using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression.CompressionAlgorithm
{
    public class GZipCompressor : ICompressionAlgorithm
    {
        public void Compress(string sourceFile, string compressedFile)
        {
            using (Stream source = File.OpenRead(sourceFile))
            {
                using (var file = new FileStream(compressedFile, FileMode.Create, FileAccess.Write))
                {
                    using (var compressor = new GZipStream(file, CompressionMode.Compress))
                    {
                        source.CopyTo(compressor);
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
