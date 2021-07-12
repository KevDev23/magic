﻿using System;
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
            name.Text = mage.characterName;
            //nameBlock(mage);
        }

        public static void test(CasterModel mage)
        {
            Debug.WriteLine("mage: " + mage.characterName+" mp: "+mage.mp+" maxMP: "+mage.maxMP);
        }

        //initializes the mana bar(manaDisplay) based on percentage of mag.maxMP
        public void setMana(CasterModel mage)
        {
           manaDisplay.Value = ((double)mage.mp / mage.maxMP) * 100;//manabar gives percentage of spell points left
            mp.Text = mage.mp.ToString();
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

        private void nameBlock(CasterModel mage)
        {
            TextBlock name = new TextBlock();
            //name.TextWrapping = TextWrapping.Wrap;
            name.Height = 50;
            name.Width = 200;
            //name.Text = mage.characterName;
            name.Inlines.Add(mage.characterName);
            name.Foreground = new SolidColorBrush(Colors.Red);
            // LayoutRoot.Children.Add(name);
            Debug.WriteLine("nameBlock");
            this.Content = name;
        }
    }
}
