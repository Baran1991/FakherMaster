using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace rTwain
{
    public partial class rTwainControl : Component, IMessageFilter
    {
        private bool msgfilter;
        private Twain tw;

        public bool ShowUI { get; set; }
        public event EventHandler<DocumentScannedEventArgs> DocumentScanned;
        public event EventHandler BeginScan;
        public event EventHandler ScanFinished;

        public rTwainControl()
        {
            InitializeComponent();
            Init();
        }

        public rTwainControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            tw = new Twain();
            tw.DocumentScanned += new EventHandler<DocumentScannedEventArgs>(tw_DocumentScanned);
        }

        private void tw_DocumentScanned(object sender, DocumentScannedEventArgs e)
        {
            OnDocumentScanned(e.ImageHandle);
        }

        public void Initialize(IntPtr handle)
        {
            tw.Init(handle);
        }

        protected void OnDocumentScanned(IntPtr image)
        {
            if (DocumentScanned != null)
            {
                DocumentScannedEventArgs args = new DocumentScannedEventArgs();
                args.ImageHandle = image;
                args.Image = TwainImageConverter.ConvertToBitmap(image);
                DocumentScanned(this, args);
            }
        }

        public void SelectSource()
        {
            tw.Select();
        }

        public void Scan()
        {
            if (!msgfilter)
            {
                Application.AddMessageFilter(this);
                msgfilter = true;
            }
            tw.Acquire(ShowUI);
        }

        public bool PreFilterMessage(ref Message m)
        {
            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Not)
                return false;

            switch (cmd)
            {
                case TwainCommand.CloseRequest:
                    {
                        OnScanFinished();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.CloseOk:
                    {
                        OnScanFinished();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.DeviceEvent:
                    {
                        break;
                    }
                case TwainCommand.TransferReady:
                    {
                        OnBeginScan();

                        do
                        {
                            IntPtr picture = tw.TransferPicture();
                            OnDocumentScanned(picture);

                            Twain.GlobalUnlock(picture);
                            Twain.GlobalFree(picture);
//                            Marshal.FreeHGlobal(picture);
                        } while (tw.HasPendingTransfer);

                        OnScanFinished();
                        tw.CloseSrc();
                        break;
                    }
            }
            return true;
        }

        protected void OnScanFinished()
        {
            ReleaseMessageFilter();

            if (ScanFinished != null)
                ScanFinished(this, EventArgs.Empty);
        }

        private void ReleaseMessageFilter()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
            }
        }

        protected void OnBeginScan()
        {
            if (BeginScan != null)
                BeginScan(this, EventArgs.Empty);
        }

        public new void Dispose()
        {
            ReleaseMessageFilter();
            tw.Finish();
            if (components != null)
            {
                components.Dispose();
            }
            base.Dispose();
        }
    }

    public class DocumentScannedEventArgs : EventArgs
    {
        public IntPtr ImageHandle { get; set; }
        public Bitmap Image { get; set; }
    }
}
