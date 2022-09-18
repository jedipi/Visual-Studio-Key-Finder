using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace VsKeyFinder
{
    /// <summary>
    /// Interaction logic for AboutWIndow.xaml
    /// </summary>
    public partial class AboutWIndow : Window
    {
        private DateTime _updated = new DateTime(2022, 9, 18);
        public AboutWIndow()
        {
            InitializeComponent();

        }

        private void EllipseClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            lblVersion.Content = $"Version: {version}";
            lblUpdated.Content = $"Last Updated: {_updated.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern)}";
        }
    }
}
