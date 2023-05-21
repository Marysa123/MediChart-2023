using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace MediChart.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationEmail.xaml
    /// </summary>
    public partial class ConfirmationEmail : Window
    {
        public int CodeCinfirmnationEmail { get; set; }
        public bool ResultConfirmation { get; set; }
        public ConfirmationEmail()
        {
            InitializeComponent();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void textbox_Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_Confirmation_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_Code.Text != "")
            {
                if (int.Parse(textbox_Code.Text) == CodeCinfirmnationEmail)
                {
                    ResultConfirmation = true;
                    this.Close();
                }
                else
                {
                    ResultConfirmation = false;
                    MessageBox.Show("Неверный код!", "Диалоговое окно", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Пустое поле!", "Диалоговое окно", MessageBoxButton.OK);
            }
        }
        public void ConfirmationEmailMessage(string Email,out bool Result)
        {
            Random random = new Random();
            int KodIntRan = random.Next(0, 1000000);
            try
            {
                string from = @"m4rysa123@yandex.ru"; // адреса отправителя
#pragma warning disable CS0219 // Переменной "pass" присвоено значение, но оно ни разу не использовано.
                string pass = "Marysa123!"; // пароль отправителя
#pragma warning restore CS0219 // Переменной "pass" присвоено значение, но оно ни разу не использовано.
                MailMessage mess = new MailMessage();
                mess.To.Add(Email); // адрес получателя
                mess.From = new MailAddress(from);
                mess.Subject = "Ваш пароль для регистрации в приложении:" + KodIntRan; // тема
                mess.Body = "Ни кому не сообщайте этот код!"; // текст сообщения
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "m4rysa123@yandex.ru";
                NetworkCred.Password = "Marysa123!";
                client.Credentials = NetworkCred;
                client.Host = "smtp.yandex.com"; //smtp-сервер отправителя
                client.Port = 25;
                client.EnableSsl = true;

                client.Send(mess); // отправка пользователю

                CodeCinfirmnationEmail = KodIntRan;
                Result = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректную почту!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                Result = false;
            }
        }
    }
}
