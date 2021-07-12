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
using System.Diagnostics;

namespace magic
{

    /// <summary>
    /// Interaction logic for characterCreation.xaml
    /// </summary>
    public partial class characterCreation : Window
    {
        public characterCreation()
        {
            InitializeComponent();
        }

        private void NewCharacter_accept(object sender, RoutedEventArgs e)
        {
            
            CasterModel newCharacter = new CasterModel();

            /*initialize the character's name, level, maxMP, and mp
             *Try catch stops input such as 8.5 and the if statement stops empty string input and anything other than an int between 1-20 from being entered 
             **/
            try 
            {
                if (!(name.Text.Equals(String.Empty)) && checkLevelRange(Int32.Parse(level.Text)))
                {
                    newCharacter.characterName = name.Text;
                    newCharacter.level = Int32.Parse(level.Text);
                    newCharacter.determineMaxMP();
                    newCharacter.mp = newCharacter.maxMP;

                    SqliteDataAccess.saveChar(newCharacter);//write to data base

                    manager sheet = new manager(newCharacter);
                    sheet.Show();
                    this.Close();
                }
                else
                {
                    characterCreationError();
                }
            }
            catch(Exception userin)
            {
                characterCreationError();
            }
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkLevelRange(int givenLevel)
        {
            if (givenLevel >= 1 && givenLevel <= 20)
                return true;

            return false;
        }

        public static void characterCreationError()
        {
            MessageBox.Show("Name was left empty or Character level is not 1-20", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
