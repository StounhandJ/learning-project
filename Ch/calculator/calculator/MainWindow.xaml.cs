using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string example = "";

        private double number;
        private double numberPast;
        private bool ready = true;
        private bool afterPoint;
        private bool localAction;
        private string originNumber = "";
        public string visibleExample = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void restart(bool localAction=false,bool all = false)
        {
            if (!ready)
            {
                visibleExample = all?"":localAction?"":number.ToString();
                example = all?"":localAction?"":number.ToString();
                number = localAction?number:0;
                ready = true;
                afterPoint = false;
                originNumber = "";
                LabelExample.Content = visibleExample;
            }
        }

        private void display()
        {
            LabelNumber.Content = number!=0?number.ToString():"";
            LabelExample.Content = visibleExample.Replace(',', '.')+originNumber;
        }

        private double rounding(double num)
        {
            number = Math.Round(num, 5);
            return number;
        }

        private void Erase_OnClick(object sender, RoutedEventArgs e)
        {
            restart(true);
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                if (tb.IsFocused)
                {
                    switch (tb.Uid)
                    {
                        case "⌫":
                            if (!localAction)
                            {
                                string cloneNumber = number.ToString();
                                double.TryParse(cloneNumber.Substring(0,cloneNumber.Length-1), out number);
                            }
                            break;
                        case "C":
                            ready = false;
                            restart(all:true);
                            break;
                        case "CE":
                            number = 0;
                            originNumber = "";
                            break;
                    }
                }
            }

            display();
        }

        private void LocalAction_OnClick(object sender, RoutedEventArgs e)
        {
            restart(true);
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                if (tb.IsFocused)
                {
                    switch (tb.Uid)
                    {
                        case "root":
                            originNumber = originNumber == "" ? $"√({number})" : $"√({originNumber})";
                            rounding(Math.Sqrt(number));
                            break;
                        case "^2":
                            originNumber =originNumber == "" ?  $"({number})²":$"({originNumber})²";
                            rounding(number * number);
                            break;
                        case "1/x":
                            originNumber = originNumber == "" ? $"1/({number})" : $"1/({originNumber})";
                            rounding(1/number);
                            break;
                        case "%":
                            rounding(numberPast/100*number);
                            originNumber = number.ToString();
                            break;
                    }
                }
            }
            localAction = true;
            display();
        }

        private void Action_OnClick(object sender, RoutedEventArgs e)
        {
            restart();
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                if (tb.IsFocused)
                {
                    switch (tb.Uid)
                    {
                        case "+/-":
                            number = number * -1;
                            break;
                        case ",":
                            afterPoint = true;
                            break;
                        default:
                            example+=number==0?tb.Uid:number+tb.Uid;
                            visibleExample+=localAction?originNumber+tb.Uid:number==0?tb.Uid:number+tb.Uid;
                            numberPast = number;
                            number = 0;
                            localAction = false;
                            afterPoint = false;
                            break;
                    }
                    display();
                }
            }
            
        }

        private void Number_OnClick(object sender, RoutedEventArgs e)
        {
            restart();
            number = localAction ? 0 : number;
            originNumber = localAction ? "" : originNumber;
            localAction = false;
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                if (tb.IsFocused)
                {
                    if (afterPoint && number.ToString().IndexOf(',')==-1)
                    {
                        double.TryParse($"{number.ToString()},{tb.Uid}",out number);
                    }
                    else
                    {
                        double.TryParse($"{number.ToString()}{tb.Uid}",out number);
                    }
                    LabelNumber.Content = number;
                }
            }
            display();
        }

        private void NumberEqually_OnClick(object sender, RoutedEventArgs e)
        {
            var response = new DataTable().Compute((example + number).Replace(',', '.'), null).ToString();
            visibleExample = $"{visibleExample+number}=".Replace(',', '.');
            double.TryParse(response, out number);
            response = response.Replace(',', '.');
            ready = false;
            localAction = false; //8160/350
            LabelExample.Content = visibleExample;
            double RoundResponse;
            double.TryParse(response.Replace('.', ','), out RoundResponse);
            LabelNumber.Content = Math.Round(RoundResponse, 9);
        }
        
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}