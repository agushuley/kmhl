namespace km.hl.receipts {
    partial class SerialsForm {
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
            this.listSerials = new System.Windows.Forms.ListBox();
            this.cbNoSerialNeed = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSerials
            // 
            this.listSerials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSerials.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listSerials.Location = new System.Drawing.Point(0, 44);
            this.listSerials.Name = "listSerials";
            this.listSerials.Size = new System.Drawing.Size(237, 223);
            this.listSerials.TabIndex = 0;
            this.listSerials.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSerials_KeyUp);
            // 
            // cbNoSerialNeed
            // 
            this.cbNoSerialNeed.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbNoSerialNeed.Location = new System.Drawing.Point(0, 2);
            this.cbNoSerialNeed.Name = "cbNoSerialNeed";
            this.cbNoSerialNeed.Size = new System.Drawing.Size(140, 18);
            this.cbNoSerialNeed.TabIndex = 1;
            this.cbNoSerialNeed.Text = "Серийные не нужны";
            this.cbNoSerialNeed.CheckStateChanged += new System.EventHandler(this.cbNoSerialNeed_CheckStateChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(196, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbSerial
            // 
            this.tbSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSerial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSerial.Location = new System.Drawing.Point(0, 24);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(153, 19);
            this.tbSerial.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.btnOk.Location = new System.Drawing.Point(154, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(42, 35);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "V";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SerialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbNoSerialNeed);
            this.Controls.Add(this.listSerials);
            this.Name = "SerialsForm";
            this.Text = "Серийные номера";
            this.Load += new System.EventHandler(this.SerialsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNoSerialNeed;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.TextBox tbSerial;
        public System.Windows.Forms.ListBox listSerials;
    }
}