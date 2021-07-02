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

            //initialize the character's name, level, maxMP, and mp
            if (!(name.Text.Equals(String.Empty)) && checkLevelRange(Int32.Parse(level.Text)))
            {
                newCharacter.characterName = name.Text;
                newCharacter.level = Int32.Parse(level.Text);
                newCharacter.determineMaxMP();
                newCharacter.mp = newCharacter.maxMP;

                Debug.WriteLine("name,level,maxmp " + newCharacter.characterName + " " + newCharacter.level + " " + newCharacter.mp);
            }
            else
            {
                
                MessageBox.Show("Name was left empty or Character level is not 1-20", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            //exiting character creation without making a new character
            this.Close();
        }

        private bool checkLevelRange(int givenLevel)
        {
            if (givenLevel >= 1 && givenLevel <= 20)
                return true;

            return false;
        }
    }
}
