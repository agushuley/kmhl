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
            checkVersion();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            new PlainScan().ShowDialog();
        }


        private void MainForm_Load(object sender, EventArgs e) {
            version.Text = "Version: " + Program.Version;
            checkVersion();
        }

        private void btnReceips_Click(object sender, EventArgs e) {
            new receipts.OrdersForm().ShowDialog();
        }

        private void checkVersion() {
            try {
                config.ConfigItem item = (config.ConfigItem)orm.OrmContext.Instance.getMapper(typeof(config.ConfigItem))[new g.orm.impl.StringKey("HL.LOGISTICS_VERSION")];
                if (item == null) {
                    return;
                }
                String[] parts = item.Value.Split('.');
                if (parts.Length != 2) {
                    return;
                }
                int major = Int32.Parse(parts[0]);
                int minor = Int32.Parse(parts[1]);
                if (major > Program.RELEASE_MAJOR || (major == Program.RELEASE_MAJOR && minor > Program.RELEASE_MINOR)) {
                    MessageBox.Show("Доступна новая версия ПО: " + item.Value + ", у Вас: " + Program.Version + ". " 
                        + "Рекомендуем Вам обновить ПО к новой версии.");
                }
            }
            catch (Exception) { };
        }
    }
}