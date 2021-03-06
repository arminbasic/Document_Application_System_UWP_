﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            splitView1.IsPaneOpen = !splitView1.IsPaneOpen;
        }
        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (apply.IsSelected) Frame.Navigate(typeof(ApplyPage1));
            else if (home.IsSelected) Frame.Navigate(typeof(MainPage));
            else if (about.IsSelected) Frame.Navigate(typeof(About));
            else if (contact.IsSelected) Frame.Navigate(typeof(Contact));
            else if (adminn.IsSelected) Frame.Navigate(typeof(AdminMode));
        }

        private void buttonApplyMP_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ApplyPage1));
        }

        private void buttonLearnMoreAbout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void buttonContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Contact));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        { if(Frame.CanGoBack)
            Frame.GoBack();
        }
    }
}
