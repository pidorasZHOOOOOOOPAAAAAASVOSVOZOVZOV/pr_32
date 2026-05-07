using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace PR_32.Pages.Records
{
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Record item = new Classes.Record()
                {
                    Name = tbName.Text,
                    Year = int.Parse(tbYear.Text),
                    Format = 1,
                    Size = 300,
                    IdManufacturer = 1,
                    Price = float.Parse(tbPrice.Text.Replace(".", ",")),
                    IdState = 1,
                    Description = ""
                };
                item.Save();
                MessageBox.Show("Сохранено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.init.OpenPage(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}