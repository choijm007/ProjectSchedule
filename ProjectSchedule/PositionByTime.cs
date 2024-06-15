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

        public int timeToPosition(List<int> lst)
        {
            int temp = (lst[0] * 24) + ((lst[1] / 10) * 4);
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

            return (36 + (86 * temp));
        }

        public int dayToPosition(DayOfWeek day)
        {
            int temp;

            switch (day)
            {
                case DayOfWeek.Monday:
                    temp = 0;
                    break;
                case DayOfWeek.Tuesday:
                    temp = 1;
                    break;
                case DayOfWeek.Wednesday:
                    temp = 2;
                    break;
                case DayOfWeek.Thursday:
                    temp = 3;
                    break;
                case DayOfWeek.Friday:
                    temp = 4;
                    break;
                case DayOfWeek.Saturday:
                    temp = 5;
                    break;
                case DayOfWeek.Sunday:
                    temp = 6;
                    break;
                default:
                    return -1;
            }

            return (36 + (86 * temp));
        }
    }
}
