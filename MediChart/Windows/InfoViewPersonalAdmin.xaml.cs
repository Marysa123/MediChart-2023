using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace MediChart.Windows
{
    /// <summary>
    /// Логика взаимодействия для InfoViewPersonalAdmin.xaml
    /// </summary>
    public partial class InfoViewPersonalAdmin : Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public string SourceIm { get; set; }
        public int Nomer { get; set; }
        public byte[] Image;
        public BitmapImage newBitmapImage;
        byte[] data;


        public InfoViewPersonalAdmin(int NomerCard)
        {
            InitializeComponent();

            this.DataContext = this;
            Nomer = NomerCard;

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();
            GetDataPersonal();
            Connection.Open();

            string Result;
            GetDataTextBox("Имя",out Result);
            textbox_Ima.Text = Result;

            GetDataTextBox("Фамилия", out Result);
            textbox_Fam.Text = Result;

            GetDataTextBox("Отчество", out Result);
            textbox_Otch.Text = Result;

            GetDataTextBox("Логин", out Result);
            textbox_Login.Text = Result;

            GetDataTextBox("Пароль", out Result);
            textbox_Password.Text = Result;

            GetDataTextBox("Электронная почта", out Result);
            textbox_EMail.Text = Result;

            GetDataTextBox("Номер Телефона", out Result);
            textbox_Phone.Text = Result;

            GetDataTextBox("Пол", out Result);
            combobox_Pol.Text = Result;

            SqlCommand.CommandText = $"select CONVERT(VARCHAR(10), getdate(), 111) from [Сотрудники] where [Номер Сотрудника] = {Nomer}";
            datapicker_data.Text = (string)SqlCommand.ExecuteScalar();

            GetDataTextBox("Адрес", out Result);
            textbox_Adress.Text = Result;

            GetDataTextBox("Образование", out Result);
            textbox_Education.Text = Result;

            GetDataTextBox("Специальность", out Result);
            textbox_Spec.Text = Result;
            Connection.Close();
        }
        private void GetDataTextBox(string NameColumn, out string Result)
        {
            SqlCommand.CommandText = $"select [{NameColumn}] from [Сотрудники] where [Номер Сотрудника] = {Nomer}";
            Result = (string)SqlCommand.ExecuteScalar();
        }
        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить сотрудника?", "Окно удаления данных", MessageBoxButton.OKCancel);

            switch (result)
            {
                case MessageBoxResult.OK:

                SqlCommand.CommandText = $"delete from [Сотрудники] where [Номер Сотрудника] = {Nomer}";
                SqlCommand.ExecuteNonQuery();

                MessageBox.Show("Сотрудник удален.", "Диалоговое окно");
                Connection.Close();
                Close();

                    break;
                    case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void button_UpdatePersonal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand.CommandText = $"update [Сотрудники] set Имя = '{textbox_Ima.Text}',Фамилия = '{textbox_Fam.Text}',Отчество = '{textbox_Otch.Text}',Логин = '{textbox_Login.Text}',Пароль = '{textbox_Password.Text}',[Электронная почта] = '{textbox_EMail.Text}',[Номер Телефона] = '{textbox_Phone.Text}',Пол = '{combobox_Pol.Text}',[Дата Рождения] = '{datapicker_data.Text}',Адрес = '{textbox_Adress.Text}',[Образование] = '{textbox_Education.Text}',[Специальность] = '{textbox_Spec.Text}' where [Номер Сотрудника] = {Nomer}";
                SqlCommand.Connection = Connection;
                SqlCommand.ExecuteNonQuery();
                Connection.Close();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте уникальность введеных данных!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void ImagePersonal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*"
            };// создаем диалоговое окно
            openFile.ShowDialog();
            string FileName = openFile.FileName;

            if (FileName == "")
            {
                
            }
            else
            {
                Connection.Open();
                ImagePersonal.Source = BitmapFrame.Create(new Uri(FileName));
                SourceIm = FileName;
                data = File.ReadAllBytes(SourceIm);
                SqlCommand.CommandText = $"update [Сотрудники] set [Фотография] = @images where [Номер Сотрудника] = {Nomer}";
                SqlCommand.Parameters.Add(new SqlParameter("@images", data));
                SqlCommand.ExecuteNonQuery();
                Connection.Close();
                ImagePersonal.IsEnabled = false;
            }

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
        private void GetDataPersonal()
        {
            SqlCommand.CommandText = $"select [Фотография] from [Сотрудники] where [Номер Сотрудника] = {Nomer}";
            Image = (byte[])SqlCommand.ExecuteScalar();

            System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            newBitmapImage = new BitmapImage();
            newBitmapImage.BeginInit();
            newBitmapImage.StreamSource = ms;
            newBitmapImage.EndInit();

            ImagePersonal.Source = newBitmapImage;
            Connection.Close();
        }
    }
}
