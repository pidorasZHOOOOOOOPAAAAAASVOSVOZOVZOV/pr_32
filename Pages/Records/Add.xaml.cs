using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Data;

namespace WpfApp1.Pages.Records
{
    public partial class Add : Page
    {
        private Record _editItem;

        public Add()
        {
            InitializeComponent();
            cbFormat.SelectedIndex = 0;
        }

        public Add(Record item)
        {
            InitializeComponent();
            _editItem = item;
            tbName.Text = item.Name;
            tbYear.Text = item.Year.ToString();
            cbFormat.SelectedIndex = item.Format;
            tbSize.Text = item.Size.ToString();
            tbIdManufacturer.Text = item.IdManufacturer.ToString();
            tbPrice.Text = item.Price.ToString();
            tbIdState.Text = item.IdState.ToString();
            tbDescription.Text = item.Description;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_editItem == null)
                {
                    Record item = new Record()
                    {
                        Name = tbName.Text,
                        Year = int.Parse(tbYear.Text),
                        Format = cbFormat.SelectedIndex,
                        Size = int.Parse(tbSize.Text),
                        IdManufacturer = int.Parse(tbIdManufacturer.Text),
                        Price = float.Parse(tbPrice.Text.Replace(".", ",")),
                        IdState = int.Parse(tbIdState.Text),
                        Description = tbDescription.Text
                    };
                    item.Save();
                }
                else
                {
                    _editItem.Name = tbName.Text;
                    _editItem.Year = int.Parse(tbYear.Text);
                    _editItem.Format = cbFormat.SelectedIndex;
                    _editItem.Size = int.Parse(tbSize.Text);
                    _editItem.IdManufacturer = int.Parse(tbIdManufacturer.Text);
                    _editItem.Price = float.Parse(tbPrice.Text.Replace(".", ","));
                    _editItem.IdState = int.Parse(tbIdState.Text);
                    _editItem.Description = tbDescription.Text;
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