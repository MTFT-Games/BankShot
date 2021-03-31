using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExternalTool
{
    /// <summary>
    /// Author: Hans Passant 
    /// (Stackoverflow link: https://stackoverflow.com/questions/17264225/how-can-user-resize-control-at-runtime-in-winforms)
    /// Defines a user re-sizable picturebox. Decided against using
    /// </summary>
    class SizeablePictureBox : PictureBox
    {
        public SizeablePictureBox()
        {
            this.ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= 0x840000;
                return cp;
            }
        }
        private const int grab = 16;
    }
}
