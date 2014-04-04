using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace km.hl {
    public partial class ClickShowUserControl : UserControl {
        public ClickShowUserControl() {
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            pressed = true;
            prevColor = this.BackColor;
            this.BackColor = System.Drawing.Color.LightYellow;
        }
        private bool pressed = false;
        System.Drawing.Color prevColor;

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if (pressed) {
                this.BackColor = prevColor;
            }
        }
    }


}
