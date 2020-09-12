using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rust_timer
{
    class Clock
    {
        private int hour;
        private int minute;
        private int second;

        public Clock()
        {
            hour = 0;
            minute = 0;
            second = 0;
        }

        public void addSecond()
        {
            second += 1;
            if(second == 60)
            {
                second = 0;
                addMinute();
            }
        }

        private void addMinute()
        {
            minute += 1;
            if (minute == 60)
            {
                minute = 0;
                addHour();
            }
        }

        private void addHour()
        {
            hour += 1;
        }

        public void reset()
        {
            second = 0;
            minute = 0;
            hour = 0;
        }

        public override String ToString()
        {
            return hour.ToString().PadLeft(2, '0') + ":" + minute.ToString().PadLeft(2, '0') + ":" + second.ToString().PadLeft(2, '0');
        }

        public int getHour()
        {
            return hour;
        }
    }


}
