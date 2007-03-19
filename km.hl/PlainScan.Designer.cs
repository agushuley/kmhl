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
            this.save = new System.Windows.Forms.SaveFileDialog();
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
            this.codes.TabIndex = 0;
            this.codes.WordWrap = false;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(140, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(94, 20);
            this.close.TabIndex = 1;
            this.close.Text = "Закрыть";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // save
            // 
            this.save.Filter = "Text files|*.txt";
            // 
            // PlainScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.close);
            this.Controls.Add(this.codes);
            this.Name = "PlainScan";
            this.Text = "PlainScan";
            this.Load += new System.EventHandler(this.PlainScan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox codes;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.SaveFileDialog save;
    }
}