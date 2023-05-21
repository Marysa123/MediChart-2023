using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediChart.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для InfoTeacherMedRab.xaml
    /// </summary>
    public partial class InfoTeacherMedRab : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        int Count;

        public List<int> MassivNomerClassRuk;
        List<Grid> GridStudent;
        public InfoTeacherMedRab()
        {
            InitializeComponent();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();

            AddTeacher();
            PanelTeacher.ItemsSource = GridStudent;
        }
        public void AddTeacher()
        {
            SqlCommand.CommandText = $"select COUNT([Номер классного руководителя]) from [Классный руководитель]";
            Count = (int)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Номер классного руководителя] from [Классный руководитель]";

            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            MassivNomerClassRuk = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerClassRuk.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            GridStudent = new List<Grid>();

            LinearGradientBrush LGB = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(28, 157, 126), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(53, 218, 69), 0.95));

            DropShadowEffect dropShadowEffect = new DropShadowEffect
            {
                Color = Colors.Black,
                ShadowDepth = 5,
                BlurRadius = 7
            };

            for (int i = 0; i < Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 280,
                    Width = 450,
                };

                Border border = new Border
                {
                    Width = 450,
                    Height = 280,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB,
                    Effect = dropShadowEffect,
                };

                SqlCommand.CommandText = $"select [Фамилия] + ' ' + [Имя] + ' ' + [Отчество] as FIO from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]} group by [Фамилия],[Имя],[Отчество]";

                TextBlock label_Caption = new TextBlock
                {
                    Text = "Карточка классного руководителя",
                    FontSize = 24,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 20, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock label_Fio = new TextBlock
                {
                    Text = "ФИО:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 50, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Fio = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(70, 51, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"select [Электронная почта] from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_Email = new TextBlock
                {
                    Text = "E-mail:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 80, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Email = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(88, 82, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"select [Номер Телефона] from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_Phone = new TextBlock
                {
                    Text = "Номер телефона:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 110, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Phone = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(170, 112, 0, 0),
                    Cursor = Cursors.Hand
                };
                SqlCommand.CommandText = $"select [Пол] from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_Pol = new TextBlock
                {
                    Text = "Пол:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 140, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Pol = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(60, 142, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"SELECT CONVERT(VARCHAR(10), getdate(), 111) from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_DataRosh = new TextBlock
                {
                    Text = "Дата рождения:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 170, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock DataRosh = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar().ToString(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(163, 172, 0, 0),
                    Cursor = Cursors.Hand
                };
                SqlCommand.CommandText = $"SELECT [Адрес Проживания] from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_Adress = new TextBlock
                {
                    Text = "Адрес проживания:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 200, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Adress = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar().ToString(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(193, 202, 0, 0),
                    Cursor = Cursors.Hand
                };
                SqlCommand.CommandText = $"SELECT [Закрепленный Класс] from [Классный руководитель] where [Номер классного руководителя] = {MassivNomerClassRuk[i]}";

                TextBlock label_Class = new TextBlock
                {
                    Text = "Класс:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 230, 0, 0),
                    Cursor = Cursors.Hand
                };

                TextBlock Class = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar().ToString(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(83, 232, 0, 0),
                    Cursor = Cursors.Hand
                };


                grid.Children.Add(border);
                grid.Children.Add(label_Caption);
                grid.Children.Add(label_Fio);
                grid.Children.Add(Fio);
                grid.Children.Add(label_Email);
                grid.Children.Add(Email);
                grid.Children.Add(label_Phone);
                grid.Children.Add(Phone);
                grid.Children.Add(label_Pol);
                grid.Children.Add(Pol);
                grid.Children.Add(label_DataRosh);
                grid.Children.Add(DataRosh);
                grid.Children.Add(label_Adress);
                grid.Children.Add(Adress);
                grid.Children.Add(label_Class);
                grid.Children.Add(Class);


                GridStudent.Add(grid);
            }
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
