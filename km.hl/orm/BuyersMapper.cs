using System;
using System.Collections.Generic;
using System.Text;

using g.orm;
using g.orm.impl;

namespace km.hl.orm {
    class BuyersMapper : AbstractSqlMapper {

        protected override string ConnectionKey {
            get { return Commons.DATABASE_ID; }
        }

        protected override void loadInstance(ORMObject obj, System.Data.DataRow rs) {
            Buyer buyer = (Buyer)obj;
            buyer.Description = Commons.decodeText(g.DbTools.ToString(rs["buyer_name"]));
        }

        protected override ORMObject createInstance(Key key, System.Data.DataRow rs) {
            return new Buyer((IntKey)key);
        }

        private class GetAllCallback : g.orm.impl.GetQueryCallback {
            public string Sql {
                get { return "SELECT DISTINCT buyer_id, buyer_name FROM inv_hl_move_orders"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
            }
        }
        protected override GetQueryCallback getSelectAllCb() {
            return new GetAllCallback();
        }

        protected override GetQueryCallback getSelectByKeyCb(Key key) {
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

        public override Key createKey(System.Data.DataRow rs) {
            return new IntKey(g.DbTools.ToInt(rs["buyer_id"]));
        }

        public override Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
