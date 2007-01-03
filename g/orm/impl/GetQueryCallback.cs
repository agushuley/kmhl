using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace g.orm.impl {
    public interface GetQueryCallback {
	    String Sql { get; }
	    void SetParams(IDbCommand cmd, ORMObject obj);
    }
}
