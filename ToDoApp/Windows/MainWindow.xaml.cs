﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Pages;

namespace ToDoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new MainPage());
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.NavigationService.CanGoBack)
            {
                mainFrame.NavigationService.GoBack();
                mainFrame.NavigationService.RemoveBackEntry();
            }
            else
            {
                MessageBox.Show("Нет страниц для возврата.");
            }
        }
    }
}
