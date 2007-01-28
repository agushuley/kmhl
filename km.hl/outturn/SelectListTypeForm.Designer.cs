namespace km.hl.outturn {
    partial class SelectListTypeForm {
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnContragents = new System.Windows.Forms.Button();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(0, 33);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(238, 241);
            // 
            // btnContragents
            // 
            this.btnContragents.Location = new System.Drawing.Point(0, 0);
            this.btnContragents.Name = "btnContragents";
            this.btnContragents.Size = new System.Drawing.Size(96, 33);
            this.btnContragents.TabIndex = 1;
            this.btnContragents.Text = "Контрагенты";
            this.btnContragents.Click += new System.EventHandler(this.btnContragents_Click);
            // 
            // btnDocuments
            // 
            this.btnDocuments.Location = new System.Drawing.Point(96, 0);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Size = new System.Drawing.Size(103, 33);
            this.btnDocuments.TabIndex = 2;
            this.btnDocuments.Text = "Документы";
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(199, 0);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(39, 33);
            this.X.TabIndex = 3;
            this.X.Text = "X";
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // SelectListTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.X);
            this.Controls.Add(this.btnDocuments);
            this.Controls.Add(this.btnContragents);
            this.Controls.Add(this.panel);
            this.Name = "SelectListTypeForm";
            this.Text = "Выберите представление документов";
            this.Load += new System.EventHandler(this.SelectViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnContragents;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Button X;
    }
}