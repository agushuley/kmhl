using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace g.forms {
    public partial class Label : Control {
        public Label() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe) {
            pe.Graphics.FillRectangle(new SolidBrush(BackColor), this.ClientRectangle);
            pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), this.ClientRectangle);
        }
    }
}
