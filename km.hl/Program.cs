using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace km.hl {
    static class Program {
        [MTAThread]
        static void Main() {
            g.config.Config.reconfigure(typeof(Program));
            Application.Run(new MainForm());            
        }
    }
}