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
    /// Логика взаимодействия для MenuMedRabWindow.xaml
    /// </summary>
    public partial class MenuMedRabWindow : Window
    {
        public int Nomer { get; set; }
        public MenuMedRabWindow(int NomerPersonal)
        {
            InitializeComponent();
            Nomer = NomerPersonal;
            DataContext = new InfoAppMedRab();
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignInAndUp signInAndUp = new SignInAndUp();
            signInAndUp.Show();
            Close();
        }

        private void button_InfoTablets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoMedicinesMedRab();
        }

        private void button_AddRecords_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new AddRecordsMedRab(Nomer);
        }

        private void button_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new PersonalProfileMedRab(Nomer);
        }

        private void button_InfoApp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoAppMedRab();
        }

        private void button_InfoPacients_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoPacientsMedRab();
        }

        private void button_InfoClassRuk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoTeacherMedRab();
        }
    }
}
