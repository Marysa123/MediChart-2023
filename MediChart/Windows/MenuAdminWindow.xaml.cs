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
    /// Логика взаимодействия для MenuAdminWindow.xaml
    /// </summary>
    public partial class MenuAdminWindow : Window
    {
        public MenuAdminWindow()
        {
            InitializeComponent();
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignInAndUp signInAndUp = new SignInAndUp();
            signInAndUp.Show();
            Close();
        }

        private void button_Info_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new AddInfoClassDiagAdmin();
        }

        private void button_AddClassRuk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoTeachecAdmin();
        }

        private void button_Personal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoPersonalAdmin();
        }


        private void button_InfoPacients_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new InfoPacientAdmin();
        }
    }
}
