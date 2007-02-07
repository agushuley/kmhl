using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    class OrderItem : ClickShowUserControl {
        public OrderItem(orm.MoveOrder order, ScanAlgorithm alghoritm) {
            InitializeComponent();

            this.alghoritm = alghoritm;
            this.order = order;

            redraw();
        }

        orm.MoveOrder order = null;

        private Label lblOrder;
        private PictureBox pictState;
        private Label lblBuyer;
        private Label lblOrderInfo;
        private ScanAlgorithm alghoritm;

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);

            List<orm.MoveOrderItem> items = new List<orm.MoveOrderItem>();
            items.AddRange(order.Items);
            new ItemsForm(items, alghoritm).ShowDialog();
            redraw();
        }

        public void redraw() {
            lblOrder.Text = order.Number;
            lblBuyer.Text = String.Format("{0} ({1})", order.Buyer.Description, order.Buyer.Id);
            int all = 0, picked = 0;
            foreach (orm.MoveOrderItem item in order.Items) {
                all += item.Quantity;
                picked += item.QtyPicked;
            }
            lblOrderInfo.Text = String.Format("it: {0} qt: {1} pq: {2}", order.Items.Count,
                    all, picked);
             pictState.Image = order.Complete ? Resources.greenBall : Resources.redBall;
        }

        #region Desighner generate code
        private void InitializeComponent() {
            this.lblOrder = new System.Windows.Forms.Label();
            this.pictState = new System.Windows.Forms.PictureBox();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblOrder.Location = new System.Drawing.Point(0, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(217, 20);
            this.lblOrder.Text = "label1";
            // 
            // pictState
            // 
            this.pictState.Location = new System.Drawing.Point(3, 19);
            this.pictState.Name = "pictState";
            this.pictState.Size = new System.Drawing.Size(12, 12);
            this.pictState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictState.Click += new System.EventHandler(this.pictState_Click);
            // 
            // lblBuyer
            // 
            this.lblBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuyer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBuyer.Location = new System.Drawing.Point(19, 19);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(88, 15);
            this.lblBuyer.Text = "lblOrder";
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblOrderInfo.Location = new System.Drawing.Point(112, 19);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(101, 15);
            this.lblOrderInfo.Text = "lblOrderInfo";
            this.lblOrderInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrderItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictState);
            this.Controls.Add(this.lblOrderInfo);
            this.Controls.Add(this.lblBuyer);
            this.Controls.Add(this.lblOrder);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Name = "OrderItem";
            this.Size = new System.Drawing.Size(216, 35);
            this.ResumeLayout(false);

        }
        #endregion

        private void pictState_Click(object sender, EventArgs e) {
            OnClick(e);
        }
    }
}
