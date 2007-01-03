using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom {
    class TodayDateMapper : g.orm.impl.AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return "db"; }
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new Date((g.orm.impl.DateKey)key);
        }

        protected override void setSelectStatementParams(System.Data.IDbCommand cmd, g.orm.Key id) {
        }

        protected override string getSelectSql() {
            return "SELECT SYSDATE dt FROM dual";
        }

        protected override void setSelectAllStatementParams(System.Data.IDbCommand stm) {
        }

        protected override string getSelectAllSql() {
            return "SELECT SYSDATE dt FROM dual";
        }

        protected override g.orm.impl.GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override g.orm.impl.GetQueryCallback getUpdateQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override g.orm.impl.GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new g.orm.impl.DateKey(Convert.ToDateTime(rs["dt"]));
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
