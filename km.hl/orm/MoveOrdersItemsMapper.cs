using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;
using g.orm;

namespace km.hl.orm {
    class MoveOrdersItemsMapper : AbstractSqlMapper, IMoveOrderItemsMapper{
        protected override string ConnectionKey {
            get { return Commons.DATABASE_ID; }
        }

        protected override void loadInstance(ORMObject obj, System.Data.DataRow rs) {
            MoveOrderItem item = (MoveOrderItem)obj;
            item.Order = (MoveOrder)Ctx.getMapper(typeof(MoveOrder))[new IntKey(g.DbTools.ToInt(rs["move_id"]))];
            item.Quantity = g.DbTools.ToInt(rs["quantity"]);
            item.QtyGived = g.DbTools.ToInt(rs["quantity_gived"]);
            item.InventoryId = g.DbTools.ToInt(rs["inventory_item_id"]);
            item.Description = Commons.decodeText(g.DbTools.ToString(rs["item_description"]));
            item.MfrCode = Commons.decodeText(g.DbTools.ToString(rs["mfg_part_num"]));
            item.InternalCode = Commons.decodeText(g.DbTools.ToString(rs["item_segment1"]));
        }

        protected override ORMObject createInstance(Key key, System.Data.DataRow rs) {
            return new MoveOrderItem((IntKey)key);
        }

        private const String BASE_SELECT = "select move_item_id, move_id, quantity, quantity_gived, inventory_item_id, item_description, item_segment1, mfg_part_num from inv_hl_move_order_items";
        protected override GetQueryCallback getSelectAllCb() {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getSelectByKeyCb(Key key) {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override GetQueryCallback getInsertQueryCB() {
            throw new Exception("The method or operation is not implemented.");
        }

        private class UpdateQCb : GetQueryCallback {
            public string Sql {
                get { return "UPDATE inv_hl_move_order_items SET quantity_gived = ? WHERE move_item_id = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, ORMObject obj) {
                MoveOrderItem item = (MoveOrderItem)obj;
                g.DbTools.setParam(cmd, ":gived", item.QtyGived);
                g.DbTools.setParam(cmd, ":id", item.Id);
            }
        }
        protected override GetQueryCallback getUpdateQueryCB() {
            throw new Exception("The method or operation is not implemented.");
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

        #endregion
    }
}
