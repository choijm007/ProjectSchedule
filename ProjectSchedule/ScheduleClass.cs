using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjectSchedule
{
    public class Schedule
    {
        public readonly int id;
        public string name = string.Empty;
        public string userMemo = string.Empty;

        public Schedule()
        {
            id = ScheduleList.createNewId();
        }
    }

    public class Alarm : Schedule
    {
        public DateTime startDay;
        public int startHour;
        public int startMinute;

        public Alarm() : base() { }
    }

    public class Appointment : Schedule
    {
        public DateTime startDay;
        public int startHour;
        public int startMinute;
        public int endHour;
        public int endMinute;

        public Appointment() : base() { }
    }

    public class RepeatSchedule : Schedule
    {
        public DateTime startDay;
        public DateTime endDay;
        public readonly int repeatType; // 0 = 매주, 1 = 매달, 2 = 매년
        public List<RepeatTime> repeatList = new List<RepeatTime>();

        public RepeatSchedule(int type) : base() { repeatType = type; }

        public List<RepeatTime> getRepeatTimeByDay(DateTime date)
        {
            List<RepeatTime> rtemp = new List<RepeatTime>();

            foreach (RepeatTime rTime in repeatList)
            {
                if ((repeatType == 0)
                    && (rTime.date.DayOfWeek == date.DayOfWeek))
                {
                    rtemp.Add(rTime);
                }
                else if ((repeatType == 1)
                    && (rTime.date.Day == date.Day))
                {
                    rtemp.Add(rTime);
                }
                else if ((repeatType == 2)
                    && (rTime.date.Month == date.Month)
                    && (rTime.date.Day == date.Day))
                {
                    rtemp.Add(rTime);
                }
            }

            return rtemp;
        }

        public int createRepeatTimeId()
        {
            List<int> idList = new List<int>();
            int temp = 1;

            for (int i = 0; i < repeatList.Count; i++)
            {
                idList.Add(repeatList[i].id);
            }

            while (true)
            {
                if (!idList.Contains(temp)) { return temp; }
                temp++;
            }
        }
    }

    public class ClassSchedule : Schedule
    {
        public DateTime startDay;
        public DateTime endDay;
        public readonly int repeatType; // 0 = 매주, 1 = 매달, 2 = 매년
        public List<RepeatTime> repeatList = new List<RepeatTime>();
        public List<ToDo> todoList = new List<ToDo>();

        public ClassSchedule(int type) : base() { repeatType = type; }

        public List<RepeatTime> getRepeatTimeByDay(DateTime date)
        {
            List<RepeatTime> rtemp = new List<RepeatTime>();

            foreach (RepeatTime rTime in repeatList)
            {
                if ((repeatType == 0)
                    && (rTime.date.DayOfWeek == date.DayOfWeek))
                {
                    rtemp.Add(rTime);
                }
                else if ((repeatType == 1)
                    && (rTime.date.Day == date.Day))
                {
                    rtemp.Add(rTime);
                }
                else if ((repeatType == 2)
                    && (rTime.date.Month == date.Month)
                    && (rTime.date.Day == date.Day))
                {
                    rtemp.Add(rTime);
                }
            }

            return rtemp;
        }

        public List<ToDo> getTodoByDay(DateTime date)
        {
            List<ToDo> temp = new List<ToDo>();

            foreach (ToDo td in todoList)
            {
                if (td.deadLine.Date == date.Date)
                {
                    temp.Add(td);
                }
            }

            return temp;
        }

        public int createRepeatTimeId()
        {
            List<int> idList = new List<int>();
            int temp = 1;

            for (int i = 0; i < repeatList.Count; i++)
            {
                idList.Add(repeatList[i].id);
            }

            while (true)
            {
                if (!idList.Contains(temp)) { return temp; }
                temp++;
            }
        }

        public int createToDoId()
        {
            List<int> idList = new List<int>();
            int temp = 1;

            for (int i = 0; i < todoList.Count; i++)
            {
                idList.Add(todoList[i].id);
            }

            while (true)
            {
                if (!idList.Contains(temp)) { return temp; }
                temp++;
            }
        }
    }

    public class RepeatTime
    {
        public readonly int id;
        public DateTime date; // repeatType에 따라 date에서 n요일, n일, n월 m일 등을 추출
        public int startHour;
        public int startMinute;
        public int endHour;
        public int endMinute;

        public RepeatTime(int id)
        { this.id = id; }
    }


    public class ToDo
    {
        public readonly string type;
        public readonly int id;
        public string name = string.Empty;
        public DateTime deadLine;
        public int deadLineHour;
        public int deadLineMinute;
        public string userMemo;

        public ToDo(int id, string type)
        { this.id = id; this.type = type; }
    }
}
