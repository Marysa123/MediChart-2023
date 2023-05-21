using MediChart.Windows;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для InfoPacientsMedRab.xaml
    /// </summary>
    public partial class InfoPacientsMedRab : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        int Count;

        public List<int> MassivNomerPersonal;
        List<Grid> GridStudent;

        public BitmapImage newBitmapImage;
        public byte[] Image;
        public InfoPacientsMedRab()
        {
            InitializeComponent();


            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();

            AddPacient();
            PanelPacient.ItemsSource = GridStudent;
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PanelPacient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerPersonal[PanelPacient.SelectedIndex];
                InfoPacientMedRabWindow infoPacientMedRabWindow = new InfoPacientMedRabWindow(IndexItem);
                infoPacientMedRabWindow.ShowDialog();
                AddPacient();
                PanelPacient.ItemsSource = null;
                PanelPacient.ItemsSource = GridStudent;
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите карточку!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void AddPacient()
        {
            SqlCommand.CommandText = $"select COUNT([Номер Учащегося]) from [Учащийся]";
            Count = (int)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Номер Учащегося] from [Учащийся]";

            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            MassivNomerPersonal = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerPersonal.Add((int)sqlDataReader.GetValue(0));
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
                    Height = 460,
                    Width = 450,
                };

                Border border = new Border
                {
                    Width = 450,
                    Height = 460,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB,
                    Effect = dropShadowEffect,
                };

                SqlCommand.CommandText = $"select [Фотография] from [Учащийся] where [Номер Учащегося] = {MassivNomerPersonal[i]}";
                Image = (byte[])SqlCommand.ExecuteScalar();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = ms;
                newBitmapImage.EndInit();


                EllipseGeometry ellipseGeometry = new EllipseGeometry();
                ellipseGeometry.Center = new Point(110, 100);
                ellipseGeometry.RadiusX = 90;
                ellipseGeometry.RadiusY = 90;

                Image ImageCaption = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Height = 360,
                    Width = 220,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 60, 0, 20),
                    Source = newBitmapImage,
                    Cursor = Cursors.Hand

                };
                TextBlock label_Image = new TextBlock
                {
                    Text = "Фотография:",
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 185, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"select [Фамилия] + ' ' + [Имя] + ' ' + [Отчество] as FIO from [Учащийся] where [Номер Учащегося] = {MassivNomerPersonal[i]} group by [Фамилия],[Имя],[Отчество]";

                TextBlock label_Caption = new TextBlock
                {
                    Text = "Карточка учащегося",
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

                SqlCommand.CommandText = $"select [Электронная почта] from [Учащийся] where [Номер Учащегося] = {MassivNomerPersonal[i]}";

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

                SqlCommand.CommandText = $"select [Номер Телефона] from [Учащийся] where [Номер Учащегося] = {MassivNomerPersonal[i]}";

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

                SqlCommand.CommandText = $"select [Номер телефона родителя] from [Учащийся] where [Номер Учащегося] = {MassivNomerPersonal[i]}";

                TextBlock label_PhoneRod = new TextBlock
                {
                    Text = "Номер телефона родителя:",
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

                TextBlock PhoneRod = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 165, 0, 0),
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
                grid.Children.Add(ImageCaption);
                grid.Children.Add(label_Image);
                grid.Children.Add(label_PhoneRod);
                grid.Children.Add(PhoneRod);

                GridStudent.Add(grid);
            }
        }
    }
}
