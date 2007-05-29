using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.config {
    public class ComfigItemMapper : AbstractSqlMapper {
        private const String BASE_SELECT = "select PARAMETER, PVALUE from INV_HL_CONFIG";

        protected override string ConnectionKey {
            get { return orm.OrmCommons.DATABASE_ID; }
        }

        protected override void loadInstance(g.orm.ORMObject obj, System.Data.DataRow rs) {
            ConfigItem i = (ConfigItem)obj;
            i.Value = g.DbTools.ToString(rs["PVALUE"]);
        }

        protected override g.orm.ORMObject createInstance(g.orm.Key key, System.Data.DataRow rs) {
            return new ConfigItem((StringKey)key);
        }

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

        private class SelectByKeyCb : GetQueryCallback {
            public SelectByKeyCb(StringKey key) {
                this.key = key;
            }
            private StringKey key;

            public string Sql {
                get { return BASE_SELECT + " WHERE PARAMETER = ?"; }
            }

            public void SetParams(System.Data.IDbCommand cmd, g.orm.ORMObject obj) {
                g.DbTools.setParam(cmd, ":parameter", key.ToString());
            }
        }
        protected override GetQueryCallback getSelectByKeyCb(g.orm.Key key) {
            return new SelectByKeyCb((StringKey)key);
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

        public override g.orm.Key createKey(System.Data.DataRow rs) {
            return new StringKey(g.DbTools.ToString(rs["PARAMETER"]));
        }

        public override g.orm.Key createKey() {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
