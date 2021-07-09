using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace magic
{
    /// <summary>
    /// Interaction logic for characterLoad.xaml
    /// </summary>
    public partial class characterLoad : Window
    {
        public characterLoad()
        {
            InitializeComponent();

            List<CasterModel> roster = new List<CasterModel>();

            roster = SqliteDataAccess.loadChar();
           
            for(int i = 0; i < roster.Count; i++)
            {
                charList.Items.Add(roster[i].characterName);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backToMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
