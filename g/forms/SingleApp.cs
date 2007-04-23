using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace g.forms {
    public class SingleApp {
        public static void Run(String name, System.Windows.Forms.Form form) {
            String lockFileName = String.Format("{0}\\{1}.lck",
                System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), name);
            if (File.Exists(lockFileName)) {
                try {
                    File.Delete(lockFileName);
                }
                catch (System.IO.IOException) {
                    System.Windows.Forms.MessageBox.Show("Запущен второй экземпляр приложения, выхожу. Если Вы не согласны с этим, удалите файл " + lockFileName);
                    return;
                }
            }
            try {
                using (StreamWriter lockFile = File.CreateText(lockFileName)) {
                    System.Windows.Forms.Application.Run(form);
                }
            }
            finally {
                File.Delete(lockFileName);
            }
        }
    }
}
