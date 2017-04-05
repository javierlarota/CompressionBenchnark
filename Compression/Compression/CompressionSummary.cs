using System;

namespace Compression
{
    public class CompressionSummary
    {
        public TimeSpan Duration { get; set; }
        public double OriginalFileSize { get; set; }
        public double CompressedFileSize { get; set; }
        public double CompressionRatio { get; set; }
        public double Speed { get; set; }
    }
}
