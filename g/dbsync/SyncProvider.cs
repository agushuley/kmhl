using System;
using System.Collections.Generic;
using System.Text;

namespace g.dbsync {
    public interface SyncProvider {
        String UserName { set; get; }
        String Password { set; get; }
        String HostName { set; get; }
        void DoSync();
    }
}
