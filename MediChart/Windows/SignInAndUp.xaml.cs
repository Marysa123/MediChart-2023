using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для SignInAndUp.xaml
    /// </summary>
    public partial class SignInAndUp : Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        public SignInAndUp()
        {
            InitializeComponent();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Registration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationUser registrationUser = new RegistrationUser();
            registrationUser.Show();
            Close();
        }

        private void border_SignIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textbox_Login.Text == "" || textbox_Password.Password.ToString() == "")
            {
                MessageBox.Show("Пустые поля!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SqlCommand = new SqlCommand();
                Connection = new SqlConnection("Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322");
                Connection.Open();
                SqlCommand.Connection = Connection;

                SqlCommand.CommandText = $"select [Номер Сотрудника] from Сотрудники where Пароль = '{textbox_Password.Password}' and Логин = '{textbox_Login.Text}'";
                object Result = SqlCommand.ExecuteScalar();

                if (Result != null)
                {
                    MenuMedRabWindow menuMedRabWindow = new MenuMedRabWindow((int)Result);
                    menuMedRabWindow.Show();
                    Connection.Close();
                    Close();
                }
                else
                {
                    SqlCommand.CommandText = $"select [Номер Учащегося] from Учащийся where Пароль = '{textbox_Password.Password}' and Логин = '{textbox_Login.Text}'";
                    Result = SqlCommand.ExecuteScalar();
                    if (Result != null)
                    {
                        MenuPacientWindow menuPacientWindow = new MenuPacientWindow((int)Result);
                        menuPacientWindow.Show();
                        Connection.Close();
                        Close();
                    }
                    else if (textbox_Login.Text == "Admin" || textbox_Password.Password == "322")
                    {
                        MenuAdminWindow menuAdminWindow = new MenuAdminWindow();
                        menuAdminWindow.Show();
                        Connection.Close();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль", "Диалоговое окно");
                    }
                }
            }
        }
    }
}
