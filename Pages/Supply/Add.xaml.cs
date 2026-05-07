using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Data;

namespace WpfApp1.Pages.Supply
{
    public partial class Add : Page
    {
        private Supply _editItem;

        public Add()
        {
            InitializeComponent();
            dpDateDelivery.SelectedDate = DateTime.Now;
        }

        public Add(Supply item)
        {
            InitializeComponent();
            _editItem = item;
            tbIdManufacturer.Text = item.IdManufacturer.ToString();
            tbIdRecord.Text = item.IdRecord.ToString();
            dpDateDelivery.SelectedDate = item.DateDelivery;
            tbCount.Text = item.Count.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_editItem == null)
                {
                    Supply item = new Supply()
                    {
                        IdManufacturer = int.Parse(tbIdManufacturer.Text),
                        IdRecord = int.Parse(tbIdRecord.Text),
                        DateDelivery = dpDateDelivery.SelectedDate ?? DateTime.Now,
                        Count = int.Parse(tbCount.Text)
                    };
                    item.Save();
                }
                else
                {
                    _editItem.IdManufacturer = int.Parse(tbIdManufacturer.Text);
                    _editItem.IdRecord = int.Parse(tbIdRecord.Text);
                    _editItem.DateDelivery = dpDateDelivery.SelectedDate ?? DateTime.Now;
                    _editItem.Count = int.Parse(tbCount.Text);
                    _editItem.Update();
                }
                MessageBox.Show("Сохранено!");
                MainWindow.init.OpenPage(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}