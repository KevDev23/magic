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
        List<CasterModel> roster = new List<CasterModel>();
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
            CasterModel test = new CasterModel();
         
          test = roster[charList.Items.IndexOf(charList.SelectedItem)];

          System.Diagnostics.Debug.WriteLine("selected:"+test.characterName+ " mp:"+test.mp+" level:"+test.level);

            //load new window and pass the character
            //this.close();
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
