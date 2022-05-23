using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ABI.Windows.Devices.HumanInterfaceDevice;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiCalculator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        
        private Tuple<decimal, decimal> GetTupleNums(out decimal secondNum)
        {
            Decimal.TryParse(TbFirst.Text, out var firstNum);
            Decimal.TryParse(TbSecond.Text, out secondNum);
            return new Tuple<decimal, decimal>(firstNum, secondNum);
        }
        private void ShowResult(decimal resultText)
        {
            ShowResult($"Result: {resultText} ");
        }
        private void ShowResult(string resultText)
        {
            TbResult.Text = $"{resultText} ";
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            var nums = GetTupleNums(out var secondNum);

            ShowResult(nums.Item1 + nums.Item2);
        }


        private void SubtractBtnClick(object sender, RoutedEventArgs e)
        {

            var nums = GetTupleNums(out var secondNum);

            ShowResult(nums.Item1 - nums.Item2);
        }

        private void DivBtnClick(object sender, RoutedEventArgs e)
        {

            var nums = GetTupleNums(out var secondNum);
            if (nums.Item2 == 0)
            {
                ShowResult("Devided by Zero");
            }
            else
                ShowResult(nums.Item1 / nums.Item2);
        }

        private void MultBtnClick(object sender, RoutedEventArgs e)
        {

            var nums = GetTupleNums(out var secondNum);

            ShowResult(nums.Item1 * nums.Item2);
        }
    }
}
