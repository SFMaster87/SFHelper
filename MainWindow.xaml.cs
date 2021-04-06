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
using System.Text.RegularExpressions;

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
            if (TablesComboBox.SelectedValue != null)
            {
                string nameTable = TablesComboBox.SelectedValue.ToString();
                TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(nameTable);
                TitlesListBox.SelectedIndex = 0;
            }
            
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
            PrimenitButton.IsEnabled = true;
        }

        private void EditButtonOnOff_Unchecked(object sender, RoutedEventArgs e)
        {
            TextTitle.IsReadOnly = true;
            PrimenitButton.IsEnabled = false;
        }

        private void AddTitleButton_Click(object sender, RoutedEventArgs e)
        {
            AddTitleWindow addTitleWindow = new AddTitleWindow();
            addTitleWindow.nameTable = TablesComboBox.SelectedValue.ToString();            
            addTitleWindow.Show();
        }

        private void AddTableButton_Click(object sender, RoutedEventArgs e)
        {
            AddTableWindow addTableWindow = new AddTableWindow();
            addTableWindow.Show();
        }
                
        private void Window_Activated(object sender, EventArgs e)
        {
            TablesComboBox.ItemsSource = DataBaseSupport.GetTables();
            if (TablesComboBox.SelectedValue != null)
            {
                string nameTable = TablesComboBox.SelectedValue.ToString();
                if (nameTable.Length > 0)
                {
                    TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(nameTable);
                }
            }
        }

        private void DelTableButton_Click(object sender, RoutedEventArgs e)
        {
            string str = TablesComboBox.Text.ToString();
            DataBaseSupport.DeleteTable(str);
            TablesComboBox.ItemsSource = DataBaseSupport.GetTables();
            if(TablesComboBox.SelectedValue != null) { 
                TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(TablesComboBox.SelectedValue.ToString());
            }
        }

        private void DelTitleButton_Click(object sender, RoutedEventArgs e)
        {
            string query = String.Format("DELETE FROM {0} WHERE NAME='{1}';",
                                        TablesComboBox.SelectedValue.ToString(), 
                                        TitlesListBox.SelectedItem.ToString()); 
            DataBaseSupport.SendQuery(query);
            if (TablesComboBox.SelectedValue != null)
            {
                TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(TablesComboBox.SelectedValue.ToString());
            }
        }

        private void PrimenitButton_Click(object sender, RoutedEventArgs e)
        {
            string query = String.Format("UPDATE {0} SET TitleText='{1}' WHERE NAME='{2}';", 
                    TablesComboBox.SelectedValue.ToString(),
                    TextTitle.Text,
                    TitlesListBox.SelectedItem.ToString());
            DataBaseSupport.SendQuery(query);
            if (TablesComboBox.SelectedValue != null)
            {
                TitlesListBox.ItemsSource = DataBaseSupport.GetTitles(TablesComboBox.SelectedValue.ToString());
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
            Regex regex = new Regex(searchBox.Text, RegexOptions.IgnoreCase);
            foreach (string item in TitlesListBox.Items)
            {
                MatchCollection matches = regex.Matches(item);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        TitlesListBox.SelectedItem = item;
                }
            }            
        }
    }
}
