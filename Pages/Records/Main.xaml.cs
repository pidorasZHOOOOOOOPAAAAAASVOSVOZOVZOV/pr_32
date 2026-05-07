using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PR_32.Pages.Records
{
    public partial class Main : Page
    {
        public IEnumerable<Classes.Record> items;

        public Main()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            items = Classes.Record.AllRecords();
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