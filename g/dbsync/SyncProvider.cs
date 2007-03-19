using System;
using System.Collections.Generic;
using System.Text;

namespace g.dbsync {
    public enum SyncProgressState {
        SYNC_PREPARE_START, SYNC_PREPARING, SYNC_PREPARE_FINISH,
        SYNC_SEND_START, SYNC_SENDING, SYNC_SEND_FINISH,
        SYNC_RECEIVE_START, SYNC_RECEIVING, SYNC_RECEIVE_FINISH,
        SYNC_PROCESS_START, SYNC_PROCESSING, SYNC_PROCESS_FINISH
    };

    public class SyncProgressArgs {
        public SyncProgressArgs(SyncProgressState state, int percentage) {
            this.state = state;
            this.percentage = percentage;
        }
        private SyncProgressState state;
        public SyncProgressState State {
            get { return state; }
        }
        private int percentage;
        public int Percentage {
            get { return percentage; }
        }
    };

    public delegate void SyncProgressDelegate(SyncProgressArgs args);

    public interface SyncProvider {
        String UserName { set; get; }
        String Password { set; get; }
        String HostName { set; get; }
        event SyncProgressDelegate OnSyncProgress;
        void DoSync();
    }
}
