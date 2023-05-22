using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediChart.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для InfoAppMedRab.xaml
    /// </summary>
    public partial class InfoAppMedRab : UserControl
    {
        class MyTable
        {
            public MyTable(string Day, string Time)
            {
                this.День = Day;
                this.Время = Time;
            }
            public string День { get; set; }
            public string Время { get; set; }
        }
        public InfoAppMedRab()
        {
            InitializeComponent();
            List<MyTable> result = new List<MyTable>(3)
            {
                new MyTable("Понедельник", "8.00 - 16.00"),
                new MyTable("Вторник", "8.00 - 16.00"),
                new MyTable("Среда", "8.00 - 16.00"),
                new MyTable("Четверг", "8.00 - 16.00"),
                new MyTable("Пятница", "8.00 - 16.00"),
                new MyTable("Суббота", "Выходной"),
                new MyTable("Воскресенье", "Выходной"),
            };
            dataGrid.ItemsSource = result;
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
