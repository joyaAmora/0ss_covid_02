﻿using app_models;
using BillingManagement.UI.ViewModels;
using System;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public MainView()
        {    
            InitializeComponent();
            DataContext = new MainViewModel();
        }


        private void CustomerNew_Click(object sender, RoutedEventArgs e)
        {
            //Customer temp = new Customer() { Name = "Undefined", LastName = "Undefined" };
            //_vm.Customers.Add(temp);
            //_vm.SelectedCustomer = temp;            
        }

        private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            //int currentIndex = _vm.Customers.IndexOf(_vm.SelectedCustomer);

            //if (currentIndex > 0)
            //    currentIndex--;

            //_vm.Customers.Remove(_vm.SelectedCustomer);

            //lvCustomers.SelectedIndex = currentIndex;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("bouh");
        }
    }
}
