using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm.impl {
    public class ObjectsCollection<T> : ICollection<T> {

        public ObjectsCollection(GenericORMObject owner, ICollection<T> inner, bool ro) {
            this.owner = owner;
            this.inner = inner;
            this.ro = ro;
        }

        private bool ro;

        public bool isRo() {
            return ro;
        }

        private ICollection<T> inner;

        public ICollection<T> getInner() {
            return inner;
        }

        private GenericORMObject owner;

        public GenericORMObject getOwner() {
            return owner;
        }

        #region ICollection<T> Members

        public void Add(T item) {
            if (ro) owner.checkRo("collection");
            try {
                inner.Add(item);
            }
            finally {
                owner.markDirty();
            }
        }

        public void Clear() {
            if (ro) owner.checkRo("collection");
            try {
                inner.Clear();
            }
            finally {
                owner.markDirty();
            }
        }

        public bool Contains(T item) {
            return inner.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            inner.CopyTo(array, arrayIndex);
        }

        public int Count {
            get { return inner.Count; }
        }

        public bool IsReadOnly {
            get { return inner.IsReadOnly; }
        }

        public bool Remove(T item) {
            if (ro) owner.checkRo("collection");
            try {
                return inner.Remove(item);
            }
            finally {
                owner.markDirty();
            }
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator() {
            return inner.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return inner.GetEnumerator();
        }

        #endregion
    }
}
