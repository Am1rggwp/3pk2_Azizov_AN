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

namespace PZ_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var task = PB(500, pbStatus);
            await task;

        }
        public async Task PB(int a, ProgressBar progressBar)
        {
            int с = 1;
            for (int i = 0; i < a; i++)
            {
                с *= a;
                progressBar.Value += a / 100;
                await Task.Delay(TimeSpan.FromSeconds(0.5));

            }
        }//В синхроном режиме, прогресс бар заполняется мнгновенно, рисовать во время запонения нельзя.
         //А в асинхронном режиме, прогресс бар заполняется постепенно, рисовать во время заполнения можно.
        

    }
}
