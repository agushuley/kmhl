using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class GenericORMObject : g.orm.ORMObject  {
	    private StateType state = StateType.NEW; 

	    private Key key;

        public GenericORMObject(Key key) {
		    this.key = key;
	    }

	    public Key ORMKey {
		    get { return this.key; }
	    }
    	
	    public void markDirty() {
		    if (state == StateType.CLEAN) {
			    state = StateType.DIRTY;
		    }
	    }

	    public StateType ORMState {
            get { return state; }
            set { this.state = value; }
	    }

	    public void checkRo(String field) {
		    if (state != StateType.LOADING) {
			    throw new ORMException("Field " + field + "of class " + GetType().FullName + " is read only!");
		    }
	    }

        public void Remove() {
            if (state != StateType.DELETED) {
                state = StateType.DELETED;
                DoRemove();
            }
        }

        protected virtual void DoRemove() {
        }
    }
}
