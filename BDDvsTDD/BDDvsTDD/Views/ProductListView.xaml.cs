using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BDDvsTDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductListModel _model;
        private float _totalSum;

        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();

            _model = new ProductListModel();

            UpdateUi();
        }

        private void onAddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var name = addNameInput.Text;
            var price = addPriceInput.Text;
            var amount = addAmountInput.Text;

            if (name != "" && price != "" && amount != "")
            {
                try
                {
                    _model.AddEntry(
                        name,
                        float.Parse(price),
                        float.Parse(amount)
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

                UpdateUi();
            }
        }

        private void onDeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product prod = ((FrameworkElement)sender).DataContext as Product;

            MessageBoxResult result = MessageBox.Show("Wirklich löschen?", "Löschen bestätigen", MessageBoxButton.OKCancel,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                _model.RemoveEntry(prod.Uuid);
                UpdateUi();
            }
        }

        private void onExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UpdateUi()
        {
            dgProducts.ItemsSource = _model.GetEntries();

            _totalSum = 0;
            foreach (var entry in _model.GetEntries())
            {
                _totalSum += entry.Price;
            }

            totalSum.Text = _totalSum.ToString();
        }

        private void onWindowClosing(object sender, CancelEventArgs e)
        {
            _model.ExportToCsv();
        }
    }
}
