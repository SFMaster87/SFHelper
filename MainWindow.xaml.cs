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
            TablesComboBox.ItemsSource = GetTables();
            TablesComboBox.SelectedIndex = 0;
            //TitelsText.ItemsSource = GetTitles(TablesComboBox.Text);
        }

        private Dictionary<string, string> titlesValue = new Dictionary<string, string>();

        private List<string> GetTables()
        {
            List<string> listTables = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=D:\MyDataBase.db; Version=3;"))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    //CommandText = "SELECT NAME from sqlite_master"
                    CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1"
                };
                using (SQLiteDataReader sqlReader = command.ExecuteReader()) 
                { 
                    while (sqlReader.Read())
                    {
                        string record = (string)sqlReader["NAME"];
                        listTables.Add(record);
                    }
                }
                connect.Close();
                return listTables;
            }
        }
        /*
         CREATE TABLE Python(
                    id INTEGER PRIMARY KEY
                    UNIQUE NOT NULL,
                    Name STRING  UNIQUE NOT NULL,
                    TitleText TEXT);
         */
        private List<string> GetTitles(string table)
        {
            List<string> listNames = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=D:\MyDataBase.db; Version=3;"))
            {
                connect.Open();
                SQLiteCommand command = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = "SELECT * FROM " + table
                };
                using (SQLiteDataReader sqlReader = command.ExecuteReader()) 
                { 
                    while (sqlReader.Read())
                    {
                        string title = sqlReader.GetValue(1).ToString();
                        string titleText = sqlReader.GetValue(2).ToString();
                        titlesValue[title] = titleText;
                        listNames.Add(title);
                    }
                }
                connect.Close();
                return listNames;
            }
        }

        private void TablesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameTable = TablesComboBox.SelectedValue.ToString();
            TitelsText.ItemsSource = GetTitles(nameTable);
            TitelsText.SelectedIndex = 0;
        }
        private void TitelsText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextTitle.Text = "";
            if (TitelsText.SelectedValue != null) 
            { 
                string title = TitelsText.SelectedValue.ToString();
                TextTitle.Text = titlesValue[title];
            }
        }
    }
}
