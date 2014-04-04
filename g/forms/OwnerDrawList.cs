using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace g.forms {
    public partial class OwnerDrawList : UserControl {
        int scrollWidth;
        int itemHeight = 1;
        int selectedIndex = 0;

        Bitmap offScreen;
        VScrollBar vs;
        ArrayList items;

        public OwnerDrawList() {
            InitializeComponent();

            this.vs = new VScrollBar();
            scrollWidth = this.vs.Width;
            this.vs.Parent = this;
            this.vs.Visible = false;
            this.vs.SmallChange = 1;
            this.vs.ValueChanged += new EventHandler(this.ScrollValueChanged);

            // Items to draw
            this.items = new ArrayList();
        }

        public ArrayList Items {
            get { return this.items; }
        }

        protected Bitmap OffScreen {
            get { return this.offScreen; }
        }

        protected VScrollBar VScrollBar {
            get { return this.vs; }
        }

        public event EventHandler SelectedIndexChanged;

        // Raise the SelectedIndexChanged event
        protected virtual void OnSelectedIndexChanged(EventArgs e) {
            if (this.SelectedIndexChanged != null)
                this.SelectedIndexChanged(this, e);
        }

        // Get or set index of selected item.
        public int SelectedIndex {
            get { return this.selectedIndex; }

            set {
                this.selectedIndex = value;
                if (this.SelectedIndexChanged != null)
                    this.SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        protected void ScrollValueChanged(object o, EventArgs e) {
            this.Refresh();
        }

        protected virtual int ItemHeight {
            get { return this.itemHeight; }
            set { this.itemHeight = value; }
        }

        // If the requested index is before the first visible index then set the
        // first item to be the requested index. If it is after the last visible
        // index, then set the last visible index to be the requested index.
        public void EnsureVisible(int index) {
            if (index < this.vs.Value) {
                this.vs.Value = index;
                this.Refresh();
            }
            else if (index >= this.vs.Value + this.DrawCount) {
                this.vs.Value = index - this.DrawCount + 1;
                this.Refresh();
            }
        }

        // Selected item moves when you use the keyboard up/down keys.
        protected override void OnKeyDown(KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Down:
                    if (this.SelectedIndex < this.vs.Maximum) {
                        EnsureVisible(++this.SelectedIndex);
                        this.Refresh();
                    }
                    break;
                case Keys.Up:
                    if (this.SelectedIndex > this.vs.Minimum) {
                        EnsureVisible(--this.SelectedIndex);
                        this.Refresh();
                    }
                    break;
            }

            base.OnKeyDown(e);
        }

        // Calculate how many items we can draw given the height of the control.
        protected int DrawCount {
            get {
                if (this.vs.Value + this.vs.LargeChange > this.vs.Maximum)
                    return this.vs.Maximum - this.vs.Value + 1;
                else
                    return this.vs.LargeChange;
            }
        }

        protected override void OnResize(EventArgs e) {
            int viewableItemCount = this.ClientSize.Height / this.ItemHeight;

            this.vs.Bounds = new Rectangle(this.ClientSize.Width - scrollWidth,
                0,
                scrollWidth,
                this.ClientSize.Height);


            // Determine if scrollbars are needed
            if (this.items.Count > viewableItemCount) {
                this.vs.Visible = true;
                this.vs.LargeChange = viewableItemCount;
                this.offScreen = new Bitmap(this.ClientSize.Width - scrollWidth - 1, this.ClientSize.Height - 2);
            }
            else {
                this.vs.Visible = false;
                this.vs.LargeChange = this.items.Count;
                this.offScreen = new Bitmap(this.ClientSize.Width - 1, this.ClientSize.Height - 2);
            }

            this.vs.Maximum = this.items.Count - 1;
        }

        // Determine what the text color should be
        // for the selected item drawn as highlighted
        protected Color CalcTextColor(Color backgroundColor) {
            if (backgroundColor.Equals(Color.Empty))
                return Color.Black;

            int sum = backgroundColor.R + backgroundColor.G + backgroundColor.B;

            if (sum > 256)
                return Color.Black;
            else
                return Color.White;
        }
    }
}
