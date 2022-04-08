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

namespace BDDvsTDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Product product = new("Tomate", 1.5f, 2);

            List<Product> products = new(0);
            for (int i = 0; i < 10; i++)
            {
                products.Add(product);
            }

            dgProducts.ItemsSource = products;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
