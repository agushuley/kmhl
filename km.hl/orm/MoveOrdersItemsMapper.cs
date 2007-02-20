using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using g.orm;

namespace km.hl.orm {
    class MoveOrdersItemsMapper : AbstractSqlMapper, IMoveOrderItemsMapper {
        protected override string ConnectionKey {
            get { return Commons.DATABASE_ID; }
        }

        protected override void loadInstance(ORMObject obj, System.Data.DataRow rs) {
            MoveOrderItem item = (MoveOrderItem)obj;
            item.Order = (MoveOrder)Ctx.getMapper(typeof(MoveOrder))[new IntKey(g.DbTools.ToInt(rs["move_id"]))];
            item.Quantity = g.DbTools.ToInt(rs["quantity"]);
            item.QtyPicked = g.DbTools.ToInt(rs["quantity_gived"]);
            item.InventoryId = g.DbTools.ToInt(rs["inventory_item_id"]);
            item.Description = Commons.decodeText(g.DbTools.ToString(rs["item_description"]));
            item.MfrCode = Commons.decodeText(g.DbTools.ToString(rs["mfg_part_num"]));
            item.InternalCode = Commons.decodeText(g.DbTools.ToString(rs["item_segment1"]));
            item.NoSerialNeed = g.DbTools.ToBoolean(rs["no_serials"]);
        }

        private class ItemsSerialsLoader : g.orm.DefferableLoader<ItemSerial, MoveOrderItem> {
            public ItemsSerialsLoader(g.orm.ORMContext ctx) {
                this.ctx = ctx;
            }
            private g.orm.ORMContext ctx;
            public ICollection<ItemSerial> load(MoveOrderItem obj) {
                IItemsSerialsMapper mapper = (IItemsSerialsMapper)ctx.getMapper(typeof(ItemSerial));
                return mapper.getSerialsForItem(obj);
            }
        }
        protected override ORMObject createInstance(Key key, System.Data.DataRow rs) {
            return new MoveOrderItem((IntKey)key, new ItemsSerialsLoader(Ctx));
        }

        private const String BASE_SELECT = "SELECT move_item_id, move_id, quantity, quantity_gived, inventory_item_id, item_description, item_segment1, mfg_part_num, no_serials FROM inv_hl_move_order_items";
        protected override GetQueryCallback getSelectAllCb() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getSelectByKeyCb(Key key) {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class UpdateQueryCb : GetQueryCallback {
            public string Sql {
                get { return "UPDATE inv_hl_move_order_items SET quantity_gived = ?, no_serials = ? WHERE move_item_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                MoveOrderItem item = (MoveOrderItem)obj;
                g.DbTools.setParam(cmd, ":gived", item.QtyPicked);
                g.DbTools.setParam(cmd, ":no_serials", item.NoSerialNeed ? "Y" : "N");
                g.DbTools.setParam(cmd, ":id", item.Id);
            }
        }
        protected override GetQueryCallback getUpdateQueryCB() {
            return new UpdateQueryCb();
        }

        protected override GetQueryCallback getDeleteQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        public override Key createKey(System.Data.DataRow rs) {
            return new IntKey(g.DbTools.ToInt(rs["move_item_id"]));
        }

        public override Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }

        #region IMoveOrderMapper Members

        private class ItemsForOrderQCb : GetQueryCallback {
            public ItemsForOrderQCb(MoveOrder order) {
                this.order = order;
            }
            private MoveOrder order;
            public string Sql {
                get { return BASE_SELECT + " WHERE move_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                g.DbTools.setParam(cmd, ":id", order.Id);
            }
        }
        public ICollection<MoveOrderItem> getItemsForOrder(MoveOrder obj) {
            ICollection<MoveOrderItem> items = new List<MoveOrderItem>();
            foreach (MoveOrderItem i in base.getObjectsForCb(new ItemsForOrderQCb(obj))) {
                items.Add(i);
            }
            return items;
        }

        private class ItemsForMfrCodeCb : GetQueryCallback {
            public ItemsForMfrCodeCb(String mfrCode) {
                this.mfrCode = mfrCode;
            }

            private String mfrCode;

            public string Sql {
                get { return BASE_SELECT + " WHERE UPPER(?) "
                    + " LIKE UPPER(REPLACE(REPLACE(REPLACE(mfg_part_num, '%', '\\%'), '_', '\\_'), '\\', '\\\\')) || '%' ESCAPE '\\'  "; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                g.DbTools.setParam(cmd, ":mfr_code", Commons.encodeText(mfrCode));
            }
        }
        public ICollection<MoveOrderItem> getItemsForMfrCode(string mfrCode) {
            ICollection<MoveOrderItem> items = new List<MoveOrderItem>();
            foreach (MoveOrderItem i in base.getObjectsForCb(new ItemsForMfrCodeCb(mfrCode))) {
                items.Add(i);
            }
            return items;
        }

        private class ItemsForIntCodeCb : GetQueryCallback {
            public ItemsForIntCodeCb(String intCode) {
                this.intCode = intCode;
            }

            private String intCode;

            public string Sql {
                get {
                    return BASE_SELECT + " WHERE UPPER(?) = UPPER(item_segment1) OR UPPER(item_segment1) LIKE UPPER(?) || '/_' ESCAPE '\\'"; 
                }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                g.DbTools.setParam(cmd, ":int_code", Commons.encodeText(intCode));
                g.DbTools.setParam(cmd, ":int_code2", g.DbTools.EschapeString(Commons.encodeText(intCode), '\\'));
            }
        }
        public ICollection<MoveOrderItem> getItemsForInternalCode(string intCode) {
            ICollection<MoveOrderItem> items = new List<MoveOrderItem>();
            foreach (MoveOrderItem i in base.getObjectsForCb(new ItemsForIntCodeCb(intCode))) {
                items.Add(i);
            }
            return items;
        }

        #endregion
    }
}
