using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace VsKeyFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _shown;
        public List<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            if (_shown)
                return;

            _shown = true;

            Products = new List<Product>();
            var productData = ProductData.GetProducts();
            var keyFinder = new KeyFinder();
            foreach (var product in productData)
            {
                var key = keyFinder.FindKey(product);
                if (!string.IsNullOrEmpty(key))
                {
                    product.Key = key;
                    Products.Add(product);
                }
            }
            datagrid.ItemsSource = Products;

        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = datagrid.SelectedItem as Product;

            if (selectedProduct != null)
                Clipboard.SetText(selectedProduct.Key);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void EllipseMax_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void EllipseMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void EllipseClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                EllipseMax_MouseDown(this, null);
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWIndow();
            aboutWindow.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() != true)
                return;

            try
            {
                File.WriteAllText(saveFileDialog.FileName, GetString());
                MessageBox.Show("File saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            printDialog.PageRangeSelection = PageRangeSelection.AllPages;
            printDialog.UserPageRangeEnabled = false;
            if (printDialog.ShowDialog() == true)
            {
                var doc = new FlowDocument();

                doc.ColumnWidth = printDialog.PrintableAreaWidth;
                doc.Blocks.Add(new Paragraph(new Run(GetString())));
                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Visual Studil Key Finder.");
            }
        }

        private string GetString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Visual Studil Key Finder.");
            builder.AppendLine($"------------------------");
            builder.AppendLine(Environment.NewLine);

            foreach (var item in Products)
            {
                builder.AppendLine(item.Name);
                builder.AppendLine(item.Key);
                builder.AppendLine(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
