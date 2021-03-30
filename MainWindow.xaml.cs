using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace SFHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TablesComboBox.ItemsSource = DataBaseSupport.GetTables();
            TablesComboBox.SelectedIndex = 0;
            //TitelsText.ItemsSource = GetTitles(TablesComboBox.Text);            
        }

        private void TablesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameTable = TablesComboBox.SelectedValue.ToString();
            TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(nameTable);
            TitlesListBox.SelectedIndex = 0;
        }
        private void TitlesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TablesComboBox.ItemsSource = DataBaseSupport.GetTables();
            TextTitle.Text = "";
            if (TitlesListBox.SelectedValue != null)
            {
                string title = TitlesListBox.SelectedValue.ToString();
                TextTitle.Text = DataBaseSupport.records[title];
            }
        }

        private void EditButtonOnOff_Checked(object sender, RoutedEventArgs e)
        {
            TextTitle.IsReadOnly = false;
        }

        private void EditButtonOnOff_Unchecked(object sender, RoutedEventArgs e)
        {
            TextTitle.IsReadOnly = true;
        }

        private void AddTitleButton_Click(object sender, RoutedEventArgs e)
        {
            //AddTitleWindow addTitleWindow = new AddTitleWindow();
            //addTitleWindow.Show();
        }

        private void AddTableButton_Click(object sender, RoutedEventArgs e)
        {
            AddTableWindow addTableWindow = new AddTableWindow();
            addTableWindow.Show();
        }
                
        private void Window_Activated(object sender, EventArgs e)
        {
            TablesComboBox.ItemsSource = DataBaseSupport.GetTables();
            string nameTable = TablesComboBox.SelectedValue.ToString();
            TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(nameTable);
            TitlesListBox.SelectedIndex = 0;
        }
    }
}
