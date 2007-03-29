namespace km.hl {
    partial class MainForm {
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
            this.btnOutturnChecked = new System.Windows.Forms.Button();
            this.btnOutturnGivved = new System.Windows.Forms.Button();
            this.btnOutturnSync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlainScan = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.btnReceipts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutturnChecked
            // 
            this.btnOutturnChecked.Location = new System.Drawing.Point(0, 17);
            this.btnOutturnChecked.Name = "btnOutturnChecked";
            this.btnOutturnChecked.Size = new System.Drawing.Size(238, 30);
            this.btnOutturnChecked.TabIndex = 0;
            this.btnOutturnChecked.Text = "1. Подтвержденные документы";
            this.btnOutturnChecked.Click += new System.EventHandler(this.btnOutturnChecked_Click);
            // 
            // btnOutturnGivved
            // 
            this.btnOutturnGivved.Location = new System.Drawing.Point(0, 47);
            this.btnOutturnGivved.Name = "btnOutturnGivved";
            this.btnOutturnGivved.Size = new System.Drawing.Size(238, 28);
            this.btnOutturnGivved.TabIndex = 1;
            this.btnOutturnGivved.Text = "2. Выданные документы";
            this.btnOutturnGivved.Click += new System.EventHandler(this.btnOutturnGivved_Click);
            // 
            // btnOutturnSync
            // 
            this.btnOutturnSync.Location = new System.Drawing.Point(0, 185);
            this.btnOutturnSync.Name = "btnOutturnSync";
            this.btnOutturnSync.Size = new System.Drawing.Size(238, 30);
            this.btnOutturnSync.TabIndex = 10;
            this.btnOutturnSync.Text = "5. Синхронизация";
            this.btnOutturnSync.Click += new System.EventHandler(this.btnOutturnSync_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 15);
            this.label1.Text = "Расходные документы";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(238, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "0. Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlainScan
            // 
            this.btnPlainScan.Location = new System.Drawing.Point(0, 137);
            this.btnPlainScan.Name = "btnPlainScan";
            this.btnPlainScan.Size = new System.Drawing.Size(238, 30);
            this.btnPlainScan.TabIndex = 3;
            this.btnPlainScan.Text = "4. Сканирование в файл";
            this.btnPlainScan.Click += new System.EventHandler(this.button1_Click);
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.version.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.version.Location = new System.Drawing.Point(73, 258);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(163, 13);
            this.version.Text = "vesrion";
            this.version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnReceipts
            // 
            this.btnReceipts.Location = new System.Drawing.Point(0, 92);
            this.btnReceipts.Name = "btnReceipts";
            this.btnReceipts.Size = new System.Drawing.Size(238, 30);
            this.btnReceipts.TabIndex = 2;
            this.btnReceipts.Text = "3. Приходные документы";
            this.btnReceipts.Click += new System.EventHandler(this.btnReceips_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 273);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlainScan);
            this.Controls.Add(this.btnOutturnSync);
            this.Controls.Add(this.btnOutturnGivved);
            this.Controls.Add(this.btnReceipts);
            this.Controls.Add(this.btnOutturnChecked);
            this.Name = "MainForm";
            this.Text = "KM Handheld Logistic";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOutturnChecked;
        private System.Windows.Forms.Button btnOutturnGivved;
        private System.Windows.Forms.Button btnOutturnSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlainScan;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Button btnReceipts;
    }
}