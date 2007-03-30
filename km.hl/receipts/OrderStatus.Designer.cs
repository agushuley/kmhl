namespace km.hl.receipts {
    partial class OrderStatusForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderStatusForm));
            this.stateNotReady = new System.Windows.Forms.RadioButton();
            this.stateReady = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stateNotReady
            // 
            this.stateNotReady.Location = new System.Drawing.Point(43, 13);
            this.stateNotReady.Name = "stateNotReady";
            this.stateNotReady.Size = new System.Drawing.Size(100, 20);
            this.stateNotReady.TabIndex = 0;
            this.stateNotReady.Text = "Не готов";
            // 
            // stateReady
            // 
            this.stateReady.Location = new System.Drawing.Point(43, 39);
            this.stateReady.Name = "stateReady";
            this.stateReady.Size = new System.Drawing.Size(100, 20);
            this.stateReady.TabIndex = 1;
            this.stateReady.Text = "Готов";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Да";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(76, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Нет";
            // 
            // OrderStatusForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(151, 112);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.stateReady);
            this.Controls.Add(this.stateNotReady);
            this.Name = "OrderStatusForm";
            this.Text = "Статус документа";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton stateNotReady;
        private System.Windows.Forms.RadioButton stateReady;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}