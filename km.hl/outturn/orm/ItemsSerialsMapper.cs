using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using km.hl.orm;

namespace km.hl.outturn.orm {
    public class ItemsSerialsMapper : AbstractSqlMapper, IItemsSerialsMapper {
        protected override string ConnectionKey {
            get { return OrmCommons.DATABASE_ID; }
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            ItemSerial serial = (ItemSerial)obj;
            serial.Item = (MoveOrderItem)Ctx.getMapper(typeof(MoveOrderItem))[new IntKey(g.DbTools.ToInt(rs["move_item_id"]))];
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new ItemSerial((ItemSerialKey)key);
        }

        protected override GetQueryCallback getSelectAllCb() {
            throw new Exception("The method or operation is not implemented.");
        }

        private const String BASE_SELECT = "SELECT move_item_id, serial_number FROM inv_hl_order_serial_nums";
        private class SelectByKeyCb : GetQueryCallback{
            public SelectByKeyCb(ItemSerialKey key) {
                this.key = key;
            }
            private ItemSerialKey key;
            public string Sql {
                get { return BASE_SELECT + " WHERE move_item_id = ? AND serial_number = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":item_id", key.ItemId);
                g.DbTools.setParam(cmd, ":serial", key.Serial);
            }
        }
        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new SelectByKeyCb((ItemSerialKey)key);
        }

        private class InsertQueryCb : GetQueryCallback {
            public string Sql {
                get { 
                    return "insert into inv_hl_order_serial_nums (move_item_id, serial_number) values (?, ?)"; 
                }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                ItemSerial serial = (ItemSerial)obj;
                g.DbTools.setParam(cmd, ":item_id", serial.Item.Id);
                g.DbTools.setParam(cmd, ":serial", serial.Serial);
            }
        }
        protected override GetQueryCallback getInsertQueryCB() {
            return new InsertQueryCb();
        }

        protected override GetQueryCallback getUpdateQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class DeleteQueryCb : GetQueryCallback {
            public string Sql {
                get {
                    return "DELETE FROM inv_hl_order_serial_nums WHERE move_item_id = ? AND serial_number = ?";
                }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                ItemSerial serial = (ItemSerial)obj;
                g.DbTools.setParam(cmd, ":item_id", serial.Item.Id);
                g.DbTools.setParam(cmd, ":serial", serial.Serial);
            }
        }
        protected override GetQueryCallback getDeleteQueryCB() {
            return new DeleteQueryCb();
        }

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new ItemSerialKey(g.DbTools.ToInt(rs["move_item_id"]), g.DbTools.ToString(rs["serial_number"]));
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class SelectByItemCb : GetQueryCallback {
            public SelectByItemCb(MoveOrderItem item) {
                this.item = item;
            }
            private MoveOrderItem item;
            public string Sql {
                get { return BASE_SELECT + " WHERE move_item_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":item_id", item.Id);
            }
        }
        public ICollection<ItemSerial> getSerialsForItem(MoveOrderItem obj) {
            ICollection<ItemSerial> list = new List<ItemSerial>();
            foreach (ItemSerial item in base.getObjectsForCb(new SelectByItemCb(obj))) {
                list.Add(item);
            }
            return list;
        }

        private class SelectByCodeCb: GetQueryCallback {
            public SelectByCodeCb(String serialCode) {
                this.code = serialCode;
            }

            private String code;

            public string Sql {
                get { return BASE_SELECT + " WHERE serial_number = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":serial", code);
            }
        }
        public ICollection<ItemSerial> getSerialsForSerial(string serialCode) {
            ICollection<ItemSerial> list = new List<ItemSerial>();
            foreach (ItemSerial item in base.getObjectsForCb(new SelectByCodeCb(serialCode))) {
                list.Add(item);
            }
            return list;
        }
    }
}
