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
           manaDisplay.Value = (mage.mp / mage.maxMP) * 100;//manabar gives percentage of spell points left
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

        
    }
}
