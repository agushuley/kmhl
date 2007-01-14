using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Lite;
using g.dbsync;

namespace oracew32 {
    public class OracleW32SyncProvider : OracleSync, SyncProvider {
        public string HostName {
            get { return this.ServerURL; }
            set { this.ServerURL = value; }
        }

        public void DoSync() {
            this.Synchronize();
        }
    }
}
