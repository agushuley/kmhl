using System;
using System.Data;
using System.Text;

namespace g.orm.olitew32 {
    class OracleLiteW32Factory : g.orm.DataFactory {
        #region DataFactory Members

        public IDbConnection getConnection(string connectionString) {
            IDbConnection cnn = Class.CreateInstance<IDbConnection>("Oracle.Lite.Data.LiteConnection, Oracle.DataAccess.Lite_w32");
            cnn.ConnectionString = connectionString;            
            return cnn;
        }

        public IDbTransaction getTransaction(IDbConnection connection) {
            return (IDbTransaction)connection;
        }

        public IDbCommand getCommand(IDbConnection connection, IDbTransaction transaction) {
            return Class.CreateInstance<IDbCommand>("Oracle.Lite.Data.LiteCommand, Oracle.DataAccess.Lite_w32");
        }

        public IDbDataAdapter getAdapter(IDbCommand select, IDbCommand update, IDbCommand insert, IDbCommand delete) {
            IDbDataAdapter adapter = Class.CreateInstance<IDbDataAdapter>("Oracle.Lite.Data.LiteDataAdapter, Oracle.DataAccess.Lite_w32");
            adapter.SelectCommand = select;
            adapter.InsertCommand = insert;
            adapter.UpdateCommand = update;
            adapter.DeleteCommand = delete;
            return adapter;
        }

        public IDbDataAdapter getAdapter(IDbCommand select) {
            return getAdapter(select, null, null, null);
        }

        #endregion
    }
}
