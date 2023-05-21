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
    /// Логика взаимодействия для AddInfoClassDiagAdmin.xaml
    /// </summary>
    public partial class AddInfoClassDiagAdmin : UserControl
    {
        public AddInfoClassDiagAdmin()
        {
            InitializeComponent();


            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;

            Connection.Open();
            GetInfoDiagnoz();
            GetInfoClass();
        }

        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        private void button_AddDiagnoz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox_NameDiagnoz.Text == "")
                {
                    MessageBox.Show("Пустые поля", "Диалоговое окно");
                }
                else
                {
                    Connection.Open();
                    SqlCommand.CommandText = $"Insert into [Список Диагнозов] ([Полное Название Диагноза]) values('{textbox_NameDiagnoz.Text}')";
                    SqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены.", "Диалоговое окно");
                    GetInfoDiagnoz();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте уникальность полей!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void button_AddClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox_NameClass.Text == "")
                {
                    MessageBox.Show("Пустые поля", "Диалоговое окно");
                }
                else
                {
                    Connection.Open();
                    SqlCommand.CommandText = $"Insert into [Список Классов] ([Название класса]) values('{textbox_NameClass.Text}')";
                    SqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены.", "Диалоговое окно");
                    GetInfoClass();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте уникальность полей!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void GetInfoClass()
        {
            SqlCommand.CommandText = "SELECT [Номер класса] as 'Номер', [Название класса] as 'Название класса' from [Список Классов]";
            DataTable dataTable = new DataTable("[Номер класса]");
            SqlDataAdapter npgsqlDataAdapter = new SqlDataAdapter(SqlCommand);
            npgsqlDataAdapter.Fill(dataTable);
            GridListClass.ItemsSource = dataTable.DefaultView;
            Connection.Close();
        }
        private void GetInfoDiagnoz()
        {
            SqlCommand.CommandText = "SELECT [Номер Диагноза] as 'Номер',[Полное Название Диагноза] as 'Наименование диагноза' from [Список Диагнозов]";
            DataTable dataTable = new DataTable("[Номер Диагноза]");
            SqlDataAdapter npgsqlDataAdapter = new SqlDataAdapter(SqlCommand);
            npgsqlDataAdapter.Fill(dataTable);
            GridListDignoz.ItemsSource = dataTable.DefaultView;
            Connection.Close();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (GridListClass.CurrentCell.Column.DisplayIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле? Все данные связанные с этим класом будут удалены.", "Окно удаления данных", MessageBoxButton.OKCancel);

                switch (result)
                {
                    case MessageBoxResult.OK:

                        var Name = ((DataRowView)GridListClass.SelectedItems[0]).Row["Номер"].ToString();

                        Connection.Open();
                        SqlCommand.CommandText = $"delete from [Список классов] where [Номер класса] = {Name}";
                        SqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена.", "Диалоговое окно");
                        GetInfoClass();


                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }

        private void DataGridRow_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (GridListDignoz.CurrentCell.Column.DisplayIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле? Все данные связанные с этим класом будут удалены.", "Окно удаления данных", MessageBoxButton.OKCancel);

                switch (result)
                {
                    case MessageBoxResult.OK:

                        var Name = ((DataRowView)GridListDignoz.SelectedItems[0]).Row["Номер"].ToString();

                        Connection.Open();
                        SqlCommand.CommandText = $"delete from [Список Диагнозов] where [Номер Диагноза] = {Name}";
                        SqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена.", "Диалоговое окно");
                        GetInfoDiagnoz();


                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand.CommandText = $"update [Список Классов] set [Название класса] = '{textbox_NameClass.Text}' where [Номер класса] = '{textbox_NomerClass.Text}'";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                GetInfoClass();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите запись", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

            try
            {
                Connection.Open();
                SqlCommand.CommandText = $"update [Список Диагнозов] set [Полное Название Диагноза] = '{textbox_NameDiagnoz.Text}' where [Номер Диагноза] = '{textbox_NomerDiagnoz.Text}'";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                GetInfoDiagnoz();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите запись", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
