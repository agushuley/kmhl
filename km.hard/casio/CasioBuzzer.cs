using System;
using System.Collections.Generic;
using System.Text;

namespace km.hard.casio {
    class CasioBuzzer : BuzzerControl {
        public void Play(BuzzerVolume volume, int freq, int time) {
            int mode = 0;
            switch (volume) 
            {
                case BuzzerVolume.min:
                    mode = Calib.SystemLibNet.Def.BUZZERVOLUME_MIN;
                    break;
                case BuzzerVolume.mid:
                    mode = Calib.SystemLibNet.Def.BUZZERVOLUME_MID;
                    break;
                case BuzzerVolume.max:
                    mode = Calib.SystemLibNet.Def.BUZZERVOLUME_MAX;
                    break;
            }
            Calib.SystemLibNet.Api.SysPlayBuzzer(mode, time, freq);
        }
    }
}
