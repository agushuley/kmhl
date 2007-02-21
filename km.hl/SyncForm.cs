using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using g.dbsync;

namespace km.hl {
    public partial class SyncForm : Form {
        g.dbsync.SyncProvider sync;
        public SyncForm() {
            InitializeComponent();

            sync = g.Class.CreateInstance<g.dbsync.SyncProvider>(g.config.Config.get("sync.provider"));
            txtUser.Text = g.config.Config.get("sync.user");
            txtPassword.Text = g.config.Config.get("sync.password");
            txtHost.Text = g.config.Config.get("sync.host");

            sync.OnSyncProgress += new g.dbsync.SyncProgressDelegate(sync_OnSyncProgress);
        }

        void sync_OnSyncProgress(g.dbsync.SyncProgressArgs args) {
            switch (args.State) {
                case SyncProgressState.SYNC_PREPARE_START:
                case SyncProgressState.SYNC_PREPARING:
                case SyncProgressState.SYNC_PREPARE_FINISH:
                    moveProgressBar(prepareBar, args.Percentage);
                    break;
                case SyncProgressState.SYNC_SEND_START:
                case SyncProgressState.SYNC_SENDING:
                case SyncProgressState.SYNC_SEND_FINISH:
                    moveProgressBar(sendBar, args.Percentage);
                    break;
                case SyncProgressState.SYNC_RECEIVE_START:
                case SyncProgressState.SYNC_RECEIVING:
                case SyncProgressState.SYNC_RECEIVE_FINISH:
                    moveProgressBar(receiveBar, args.Percentage);
                    break;
                case SyncProgressState.SYNC_PROCESS_START:
                case SyncProgressState.SYNC_PROCESSING:
                case SyncProgressState.SYNC_PROCESS_FINISH:
                    moveProgressBar(processBar, args.Percentage);
                    break;
            }
        }

        private void moveProgressBar(ProgressBar bar, int p) {
            for (int i = bar.Value; i < p; i++) {
                bar.Value++;
            }
        }

        private void btnDo_Click(object sender, EventArgs e) {
            try {
                state.Text = "Sync started...";
                orm.Context.Instance.commit();
                orm.Context.Instance.close();

                prepareBar.Value = 0;
                processBar.Value = 0;
                receiveBar.Value = 0;
                sendBar.Value = 0;

                sync.DoSync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally {
                state.Text = "Sync finished.";
            }
        }
    }
}