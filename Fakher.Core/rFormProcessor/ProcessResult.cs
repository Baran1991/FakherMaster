using System;
using System.Drawing;

namespace rFormProcessor
{
    public class ProcessResult : IDisposable
    {
        public Bitmap RawImage { get; set; }
        public Bitmap ProcessedImage { get; set; }
        public Bitmap IdentifierImage { get; set; }
        public int IdentificationConfidence { get; set; }
        public string Identifier { get; set; }
        public string Answers { get; set; }
        public long PreProcessDuration;
        public long IdentificationDuration;
        public long ReadFieldsDuration;

        public ProcessResult()
        {
//            Identifier = "";
            Answers = "";
        }

        public void Dispose()
        {
            RawImage.Dispose();
            ProcessedImage.Dispose();
            IdentifierImage.Dispose();
        }
    }
}