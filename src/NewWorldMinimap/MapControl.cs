﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewWorldMinimap
{
    public class MapControl : PictureBox
    {
        public bool IsCircular { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var path = new GraphicsPath())
            {
                if (IsCircular)
                    path.AddEllipse(0, 0, (this.Parent as MapForm).DisplayRectangle.Width, (this.Parent as MapForm).DisplayRectangle.Height - 1);
                else
                    path.AddRectangle(new Rectangle(0, 0, Parent.Width, Parent.Height));
                Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width, this.Height);
            }
        }
    }
}
