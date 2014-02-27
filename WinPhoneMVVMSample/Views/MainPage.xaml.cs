using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinPhoneMVVMSample.ViewModels;
using System.Windows.Data;

namespace WinPhoneMVVMSample.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new RegisterViewModel();
        }

        private void boundTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            BindingExpression bindingExpression = txtbox.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
        }
    }
}