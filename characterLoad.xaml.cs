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
        List<CasterModel> roster = new List<CasterModel>();//for building list
        MessageBoxResult confirm;
        public characterLoad()
        {
            InitializeComponent();

            //getting charcters from db
            roster = SqliteDataAccess.loadChar();
            for(int i = 0; i < roster.Count; i++)
            {
                charList.Items.Add(roster[i].characterName);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {         

            try
            {
                manager sheet = new manager(roster[charList.Items.IndexOf(charList.SelectedItem)]);
                sheet.Show();
                this.Close();
            }
            catch(Exception loadError)
            {
                MessageBox.Show("Something went wrong, make sure you have clicked a character");
            }

           
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            confirm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(confirm == MessageBoxResult.Yes)
            {
                SqliteDataAccess.deleteChar(roster[charList.Items.IndexOf(charList.SelectedItem)]);
            }
            
        }

        private void backToMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
