using System;

namespace rComponents
{
    public class CustomButtonClickEventArgs : EventArgs
    {
        public rGridViewButton Button { get; set; }
        public int ButtonIndex { get; set; }

        public CustomButtonClickEventArgs(rGridViewButton button, int index)
        {
            Button = button;
            ButtonIndex = index;
        }
    }
}