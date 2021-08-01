using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        CasterModel mage = new CasterModel();
        
        public manager(CasterModel selected)
        {
           // Debug.WriteLine("before InitializeComponent: " + (double)(selected.mp / selected.maxMP * 100));

            InitializeComponent();

            mage = selected;
            mage.determineMaxMP();
            updateText(mage);
            setMana(mage);

        }

        //initializes the mana bar(manaDisplay) based on percentage of mag.maxMP and text display
        public void setMana(CasterModel mage)
        {
           manaDisplay.Value = ((double)mage.mp / mage.maxMP) * 100;//manabar gives percentage of spell points left
           updateText(mage);
           Debug.WriteLine("setMana: "+(double)(mage.mp / mage.maxMP * 100));
           Debug.WriteLine("setMana - current MP is " + mage.mp);
           
        }

        public void incrementMana(int add)
        {
            mage.mp += add;
            setMana(mage);
        }

        private void cast1_Click(object sender, RoutedEventArgs e)
        {
            /*On click of any of the buttons used to cast spells the tag of the corresponding button is turned into a string which 
             * is pased to Int32.Parse() so its a int at the end of all that
             */
            mage.mp -= Int32.Parse((string)((Button)sender).Tag);
            setMana(mage);
        }

        private void longRest_Click(object sender, RoutedEventArgs e)
        {
            mage.mp = mage.maxMP;
            setMana(mage);
        }

        private void recover_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(mage.mp < mage.maxMP)
                {
                    incrementMana(Int32.Parse(recoverInput.Text));
                }
                
            }
            catch(Exception recoveryError)
            {
                MessageBox.Show("Please enter a integer","Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void levelup_Click(object sender, RoutedEventArgs e)
        {
            if(mage.level < 20)
                mage.level++;

           mage.determineMaxMP();
           setMana(mage);
           updateText(mage);


        }

        private void leveldown_Click(object sender, RoutedEventArgs e)
        {
            if (mage.level > 1)
                mage.level--;
            mage.determineMaxMP();

            if(mage.mp > mage.maxMP)//if the resource is greater than the max set the resource to the max
            {
                mage.mp = mage.maxMP;
            }

            updateText(mage);
            setMana(mage);

        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("calling saveData mp, maxMP, level: " + mage.mp + " " + mage.maxMP + " " + mage.level);
            SqliteDataAccess.updateChar(mage);
        }

        public void updateText(CasterModel mage)
        {
            name.Text = mage.characterName;
            level.Text = "Level: " + mage.level.ToString();
            mp.Text = mage.mp.ToString() + "/" + mage.maxMP.ToString();
        }
    }
}
