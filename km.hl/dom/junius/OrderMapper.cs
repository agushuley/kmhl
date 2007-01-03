using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.dom.junius {
    class OrderMapper : g.orm.impl.AbstractSqlMapper {
        protected override string ConnectionKey {
            get { return "orders-db"; }
        }

        private const String BASE_SELECT = "SELECT id, ddate, status, name, description FROM ord_master ";

        class SelectAllCallback : g.orm.impl.GetQueryCallback {
            #region GetQueryCallback Members

            public string Sql {
                get { return BASE_SELECT; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
            }

            #endregion
        }
        protected override g.orm.impl.GetQueryCallback getSelectAllCb() {
            return new SelectAllCallback();
        }

        class SelectByIdCallback : g.orm.impl.GetQueryCallback {
            g.orm.impl.IntKey key = null;
            internal SelectByIdCallback(g.orm.impl.IntKey key) {
                this.key = key;
            }

            #region GetQueryCallback Members

            public string Sql {
                get { return BASE_SELECT + " WHERE id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, "@id", key.Int);
            }

            #endregion
        }
        protected override g.orm.impl.GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new SelectByIdCallback((g.orm.impl.IntKey)key);
        }

        class DetailsLoader : g.orm.DeferableLoader<OrderDetail, Order> {
            g.orm.ORMContext ctx;
            internal DetailsLoader(g.orm.ORMContext ctx) {
                this.ctx = ctx;
            }
            #region DeferableLoader<OrderDetail,Order> Members
            public ICollection<OrderDetail> load(Order obj) {
                OrderDetailsMapper detailsMapper = (OrderDetailsMapper)ctx.getMapper(typeof(OrderDetail));
                IList<OrderDetail> details = new List<OrderDetail>();
                foreach (OrderDetail d in detailsMapper.getDetailsForOrder(obj)) {
                    details.Add(d);
                }
                return details;
            }
            #endregion
        }
        DetailsLoader detailsLoader;
        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            Order order = (Order)obj;
            order.Date = g.DbTools.ToDateTime(rs["ddate"]);
            order.Description = g.DbTools.ToString(rs["Description"]);
            order.Name = g.DbTools.ToString(rs["Name"]);
            order.Status = (byte)g.DbTools.ToInt(rs["Status"]);

            if (detailsLoader == null) {
                detailsLoader = new DetailsLoader(Context);
            }
            order.detailsLoader = detailsLoader;
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new Order((g.orm.impl.IntKey)key);
        }

        protected override g.orm.impl.GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        class UpdateCallback : g.orm.impl.GetQueryCallback {
            #region GetQueryCallback Members
            public string Sql {
                get { return "UPDATE ord_master "
                    +"SET ddate = ?, status = ?, name = ?, description = ? " +
                    "WHERE id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                Order order = (Order)obj;
                g.DbTools.setParam(cmd, "@date", order.Date);
                g.DbTools.setParam(cmd, "@status", order.Status);
                g.DbTools.setParam(cmd, "@name", order.Name);
                g.DbTools.setParam(cmd, "@description", order.Description);
                g.DbTools.setParam(cmd, "@id", order.Id);
            }
            #endregion
        }
        protected override g.orm.impl.GetQueryCallback getUpdateQueryCB() {
            return new UpdateCallback();
        }

        protected override g.orm.impl.GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new g.orm.impl.IntKey(g.DbTools.ToInt(rs["ID"]));
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
