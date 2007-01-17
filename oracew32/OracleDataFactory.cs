using System;
using System.Data;
using System.Text;

using Oracle.DataAccess.Client;

namespace oracew32 {
    class OracleDataFactory : g.orm.DataFactory {
        #region DataFactory Members

        public IDbConnection getConnection(string connectionString) {
            return new OracleConnection(connectionString);
        }

        public IDbTransaction getTransaction(IDbConnection connection) {
            return connection.BeginTransaction();
        }

        public IDbCommand getCommand(IDbConnection connection, IDbTransaction transaction) {
            IDbCommand command = new OracleCommand("", (OracleConnection)connection);
            command.Transaction = transaction;
            return command;
        }

        public IDbDataAdapter getAdapter(IDbCommand select, IDbCommand update, IDbCommand insert, IDbCommand delete) {
            IDbDataAdapter adapter = new OracleDataAdapter();
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
