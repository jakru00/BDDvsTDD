using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        private readonly ProductListModel _model;
        public MainWindow()
        {
            InitializeComponent();

            _model = new ProductListModel();

            updateEntries();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            var name = addNameInput.Text;
            var price = addPriceInput.Text;
            var amount = addAmountInput.Text;
            if (name != "" && price != "" && amount != "")
            {
                try
                {
                    _model.addEntry(
                        name,
                        float.Parse(price),
                        int.Parse(amount)
                    );
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                addNameInput.Clear();
                addPriceInput.Clear();
                addAmountInput.Clear();

                updateEntries();
            }
        }

        private void deleteProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exportImportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateEntries()
        {
            dgProducts.ItemsSource = _model.getEntries();
        }
    }
}
