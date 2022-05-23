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
        
        private Tuple<Double, Double> GetTupleNums()
        {
            Double.TryParse(TbFirst.Text, out var firstNum);
            Double.TryParse(TbSecond.Text, out var secondNum);
            return new Tuple<Double, Double>(firstNum, secondNum);
        }

        private void ShowResult(string resultText)
        {
            TbResult.Text = $"{resultText} ";
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            ShowResult((f, s) => f + s);
        }


        private void SubtractBtnClick(object sender, RoutedEventArgs e)
        {
            ShowResult((f, s) => f - s);
        }

        private void DivBtnClick(object sender, RoutedEventArgs e)
        {

            var nums = GetTupleNums();
            if (nums.Item2 == 0)
            {
                ShowResult("Devided by Zero");
            }
            else
                ShowResult((f, s) => f / s);
        }

        private void MultBtnClick(object sender, RoutedEventArgs e)
        {

            ShowResult((f, s)=> f * s);
        }

        private void PowBtnClick(object sender, RoutedEventArgs e)
        {
            ShowResult(Math.Pow);
        }

        private void ShowResult(Func<double, double, double> func)
        {

            var nums = GetTupleNums();
            
            ShowResult($"Result: {func(nums.Item1, nums.Item2)} ");
        }

        private void SqrtBtnClick(object sender, RoutedEventArgs e)
        {
            ShowResult((f,s)=>Math.Pow(s, 1/f));
        }
    }
}
