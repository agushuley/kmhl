namespace km.hl.outturn {
    partial class ItemsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.itemsViews = new System.Windows.Forms.Panel();
            this.code = new System.Windows.Forms.TextBox();
            this.btnScanned = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemsViews
            // 
            this.itemsViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsViews.AutoScroll = true;
            this.itemsViews.Location = new System.Drawing.Point(0, 32);
            this.itemsViews.Name = "itemsViews";
            this.itemsViews.Size = new System.Drawing.Size(238, 243);
            // 
            // code
            // 
            this.code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.code.Location = new System.Drawing.Point(0, 1);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(136, 23);
            this.code.TabIndex = 1;
            // 
            // btnScanned
            // 
            this.btnScanned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanned.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnScanned.Location = new System.Drawing.Point(136, 0);
            this.btnScanned.Name = "btnScanned";
            this.btnScanned.Size = new System.Drawing.Size(34, 32);
            this.btnScanned.TabIndex = 2;
            this.btnScanned.Text = ">";
            this.btnScanned.Click += new System.EventHandler(this.btnScanned_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnClear.Location = new System.Drawing.Point(170, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(34, 32);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "O";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(204, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnScanned);
            this.Controls.Add(this.code);
            this.Controls.Add(this.itemsViews);
            this.Name = "ItemsForm";
            this.Text = "Позиции";
            this.Load += new System.EventHandler(this.ItemsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScanned;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox code;
        internal System.Windows.Forms.Panel itemsViews;
    }
}