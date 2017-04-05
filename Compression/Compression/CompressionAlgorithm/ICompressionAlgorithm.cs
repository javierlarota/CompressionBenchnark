namespace Compression.CompressionAlgorithm
{
    public interface ICompressionAlgorithm
    {
        void Compress(string sourceFile, string compressedFile);
        void UnCompress(string compressedFile, string destinationFile);
    }
}