namespace km.hl.receipts {
    partial class AssignItemForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.items = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.Text = "Код:";
            // 
            // textBox1
            // 
            this.tbCode.Location = new System.Drawing.Point(34, 0);
            this.tbCode.Name = "textBox1";
            this.tbCode.Size = new System.Drawing.Size(130, 23);
            this.tbCode.TabIndex = 1;
            this.tbCode.Text = "tbCode";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(166, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Отменить";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // items
            // 
            this.items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.items.AutoScroll = true;
            this.items.Location = new System.Drawing.Point(0, 23);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(238, 252);
            // 
            // AssignItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.items);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label1);
            this.Name = "AssignItemForm";
            this.Text = "AssignItemForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel items;
    }
}