using System;

namespace rComponents
{
    public interface IProgressive
    {
        event EventHandler<ProgressEventArgs> Progress;
        void OnProgress(string text, int value, int maximum);
    }

    public class ProgressEventArgs : EventArgs
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public int Maximum { get; set; }
    }
}