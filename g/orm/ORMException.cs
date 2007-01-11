using System;
using System.Collections.Generic;
using System.Text;

namespace g.orm {
    public class ORMException : Exception {
        public ORMException(Exception i)
            : base(i.Message, i) {
        }
        public ORMException(String message)
            : base(message) {
        }

        public ORMException(String message, Exception i)
            : base(message, i) {
        }
    }
}
