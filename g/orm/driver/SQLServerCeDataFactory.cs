using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace g.orm.driver {
    public class SQLServerCeDataFactory : g.orm.DataFactory {
        #region DataFactory Members

        public System.Data.IDbConnection getConnection(string connectionString) {
            return new SqlCeConnection(connectionString);
        }

        public System.Data.IDbTransaction getTransaction(System.Data.IDbConnection connection) {
            return connection.BeginTransaction();
        }

        public System.Data.IDbCommand getCommand(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction) {
            return new SqlCeCommand("", (SqlCeConnection)connection, (SqlCeTransaction)transaction);
        }

        public System.Data.IDbDataAdapter getAdapter(System.Data.IDbCommand select, System.Data.IDbCommand update, System.Data.IDbCommand insert, System.Data.IDbCommand delete) {
            System.Data.IDbDataAdapter adapter = new SqlCeDataAdapter();

            adapter.SelectCommand = select;
            adapter.InsertCommand = insert;
            adapter.UpdateCommand = update;
            adapter.DeleteCommand = delete;

            return adapter;
        }

        public System.Data.IDbDataAdapter getAdapter(System.Data.IDbCommand select) {
            return getAdapter(select, null, null, null);
        }

        #endregion
    }
}
