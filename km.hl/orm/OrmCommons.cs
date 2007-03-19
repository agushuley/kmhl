using System;
using System.Collections.Generic;
using System.Text;

namespace km.hl.orm {
    public static class OrmCommons {
        public const String DATABASE_ID = "hl-db";

        public static String decodeText(String p) {
            return g.HttpUtility.UrlDecode(p, Encoding.GetEncoding("Windows-1251"));
        }

        public static String encodeText(String p) {
            return g.HttpUtility.UrlEncode(p, Encoding.GetEncoding("Windows-1251"));
        }
    }
}
