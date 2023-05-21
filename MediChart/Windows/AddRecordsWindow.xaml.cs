using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для AddRecordsWindow.xaml
    /// </summary>
    public partial class AddRecordsWindow : Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public int Nomer { get; set; }
        public AddRecordsWindow(int NomerPerosnal)
        {
            InitializeComponent();

            Nomer = NomerPerosnal;
            textbox_Data.Text = DateTime.Now.ToString();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;

            Connection.Open();

            SqlCommand.CommandText = $"Select  [Фамилия] + ' ' + [Имя] + ' ' + [Отчество] as FIO from [Сотрудники] where [Номер Сотрудника] = {Nomer}";
            textbox_FioPersonal.Text =  (string)SqlCommand.ExecuteScalar();

            SetViewNameDiagnoz();
            SetViewFIOPacient();
        }
        List<string> MassivNameDiagnoz;
        List<string> MassivNameFIOPacient;

        private void SetViewNameDiagnoz()
        {
            SqlCommand.CommandText = "select [Полное Название Диагноза] from [Список Диагнозов]";

            MassivNameDiagnoz = new List<string>();
            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                MassivNameDiagnoz.Add((string)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            combobox_Diagnoz.ItemsSource = MassivNameDiagnoz;
        }
        private void SetViewFIOPacient()
        {
            SqlCommand.CommandText = "select [Фамилия] + ' ' + [Имя] + ' ' + [Отчество] as FIO from [Учащийся]";

            MassivNameFIOPacient = new List<string>();
            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                MassivNameFIOPacient.Add((string)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            combobox_FioPacients.ItemsSource = MassivNameFIOPacient;
            Connection.Close();
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_AddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Diagnoz.Text == "" || combobox_FioPacients.Text == "" || textbox_Jalobi.Text == "" || textbox_Lechenie.Text == "")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AddDocument();
                Connection.Open();
                var data = File.ReadAllBytes(FileName);

                SqlCommand.CommandText = $"insert into [Журнал Посещений] (Дата,[ФИО Пациента],[ФИО Сотрудника],Жалобы,Назначенное_Лечение,Диагноз,[Документ справка]) values ('{textbox_Data.Text}','{combobox_FioPacients.Text}','{textbox_FioPersonal.Text}','{textbox_Jalobi.Text}','{textbox_Lechenie.Text}','{combobox_Diagnoz.Text}',@doc)"; // Создание запроса
                SqlCommand.Connection = Connection; // Инифиализация подключения

                SqlCommand.Parameters.Add(new SqlParameter("@doc", data));

                SqlCommand.ExecuteNonQuery(); // Выполнение запроса
                Connection.Close(); // Закрытие подключения
                MessageBox.Show("Успешное создание записи", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
        string FileName;
        public void AddDocument()
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();
            FileName = openFile.FileName;              
        }
        private void button_ViewDocument_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Diagnoz.Text == "" || combobox_FioPacients.Text == "" || textbox_Jalobi.Text == "" || textbox_Lechenie.Text == "")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var helper = new ClassWord("spravka.docx");

                var items = new Dictionary<string, string>
                {
                    { "<FioPacient>",combobox_FioPacients.Text },
                    { "<Jalobi>",textbox_Jalobi.Text },
                    { "<Diagnozt>",combobox_Diagnoz.Text },
                    { "<Lechenie>",textbox_Lechenie.Text },
                    { "<Data>",textbox_Data.Text },
                    { "<FioPersonal>",textbox_FioPersonal.Text }
                };
                helper.Process(items);
            }
        }

        private void textbox_FioPacients_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }
    }
}
