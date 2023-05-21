using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для InfoRecordsWindow.xaml
    /// </summary>
    public partial class InfoRecordsWindow : System.Windows.Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public int NomerRecords { get; set; }
        List<string> MassivNameDiagnoz;
        public byte[] Document { get; set; }

        public InfoRecordsWindow(int NomerRecords)
        {
            InitializeComponent();

            this.NomerRecords = NomerRecords;

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;

            Connection.Open();
            SetViewNameDiagnoz();
            GetInfoRecords();
        }

        private void button_DeleteRecord_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);

            switch (result)
            {
                case MessageBoxResult.OK:


                SqlCommand.CommandText = $"delete from [Журнал Посещений] where [Номер_Записи] = {NomerRecords}";
                SqlCommand.ExecuteNonQuery();

                MessageBox.Show("Успешное удаление записи", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();

                  break;
                 case MessageBoxResult.Cancel:
                  break;
                
            }
        }
        private void GetInfoRecords()
        {
            SqlCommand.CommandText = $"select [ФИО Пациента] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            combobox_FioPacients.Text = (string)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [ФИО Сотрудника] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            textbox_FioPersonal.Text = (string)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select CONVERT(VARCHAR(10), getdate(), 111) from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            textbox_Data.Text = (string)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Жалобы] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            textbox_Jalobi.Text = (string)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Назначенное_Лечение] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            textbox_Lechenie.Text = (string)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Диагноз] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            combobox_Diagnoz.Text = (string)SqlCommand.ExecuteScalar();

        }

        private void button_DownloadDocument_Click(object sender, RoutedEventArgs e)
        {
            GetDataPredmet();
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
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
        public void GetDataPredmet()
        {
            SqlCommand.CommandText = $"select [Документ справка] from [Журнал Посещений] where Номер_Записи = {NomerRecords}";
            Document = (byte[])SqlCommand.ExecuteScalar();


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Word files (*.doc)|*.docx|ALL files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();



            string filePatch2 = saveFileDialog.FileName;
            if (filePatch2 == "")
            {
                return;
            }
            FileStream fileStream = new FileStream(filePatch2, FileMode.Create);

            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(Document, 0, Document.Length);
            MessageBox.Show("Успешное скачивание файла", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SqlCommand.CommandText = $"update [Журнал Посещений] set Дата = '{textbox_Data.Text}',[ФИО Пациента] = '{combobox_FioPacients.Text}',[ФИО Сотрудника] = '{textbox_FioPersonal.Text}',Жалобы = '{textbox_Jalobi.Text}',[Назначенное_Лечение] = '{textbox_Lechenie.Text}',Диагноз = '{combobox_Diagnoz.Text}' where Номер_Записи = {NomerRecords}";
            SqlCommand.ExecuteNonQuery();
            MessageBox.Show("Успешное обновление записи", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
