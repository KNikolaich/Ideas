using System;
using Windows.System;
using Windows.UI.Popups;
using FirstWinUi.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.Web.WebView2.Core;

namespace FirstWinUi.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = App.GetService<MainViewModel>();
            InitializeComponent();
            webView2.NavigationStarting += EnsureHttps;
            //txtAddress.KeyDown += AddressBar_KeyDown;
        }

        private void AddressBar_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.Enter)
            {
                Navigate();
            }
        }

        private void EnsureHttps(WebView2 sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView2.ExecuteScriptAsync($"alert('{uri} не верный url, - попробуйте использовать префикс https')");
                args.Cancel = true;
            }
            else
            {
                txtAddress.Text = uri;
            }
        }

        private void BtnGoClick(object sender, RoutedEventArgs e)
        {
            Navigate();
        }

        private void Navigate()
        {

            try
            {
                webView2.Source = new Uri(txtAddress.Text);
            }
            catch (FormatException ex)
            {
                webView2.ExecuteScriptAsync($"alert('{ex.Message}')");
            }
        }
        
    }
}
