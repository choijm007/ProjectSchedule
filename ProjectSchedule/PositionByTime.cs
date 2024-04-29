using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchedule
{
    public partial class Form1
    {
        public int timeToPosition(int hour, int minute)
        {
            int temp = (hour * 24) + ((minute / 10) * 4);
            return (63 + temp);
        }

        public int dayToPosition(string day)
        {
            int temp;

            switch (day)
            {
                case "월":
                case "월요일":
                    temp = 0;
                    break;
                case "화":
                case "화요일":
                    temp = 1;
                    break;
                case "수":
                case "수요일":
                    temp = 2;
                    break;
                case "목":
                case "목요일":
                    temp = 3;
                    break;
                case "금":
                case "금요일":
                    temp = 4;
                    break;
                case "토":
                case "토요일":
                    temp = 5;
                    break;
                case "일":
                case "일요일":
                    temp = 6;
                    break;
                default:
                    return -1;
            }

            return (35 + 87 * temp);
        }
    }
}
