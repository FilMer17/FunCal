using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunCal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> months = new List<string> { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };

            for (int i = 0; i < months.Count; i++)
            {
                chooseMonth.Items.Add(months[i]);
            }

            for (int i = -50; i < 51; i++)
            {
                chooseYear.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            chooseMonth.SelectedItem = months[DateTime.Today.Month - 1];
            chooseYear.SelectedItem = DateTime.Today.Year;

            chooseMonth.SelectionChanged += (o, e) => ReloadCalendar();
            chooseYear.SelectionChanged += (o, e) => ReloadCalendar();
        }

        private void ReloadCalendar()
        {
            if (chooseMonth.SelectedItem == null) return;
            if (chooseYear.SelectedItem == null) return;

            int month = chooseMonth.SelectedIndex + 1;

            int year = (int)chooseYear.SelectedItem;

            DateTime targetDate = new DateTime(year, month, 1);

            Calendar.CreateCalendar(targetDate);
        }

        private void TaskAdded(object sender, DayChangedEventArgs e)
        {
            //save the text edits to persistant storage
        }
    }
}
