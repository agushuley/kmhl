using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Lite;

namespace g.dbsync {
    public class OracleCeSyncProvider : OracleSync, SyncProvider {
        public OracleCeSyncProvider() {
            this.Option = SyncOption.DEBUG;
            this.SetEventHandler(new SyncEventHandler(OracleCeSyncProvider_OnSyncProgress), true);
        }

        void OracleCeSyncProvider_OnSyncProgress(Object obj, SyncEventArgs args) {
            if (OnSyncProgress != null) {
                SyncProgressState? state = null;
                switch (args.stage) {
                    case SyncEventArgs.SYNC_PREPARE_START: state = SyncProgressState.SYNC_PREPARE_START; break;
                    case SyncEventArgs.SYNC_PREPARING: state = SyncProgressState.SYNC_PREPARING; break;
                    case SyncEventArgs.SYNC_PREPARE_FINISH: state = SyncProgressState.SYNC_PREPARE_FINISH; break;
                    case SyncEventArgs.SYNC_PROCESS_START: state = SyncProgressState.SYNC_PROCESS_START; break;
                    case SyncEventArgs.SYNC_PROCESSING: state = SyncProgressState.SYNC_PROCESSING; break;
                    case SyncEventArgs.SYNC_PROCESS_FINISH: state = SyncProgressState.SYNC_PROCESS_FINISH; break;
                    case SyncEventArgs.SYNC_RECEIVE_START: state = SyncProgressState.SYNC_RECEIVE_START; break;
                    case SyncEventArgs.SYNC_RECEIVING: state = SyncProgressState.SYNC_RECEIVING; break;
                    case SyncEventArgs.SYNC_RECEIVE_FINISH: state = SyncProgressState.SYNC_RECEIVE_FINISH; break;
                    case SyncEventArgs.SYNC_SEND_START: state = SyncProgressState.SYNC_SEND_START; break;
                    case SyncEventArgs.SYNC_SENDING: state = SyncProgressState.SYNC_SENDING; break;
                    case SyncEventArgs.SYNC_SEND_FINISH: state = SyncProgressState.SYNC_SEND_FINISH; break;
                };
                if (state != null) {
                    OnSyncProgress(new SyncProgressArgs((SyncProgressState)state, args.percentage));
                }
            }
        }

        public string HostName {
            get { return this.ServerURL; }
            set { this.ServerURL = value; }
        }

        public void DoSync() {
            this.Synchronize();
        }

        public event SyncProgressDelegate OnSyncProgress;
    }
}
