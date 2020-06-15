using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FunCal
{
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DateTime date;
        string task;
        bool enable;
        bool todayMonth;
        bool todayNow;

        public bool IsToday
        {
            get { return todayNow; }
            set
            {
                todayNow = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("todayNow"));
            }
        }

        public bool IsThisMonth
        {
            get { return todayMonth; }
            set
            {
                todayMonth = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("todayMonth"));
            }
        }

        public bool Enabled
        {
            get { return enable; }
            set
            {
                enable = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Enabled"));
            }
        }

        public string Tasks
        {
            get { return task; }
            set
            {
                task = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Tasks"));
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Date"));
            }
        }
    }
}