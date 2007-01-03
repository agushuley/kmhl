using System;
using System.Collections.Generic;
using System.Text;

using g.orm;
using g.orm.impl;

namespace km.hl.dom.junius {
    class OrderDetailsMapper : AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return "orders-db"; }
        }

        protected override void loadInstance(ORMObject obj, System.Data.DataRow rs) {
            OrderDetail detail = (OrderDetail)obj;
            detail.Order = (Order)Context.getMapper(typeof(Order))[new IntKey(detail.OrderId)];
            detail.Date = g.DbTools.ToDateTime(rs["ddate"]);
            detail.Description = g.DbTools.ToString(rs["description"]);
            detail.Ordered = g.DbTools.ToInt(rs["qtyordered"]);
            detail.Shipped = g.DbTools.ToInt(rs["qtyshipped"]);
            detail.Received = g.DbTools.ToInt(rs["qtyreceived"]);
            detail.Cost = g.DbTools.ToDecimal(rs["cost"]);
        }

        protected override ORMObject createInstance(Key key, System.Data.DataRow rs) {
            return new OrderDetail((OrderDetail.OrderDetailsKey)key);
        }

        private const String BASE_SELECT = "SELECT id, key, ddate, description, qtyordered, qtyshipped, qtyreceived, cost FROM ord_detail ";
        class SelectAllCallback : GetQueryCallback {
            #region GetQueryCallback Members
            public string Sql {
                get { return BASE_SELECT; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
            }
            #endregion
        }
        protected override GetQueryCallback getSelectAllCb() {
            return new SelectAllCallback();
        }

        class SelectByKeyCallback : GetQueryCallback {
            int key, id;
            internal SelectByKeyCallback(int key, int id) {
                this.key = key;
                this.id = id;
            }
            #region GetQueryCallback Members
            public string Sql {
                get { return BASE_SELECT + " WHERE id = ? AND key = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                g.DbTools.setParam(cmd, "@id", id);
                g.DbTools.setParam(cmd, "@key", obj);
            }

            #endregion
        }
        protected override GetQueryCallback getSelectByKeyCb(Key key) {
            return new SelectByKeyCallback(((OrderDetail.OrderDetailsKey)key).line, ((OrderDetail.OrderDetailsKey)key).order);
        }

        class DetailsForOrderCb : GetQueryCallback {
            Order order;
            internal DetailsForOrderCb(Order order) {
                this.order = order;
            }
            #region GetQueryCallback Members

            public string Sql {
                get { return BASE_SELECT + " WHERE key = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                g.DbTools.setParam(cmd, "@id", order.Id);
            }

            #endregion
        }
        internal ICollection<ORMObject> getDetailsForOrder(Order order) {
            return getObjectsForCb(new DetailsForOrderCb(order));
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
            return new OrderDetail.OrderDetailsKey(g.DbTools.ToInt(rs["key"]), g.DbTools.ToInt(rs["id"]));
        }

        public override Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
