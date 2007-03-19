using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public abstract class AbstractKey : Key {
	    public abstract Object[] Values { get; }

        override public bool Equals(Object objb) {
            Object[] values = this.Values;
            if (objb == null) return false;
            if (!(objb is Key)) return false;
            Object[] valuesb = ((Key)objb).Values;
            if (valuesb.Length != values.Length) return false;

            for (int i = 0; i < values.Length; i++) {
                if (!values[i].Equals(valuesb[i]))
                    return false;
            }

            return true;
        }

	    override public int GetHashCode() {
		    Object[] values = Values;
    		       
		    int hashCode = 0;
		    for (int i = 0; i < values.Length; i++) {
			    hashCode = hashCode ^ values[i].GetHashCode();
		    }
		    return hashCode;
	    }	
    }
}
