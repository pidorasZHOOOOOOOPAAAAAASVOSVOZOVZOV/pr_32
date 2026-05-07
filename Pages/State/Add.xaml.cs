using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Data;

namespace WpfApp1.Pages.State
{
    public partial class Add : Page
    {
        private State _editItem;

        public Add()
        {
            InitializeComponent();
        }

        public Add(State item)
        {
            InitializeComponent();
            _editItem = item;
            tbName.Text = item.Name;
            tbSubname.Text = item.Subname;
            tbDescription.Text = item.Description;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_editItem == null)
                {
                    State item = new State()
                    {
                        Name = tbName.Text,
                        Subname = tbSubname.Text,
                        Description = tbDescription.Text
                    };
                    item.Save();
                }
                else
                {
                    _editItem.Name = tbName.Text;
                    _editItem.Subname = tbSubname.Text;
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