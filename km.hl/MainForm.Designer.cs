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
            this.SuspendLayout();
            // 
            // btnOutturnChecked
            // 
            this.btnOutturnChecked.Location = new System.Drawing.Point(4, 26);
            this.btnOutturnChecked.Name = "btnOutturnChecked";
            this.btnOutturnChecked.Size = new System.Drawing.Size(233, 30);
            this.btnOutturnChecked.TabIndex = 0;
            this.btnOutturnChecked.Text = "1. Подтвержденные документы";
            this.btnOutturnChecked.Click += new System.EventHandler(this.btnOutturnChecked_Click);
            // 
            // btnOutturnGivved
            // 
            this.btnOutturnGivved.Location = new System.Drawing.Point(3, 62);
            this.btnOutturnGivved.Name = "btnOutturnGivved";
            this.btnOutturnGivved.Size = new System.Drawing.Size(233, 30);
            this.btnOutturnGivved.TabIndex = 1;
            this.btnOutturnGivved.Text = "2. Выданные документы";
            this.btnOutturnGivved.Click += new System.EventHandler(this.btnOutturnGivved_Click);
            // 
            // btnOutturnSync
            // 
            this.btnOutturnSync.Location = new System.Drawing.Point(4, 143);
            this.btnOutturnSync.Name = "btnOutturnSync";
            this.btnOutturnSync.Size = new System.Drawing.Size(233, 30);
            this.btnOutturnSync.TabIndex = 2;
            this.btnOutturnSync.Text = "3. Синхронизация";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.Text = "Расходные документы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOutturnSync);
            this.Controls.Add(this.btnOutturnGivved);
            this.Controls.Add(this.btnOutturnChecked);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Text = "KM Handheld Logistic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOutturnChecked;
        private System.Windows.Forms.Button btnOutturnGivved;
        private System.Windows.Forms.Button btnOutturnSync;
        private System.Windows.Forms.Label label1;
    }
}