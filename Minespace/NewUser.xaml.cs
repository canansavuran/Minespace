using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Minespace
{
    public partial class NewUser : PhoneApplicationPage
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (login.IsChecked == true)
            {

                Uri Uri2 = new Uri(String.Format("/Login.xaml?Ne=" + "login"), UriKind.Relative);
                NavigationService.Navigate(Uri2);
            }

            else if (create.IsChecked == true)
            {
                Uri Uri2 = new Uri(String.Format("/Login.xaml?Ne=" + "create"), UriKind.Relative);
                NavigationService.Navigate(Uri2);
            }
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}