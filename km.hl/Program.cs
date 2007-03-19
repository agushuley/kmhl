using System;
using System.Collections.Generic;
using System.Windows.Forms;

using km.hard;
using km.hard.scan;

namespace km.hl {
    static class Program {
        [MTAThread]
        static void Main() {
            g.config.Config.reconfigure(typeof(Program));
            Application.Run(new MainForm());            
        }

        static public BuzzerControl getBuzzer() {
            return g.Class.CreateInstance<BuzzerControl>(g.config.Config.get("buzzerDriver"));
        }

        static public Scanner getScanner() {
            return g.Class.CreateInstance<Scanner>(g.config.Config.get("scannerDriver"));
        }

        public static void playMinor() {
            Program.getBuzzer().Play(km.hard.BuzzerVolume.mid, 25, 50);
        }

        internal static void playMajor() {
            Program.getBuzzer().Play(km.hard.BuzzerVolume.min, 50, 100);
        }
    }
}