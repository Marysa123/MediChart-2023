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
    /// Логика взаимодействия для AddRecordsMedRab.xaml
    /// </summary>
    ///
    public partial class AddRecordsMedRab : UserControl
    {
        private SqlConnection Connection;
        private SqlCommand SqlCommand;

        int Count;

        public List<int> MassivNomerRecords;
        List<Grid> GridStudent;
        public int Nomer { get; set; }
        public AddRecordsMedRab(int NomerPersonal)
        {
            Nomer = NomerPersonal;
            InitializeComponent();

            Connection = new SqlConnection();
            SqlCommand = new SqlCommand();

            Connection.ConnectionString = "Data Source=62.78.81.19;Initial Catalog=db_MediChart;User ID=25-тпСердцевДмВ;Password=228322";
            SqlCommand.Connection = Connection;
            Connection.Open();

            AddRecords();

            PanelRecords.ItemsSource = GridStudent;
        }

        private void button_AddRecords_Click(object sender, RoutedEventArgs e)
        {
            AddRecordsWindow addRecordsWindow = new AddRecordsWindow(NomerPerosnal:Nomer);
            addRecordsWindow.ShowDialog();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        public void AddRecords()
        {
            SqlCommand.CommandText = $"select COUNT([Номер_Записи]) from [Журнал Посещений]";
            Count = (int)SqlCommand.ExecuteScalar();

            SqlCommand.CommandText = $"select [Номер_Записи] from [Журнал Посещений]";

            SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();

            MassivNomerRecords = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerRecords.Add((int)sqlDataReader.GetValue(0));
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

                SqlCommand.CommandText = $"select [ФИО Пациента] from [Журнал Посещений] where [Номер_Записи] = {MassivNomerRecords[i]}";

                TextBlock label_Caption = new TextBlock
                {
                    Text = "Карточка записи",
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

                TextBlock label_FioPac = new TextBlock
                {
                    Text = "ФИО пациента:",
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

                TextBlock FIO_Pac = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(160, 51, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"select [ФИО Сотрудника] from [Журнал Посещений] where [Номер_Записи] = {MassivNomerRecords[i]}";

                TextBlock label_FioPer = new TextBlock
                {
                    Text = "ФИО Сотрудника:",
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

                TextBlock FIO_Per = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(178, 82, 0, 0),
                    Cursor = Cursors.Hand
                };

                SqlCommand.CommandText = $"select CONVERT(VARCHAR(16), getdate(), 111) from [Журнал Посещений] where [Номер_Записи] = {MassivNomerRecords[i]}";

                TextBlock label_Data = new TextBlock
                {
                    Text = "Дата посещения:",
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

                TextBlock Data = new TextBlock
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
                SqlCommand.CommandText = $"select [Диагноз] from [Журнал Посещений] where [Номер_Записи] = {MassivNomerRecords[i]}";

                TextBlock label_Diagnoz = new TextBlock
                {
                    Text = "Поставленный диагноз:",
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

                TextBlock Diagnoz = new TextBlock
                {
                    Text = (string)SqlCommand.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(20, 172, 0, 0),
                    Cursor = Cursors.Hand
                };

                grid.Children.Add(border);
                grid.Children.Add(label_Caption);
                grid.Children.Add(label_FioPac);
                grid.Children.Add(FIO_Pac);
                grid.Children.Add(label_FioPer);
                grid.Children.Add(FIO_Per);
                grid.Children.Add(label_Data);
                grid.Children.Add(Data);
                grid.Children.Add(label_Diagnoz);
                grid.Children.Add(Diagnoz);

                GridStudent.Add(grid);
            }
        }

        private void PanelRecords_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerRecords[PanelRecords.SelectedIndex];
                InfoRecordsWindow infoRecordsWindow = new InfoRecordsWindow(IndexItem);
                infoRecordsWindow.ShowDialog();
                AddRecords();
                PanelRecords.ItemsSource = null;
                PanelRecords.ItemsSource = GridStudent;
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите карточку!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
