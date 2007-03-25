using System;
using System.Collections.Generic;
using System.Text;
using g.orm.impl;

using km.hl.orm;

namespace km.hl.receipts.orm {
    public class OrdersMapper : AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return OrmCommons.DATABASE_ID; }
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new Order((IntKey)key);
        }

        private const String BASE_SELECT = "SELECT order_id, creation_date, order_number, order_date, description, status, vendor_id, vendor_name, scanner_id, is_complete FROM po_hl_orders";
        private class SelectAllCb : GetQueryCallback {
            public string Sql {
                get { return BASE_SELECT; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
            }
        }
        protected override GetQueryCallback getSelectAllCb() {
            return new SelectAllCb();
        }

        private class SelectByIdCb : GetQueryCallback {
            public SelectByIdCb(IntKey key) {
                this.key = key;
            }
            IntKey key;
            public string Sql {
                get { return BASE_SELECT + " WHERE order_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":order_id", key.Int);
            }
        }
        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new SelectByIdCb((IntKey)key);
        }

        protected override GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public class UpdateQueryCb : GetQueryCallback {
            public string Sql {
                get { return "UPDATE po_hl_orders SET is_complete = ? "
                    + "WHERE order_id = ?" ; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                Order o = (Order) obj;
                g.DbTools.setParam(cmd, ":is_complete", o.IsComplete ? "Y" : "N");
                g.DbTools.setParam(cmd, ":order_id", o.Id);
            }
        }
        protected override GetQueryCallback getUpdateQueryCB() {
            return new UpdateQueryCb();
        }

        protected override GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            Order o = (Order)obj;

            o.CreateDate = g.DbTools.ToDateTime(rs["creation_date"]);
            o.Number = OrmCommons.decodeText(g.DbTools.ToString(rs["order_number"]));
            o.OrderDate = g.DbTools.ToDateTime(rs["order_date"]);
            o.Description = OrmCommons.decodeText(g.DbTools.ToString(rs["description"]));
            o.VendorId = g.DbTools.ToInt(rs["vendor_id"]);
            o.Vendor = OrmCommons.decodeText(g.DbTools.ToString(rs["vendor_name"]));
            o.IsComplete = g.DbTools.ToBoolean(rs["is_complete"]);

            foreach (OrderItem item in ((OrderItem.IOrderItemMapper)Context.getMapper(typeof(OrderItem))).getItemsForOrder((IntKey)o.ORMKey)) {
                o.Items.Add(item);
            }
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new IntKey(g.DbTools.ToInt(rs["order_id"]));
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
