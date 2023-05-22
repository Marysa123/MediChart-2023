
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediChart.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationUser.xaml
    /// </summary>
    public partial class RegistrationUser : Window
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        List<string> MassivNameClass;
        byte[] data;


        public string SourceIm { get; private set; }

        public RegistrationUser()
        {
            InitializeComponent();

            SqlCommand = new SqlCommand();
            Connection = new SqlConnection();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();

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
        }

        private void exinInWindowSignInAndUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignInAndUp signInAndUp = new SignInAndUp();
            signInAndUp.Show();
            Close();
        }

        private void button_Register_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_Fam.Text == "" || textbox_Ima.Text == "" || textbox_Otc.Text == "" || textbox_Login.Text == "" || textbox_Password.Password == "" || textbox_VerifityPassword.Password == "" || textbox_Phone.Text == "" || textbox_EMail.Text == "" || combobox_pol.Text == "" || datapicker_data.Text == "" || textbox_Adress.Text == "" || textbox_PhoneRod.Text == "" || combobox_Class.Text == "")
            {
                MessageBox.Show("Отсутствует значение в одном из полей!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
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
                ValidateInfoStudentLogin(textbox_Login.Text,out bool ResultLogin);
                if (ResultLogin == true)
                {
                    ValidateInfoStudentEmail(textbox_EMail.Text, out bool ResultEmail);
                    if (ResultEmail == true)
                    {
                        ValidateInfoStudentPhone(textbox_Phone.Text, result: out bool ResultPhone);
                        if (ResultPhone == true)
                        {
                            try
                            {
                                ConfirmationEmail confirmationEmail = new ConfirmationEmail();
                                confirmationEmail.ConfirmationEmailMessage(textbox_EMail.Text, out bool Result);
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
                                    SourceIm = "./icon_Images.png";
                                    data = File.ReadAllBytes(SourceIm);

                                    Connection.Open();
                                    SqlCommand.CommandText = $"Insert into Учащийся (Имя,Фамилия, Отчество, Логин, Пароль,[Электронная почта],[Номер Телефона],[Номер телефона родителя],Пол,[Дата Рождения],[Адрес Проживания],[FK Номер Класса],[Фотография]) values('{textbox_Ima.Text}','{textbox_Fam.Text}','{textbox_Otc.Text}','{textbox_Login.Text}','{textbox_VerifityPassword.Password}','{textbox_EMail.Text}','{textbox_Phone.Text}','{textbox_PhoneRod.Text}','{combobox_pol.Text}','{datapicker_data.Text}','{textbox_Adress.Text}','{combobox_Class.Text}',@photo)";
                                    SqlCommand.Parameters.Add(new SqlParameter("@photo", data));
                                    SqlCommand.ExecuteNonQuery();
                                    Connection.Close();
                                    MessageBox.Show("Успешная регистрация", "Диалоговое окно");
                                    SignInAndUp signInAndUp = new SignInAndUp();
                                    signInAndUp.Show();
                                    Close();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Неизвестная ошибка!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
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
        private void textbox_Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        public bool ValidateInfoStudentPhone(string PhoneOne, out bool result)
        {
            Connection.Close();
            Connection.Open();
            SqlCommand.CommandText = $"select [Номер Телефона] from [Учащийся] where [Номер Телефона] = '{PhoneOne}'";
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
            SqlCommand.CommandText = $"select [Электронная почта] from [Учащийся] where [Электронная почта] = '{EmailOne}'";
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

        private void textbox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
