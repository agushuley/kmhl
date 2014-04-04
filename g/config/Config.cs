using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

namespace g.config {
    public class Config {
        private static Dictionary<String, String> config = null;
        private static Object configLock = new Object();

        public static String get(String key) {
            lock (configLock) {
                if (config == null) {
                    config = loadConfig();
                }
                try {
                    return config[key];
                }
                catch (KeyNotFoundException) {
                    return null;
                }
            }
        }

        public static Dictionary<String, String> get() {
            lock (configLock) {
                if (config == null) {
                    config = loadConfig();
                }
                return config;
            }
        }

        public static void reconfigure(Type type) {
            if (type == null) {
                throw new ArgumentNullException();
            }
            lock (configLock) {
                config = null;
                configuredType = type;
            }
        }
        private static Type configuredType = typeof(Config);

        private static Dictionary<String, String> loadConfig() {            
            Dictionary<String, String> dict = new Dictionary<String, String>();

            String baseName = configuredType.Assembly.GetName().CodeBase + ".xml";

            loadConfig(baseName, dict);
            loadConfig(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + System.IO.Path.GetFileName(baseName), dict);

            return dict;
        }

        private static void loadConfig(String path, Dictionary<String, String> dict) {
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(path);
            }
            catch (System.IO.FileNotFoundException) { 
                return;  
            }
            foreach (XmlNode node in doc.SelectNodes("/config/value")) {
                XmlElement el = (XmlElement) node;
                if (dict.ContainsKey(el.GetAttribute("name"))) {
                    dict.Remove(el.GetAttribute("name"));
                }
                dict.Add(el.GetAttribute("name"), el.InnerXml);
            }
        }

        public static void clean() {
            lock (configLock) {
                config = null;
            }
        }

        public static String get(string p, string p_2) {
            String value = get(p);
            if (value != null) return value;
            return p_2;
        }
    }
}
