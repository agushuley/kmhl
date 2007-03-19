using System;
using System.Collections.Generic;
using System.Text;

namespace km.hard {
    public enum BuzzerVolume {
        min, mid, max
    }
    public interface BuzzerControl {
        void Play(BuzzerVolume volume, int freq, int time);
    }
}
