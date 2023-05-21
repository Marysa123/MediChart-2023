using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для InfoTeachecAdmin.xaml
    /// </summary>
    public partial class InfoTeachecAdmin : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        List<string> MassivNameClass;


        public InfoTeachecAdmin()
        {
            InitializeComponent();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            GetInfo();
            SetViewNameClass();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Connection.Close();
                Connection.Open();
                SqlCommand.CommandText = $"update [Классный руководитель] set Фамилия = '{textbox_Fam.Text}',Имя = '{textbox_Ima.Text}',Отчество = '{textbox_Otch.Text}',[Электронная почта] = '{textbox_EMail.Text}',[Номер Телефона] = '{textbox_Phone.Text}',Пол = '{combobox_Pol.Text}',[Дата Рождения] = '{datapicker_data.Text}',[Адрес Проживания] = '{textbox_Adress.Text}',[Закрепленный класс] = '{combobox_Class.Text}' where [Номер классного руководителя] = '{label_Номер.Content}'";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                GetInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте уникальность введенных данных!", "Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void button_AddClassRuk_Click(object sender, RoutedEventArgs e)
        {
            Connection.Close();
            Connection.Open();
            try
            {
                if (textbox_Ima.Text == "" || textbox_Ima.Text == "" || textbox_Otch.Text == "" || textbox_Phone.Text == "" || textbox_EMail.Text == "" || textbox_Adress.Text == "" || combobox_Class.Text == "" || combobox_Pol.Text == "" || datapicker_data.Text == "")
                {
                    MessageBox.Show("Пустые поля", "Диалоговое окно");
                }
                else
                {
                    SqlCommand.CommandText = $"Insert into [Классный руководитель] (Имя,Фамилия,Отчество,[Электронная почта],[Номер Телефона],Пол,[Дата Рождения],[Адрес Проживания],[Закрепленный класс]) values('{textbox_Ima.Text}','{textbox_Fam.Text}','{textbox_Otch.Text}','{textbox_EMail.Text}','{textbox_Phone.Text}','{combobox_Pol.Text}','{datapicker_data.Text}','{textbox_Adress.Text}','{combobox_Class.Text}')";
                    SqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены.", "Диалоговое окно");
                    Connection.Close();
                    GetInfo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте уникальность введенных данных!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SetViewNameClass()
        {
            Connection.Open();
            SqlCommand.CommandText = "select [Название класса] from [Список Классов]";

            MassivNameClass = new List<string>();
            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                MassivNameClass.Add((string)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            combobox_Class.ItemsSource = MassivNameClass;
            Connection.Close();
        }
        private void GetInfo()
        {
            SqlCommand.CommandText = "SELECT [Номер классного руководителя] as 'Номер',Имя,Фамилия,Отчество,[Электронная почта] as 'Электронная почта',[Номер Телефона] as 'Номер телефона',Пол,[Дата Рождения] as 'Дата рождения',[Адрес Проживания] as 'Адрес проживания',[Закрепленный класс] as 'Закрепленный класс' from [Классный руководитель]";
            DataTable dataTable = new DataTable("[Номер классного руководителя]");
            SqlDataAdapter npgsqlDataAdapter = new SqlDataAdapter(SqlCommand);
            npgsqlDataAdapter.Fill(dataTable);
            Grid.ItemsSource = dataTable.DefaultView;
            Connection.Close();
        }

        private void textbox_Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }

        private void textbox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
                        SqlCommand.CommandText = $"delete from [Классный руководитель] where [Номер классного руководителя] = {Name}";
                        SqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена.", "Диалоговое окно");
                        GetInfo();


                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }
    }
}
