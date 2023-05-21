using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для PersonalProfilePacient.xaml
    /// </summary>
    public partial class PersonalProfilePacient : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public string SourceIm { get; set; }
        public string Pol { get; set; }
        public string DataRosh { get; set; }
        public string Class { get; set; }

        public BitmapImage newBitmapImage;
        public byte[] Image;
        byte[] data;

        public int Nomer { get; set; }

        List<string> MassivNameClass;


        public PersonalProfilePacient(int NomerPersonal)
        {
            InitializeComponent();

            this.Nomer = NomerPersonal;
            this.DataContext = this;

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();
            GetImages();

            string Result;
            GetDataTextBox("Имя", out Result);
            textbox_Ima.Text = Result;

            GetDataTextBox("Фамилия", out Result);
            textbox_Fam.Text = Result;

            GetDataTextBox("Отчество", out Result);
            textbox_Otc.Text = Result;

            GetDataTextBox("Электронная почта", out Result);
            textbox_EMail.Text = Result;

            GetDataTextBox("Номер Телефона", out Result);
            textbox_Phone.Text = Result;

            GetDataTextBox("Номер телефона родителя", out Result);
            textbox_Rod.Text = Result;

            GetDataTextBox("Пол", out Result);
            Pol = Result;

            SqlCommand.CommandText = $"select CONVERT(VARCHAR(10), getdate(), 111) from [Учащийся] where [Номер Учащегося] = {Nomer}";
            DataRosh = (string)SqlCommand.ExecuteScalar();

            GetDataTextBox("FK Номер Класса", out Result);
            Class = Result;

            GetDataTextBox("Адрес Проживания", out Result);
            textbox_Adres.Text = Result;

            SetViewNameClass();
        }
        private void SetViewNameClass()
        {
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
        private void GetDataTextBox(string NameColumn, out string Result)
        {
            SqlCommand.CommandText = $"select [{NameColumn}] from [Учащийся] where [Номер Учащегося] = {Nomer}";
            Result = (string)SqlCommand.ExecuteScalar();
        }
        private void GetImages()
        {
            SqlCommand.CommandText = $"select [Фотография] from [Учащийся] where [Номер Учащегося] = {Nomer}";
            try
            {
                Image = (byte[])SqlCommand.ExecuteScalar();
            }
            catch (Exception)
            {
                SourceIm = "/Resources/Images/icon_Images.png";
            }

            if (Image == null)
            {

            }
            else 
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = ms;
                newBitmapImage.EndInit();

                ImagesProfile.Source = newBitmapImage;
            }     
        }

        private void ImagesProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();
            string FileName = openFile.FileName;

            if (FileName == "")
            {

            }
            else
            {
                ImagesProfile.Source = BitmapFrame.Create(new Uri(FileName));
                SourceIm = FileName;

                data = File.ReadAllBytes(SourceIm);

                Connection.Close();
                Connection.Open();
                SqlCommand.CommandText = $"update [Учащийся] set Фотография = @images"; // Создание запроса
                SqlCommand.Connection = Connection; // Инифиализация подключения
                SqlCommand.Parameters.Add(new SqlParameter("@images", data));
                SqlCommand.ExecuteNonQuery();
                Connection.Close();
                MessageBox.Show("Фотография обновлена", "Диалоговое окно");
                ImagesProfile.IsEnabled = false;
            }
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection.Close();
                Connection.Open();
                SqlCommand.CommandText = $"update [Учащийся] set Фамилия = '{textbox_Fam.Text}',Имя = '{textbox_Ima.Text}',Отчество = '{textbox_Otc.Text}',[Электронная почта] = '{textbox_EMail.Text}',[Номер Телефона] = '{textbox_Phone.Text}',Пол = '{combobox_Pol.Text}',[Дата Рождения] = '{datapicker_data.Text}',[Адрес Проживания] = '{textbox_Adres.Text}',[FK Номер Класса] = '{combobox_Class.Text}',[Номер телефона родителя] = '{textbox_Rod.Text}' where [Номер Учащегося] = '{Nomer}'";
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void textbox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }
    }
}
