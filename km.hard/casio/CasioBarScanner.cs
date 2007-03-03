using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Calib;
using km.hard.scan;

namespace km.hard.casio {
    public class CasioBarScanner : Scanner {
        public CasioBarScanner() {
            checkCasioOk(OBReadLibNet.Api.OBRSetCode39Option(OBReadLibNet.Def.OBR_CODE_ENABLE, 2, 38,
                OBReadLibNet.Def.OBR_39SON | OBReadLibNet.Def.OBR_39ASON,
                OBReadLibNet.Def.OBR_CHKDON, OBReadLibNet.Def.OBR_CHKKON));
        }

        public void Attach(Form owner) {
            this.owner = owner;

            this.owner.Deactivate += new EventHandler(owner_Deactivate);
            this.owner.Disposed += new EventHandler(owner_Deactivate);
            this.owner.Activated += new EventHandler(owner_Activated);

            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 250;
            timer.Enabled = true;

            if (this.owner.Focused) {
                owner_Activated(this, null);
            }
        }

        bool enabled = false;

        void timer_Tick(object sender, EventArgs e) {
            if (!enabled) {
                return;
            }
            try {
                int size = 0, code = 0;
                byte number = 0, len = 0;
                checkCasioOk(Calib.OBReadLibNet.Api.OBRGetStatus(ref size, ref number));
                if (number > 0) {
                    byte[] buffer = new byte[size];
                    checkCasioOk(Calib.OBReadLibNet.Api.OBRGets(buffer, ref code, ref len));
                    String scan = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, buffer.Length).Trim();
                    checkCasioOk(Calib.OBReadLibNet.Api.OBRClearBuff());
                    if (Scanned != null) {
                        Scanned(scan);
                    }
                }
            }
            catch (ScanException) {}
        }

        private Form owner = null;

        bool activating = false;
        void owner_Activated(object sender, EventArgs e) {
            if (!enabled && !activating) {
                try {
                    activating = true;
                    checkCasioOk(OBReadLibNet.Api.OBROpen(owner.Handle, OBReadLibNet.Def.OBR_ALL));
                    enabled = true;
                }
                catch (ScanException ex) {
                    MessageBox.Show("Scanner opening error: " + ex.ToString());
                }
                finally {
                    activating = false;
                }
            }
        }

        private void checkCasioOk(int p) {
            if (p != OBReadLibNet.Def.OBR_OK) {
                switch (p) {
                    case (OBReadLibNet.Def.OBR_NONDT):
                        throw new ScanException("error end");
                    case (OBReadLibNet.Def.OBR_PON):
                        throw new ScanException("Already open");
                    case (OBReadLibNet.Def.OBR_POF):
                        throw new ScanException("Not open");
                    case (OBReadLibNet.Def.OBR_PRM):
                        throw new ScanException("parameter error");
                    case (OBReadLibNet.Def.OBR_NOT_DEVICE):
                        throw new ScanException("OBR Driver(Scanner) device is not available");
                    case (OBReadLibNet.Def.OBR_NOT_DEVICE_DECODE):
                        throw new ScanException("OBR Driver(decode) device is not available");
                    case (OBReadLibNet.Def.OBR_ERROR_HOTKEY):
                        throw new ScanException("RegisterHotKey error");
                    default:
                        throw new ScanException("Unknown error: " + p.ToString("X"));
                }
            }
        }

        void owner_Deactivate(object sender, EventArgs e) {
            if (enabled) {
                try {
                    checkCasioOk(OBReadLibNet.Api.OBRClose());
                }
                catch (ScanException) {}
            }
            enabled = false;
        }

        void owner_Disposed(object sender, EventArgs e) {
            owner_Deactivate(sender, e);
        }

        public event OnScanned Scanned;
    }
}
