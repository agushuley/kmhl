using System;
using System.Collections.Generic;
using System.Text;

using g.orm.impl;

namespace km.hl.config {
    public class ConfigItem : GenericORMObject {
        public ConfigItem(StringKey key) : base(key) {}

        private String value;
        public String Value
        {
          get { return this.value; }
          set { this.value = value; }
        }
    }
}
