using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;
using g.orm;

namespace km.hl.orm {
    public class MoveOrdersMapper : AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return Commons.DATABASE_ID; }
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            MoveOrder order = (MoveOrder)obj;
            order.Description = decode(g.DbTools.ToString(rs["Description"]));
            order.State = (MoveOrderSate)Enum.Parse(typeof(MoveOrderSate), g.DbTools.ToString(rs["status"]), true);
            order.Number = g.DbTools.ToString(rs["move_number"]);
            order.MoveDate = g.DbTools.ToDateTimeZ(rs["move_date"]);
            order.CreationDate = g.DbTools.ToDateTime(rs["creation_date"]);
            AbstractSqlMapper bm = (AbstractSqlMapper)Ctx.getMapper(typeof(Buyer));
            Key bk = bm.createKey(rs);
            if (!bm.Registry.ContainsKey(bk)) {
                order.Buyer = (Buyer)bm.loadObject(rs);
            }
            else {
                order.Buyer = (Buyer)bm.Registry[bk];
            }
            order.Complete = g.DbTools.ToBoolean(rs["is_complete"]);
        }

        private string decode(string p) {
            return Commons.decodeText(p);
        }

        private class MoveOrderItemsLoader : g.orm.DefferableLoader<MoveOrderItem, MoveOrder> {
            public MoveOrderItemsLoader(g.orm.ORMContext ctx) {
                this.ctx = ctx;
            }
            private g.orm.ORMContext ctx;
            public ICollection<MoveOrderItem> load(MoveOrder obj) {
                IMoveOrderItemsMapper mapper = (IMoveOrderItemsMapper)ctx.getMapper(typeof(MoveOrderItem));
                return mapper.getItemsForOrder(obj);
            }
        }
        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new MoveOrder((IntKey)key, new MoveOrderItemsLoader(Ctx));
        }

        private const String BASE_SELECT = "SELECT move_id, creation_date, move_number, move_date, description, status, buyer_id, buyer_name, scanner_id, is_complete FROM inv_hl_move_orders";

        public class AllCb : GetQueryCallback {
            public string Sql {
                get { return BASE_SELECT; }
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
                get { return BASE_SELECT + " WHERE move_id = ?"; }
            }
            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":id", id);
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

        private class UpdateCallback : g.orm.impl.GetQueryCallback {
            public string Sql {
                get { return "UPDATE inv_hl_move_orders SET status = ?, is_complete = ? WHERE move_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                MoveOrder order = (MoveOrder)obj;
                g.DbTools.setParam(cmd, ":status", order.State.ToString());
                g.DbTools.setParam(cmd, ":is_complete", order.Complete ? "Y" : "N");

                g.DbTools.setParam(cmd, ":id", order.Id);
            }
        }
        protected override GetQueryCallback getUpdateQueryCB() {
            return new UpdateCallback();   
        }

        protected override GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
