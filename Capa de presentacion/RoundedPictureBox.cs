using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public class RoundedPictureBox : PictureBox
    {
        public int CornerRadius { get; set; } = 20;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(rect.Right - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(rect.Right - CornerRadius, rect.Bottom - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseFigure();

                Region = new Region(path);
                if (this.Image != null)
                {
                    g.SetClip(path);
                    g.DrawImage(this.Image, rect);
                }
            }
        }
    }
}
