using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment
{
    public class Time
    {
        private int _Seconds;
        private int _Minutes;
        private int _Hours;

        public int Seconds
        {
            get { return _Seconds; } 
            set
            {
                _Seconds = value % 60;
                //Minutes = value / 60;
                AddMinutes(value / 60);
            }
        }

        /// <summary>
        /// Represents the seconds portion of this Time object
        /// </summary>
        /// <remarks>Has a max value of 59</remarks>
        //public int Seconds
        //{
        //    get { return _Seconds; }
        //    protected set { _Seconds = value; }
        //}
        /// <summary>
        /// represents the minutes portion of this Time object
        /// </summary>
        ///<remarks>Has a max value of 59</remarks>
        public int Minutes
        {
            get { return _Minutes; }
            protected set { _Minutes = value; }
        }
        /// <summary>
        /// Represents the hours portion of this Time object
        /// </summary>
        public int Hours
        {
            get { return _Hours; }
            protected set { _Hours = value; }
        }

        //This is the method to use to create a wide way to create constructors
        /// <summary>
        /// Initializes the object with zero parameters
        /// </summary>
        public Time() : this (0,0,0)
        {
        }
        /// <summary>
        /// Initialized the object with just the seconds passed in
        /// </summary>
        /// <param name="seconds">Set this object's seconds value and default hour and minutes to zero</param>
        public Time(int seconds) : this (seconds, 0, 0)
        {
        }
        /// <summary>
        /// Initialized the objects with the seconds and minutes parameters
        /// </summary>
        /// <param name="seconds">Initialized the parameter seconds with this argument</param>
        /// <param name="minutes">Initialeses the parameter minutes with this argument</param>
        /// <remarks>Sets Hours to zero</remarks>
        public Time(int seconds, int minutes) : this (seconds, minutes, 0)
        {
        }

        //You want to avoid the work in the constructor if possible 
        /// <summary>
        /// Initializes the object with the given parameters
        /// </summary>
        /// <param name="seconds">Initialises the parameter seconds with this argument</param>
        /// <param name="minutes">Initialses the parameter minute with this argument</param>
        /// <param name="hours">Initialises the parameter hour with this argument</param>
        /// <remarks>This is the constructor that the other constructors calls upon</remarks>
        public Time(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            //Minutes = minutes;
            AddMinutes(minutes);
            //Hours = hours;
            AddHours(hours);
        }

        public void AddSeconds(int second)
        {
            Seconds += second;
        }
        public void AddMinutes(int minute)
        {
            int temp = minute + Minutes;
            Minutes = temp % 60;
            AddHours(temp / 60);
        }
        public void AddHours(int hours)
        {
            int temp = hours + Hours;
            Hours = temp % 24;
            //TimeSpan would be this code below
            //Hours += hours;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", Hours, Minutes, Seconds);
        }

    }
}
