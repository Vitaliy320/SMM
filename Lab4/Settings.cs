    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Settings
    {
        public const int Delay = 1;

        public const double DEVICE_1_MU = 0.23, 
                            DEVICE_2_TIME = 5, 
                            DEVICE_3_TIME = 10;

        public const int QUEUE_1_LIMIT = 9,
                         QUEUE_2_LIMIT = 3;

        public const double TimeMeasure = 1;
    }

    public enum WorkMode
    {
        Intensity = 1,
        Time = 2
    }
}
