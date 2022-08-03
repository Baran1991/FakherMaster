using System;
using System.Drawing;
using System.Windows.Forms;

namespace rComponents
{
    [Serializable]
    public class rGridViewButton
    {
        public string Text { get; set; }
        public Image Image { get; set; }
        public bool VisibleOnSelect { get; set; }
        public bool EnableOnSelect { get; set; }
        public rGridViewButtonPosition Position { get; set; }
        internal object Control { get; set; }

        public rGridViewButton()
        {
            Position = rGridViewButtonPosition.Before;
        }
    }

    public enum rGridViewButtonPosition
    {
        Before,
        After
    }
}
    