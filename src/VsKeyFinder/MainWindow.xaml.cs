using System.Collections.Generic;
using System.Windows;
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


    }
}
