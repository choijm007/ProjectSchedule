using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

    public class ForDisplay
    {
        public readonly int id;
        public readonly int subId;
        public readonly int startTimeForSorting;
        public string type;
        public string name;
        public string startDay;
        public string endDay;
        public string startTime;
        public string endTime;
        public string userMemo;
        public string displayText;

        public List<int> getStartTimeToInt()
        {
            string[] timeParts = startTime.Split(':');

            return new List<int> { int.Parse(timeParts[0]), int.Parse(timeParts[1]) };
        }

        public List<int> getEndTimeToInt()
        {
            if (endTime == string.Empty) return null;

            string[] timeParts = endTime.Split(':');

            return new List<int> { int.Parse(timeParts[0]), int.Parse(timeParts[1]) };
        }

        public ForDisplay(Alarm alarm)
        {
            id = alarm.id;
            subId = -1;
            type = "알람";
            name = alarm.name;
            startDay = alarm.startDay.ToString("yyyy-MM-dd");
            endDay = string.Empty;
            startTime = alarm.startHour.ToString() + ":" + alarm.startMinute.ToString();
            endTime = string.Empty;
            userMemo = alarm.userMemo;
            startTimeForSorting = alarm.startHour * 100 + alarm.startMinute;
            displayText = $"{startTime} 에 {name} 이(가) 있습니다.";
        }

        public ForDisplay(Appointment appointment)
        {
            id = appointment.id;
            subId = -1;
            type = "일회성 일정";
            name = appointment.name;
            startDay = appointment.startDay.ToString("yyyy-MM-dd");
            endDay = string.Empty;
            startTime = appointment.startHour.ToString() + ":" + appointment.startMinute.ToString();
            endTime = appointment.endHour.ToString() + ":" + appointment.endMinute.ToString();
            userMemo = appointment.userMemo;
            startTimeForSorting = appointment.startHour * 100 + appointment.startMinute;
            displayText = $"{startTime} 부터 {endTime} 까지 {name} 일정이 있습니다.";
        }

        public ForDisplay(RepeatTime repeatTime, RepeatSchedule repeatSchedule)
        {
            id = repeatSchedule.id;
            subId = repeatTime.id;
            type = "반복성 일정";
            name = repeatSchedule.name;
            startDay = repeatSchedule.startDay.ToString("yyyy-MM-dd");
            endDay = repeatSchedule.endDay.ToString("yyyy-MM-dd");
            startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
            endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
            userMemo = repeatSchedule.userMemo;
            startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
            displayText = $"{startTime} 부터 {endTime} 까지 {name} 일정이 있습니다.";
        }

        public ForDisplay(RepeatTime repeatTime, ClassSchedule classSchedule)
        {
            id = classSchedule.id;
            subId = repeatTime.id;
            type = "수업";
            name = classSchedule.name;
            startDay = classSchedule.startDay.ToString("yyyy-MM-dd");
            endDay = classSchedule.endDay.ToString("yyyy-MM-dd");
            startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
            endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
            userMemo = classSchedule.userMemo;
            startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
            displayText = $"{startTime} 부터 {endTime} 까지 {name} 수업이 있습니다.";
        }

        public ForDisplay(RepeatTime repeatTime, RepeatSchedule repeatSchedule, DateTime sDay)
        {
            id = repeatSchedule.id;
            subId = repeatTime.id;
            type = "반복성 일정";
            name = repeatSchedule.name;
            startDay = sDay.ToString("yyyy-MM-dd");
            endDay = repeatSchedule.endDay.ToString("yyyy-MM-dd");
            startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
            endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
            userMemo = repeatSchedule.userMemo;
            startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
            displayText = $"{startTime} 부터 {endTime} 까지 {name} 일정이 있습니다.";
        }

        public ForDisplay(RepeatTime repeatTime, ClassSchedule classSchedule, DateTime sDay)
        {
            id = classSchedule.id;
            subId = repeatTime.id;
            type = "수업";
            name = classSchedule.name;
            startDay = sDay.ToString("yyyy-MM-dd");
            endDay = classSchedule.endDay.ToString("yyyy-MM-dd");
            startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
            endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
            userMemo = classSchedule.userMemo;
            startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
            displayText = $"{startTime} 부터 {endTime} 까지 {name} 수업이 있습니다.";
        }

        public ForDisplay(ToDo todo, ClassSchedule classSchedule)
        {
            id = classSchedule.id;
            subId = todo.id;
            type = "수업";
            name = $"{classSchedule.name} 수업의 {todo.name} 과제";
            startDay = todo.deadLine.ToString("yyyy-MM-dd");
            endDay = string.Empty;
            startTime = todo.deadLineHour.ToString() + ":" + todo.deadLineMinute.ToString();
            endTime = string.Empty;
            userMemo = todo.userMemo;
            startTimeForSorting = todo.deadLineHour * 100 + todo.deadLineMinute;
            displayText = $"{startTime} 에 {name} {todo.type} 이(가) 마감됩니다.";
        }

        public override string ToString()
        {
            return displayText;
        }
    }
}
