using System;
using System.Collections.Generic;
using System.Text;

namespace g {
    public class DbTools {
        public static DateTime ToDateTime(Object obj) {
            if (obj == DBNull.Value || obj == null) throw new ArgumentNullException();
            return Convert.ToDateTime(obj);
        }

        public static DateTime? ToDateTimeZ(Object obj) {
            if (obj == DBNull.Value || obj == null) return null;
            return Convert.ToDateTime(obj);
        }

        public static int? ToIntZ(Object obj) {
            if (obj == DBNull.Value || obj == null) return null;
            return Convert.ToInt32(obj);
        }

        public static int ToInt(Object obj) {
            if (obj == DBNull.Value || obj == null) throw new ArgumentNullException();
            return Convert.ToInt32(obj);
        }

        public static String ToString(Object obj) {
            if (obj == DBNull.Value || obj == null) return null;
            return Convert.ToString(obj);
        }

        public static object ToObject(Object p) {
            if (p == null) return DBNull.Value;
            return p;
        }

        public static decimal? ToDecimalZ(Object obj) {
            if (obj == DBNull.Value || obj == null) return null;
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(Object obj) {
            if (obj == DBNull.Value || obj == null) throw new ArgumentNullException();
            return Convert.ToDecimal(obj);
        }

        public static void setParam(System.Data.IDbCommand cmd, string paramName, Object paramValue) {
            if (cmd.Parameters.Contains(paramName)) {
                ((System.Data.IDbDataParameter)cmd.Parameters[paramName])
                    .Value = paramValue;
            }
            else {
                System.Data.IDbDataParameter param = cmd.CreateParameter();
                param.ParameterName = paramName;
                param.Value = ToObject(paramValue);
                cmd.Parameters.Add(param);
            }
        }


        public static bool ToBoolean(object p) {
            String val = ToString(p);
            if (val == null) return false;
            if (val.Equals("y", StringComparison.OrdinalIgnoreCase)
                || val.Equals("1", StringComparison.OrdinalIgnoreCase)
                ) 
            {
                return true;
            }
            return false;
        }

        public static String EschapeString(String str, char eschape) {
            if (String.IsNullOrEmpty(str)) {
                return str;
            }
            return str.Replace("%", "" + eschape + '%')
                .Replace("_", "" + eschape + '_')
                .Replace("" + eschape, "" + eschape + eschape);
        }
    }
}
