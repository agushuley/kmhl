using System;
using System.Data;
using System.Text;

namespace g.orm {
    public interface DataFactory {
        IDbConnection getConnection(String connectionString);
        IDbTransaction getTransaction(IDbConnection connection);
        IDbCommand getCommand(IDbConnection connection, IDbTransaction transaction);
        IDbDataAdapter getAdapter(IDbCommand select, IDbCommand update, IDbCommand insert, IDbCommand delete);
        IDbDataAdapter getAdapter(IDbCommand select);
    }
}
