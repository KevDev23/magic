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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace magic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //For making new character to save
        private void NewCharacter_Click(object sender, RoutedEventArgs e)
        {
            characterCreation creationWin = new characterCreation();
            creationWin.Show();
        }

        //load a character
        private void LoadCharacter_Click(object sender, RoutedEventArgs e)
        {
            //List<CasterModel> test;// = new List<CasterModel>();

            //test = SqliteDataAccess.loadChar();
           
           
        }
    }
}
