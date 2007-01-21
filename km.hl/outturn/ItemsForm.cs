using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    public partial class ItemsForm : Form {
        public ItemsForm(ICollection<orm.MoveOrderItem> items) {
            InitializeComponent();

            this.items = new orm.MoveOrderItem[items.Count];
            items.CopyTo(this.items, 0);
        }

        orm.MoveOrderItem[] items;

        private void ItemsForm_Load(object sender, EventArgs e) {
            foreach (orm.MoveOrderItem item in items) {
                Button button = new Button();
                button.Text = item.Description;
                button.Dock = DockStyle.Top;
                this.Controls.Add(button);
            }
        }
    }
}