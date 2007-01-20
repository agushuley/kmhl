namespace km.hl {
    partial class SyncForm {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.prepareBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.sendBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.receiveBar = new System.Windows.Forms.ProgressBar();
            this.processBar = new System.Windows.Forms.ProgressBar();
            this.state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.Text = "Хост:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(101, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(136, 21);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(101, 29);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(136, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(101, 56);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(136, 21);
            this.txtHost.TabIndex = 3;
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(32, 81);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(182, 24);
            this.btnDo.TabIndex = 4;
            this.btnDo.Text = "Синхронизировать";
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.Text = "Подготовка";
            // 
            // prepareBar
            // 
            this.prepareBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prepareBar.Location = new System.Drawing.Point(75, 111);
            this.prepareBar.Name = "prepareBar";
            this.prepareBar.Size = new System.Drawing.Size(162, 20);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.Text = "Посылка";
            // 
            // sendBar
            // 
            this.sendBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBar.Location = new System.Drawing.Point(60, 137);
            this.sendBar.Name = "sendBar";
            this.sendBar.Size = new System.Drawing.Size(177, 20);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.Text = "Получение";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.Text = "Обработка";
            // 
            // receiveBar
            // 
            this.receiveBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveBar.Location = new System.Drawing.Point(72, 163);
            this.receiveBar.Name = "receiveBar";
            this.receiveBar.Size = new System.Drawing.Size(165, 20);
            // 
            // processBar
            // 
            this.processBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.processBar.Location = new System.Drawing.Point(75, 189);
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(162, 20);
            // 
            // state
            // 
            this.state.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.state.Location = new System.Drawing.Point(4, 213);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(233, 81);
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.state);
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.receiveBar);
            this.Controls.Add(this.sendBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.prepareBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SyncForm";
            this.Text = "Sync";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar sendBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar receiveBar;
        private System.Windows.Forms.ProgressBar processBar;
        private System.Windows.Forms.ProgressBar prepareBar;
        private System.Windows.Forms.Label state;
    }
}