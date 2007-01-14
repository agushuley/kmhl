using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;

namespace km.hl.dom.hl {
    public class MoveOrdersMapper : AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return "hl-db"; }
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            MoveOrder order = (MoveOrder)obj;
            order.Description = decode(g.DbTools.ToString(rs["Description"]));
        }

        private string decode(string p) {
            if (p == null) return null;
            return g.HttpUtility.UrlDecode(p, Encoding.GetEncoding("Windows-1251"));
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new MoveOrder((IntKey)key);
        }

        public class AllCb : GetQueryCallback {
            public string Sql {
                get { return "SELECT move_id, description FROM inv_mv_orders"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
            }
        }
        protected override GetQueryCallback getSelectAllCb() {
            return new AllCb();
        }

        public class CbById : GetQueryCallback {
            int id;
            public CbById(int id) {
                this.id = id;
            }
            public string Sql {
                get { return "SELECT move_id, description FROM inv_mv_orders WHERE move_id = ?"; }
            }
            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, "@id", id);
            }
        }
        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new CbById(((IntKey)key).Int);
        }
        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new IntKey(g.DbTools.ToInt(rs["move_id"]));
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

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
