using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FunCal
{
    public class Calendar : Control
    {
        public ObservableCollection<Day> Days { get; set; }
        public ObservableCollection<string> NameDays { get; set; }

        public static DependencyProperty TodayProp = DependencyProperty.Register("Today", typeof(DateTime), typeof(Calendar));

        public event EventHandler<DayChangedEventArgs> DayChanged;

        public DateTime Today
        {
            get { return (DateTime)GetValue(TodayProp); }
            set { SetValue(TodayProp, value); }
        }
        private static int DayOfWeekNumber(DayOfWeek dow)
        {
            return Convert.ToInt32(dow.ToString("D"));
        }

        public void CreateCalendar(DateTime today)
        {
            Days.Clear();

            DateTime dayTod = new DateTime(today.Year, today.Month, 1);
            int posun = DayOfWeekNumber(dayTod.DayOfWeek);

            if (posun != 1) dayTod = dayTod.AddDays(-posun + 1);

            for (int i = 1; i <= 42; i++)
            {
                Day day = new Day { Date = dayTod, Enabled = true, IsThisMonth = today.Month == dayTod.Month };
                day.PropertyChanged += _DayChanged;
                day.IsToday = dayTod == DateTime.Today;
                Days.Add(day);
                dayTod = dayTod.AddDays(1);
            }
        }
        public Calendar()
        {
            DataContext = this;
            Today = DateTime.Today;

            NameDays = new ObservableCollection<string> { "Pondělí", "Úterý", "Středa", "Čtvrtek", "Pátek", "Sobota", "Neděle" };

            Days = new ObservableCollection<Day>();
            CreateCalendar(DateTime.Today);
        }
        static Calendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(typeof(Calendar)));
        }

        private void _DayChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Notes") return;
            if (DayChanged == null) return;

            DayChanged(this, new DayChangedEventArgs(sender as Day));
        }

    }

    public class DayChangedEventArgs : EventArgs
    {
        public Day Day { get; set; }

        public DayChangedEventArgs(Day day)
        {
            Day = day;
        }
    }
}