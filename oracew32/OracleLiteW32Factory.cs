using System;
using System.Data;
using System.Text;

using Oracle.Lite.Data;

namespace oracew32 {
    class OracleLiteW32Factory : g.orm.DataFactory {
        #region DataFactory Members

        public IDbConnection getConnection(string connectionString) {
            return new LiteConnection(connectionString);
        }

        public IDbTransaction getTransaction(IDbConnection connection) {
            return (IDbTransaction)connection;
        }

        public IDbCommand getCommand(IDbConnection connection, IDbTransaction transaction) {
            return new LiteCommand("", (LiteConnection)connection);
        }

        public IDbDataAdapter getAdapter(IDbCommand select, IDbCommand update, IDbCommand insert, IDbCommand delete) {
            IDbDataAdapter adapter = new LiteDataAdapter();
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
