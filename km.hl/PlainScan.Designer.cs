namespace km.hl {
    partial class PlainScan {
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
            this.codes = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.btnStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codes
            // 
            this.codes.AcceptsReturn = true;
            this.codes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codes.Location = new System.Drawing.Point(4, 20);
            this.codes.Multiline = true;
            this.codes.Name = "codes";
            this.codes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codes.Size = new System.Drawing.Size(231, 252);
            this.codes.TabIndex = 3;
            this.codes.WordWrap = false;
            this.codes.TextChanged += new System.EventHandler(this.codes_TextChanged);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(140, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(94, 20);
            this.close.TabIndex = 2;
            this.close.Text = "Закрыть";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // save
            // 
            this.saveDlg.Filter = "Text files (*.txt)|*.txt";
            // 
            // btnStore
            // 
            this.btnStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStore.Location = new System.Drawing.Point(40, 0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(94, 20);
            this.btnStore.TabIndex = 1;
            this.btnStore.Text = "Сохранить";
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // PlainScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.close);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.codes);
            this.Name = "PlainScan";
            this.Text = "PlainScan";
            this.Load += new System.EventHandler(this.PlainScan_Load);
            this.Controls.SetChildIndex(this.codes, 0);
            this.Controls.SetChildIndex(this.btnStore, 0);
            this.Controls.SetChildIndex(this.close, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox codes;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.Button btnStore;
    }
}