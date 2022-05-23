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
            MyWebView.NavigationStarting += EnsureHttps;
        }

        private void EnsureHttps(WebView2 sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {

                MyWebView.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
            else
            {
                addressBar.Text = uri;
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
                Uri targetUri = new Uri(addressBar.Text);
                MyWebView.Source = targetUri;
            }
            catch (FormatException ex)
            {
                MyWebView.NavigateToString(ex.Message);
            }
        }

        private void MyWebView_CoreProcessFailed(WebView2 sender, CoreWebView2ProcessFailedEventArgs args)
        {

            MyWebView.NavigateToString(args.Reason + args.ProcessDescription);
            
        }
    }
}
