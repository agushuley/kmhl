using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using km.hl.orm;

namespace km.hl.outturn {
    public partial class ItemView : ClickShowUserControl {
        public ItemView(MoveOrderItem item) {
            InitializeComponent();

            this.item = item;
            redraw();
        }

        private PictureBox bxStatus;

        private MoveOrderItem item;

        public MoveOrderItem Item {
            get { return item; }
        }

        public void redraw() {
            lblItem.Text = item.Description;
            lblIntCode.Text = item.InternalCode;
            lblMnfCode.Text = item.MfrCode;
            lblStatus.Text = String.Format("{0} / {1} / {2}", item.Quantity, item.QtyPicked,
                (item.NoSerialNeed ? "-" : (Object)item.Serials.Count));
            bxStatus.Image = item.QtyPicked == item.Quantity ? Resources.greenBall : Resources.redBall;
        }

        #region desighner generated code
        private Label lblItem;
        private Label lblIntCode;
        private Label lblMnfCode;
        private Label lblStatus;

        private void InitializeComponent() {
            this.lblItem = new System.Windows.Forms.Label();
            this.lblIntCode = new System.Windows.Forms.Label();
            this.lblMnfCode = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bxStatus = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(0, 1);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(199, 16);
            this.lblItem.Text = "label1";
            // 
            // lblIntCode
            // 
            this.lblIntCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIntCode.Location = new System.Drawing.Point(0, 18);
            this.lblIntCode.Name = "lblIntCode";
            this.lblIntCode.Size = new System.Drawing.Size(144, 16);
            this.lblIntCode.Text = "label1";
            // 
            // lblMnfCode
            // 
            this.lblMnfCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMnfCode.Location = new System.Drawing.Point(0, 35);
            this.lblMnfCode.Name = "lblMnfCode";
            this.lblMnfCode.Size = new System.Drawing.Size(144, 16);
            this.lblMnfCode.Text = "label1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(142, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 33);
            this.lblStatus.Text = "label4";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bxStatus
            // 
            this.bxStatus.Location = new System.Drawing.Point(205, 1);
            this.bxStatus.Name = "bxStatus";
            this.bxStatus.Size = new System.Drawing.Size(12, 12);
            this.bxStatus.Click += new System.EventHandler(this.bxStatus_Click);
            // 
            // ItemView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bxStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblMnfCode);
            this.Controls.Add(this.lblIntCode);
            this.Controls.Add(this.lblItem);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Name = "ItemView";
            this.Size = new System.Drawing.Size(218, 50);
            this.ResumeLayout(false);

        }
        #endregion

        private void bxStatus_Click(object sender, EventArgs e) {
            OnClick(e);
        }
    }
}