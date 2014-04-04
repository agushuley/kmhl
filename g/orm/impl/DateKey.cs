using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class DateKey : AbstractKey {
        DateTime date;

        public DateKey(DateTime date) {
	        this.date = date;
        }

        override public Object[] Values {
            get {
                return new Object[] { date };
            }
        }

        public DateTime Date {
            get { return date; }
        }
    }    
}
