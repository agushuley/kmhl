using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using km.hl.orm;

namespace km.hl.receipts.orm {
    public class OrderItemSerialMapper : AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return OrmCommons.DATABASE_ID; }
        }

        protected override GetQueryCallback getSelectAllCb() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getUpdateQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            throw new Exception("The method or operation is not implemented.");
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
