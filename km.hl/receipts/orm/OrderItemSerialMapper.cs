using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using km.hl.orm;

namespace km.hl.receipts.orm {
    public class OrderItemSerialMapper : AbstractSqlMapper, OrderItemSerial.IOrdersItemsSerialsMapper {
        private const String BASE_SELECT = "SELECT order_item_id, seq_location, serial_number FROM po_hl_order_serial_nums ";

        protected override string ConnectionKey {
            get { return OrmCommons.DATABASE_ID; }
        }

        protected override GetQueryCallback getSelectAllCb() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class GetByIdCb : GetQueryCallback {
            public GetByIdCb(OrderItemSerialKey key) {
                this.key = key;
            }
            private OrderItemSerialKey key;

            public string Sql {
                get { return BASE_SELECT + " WHERE order_item_id = ? AND seq_location = ? AND serial_number = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":order_item_id", key.Id);
                g.DbTools.setParam(cmd, ":seq_type", key.SqType);
                g.DbTools.setParam(cmd, ":serial_number", key.Serial);
            }
        }
        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new GetByIdCb((OrderItemSerialKey)key);
        }

        private class InsertCb : GetQueryCallback {
            public string Sql {
                get { return "INSERT INTO po_hl_order_serial_nums (order_item_id, seq_location, serial_number) " +
                    "VALUES (?, ?, ?)"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                OrderItemSerial serial = (OrderItemSerial)obj;

                g.DbTools.setParam(cmd, ":order_item_id", serial.Id);
                g.DbTools.setParam(cmd, ":seq_type", serial.SeqType);
                g.DbTools.setParam(cmd, ":serial_number;", serial.Serial);
            }
        }
        protected override GetQueryCallback getInsertQueryCB() {
            return new InsertCb();
        }

        protected override GetQueryCallback getUpdateQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class DeleteCb : GetQueryCallback {
            public string Sql {
                get {
                    return "DELETE FROM po_hl_order_serial_nums WHERE order_item_id = ? AND seq_location = ? AND serial_number = ?";
                }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                OrderItemSerial serial = (OrderItemSerial)obj;

                g.DbTools.setParam(cmd, ":order_item_id", serial.Id);
                g.DbTools.setParam(cmd, ":seq_type", serial.SeqType);
                g.DbTools.setParam(cmd, ":serial_number;", serial.Serial);
            }
        }
        protected override GetQueryCallback getDeleteQueryCB() {
            return new DeleteCb();
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new OrderItemSerialKey(g.DbTools.ToInt(rs["seq_location"]),
                g.DbTools.ToInt(rs["order_item_id"]), g.DbTools.ToString(rs["serial_number"]));
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new OrderItemSerial((OrderItemSerialKey)key);
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class SerialsForItemCb : GetQueryCallback {
            public SerialsForItemCb(OrderItemKey key) {
                this.key = key;
            }
            private OrderItemKey key;

            public string Sql {
                get { return BASE_SELECT + " WHERE order_item_id = ? AND seq_location = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":order_item_id", key.Id);
                g.DbTools.setParam(cmd, ":seq_type", key.SqType);
            }
        }
        public ICollection<OrderItemSerial> getSerialsForItem(OrderItemKey key) {
            ICollection<OrderItemSerial> items = new List<OrderItemSerial>();
            foreach (OrderItemSerial item in getObjectsForCb(new SerialsForItemCb(key))) {
                items.Add(item);
            }
            return items;
        }
    }
}
