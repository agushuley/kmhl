namespace km.hl.receipts {
    partial class NewItemForm {
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Button btnCreate;
            System.Windows.Forms.Button btnCancel;
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(4, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 20);
            label1.Text = "Название:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(4, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(231, 23);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(4, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(231, 20);
            label2.Text = "Код производителя:";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(4, 82);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(231, 23);
            this.tbCode.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCreate.Location = new System.Drawing.Point(4, 111);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(72, 20);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Создать";
            btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(83, 111);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(72, 20);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отменить";
            // 
            // NewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 139);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnCreate);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(label1);
            this.Name = "NewItemForm";
            this.Text = "Новая позиция";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NewItemForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCode;
    }
}