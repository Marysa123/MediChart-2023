using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для InfoMedicinesMedRab.xaml
    /// </summary>
    public partial class InfoMedicinesMedRab : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        public InfoMedicinesMedRab()
        {
            InitializeComponent();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();
            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();
            GetInfo();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textbox_Kolvo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_AddMedicines_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_FullName.Text == "" || textbox_InfoMedicines.Text == "" || textbox_Kolvo.Text == "" || textbox_SeriasNomer.Text == "")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно");
            }
            else
            {
                Connection.Open();
                SqlCommand.CommandText = $"Insert into Лекарства (Серийный_Номер,Полное_Название,Количество,[Описание лекарства]) values('{textbox_SeriasNomer.Text}','{textbox_FullName.Text}',{textbox_Kolvo.Text},'{textbox_InfoMedicines.Text}')";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно добавлены.", "Диалоговое окно");
                GetInfo();
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand.CommandText = $"update Лекарства set Серийный_Номер = '{textbox_SeriasNomer.Text}',Полное_Название = '{textbox_FullName.Text}',Количество = {textbox_Kolvo.Text},[Описание лекарства] = '{textbox_InfoMedicines.Text}' where Номер_Лекарства = '{label_Номер.Content}'";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                GetInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите запись", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Grid.CurrentCell.Column.DisplayIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);

                switch (result)
                {
                    case MessageBoxResult.OK:

                        var Name = ((DataRowView)Grid.SelectedItems[0]).Row["Номер лекарства"].ToString();

                        Connection.Open();
                        SqlCommand.CommandText = $"delete from Лекарства where Номер_Лекарства = {Name}";
                        SqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена.", "Диалоговое окно");
                        GetInfo();


                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }
        private void GetInfo()
        {
            SqlCommand.CommandText = "SELECT Номер_Лекарства as 'Номер лекарства',Серийный_Номер as 'Серийный номер', Полное_Название as 'Полное название',Количество,[Описание лекарства] as 'Описание лекарства' from Лекарства";
            DataTable dataTable = new DataTable("Номер_Лекарства");
            SqlDataAdapter npgsqlDataAdapter = new SqlDataAdapter(SqlCommand);
            npgsqlDataAdapter.Fill(dataTable);
            Grid.ItemsSource = dataTable.DefaultView;
            Connection.Close();
        }

    }
}
