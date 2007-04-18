using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace km.hl {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void btnOutturnChecked_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(outturn.orm.MoveOrderSate.C).ShowDialog();
        }

        private void btnOutturnGivved_Click(object sender, EventArgs e) {
            new outturn.SelectListTypeForm(outturn.orm.MoveOrderSate.G).ShowDialog();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e) {
            orm.OrmContext.Instance.close();
        }

        private void btnOutturnSync_Click(object sender, EventArgs e) {
            new SyncForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            new PlainScan().ShowDialog();
        }

		[DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hwnd, char[] lpClassName, int nMaxCount);

		[DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hwnd, char[] lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(char[] lpClassName, char[] lpWindowName);

        const int SW_RESTORE = 9;

        private void MainForm_Load(object sender, EventArgs e) {
            MessageBox.Show("");
            char[] cl = new char[1024], name = new char[1024];
            int result = GetWindowTextW(Handle, name, 1024);
            result = GetClassNameW(Handle, cl, 1024);
            IntPtr win = FindWindow(cl, name);
            if (win != IntPtr.Zero) {
                MessageBox.Show("Работает второй экземпляр приложения");
                ShowWindow(win, SW_RESTORE);
                Close();
                return;
            }

            version.Text = "Version: " + Program.VERSION;
        }

        private void btnReceips_Click(object sender, EventArgs e) {
            new receipts.OrdersForm().ShowDialog();
        }
    }
}