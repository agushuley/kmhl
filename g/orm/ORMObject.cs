using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm {
    public class ORMObject  {
	    public enum StateType { NEW, DIRTY, CLEAN, LOADING, DELETED };
	    private StateType state = StateType.NEW; 

	    private Key key;

        public ORMObject(Key key) {
		    this.key = key;
	    }

	    public Key Key {
		    get { return this.key; }
	    }
    	
	    protected void markDirty() {
		    if (state == StateType.CLEAN) {
			    state = StateType.DIRTY;
		    }
	    }

	    public StateType State {
            get { return state; }
            set { this.state = value; }
	    }

	    protected void checkRo(String field) {
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
