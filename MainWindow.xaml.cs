using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using WpfApp1.Data;
using WpfApp1.Pages.Records;
using WpfApp1.Pages.Manufacturers;
using WpfApp1.Pages.States;
using WpfApp1.Pages.Supplies;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public Pages.Records.Main mainRecords = new Pages.Records.Main();

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(mainRecords);
        }

        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }

        private void OpenRecordList(object sender, RoutedEventArgs e)
        {
            OpenPage(mainRecords);
            mainRecords.LoadData();
        }

        private void OpenRecordAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Records.Add());
        }

        private void ExportRecord(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                Record.ExportToCsv(saveFileDialog.FileName, mainRecords.items);
                MessageBox.Show($"Экспорт завершен: {saveFileDialog.FileName}");
            }
        }

        private void OpenManufacturesList(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Manufacturers.Main());
        }

        private void OpenManufacturesAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Manufacturers.Add());
        }

        private void OpenSupplyList(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Supplies.Main());
        }

        private void OpenSupplyAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Supplies.Add());
        }

        private void OpenStateList(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.States.Main());
        }

        private void OpenStateAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.States.Add());
        }
    }
}