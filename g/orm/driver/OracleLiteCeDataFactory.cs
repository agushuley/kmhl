using System;
using System.Text;
using Oracle.Lite.Data;

namespace g.orm.driver {
    public class OracleLiteCeDataFactory : DataFactory {
        #region DataFactory Members

        public System.Data.IDbConnection getConnection(string connectionString) {
            return new LiteConnection(connectionString);
        }

        public System.Data.IDbTransaction getTransaction(System.Data.IDbConnection connection) {
            return (System.Data.IDbTransaction)connection;
        }

        public System.Data.IDbCommand getCommand(System.Data.IDbConnection connection, System.Data.IDbTransaction transaction) {
            return new LiteCommand((LiteConnection)connection);
        }

        public System.Data.IDbDataAdapter getAdapter(System.Data.IDbCommand select, System.Data.IDbCommand update, System.Data.IDbCommand insert, System.Data.IDbCommand delete) {
            System.Data.IDbDataAdapter adapter = Class.CreateInstance<System.Data.IDbDataAdapter>("Oracle.Lite.Data.LiteDataAdapter, Oracle.DataAccess.Lite_wce", null);
            adapter.SelectCommand = (LiteCommand)select;
            adapter.InsertCommand = (LiteCommand)insert;
            adapter.UpdateCommand = (LiteCommand)update;
            adapter.DeleteCommand = (LiteCommand)delete;
            return adapter;
        }

        public System.Data.IDbDataAdapter getAdapter(System.Data.IDbCommand select) {
            return getAdapter(select, null, null, null);
        }

        #endregion
    }
}
