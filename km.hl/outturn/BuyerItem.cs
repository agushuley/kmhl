using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace km.hl.outturn {
    class BuyerItem : ClickShowUserControl {
        public BuyerItem(orm.Buyer buyer, ICollection<orm.MoveOrder> orders, ScanAlgorithm alghoritm) {
            InitializeComponent();

            lblBuyer.Text = String.Format("{0} ({1})", buyer.Description, buyer.Id);
            this.buyer = buyer;
            this.alghoritm = alghoritm;

            foreach (orm.MoveOrder order in orders) {
                if (order.Buyer == buyer) {
                    this.orders.Add(order);
                }
            }
            redraw();
        }

        IDictionary<orm.MoveOrder, BuyerOrderView> views = null;
        IList<orm.MoveOrder> orders = new List<orm.MoveOrder>();

        private g.forms.Label lblBuyer;
        private PictureBox pictState;
        private Label lblOrder;
        private Label lblOrderInfo;
        private ScanAlgorithm alghoritm;

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);

            List<orm.MoveOrderItem> items = new List<orm.MoveOrderItem>();
            foreach (orm.MoveOrder order in orders) {
                items.AddRange(order.Items);
            }
            new ItemsForm(items, alghoritm).ShowDialog();
            redraw();
        }

        public void redraw() {
            if (views == null) {
                Dictionary<orm.MoveOrder, BuyerOrderView> vs = new Dictionary<km.hl.orm.MoveOrder,BuyerOrderView>();
                Height = pictState.Top;
                for (int i = 0; i < orders.Count; i++) {
                    BuyerOrderView v = new BuyerOrderView();
                    if (i == 0) {
                        v.name = lblOrder;
                        v.state = lblOrderInfo;
                        v.picture = pictState;
                    }
                    else {
                        v = createOrderControls(Height);
                    }
                    vs.Add(orders[i], v);
                    Height += 16;
               }
               views = vs;
            }
            foreach (KeyValuePair<orm.MoveOrder, BuyerOrderView> pair in views) {
                pair.Value.name.Text = pair.Key.Number;
                int all = 0, picked = 0;
                foreach (orm.MoveOrderItem item in pair.Key.Items) {
                    all += item.Quantity;
                    picked += item.QtyPicked;
                }
                pair.Value.state.Text = String.Format("it: {0} qt: {1} pq: {2}", pair.Key.Items.Count,
                    all, picked);
                pair.Value.picture.Image = pair.Key.Complete ? Resources.greenBall : Resources.redBall;
            }
        }

        private BuyerOrderView createOrderControls(int top) {
            BuyerOrderView v = new BuyerOrderView();

            v.picture = new PictureBox();
            Controls.Add(v.picture);
            v.picture.Location = new System.Drawing.Point(3, top);
            v.picture.Name = "pictState";
            v.picture.Size = new System.Drawing.Size(12, 12);
            v.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            v.picture.Click += new System.EventHandler(this.pictState_Click);


            v.name = new Label();
            Controls.Add(v.name);
            v.name.Location = new System.Drawing.Point(19, top);
            v.name.Size = new System.Drawing.Size(88, 15);
            v.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            v.name.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            v.name.Name = "lblOrder";
            v.name.Text = "lblOrder";

            v.state = new Label();
            Controls.Add(v.state);
            v.state.Location = new System.Drawing.Point(112, top);
            v.state.Size = new System.Drawing.Size(101, 15);
            v.state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            v.state.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            v.state.Name = "lblOrderInfo";
            v.state.Text = "lblOrderInfo";
            v.state.TextAlign = System.Drawing.ContentAlignment.TopRight;

            return v;
        }

        orm.Buyer buyer;

        #region Desighner generate code
        private void InitializeComponent() {
            this.lblBuyer = new g.forms.Label();
            this.pictState = new System.Windows.Forms.PictureBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBuyer
            // 
            this.lblBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuyer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblBuyer.Location = new System.Drawing.Point(0, 0);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(217, 20);
            this.lblBuyer.Text = "label1";
            // 
            // pictState
            // 
            this.pictState.Location = new System.Drawing.Point(3, 19);
            this.pictState.Name = "pictState";
            this.pictState.Size = new System.Drawing.Size(12, 12);
            this.pictState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictState.Click += new System.EventHandler(this.pictState_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblOrder.Location = new System.Drawing.Point(19, 19);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(88, 15);
            this.lblOrder.Text = "lblOrder";
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
            // BuyerItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictState);
            this.Controls.Add(this.lblOrderInfo);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.lblBuyer);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Name = "BuyerItem";
            this.Size = new System.Drawing.Size(216, 35);
            this.ResumeLayout(false);

        }
        #endregion

        private struct BuyerOrderView {
            public Label name, state;
            public PictureBox picture;
        }

        private void pictState_Click(object sender, EventArgs e) {
            OnClick(e);
        }
    }
}
