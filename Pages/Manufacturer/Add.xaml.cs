using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace PR_32.Pages.Manufacturer
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
                Classes.Manufacturer item = new Classes.Manufacturer()
                {
                    Name = tbName.Text,
                    CountryCode = 1,
                    Phone = tbPhone.Text,
                    Mail = tbEmail.Text
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