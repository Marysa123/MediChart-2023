using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediChart.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для InfoPacientAdmin.xaml
    /// </summary>
    public partial class InfoPacientAdmin : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public InfoPacientAdmin()
        {
            InitializeComponent();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();
            GetInfo();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Grid.CurrentCell.Column.DisplayIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);

                switch (result)
                {
                    case MessageBoxResult.OK:

                        var Name = ((DataRowView)Grid.SelectedItems[0]).Row["Номер"].ToString();

                        Connection.Open();
                        SqlCommand.CommandText = $"delete from [Учащийся] where [Номер Учащегося] = {Name}";
                        SqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена.", "Диалоговое окно");
                        GetInfo();


                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }

        private void button_UpdatePacient_Click(object sender, RoutedEventArgs e)
        {
            ValidateInfoStudentLogin(textbox_Login.Text, out bool ResultLogin);
            if (ResultLogin == true)
            {
                try
                {
                    Connection.Open();
                    SqlCommand.CommandText = $"update [Учащийся] set Логин = '{textbox_Login.Text}',Пароль = '{textbox_Password.Text}' where [Номер Учащегося] = '{label_Номер.Content}'";
                    SqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                    GetInfo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Выберите запись", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                textbox_Login.Clear();
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Login, "Логин уже занят.");
                textbox_Login.BorderBrush = Brushes.Red;
            }
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void GetInfo()
        {
            SqlCommand.CommandText = "SELECT [Номер Учащегося] as 'Номер',Имя,Фамилия,Отчество,Логин,Пароль from [Учащийся]";
            DataTable dataTable = new DataTable("[Номер Учащегося]");
            SqlDataAdapter npgsqlDataAdapter = new SqlDataAdapter(SqlCommand);
            npgsqlDataAdapter.Fill(dataTable);
            Grid.ItemsSource = dataTable.DefaultView;
            Connection.Close();
        }
        public bool ValidateInfoStudentLogin(string LoginOne, out bool result)
        {
            Connection.Close();
            Connection.Open();
            SqlCommand.CommandText = $"select [Логин] from [Учащийся] where [Логин] = '{LoginOne}'";
            SqlCommand.Connection = Connection;
            string LoginTwo = (string)SqlCommand.ExecuteScalar();

            if (LoginOne == LoginTwo)
            {
                Connection.Close();
                return result = false;
            }
            else
            {
                SqlCommand.CommandText = $"select [Логин] from [Сотрудники] where [Логин] = '{LoginOne}'";
                string LoginThree = (string)SqlCommand.ExecuteScalar();

                if (LoginOne == LoginThree)
                {
                    Connection.Close();
                    return result = false;
                }
            }
            Connection.Close();
            return result = true;
        }
    }
}
