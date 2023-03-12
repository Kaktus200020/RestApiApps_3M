﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace RestApiApp_Comic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentNumber = 0;
        private int maxNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
            btnNext.IsEnabled = false;
        }

        

        private async void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber <maxNumber)
            {
                currentNumber++;
                btnPrev.IsEnabled = true;
                await LoadImage(currentNumber);
                if (currentNumber == maxNumber)
                {
                    btnNext.IsEnabled = false;
                }
            }
        }

        private async void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber--;
                btnNext.IsEnabled = true;
                await LoadImage(currentNumber);
                if(currentNumber==1)
                {
                    btnPrev.IsEnabled = false;
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }
        async Task LoadImage(int num=0)
        {
            ComicModel comicModel = await ComicProcessor.LoadComic(num);
            
            if(num<=0)
            {
                currentNumber = comicModel.Num;
                maxNumber = currentNumber;
            }
            
            Uri uri = new Uri(comicModel.Img);
            imageComic.Source = new BitmapImage(uri);
            lbl1.Content = comicModel.Title;
            lbl2.Content = comicModel.Day+"."+ comicModel.Month+"."+ comicModel.Year;
        }

        private async void ButtonRandom_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            currentNumber=random.Next(1,maxNumber+1);
            await LoadImage(currentNumber);
            if (currentNumber == 1)
            {
                btnPrev.IsEnabled = false;
            }
            else if (currentNumber == maxNumber)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = true;
            }
        }

        private async void ButtonInput_Click(object sender, RoutedEventArgs e)
        {
            currentNumber =int.Parse( txtBox.Text);
            await LoadImage(currentNumber);
            if (currentNumber == 1)
            {
                btnPrev.IsEnabled = false;
            }
            else if (currentNumber == maxNumber)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = true;
            }
        }
    }
}
