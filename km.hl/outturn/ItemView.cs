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
            lblQty.Text = item.Quantity.ToString();
            lblPickedQty.Text = item.QtyPicked.ToString();
            lblMisc.Text = item.NoSerialNeed ? "ns" : "";
            bxStatus.Image = item.QtyPicked == item.Quantity ? Resources.greenBall : Resources.redBall;
        }

        #region desighner generated code
        private Label lblItem;
        private Label lblQty;
        private Label lblIntCode;
        private Label lblMnfCode;
        private Label lblPickedQty;
        private Label lblMisc;

        private void InitializeComponent() {
            this.lblItem = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblIntCode = new System.Windows.Forms.Label();
            this.lblMnfCode = new System.Windows.Forms.Label();
            this.lblPickedQty = new System.Windows.Forms.Label();
            this.lblMisc = new System.Windows.Forms.Label();
            this.bxStatus = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(0, 1);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(166, 16);
            this.lblItem.Text = "label1";
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblQty.Location = new System.Drawing.Point(163, 2);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 16);
            this.lblQty.Text = "label4";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIntCode
            // 
            this.lblIntCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIntCode.Location = new System.Drawing.Point(0, 18);
            this.lblIntCode.Name = "lblIntCode";
            this.lblIntCode.Size = new System.Drawing.Size(166, 16);
            this.lblIntCode.Text = "label1";
            // 
            // lblMnfCode
            // 
            this.lblMnfCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMnfCode.Location = new System.Drawing.Point(0, 35);
            this.lblMnfCode.Name = "lblMnfCode";
            this.lblMnfCode.Size = new System.Drawing.Size(166, 16);
            this.lblMnfCode.Text = "label1";
            // 
            // lblPickedQty
            // 
            this.lblPickedQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPickedQty.Location = new System.Drawing.Point(163, 18);
            this.lblPickedQty.Name = "lblPickedQty";
            this.lblPickedQty.Size = new System.Drawing.Size(54, 16);
            this.lblPickedQty.Text = "label4";
            this.lblPickedQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMisc
            // 
            this.lblMisc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMisc.Location = new System.Drawing.Point(163, 35);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(40, 16);
            this.lblMisc.Text = "label4";
            this.lblMisc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bxStatus
            // 
            this.bxStatus.Location = new System.Drawing.Point(205, 37);
            this.bxStatus.Name = "bxStatus";
            this.bxStatus.Size = new System.Drawing.Size(12, 12);
            this.bxStatus.Click += new System.EventHandler(this.bxStatus_Click);
            // 
            // ItemView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bxStatus);
            this.Controls.Add(this.lblMisc);
            this.Controls.Add(this.lblPickedQty);
            this.Controls.Add(this.lblQty);
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