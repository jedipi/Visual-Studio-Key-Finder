using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using VsKeyFinder.Data;
using WPFLocalizeExtension.Engine;

namespace VsKeyFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _shown;
        public List<Product> Products { get; set; }
        public List<Locale> Locales { get; set; }
        public MainWindow()
        {

            InitializeComponent();


        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {

            var a = Properties.Resources.TxtPrint;
            if (_shown)
                return;

            _shown = true;



            Locales = LocaleData.GetLocales();

            cmbLocale.ItemsSource = Locales;
            cmbLocale.DisplayMemberPath = "Name";
            cmbLocale.SelectedValuePath = "Code";

            var index = 0;
            var currentCulture = CultureInfo.CurrentCulture;
            switch (currentCulture.Name)
            {
                case "zh":
                case "zh-CN":
                case "zh-SG":
                case "zh-Hans":
                    index = 1;
                    break;
                case "zh-HK":
                case "zh-TW":
                case "zh-MO":
                    index = 2;
                    break;
                default:
                    index = 0;
                    break;
            }
            cmbLocale.SelectedIndex = index;
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
                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Visual Studio Key Finder.");
            }
        }

        private string GetString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Visual Studio Key Finder.");
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var locale = cmbLocale.SelectedItem as Locale;

            ChangeLocale(locale);

        }

        private void ChangeLocale(Locale locale)
        {
            LocalizeDictionary.Instance.Culture = new CultureInfo(locale.Code);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale.Code);
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
    }
}
