using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.orm {
    public static class Commons {
        public const String DATABASE_ID = "hl-db";

        public static string decodeText(string p) {
            return g.HttpUtility.UrlDecode(p, Encoding.GetEncoding("Windows-1251"));
        }
    }
}
