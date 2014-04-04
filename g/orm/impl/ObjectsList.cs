using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class ObjectsList<T> : ObjectsCollection<T>, IList<T> {
        public ObjectsList(GenericORMObject owner, IList<T> inner, bool ro) : base(owner, inner, ro) {
        }

        #region IList<T> Members

        private IList<T> inner() {
            return (IList<T>)getInner();
        }

        public int IndexOf(T item) {
            return inner().IndexOf(item);
        }

        public void Insert(int index, T item) {
            if (isRo()) getOwner().checkRo("collection");
            try {
                inner().Insert(index, item);
            }
            finally {
                getOwner().markDirty();
            }
        }

        public void RemoveAt(int index) {
            if (isRo()) getOwner().checkRo("collection");
            try {
                inner().RemoveAt(index);
            }
            finally {
                getOwner().markDirty();
            }
        }

        public T this[int index] {
            get {
                return inner()[index];
            }
            set {
                if (isRo()) getOwner().checkRo("collection");
                try {
                    inner()[index] = value;
                }
                finally {
                    getOwner().markDirty();
                }
            }
        }

        #endregion
    }
}
