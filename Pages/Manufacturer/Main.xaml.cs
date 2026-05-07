using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Data;

namespace WpfApp1.Pages.Manufacturers
{
    public partial class Main : Page
    {
        public List<Data.Manufacturer> items;

        public Main()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            items = Data.Manufacturer.GetAll();
            lvItems.ItemsSource = items;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
                lvItems.ItemsSource = items;
            else
                lvItems.ItemsSource = items.Where(x =>
                    x.Name.ToLower().Contains(tbSearch.Text.ToLower()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (lvItems.SelectedItem is Data.Manufacturer selected)
            {
                MainWindow.init.OpenPage(new Add(selected));
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lvItems.SelectedItem is Data.Manufacturer selected)
            {
                if (MessageBox.Show($"Удалить {selected.Name}?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    selected.Delete();
                    LoadData();
                }
            }
        }
    }
}