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
            InitializeComponent();

            //access caster from here?
            mage = selected;
            mage.determineMaxMP();
            //manaDisplay.Foreground = Color.Blue;
            setMana(mage);
        }

        public static void test(CasterModel mage)
        {
            Debug.WriteLine("mage: " + mage.characterName+" mp: "+mage.mp+" maxMP: "+mage.maxMP);
        }

        //initializes the mana bar(manaDisplay) based on percentage of mag.maxMP
        public void setMana(CasterModel mage)
        {
           
           manaDisplay.Value = ((double)mage.mp / mage.maxMP) * 100;//manabar gives percentage of spell points left
           Debug.WriteLine((double)(mage.mp / mage.maxMP * 100));
        }

        public void decrementMana(int subtract)
        {
            mage.mp -= subtract;
            setMana(mage);
        }

        public void incrementMana(int add)
        {
            mage.mp += add;
            setMana(mage);
        }

        private void cast1_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(2);
        }

        private void cast2_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(3);
        }

        private void cast3_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(5);
        }

        private void cast4_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(6);
        }

        private void cast5_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(7);
        }

        private void cast6_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(9);
        }

        private void cast7_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(10);
        }

        private void cast8_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(11);
        }

        private void cast9_Click(object sender, RoutedEventArgs e)
        {
            decrementMana(13);
        }

       
    }
}
