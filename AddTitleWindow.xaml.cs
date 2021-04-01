using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SFHelper
{
    /// <summary>
    /// Interaction logic for AddTitleWindow.xaml
    /// </summary>
    public partial class AddTitleWindow : Window
    {
        public AddTitleWindow()
        {
            InitializeComponent();
        }
        public string nameTable = "";

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string nameTitle = textBox.Text;
                if(nameTitle.Length > 0 && nameTable.Length > 0)
                    DataBaseSupport.CreateTitle(nameTable, nameTitle);
                Close();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            textBox.Focus();
        }
    }
}
