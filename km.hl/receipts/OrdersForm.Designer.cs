namespace km.hl.receipts {
    partial class OrdersForm {
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
            this.documentsPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // documentsPanel
            // 
            this.documentsPanel.AutoScroll = true;
            this.documentsPanel.Location = new System.Drawing.Point(0, 20);
            this.documentsPanel.Name = "documentsPanel";
            this.documentsPanel.Size = new System.Drawing.Size(238, 255);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(166, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.documentsPanel);
            this.Name = "OrdersForm";
            this.Text = "Документы закупки";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel documentsPanel;
        private System.Windows.Forms.Button btnClose;
    }
}