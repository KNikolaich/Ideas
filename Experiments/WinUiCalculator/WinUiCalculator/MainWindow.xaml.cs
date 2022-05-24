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
        
        /// <summary>
        /// Взятие пары значений из контролов
        /// </summary>
        private Tuple<Double, Double> GetTupleNums()
        {
            Double.TryParse(TbFirst.Text, out var firstNum);
            Double.TryParse(TbSecond.Text, out var secondNum);
            return new Tuple<Double, Double>(firstNum, secondNum);
        }

        /// <summary>
        /// Показ результата в текстовом контроле
        /// </summary>
        /// <param name="resultText"></param>
        private void ShowResult(string resultText)
        {
            TbResult.Text = $"{resultText} ";
        }

        /// <summary>
        /// Сложение
        /// </summary>
        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            CalcResult((f, s) => f + s);
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        private void SubtractBtnClick(object sender, RoutedEventArgs e)
        {
            CalcResult((f, s) => f - s);
        }

        /// <summary>
        /// Деление
        /// </summary>
        private void DivBtnClick(object sender, RoutedEventArgs e)
        {

            var nums = GetTupleNums();
            if (nums.Item2 == 0)
            {
                ShowResult("Devided by Zero");
            }
            else
                CalcResult((f, s) => f / s);
        }

        /// <summary>
        /// Умножение
        /// </summary>
        private void MultBtnClick(object sender, RoutedEventArgs e)
        {

            CalcResult((f, s)=> f * s);
        }

        /// <summary>
        /// Просто возведение в степень
        /// </summary>
        private void PowBtnClick(object sender, RoutedEventArgs e)
        {
            CalcResult(Math.Pow);
        }


        /// <summary>
        /// Взять корень размерности первого числа от второго числа
        /// </summary>
        private void SqrtBtnClick(object sender, RoutedEventArgs e)
        {
            CalcResult((f,s)=>Math.Pow(s, 1/f)); // для того, чтобы взять корень, надо возвести в степень обратно пропорциональную нужному корню
        }

        /// <summary>
        /// Общая функция расчета результата,  принимаем функцию, и делаем с числами из входных полей эту функцию
        /// </summary>
        /// <param name="func"></param>
        private void CalcResult(Func<double, double, double> func)
        {
            var nums = GetTupleNums();
            ShowResult($"Result: {func(nums.Item1, nums.Item2)} ");
        }
    }
}
