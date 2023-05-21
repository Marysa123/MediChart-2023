using MediChart.WindowUserControl;
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
using System.Windows.Shapes;

namespace MediChart.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuPacientWindow.xaml
    /// </summary>
    public partial class MenuPacientWindow : Window
    {
        public int Nomer { get; set; }
        public MenuPacientWindow(int NomerPersonal)
        {
            this.Nomer = NomerPersonal;
            InitializeComponent();

            DataContext = new InfoAppPacient();
        }

        private void button_InfoApp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoAppPacient();
        }

        private void button_InfoRecords_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoRecordsPacinet(Nomer);
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignInAndUp signInAndUp = new SignInAndUp();
            signInAndUp.Show();
            Close();
        }

        private void button_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new PersonalProfilePacient(Nomer);
        }
    }
}
