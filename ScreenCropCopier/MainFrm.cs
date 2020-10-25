using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCropCopier
{
    public partial class MainFrm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        
        public MainFrm()
        {
            InitializeComponent();
        }

        private static int Opacity = 100;

        Rectangle copyrect = new Rectangle(0, 0, 100, 100);

        CopyWindow Frm = new CopyWindow();

        private void Loaded(object sender, EventArgs e)
        {
            Frm.Show();

            var trd = new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                while (true)
                {
                    var i = new Bitmap(copyrect.Width, copyrect.Height);
                    using (Graphics g = Graphics.FromImage(i))
                    {
                        g.CopyFromScreen(copyrect.X, copyrect.Y, 0, 0, copyrect.Size, CopyPixelOperation.SourceCopy);
                    }
                    Frm.SetBitmap(i, Opacity);
                    GC.Collect(1);
                    System.Threading.Thread.Sleep(16);
                }
            });
            trd.IsBackground = true;
            trd.Start();
        }

        internal class CopyWindow : Form
        {
            public CopyWindow()
            {
                FormBorderStyle = FormBorderStyle.None;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    try
                    {
                        var style = base.CreateParams;
                        style.ClassStyle |= 200;
                        style.ExStyle |= 0x8;
                        style.ExStyle |= 0x80000;
                        style.ExStyle |= 0x8000000;
                        return style;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x84)
                {
                    Point pos = new Point(m.LParam.ToInt32());
                    pos = PointToClient(pos);
                    m.Result = (IntPtr)2;
                    return;
                }
                try
                {
                    base.WndProc(ref m);
                }
                catch { }
            }

            internal void EnableMouseClickThru()
            {
                try
                {
                    NativeMethods.SetWindowLong (Handle, new IntPtr(-20), new IntPtr(NativeMethods.GetWindowLong(Handle, -20) | 0x20));
                }
                catch
                { }
            }

            internal void DisableMouseClickThru()
            {
                try
                {
                    NativeMethods.SetWindowLong (Handle, new IntPtr(-20), new IntPtr(NativeMethods.GetWindowLong(Handle, -20) & ~0x20));
                }
                catch { }
            }

            internal void SetBitmap(Bitmap bitmap, int alpha = 100)
            {
                IntPtr screenDc = NativeMethods.GetDC(IntPtr.Zero);
                IntPtr compatibleMemoryDc = NativeMethods.CreateCompatibleDC(screenDc);
                IntPtr hgdiBitmap = IntPtr.Zero;
                IntPtr hgdiOldBitmap = IntPtr.Zero;
                try
                {
                    try
                    {
                        hgdiBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    }
                    catch
                    { return; }
                    hgdiOldBitmap = NativeMethods.SelectObject(compatibleMemoryDc, hgdiBitmap);
                    NativeMethods.SizeStruct size = new NativeMethods.SizeStruct()
                    {
                        X = bitmap.Width,
                        Y = bitmap.Height
                    };
                    NativeMethods.PointStruct sourcePoint = new NativeMethods.PointStruct();
                    NativeMethods.PointStruct topPoint = new NativeMethods.PointStruct()
                    {
                        X = Left,
                        Y = Top
                    };

                    NativeMethods.BlendFunctionStruct blend = new NativeMethods.BlendFunctionStruct()
                    {
                        BlendOp = (byte)(255 * alpha / 100d) /* opacity */,
                        BlendFlags = 0x00 /* AC_SRC_OVER */,
                        AlphaFormat = 0x01 /* AC_SRC_ALPHA */,
                        SourceConstantAlpha = (byte)(255 * alpha / 100d)
                    };

                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            NativeMethods.UpdateLayeredWindow(Handle, screenDc, ref topPoint, ref size, compatibleMemoryDc,
                                ref sourcePoint, 0, ref blend, 2 /* ULW_ALPHA */);
                        });
                    }
                    catch { }
                }
                finally
                {
                    if (screenDc != IntPtr.Zero)
                    {
                        NativeMethods.ReleaseDC(IntPtr.Zero, screenDc);
                    }

                    if (hgdiBitmap != IntPtr.Zero)
                    {
                        NativeMethods.SelectObject(compatibleMemoryDc, hgdiOldBitmap);
                        NativeMethods.DeleteObject(hgdiBitmap);
                    }

                    NativeMethods.DeleteDC(compatibleMemoryDc);
                }
            }
        }

        internal class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

            [DllImport("user32.dll", SetLastError = true)]
            public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref PointStruct pptDst,
                ref SizeStruct pSize, IntPtr hDc, ref PointStruct pptSrc, int crKey, ref BlendFunctionStruct pBlend, int dwFlags);

            [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
            public extern static IntPtr SetWindowLong(IntPtr handle, IntPtr index, IntPtr dwNewLong);

            [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", SetLastError = true)]
            public extern static IntPtr GetDC(IntPtr handle);

            [DllImport("user32.dll", SetLastError = false)]
            public extern static IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

            [DllImport("gdi32.dll", SetLastError = true)]
            public extern static IntPtr CreateCompatibleDC(IntPtr hDc);

            [DllImport("gdi32.dll", SetLastError = true)]
            public extern static bool DeleteDC(IntPtr hDc);

            [DllImport("gdi32.dll", SetLastError = false)]
            public extern static IntPtr SelectObject(IntPtr hDc, IntPtr hgdiObject);

            [DllImport("gdi32.dll", SetLastError = true)]
            public extern static bool DeleteObject(IntPtr hgdiObject);

            [DllImport("user32.dll")]
            public static extern short GetKeyState(int nVirtKey);

            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam);

            public struct PointStruct
            {
                public int X;
                public int Y;
            }

            public struct SizeStruct
            {
                public int X;
                public int Y;
            }

            public struct BlendFunctionStruct
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }
        }
        
        private void ClickThru(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                Frm.EnableMouseClickThru();
            }
            else
            {
                Frm.DisableMouseClickThru();
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            copyrect = new Rectangle((int)RectX.Value, (int)RectY.Value, (int)RectW.Value, (int)RectH.Value);
        }

        private void OpacityChanged(object sender, EventArgs e)
        {
            Opacity = (int)((NumericUpDown)sender).Value;
        }
    }
}
