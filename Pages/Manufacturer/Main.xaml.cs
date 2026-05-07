using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PR_32.Pages.Manufacturer
{
    public partial class Main : Page
    {
        public IEnumerable<Classes.Manufacturer> items;

        public Main()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            items = Classes.Manufacturer.AllManufactures();
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
    }
}