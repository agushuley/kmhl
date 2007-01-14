using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Lite;

namespace g.dbsync {
    public class OracleCeSyncProvider : OracleSync, SyncProvider {
        public string HostName {
            get { return this.ServerURL; }
            set { this.ServerURL = value; }
        }

        public void DoSync() {
            this.Synchronize();
        }
    }
}
