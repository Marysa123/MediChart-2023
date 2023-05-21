using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Shapes;
using System.Xml;

namespace MediChart.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPersonalWindow.xaml
    /// </summary>
    public partial class AddPersonalWindow : Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;
        public string SourceIm { get; set; }
        byte[] data;

        public AddPersonalWindow()
        {
            SourceIm = "/Resources/Images/icon_Images.png";

            InitializeComponent();

            this.DataContext = this;



            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();
        }
        
        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
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

        private void button_AddPersonal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data = File.ReadAllBytes(SourceIm);
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите фотографию!", "Диалоговое окно");
                return;
            }

            if (textbox_Ima.Text == "" || textbox_Ima.Text == "" || textbox_Otch.Text == "" || textbox_Phone.Text == "" || textbox_EMail.Text == "" || textbox_Adress.Text == "" || combobox_Pol.Text == "" || datapicker_data.Text == "" || textbox_Education.Text == ""  || textbox_Login.Text == "" || textbox_Password.Password == "" || textbox_Spec.Text == "" || SourceIm == "/Resources/Images/icon_Images.png")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно");
            }
            else if (textbox_Password.Password != textbox_VerifityPassword.Password)
            {
                textbox_Password.Clear();
                textbox_VerifityPassword.Clear();
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Password, "Пароли не совпадают.");
                textbox_Password.BorderBrush = Brushes.Red;
                textbox_VerifityPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                ValidateInfoStudentLogin(textbox_Login.Text, out bool ResultLogin);
                if (ResultLogin == true)
                {
                    ValidateInfoStudentEmail(textbox_EMail.Text, out bool ResultEmail);
                    if (ResultEmail == true)
                    {
                        ValidateInfoStudentPhone(textbox_Phone.Text, result: out bool ResultPhone);
                        if (ResultPhone == true)
                        {
                            ConfirmationEmail confirmationEmail = new ConfirmationEmail();
                            confirmationEmail.ConfirmationEmailMessage(textbox_EMail.Text,out bool Result);
                            if (Result == true)
                            {
                                confirmationEmail.ShowDialog();
                            }
                            else
                            {
                                return;
                            }


                            if (confirmationEmail.ResultConfirmation == false)
                            {
                                MessageBox.Show("Неверный код!", "Диалоговое окно", MessageBoxButton.OK);
                            }
                            else
                            {
                                Connection.Open();
                                SqlCommand.CommandText = $"insert into [Сотрудники] (Имя,Фамилия,Отчество,Логин,Пароль,[Электронная почта],[Номер Телефона],Пол,[Дата Рождения],Адрес,[Образование],[Специальность],[Фотография])  VALUES('{textbox_Ima.Text}','{textbox_Fam.Text}','{textbox_Otch.Text}','{textbox_Login.Text}','{textbox_Password.Password}','{textbox_EMail.Text}','{textbox_Phone.Text}','{combobox_Pol.Text}','{datapicker_data.Text}','{textbox_Adress.Text}','{textbox_Education.Text}','{textbox_Spec.Text}',@images)"; // Создание запроса
                                SqlCommand.Connection = Connection; // Инифиализация подключения
                                SqlCommand.Parameters.Add(new SqlParameter("@images", data));
                                SqlCommand.ExecuteNonQuery();
                                Connection.Close();
                                MessageBox.Show("Данные успешно добавлены.", "Диалоговое окно");
                                Close();
                            }
                        }
                        else
                        {
                            textbox_Phone.Clear();
                            MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Phone, "Номер уже занят.");
                            textbox_Phone.BorderBrush = Brushes.Red;
                        }
                    }
                    else
                    {
                        textbox_EMail.Clear();
                        MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_EMail, "Почта уже занята.");
                        textbox_EMail.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    textbox_Login.Clear();
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Login, "Логин уже занят.");
                    textbox_Login.BorderBrush = Brushes.Red;
                }
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
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
                Image.Source = BitmapFrame.Create(new Uri(FileName));
                SourceIm = FileName;
            }
        }
        public bool ValidateInfoStudentPhone(string PhoneOne, out bool result)
        {
            Connection.Close();
            Connection.Open();
            SqlCommand.CommandText = $"select [Номер Телефона] from [Сотрудники] where [Номер Телефона] = '{PhoneOne}'";
            SqlCommand.Connection = Connection;
            string PhoneTwo = (string)SqlCommand.ExecuteScalar();

            if (PhoneOne == PhoneTwo)
            {
                Connection.Close();
                return result = false;
            }
            Connection.Close();
            return result = true;
        }
        public bool ValidateInfoStudentEmail(string EmailOne, out bool result)
        {
            Connection.Close();
            Connection.Open();
            SqlCommand.CommandText = $"select [Электронная почта] from [Сотрудники] where [Электронная почта] = '{EmailOne}'";
            SqlCommand.Connection = Connection;
            string EmailTwo = (string)SqlCommand.ExecuteScalar();

            if (EmailOne == EmailTwo)
            {
                Connection.Close();
                return result = false;
            }
            Connection.Close();
            return result = true;
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
