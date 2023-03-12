using RestApiApp_Cartoon.Models;
using System;
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

namespace RestApiApp_Cartoon
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
            CartoonModel model =await LoadCartoon(int.Parse(txtBoxId.Text));
            //lblId.Content = "Id: " + model.Id;
            lblName.Content = "Name: " + model.Name;
            lblLocationName.Content = "Location Name: " + model.Location.Name;
            lblSpecies.Content = "Species: " + model.Species;
            Uri uri = new Uri(model.Image);
            image.Source = new BitmapImage(uri);
        }
        private async Task<CartoonModel> LoadCartoon(int id)
        {
            return await CartoonProcessor.LoadCartoon(id);
        }

        private async void ButtonCount_Click(object sender, RoutedEventArgs e)
        {
            string[] species ={};
            for (int i = 1; i < 827; i++)
            {
                CartoonModel model = await LoadCartoon(i);
                
                if(!species.Contains(model.Species))
                {
                    
                    species=species.Append( model.Species ).ToArray();
                    
                }
                
                
            }
            string ans="";
            for (int i = 0; i < species.Length; i++)
            {
                ans += species[i]+" ";
            }
            lblCount.Content = ans;
        }
    }
}
