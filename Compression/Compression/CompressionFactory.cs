using System;
using Compression.CompressionAlgorithm;

namespace Compression
{
    public enum CompressionType
    {
        Snappy,
        LZ4,
        SharpZipLib,
        Zip,
        GZip
    }
    public class CompressionFactory
    {
        public static ICompressionAlgorithm GetCompressionAlgorithm(CompressionType compressionType)
        {
            switch (compressionType)
            {
                case CompressionType.Snappy:
                    return new SnappyCompressor();
                case CompressionType.LZ4:
                    return new LZ4Compressor();
                case CompressionType.SharpZipLib:
                    return new SharpZipLibCompressor();
                case CompressionType.Zip:
                    return new ZipCompressor();
                case CompressionType.GZip:
                    return new GZipCompressor();
                default:
                    throw new Exception("Unsupported compression Type");
            }
        }
    }
}
