using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework4
{
    //声明参数类型
    public class SetAlarmClockArgs : EventArgs
    {
        public DateTime setAlarmClock;
    }
    //声明委托类型
    public delegate void SetAlarmClockHandler(object sender, SetAlarmClockArgs e);
    //定义事件源（闹钟）
    public class AlarmClock
    {
        //声明事件
        public event SetAlarmClockHandler SetAlarm;
        public DateTime now = DateTime.Now;
        public void SetAlarmClock(DateTime alarm)
        {
            SetAlarmClockArgs yourAlarmClock = new SetAlarmClockArgs();
            yourAlarmClock.setAlarmClock = alarm;
            while (now <= alarm)
            {
                //便于观察，可删除
                Console.Write('.');
                now = DateTime.Now;
            }
            SetAlarm(this, yourAlarmClock);
        }
    }
    class program1
    {
        static void Main(string[] args)
        {
            var alarmClock = new AlarmClock();
            alarmClock.SetAlarm += ShowAlarm;
            //注册事件
            string day = Console.ReadLine();
            string hour = Console.ReadLine();
            string minute = Console.ReadLine();
            
            int iday = int.Parse(day);
            int ihour = int.Parse(hour);
            int iminute = int.Parse(minute);
            DateTime alarm = new DateTime(2018,10,iday,ihour,iminute,00);
            if (alarmClock.now > alarm)
            {
                Console.WriteLine("You input wrong clock, please input new one again!");
                Console.Write("Done!!!");
            }
            else
            {
                alarmClock.SetAlarmClock(alarm);
                Console.WriteLine("Done!");
            }
        }
        //事件处理方法
        static void ShowAlarm(object sender, SetAlarmClockArgs e)
        {
            Console.WriteLine($"Alarm......Now is {e.setAlarmClock}");
        }
    }
}
