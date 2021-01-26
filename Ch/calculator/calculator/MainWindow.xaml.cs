using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using org.mariuszgromada.math.mxparser;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private double number;
        private double numberPast;
        private int openBracket;
        private int closeBracket;
        private bool ready = true;
        private bool afterPoint;
        private bool localAction;
        private bool bracket;
        private bool action;
        private bool denial;
        private bool standardCalculator = true;
        private string example = "";
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
                numberPast = number;
                number = localAction?number:0;
                openBracket = 0;
                closeBracket = 0;
                ready = true;
                afterPoint = false;
                action = false;
                bracket = false;
                denial = false;
                originNumber = "";
                LabelExample.Content = visibleExample;
            }
        }

        private int sub(string str)
        {
            var close = 0;
            var open = 0;
            var response = -1;
            for(int i=str.Length-1;i>=0;i--)
            {
                if (str[i] == ')')
                {
                    close += 1;
                }
                else if (str[i] == '(')
                {
                    open += 1;
                }

                if (close==open)
                {
                    response = i;
                    break;
                }
            }

            return response;
        }


        private void display()
        {
            LabelNumber.Content = (denial?"-":"")+(number!=0?number.ToString():"");
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
                            if (!standardCalculator)
                            {
                                tb.Content = "C";
                                tb.Uid = "C";
                            }
                            break;
                    }
                }
            }
            display();
        }

        private void LocalAction_OnClick(object sender, RoutedEventArgs e)
        {
            restart(true);
            number = Double.IsInfinity(number)?0: number != 0 ? number : numberPast;
            action = false;
            var localExample = number.ToString();
            if (bracket)
                {
                    var index = sub(visibleExample);
                    visibleExample = visibleExample.Length!=0?visibleExample.Substring(0,index):"";
                    index = sub(example);
                    localExample = example.Length!=0?example.Substring(index+1,example.Length-index-2):localExample;
                    var eh = "";
                    try 
                    {
                        eh = new Expression((localExample).Replace(',', '.')).calculate().ToString();
                    }
                    catch (Exception exception)
                    {
                        ready = false;
                        restart(all:true);
                        LabelExample.Content = "";
                        LabelNumber.Content = "Ошибка";
                    }
                    double.TryParse(eh,out number);
                    example = example.Length!=0?example.Substring(0,index):"";
                }
            
            bracket = false;
            localAction = true;
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                if (tb.IsFocused)
                {
                    switch (tb.Uid)
                    {
                        case "root":
                            originNumber = originNumber == "" ? $"√({localExample})" : $"√({originNumber})";
                            rounding(Math.Sqrt(number));
                            break;
                        case "^2":
                            originNumber =originNumber == "" ?  $"({localExample})²":$"({originNumber})²";
                            rounding(number * number);
                            break;
                        case "1/x":
                            originNumber = originNumber == "" ? $"1/({localExample})" : $"1/({originNumber})";
                            rounding(1/number);
                            break;
                        case "abs":
                            originNumber = originNumber == "" ? $"|{localExample}|" : $"|{originNumber}|";
                            rounding(Math.Abs(number));
                            break;
                        case "sin":
                            originNumber = originNumber == "" ? $"sin({localExample})" : $"sin({originNumber})";
                            rounding(Math.Sin(number));
                            break;
                        case "cos":
                            originNumber = originNumber == "" ? $"cos({localExample})" : $"cos({originNumber})";
                            rounding(Math.Cos(number));
                            break;
                        case "tg":
                            originNumber = originNumber == "" ? $"tg({localExample})" : $"tg({originNumber})";
                            rounding(Math.Tan(number));
                            break;
                        case "fact":
                            originNumber = originNumber == "" ? $"fact({localExample})" : $"fact({originNumber})";
                            double response = 1;
                            for (int i = 1; i < number+1; i++)
                            {
                                response *= i;
                            }
                            rounding(response);
                            break;
                        case "10^":
                            originNumber = originNumber == "" ? $"10^({localExample})" : $"10^({originNumber})";
                            rounding(Math.Pow(10,number));
                            break;
                        case "log":
                            originNumber = originNumber == "" ? $"log({localExample})" : $"log({originNumber})";
                            rounding(Math.Log10(number));
                            break;
                        case "ln":
                            originNumber = originNumber == "" ? $"ln({localExample})" : $"ln({originNumber})";
                            rounding(Math.Log(number));
                            break;
                        case "%":
                            if (example[example.Length - 1] == '+' || example[example.Length - 1] == '-')
                            {
                                rounding(numberPast / 100 * number);
                            }
                            else
                            {
                                rounding(number / 100);
                            }
                            originNumber = number.ToString();
                            break;
                        case "pi":
                            rounding( Math.PI);
                            localAction = false;
                            break;
                        case "e":
                            rounding( Math.E);
                            localAction = false;
                            break;
                    }
                }
            }
            
            display();
        }

        private void ActionRestart(Button tb)
        {
            example+=number==0?tb.Uid:number+tb.Uid;
            visibleExample+=(denial?"-":"")+(localAction?originNumber+tb.Uid:number==0?tb.Uid:number+tb.Uid);
            numberPast = number!=0?number:numberPast;
            number = 0;
            originNumber = "";
            localAction = false;
            afterPoint = false;
            bracket = false;
            denial = false;
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
                            if (example[example.Length-1]=='+' || example[example.Length-1]=='-' )
                            {
                                example = example.Substring(0,example.Length-1)+(number*-1<0 && example[example.Length-1]=='-'?"+":"-");
                                denial = true;
                            }
                            else
                            { 
                                number = number * -1;
                            }
                            break;
                        case ",":
                            afterPoint = true;
                            break;
                        case "(":
                            if (!bracket && (action || (visibleExample=="" && originNumber=="")))
                            {
                                ActionRestart(tb);
                                openBracket += 1;
                            }
                            break;
                        case ")":
                            if (openBracket != closeBracket)
                            {

                                if (number == 0 && sub(example) == -1)
                                {
                                    example += "0";
                                    visibleExample += "0";
                                }

                                ActionRestart(tb);
                                closeBracket += 1;
                            }
                            bracket = true;
                            break;
                        default:
                            if (action)
                            {
                                example = example.Substring(0,example.Length-1);
                                visibleExample = visibleExample.Substring(0,visibleExample.Length-1);
                            }
                            ActionRestart(tb);
                            action = true;
                            break;
                    }
                    display();
                }
            }
            
        }

        private void Number_OnClick(object sender, RoutedEventArgs e)
        {
            if (bracket)
            {
                return;
            }

            if (!standardCalculator)
            {
                foreach (Button tb in FindVisualChildren<Button>(contol))
                {
                    if (tb.Content == "C")
                    {
                        tb.Content = "CE";
                        tb.Uid = "CE";
                    }
                }

                
            }
            restart(all:true);
            number = localAction ? 0 : number;
            originNumber = localAction ? "" : originNumber;
            localAction = false;
            action = false;
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

        private void ButtonEqually_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ready)
                {
                    return;
                }
                Expression eh = new Expression((example + (bracket?"":number==0?numberPast.ToString():number.ToString())).Replace(',', '.'));
                var response = eh.calculate().ToString();
                //var response = new DataTable().Compute((example + number).Replace(',', '.'), null).ToString();
                visibleExample = $"{visibleExample+(denial?"-":"")+(bracket?"":number==0?numberPast.ToString():number.ToString())}=".Replace(',', '.');
                double.TryParse(response, out number);
                response = response.Replace(',', '.');
                ready = false;
                localAction = false;
                LabelExample.Content = visibleExample;
                double RoundResponse;
                double.TryParse(response.Replace('.', ','), out RoundResponse);
                LabelNumber.Content = Math.Round(RoundResponse, 9);
            }
            catch (Exception exception)
            {
                ready = false;
                restart(all:true);
                LabelExample.Content = "";
                LabelNumber.Content = "Ошибка";
            }
        }

        private void Standard_OnClick(object sender, RoutedEventArgs e)
        {
            Remove();
            CreateStandard();
            standardCalculator = true;
        }
        
        private void Engineering_OnClick(object sender, RoutedEventArgs e)
        {
            Remove();
            CreateEngineering();
            standardCalculator = false;
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            contol.Close();
        }
        public void Remove()
        {
            ready = false;
            restart(all:true);
            display();
            var RowCount = mainGrid.RowDefinitions.Count;
            var ColumnCount = mainGrid.ColumnDefinitions.Count;
            var ButtonList = new List<Button>();
            for (int i = 0; i < RowCount; i++)
            {
                mainGrid.RowDefinitions.RemoveAt(0);
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                mainGrid.ColumnDefinitions.RemoveAt(0);
            }
            foreach (Button tb in FindVisualChildren<Button>(contol))
            {
                ButtonList.Add(tb);
            }
            foreach (var button in ButtonList)
            {
                mainGrid.Children.Remove(button);
            }
        }

        public void CreateStandard()
        {
            var buttonEvents = new Dictionary<string, RoutedEventHandler>()
            {
                {"%", LocalAction_OnClick},
                {"1/x", LocalAction_OnClick},
                {"^2", LocalAction_OnClick},
                {"root", LocalAction_OnClick},
                {"C", Erase_OnClick},
                {"CE", Erase_OnClick},
                {"⌫", Erase_OnClick},
                {"÷", Action_OnClick},
                {"*", Action_OnClick},
                {"-", Action_OnClick},
                {"+", Action_OnClick},
            };
            for (int i = 0; i < 8; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 4; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            Grid.SetRow(LabelExample,0);
            Grid.SetColumn(LabelExample,2);
            Grid.SetColumnSpan(LabelExample,2);
            Grid.SetRow(LabelNumber,1);
            Grid.SetColumn(LabelNumber,2);
            Grid.SetColumnSpan(LabelNumber,2);
            LabelNumber.FontSize = 38;
            
            var ListNumber = new List<Button>();
            ListNumber.Add(new Button(){Content = "+/-",Uid = "+/-"});
            ListNumber.Add(new Button(){Content = "0",Uid = "0"});
            ListNumber.Add(new Button(){Content = ",",Uid = ","});
            ListNumber.Add(new Button(){Content = "1",Uid = "1"});
            ListNumber.Add(new Button(){Content = "2",Uid = "2"});
            ListNumber.Add(new Button(){Content = "3",Uid = "3"});
            ListNumber.Add(new Button(){Content = "4",Uid = "4"});
            ListNumber.Add(new Button(){Content = "5",Uid = "5"});
            ListNumber.Add(new Button(){Content = "6",Uid = "6"});
            ListNumber.Add(new Button(){Content = "7",Uid = "7"});
            ListNumber.Add(new Button(){Content = "8",Uid = "8"});
            ListNumber.Add(new Button(){Content = "9",Uid = "9"});
            
            var column = 0;
            var row = 7;
            foreach (var button in ListNumber)
            {
                Grid.SetRow(button,row);
                Grid.SetColumn(button,column);
                row -= column == 2 ? 1 : 0;
                column = column == 2 ?  0 : column+1;
                button.Margin = new Thickness(1.5);
                button.Background = (Brush)new BrushConverter().ConvertFrom("#ffffff");
                button.FontSize = 20;
                button.Opacity = 0.75;
                if (button.Uid!="+/-")
                {
                    button.Click += Number_OnClick;
                }
                else
                {
                    button.Click += Action_OnClick;
                }
                mainGrid.Children.Add(button);
            }
            var ListButtonAction = new List<Button>();
            ListButtonAction.Add(new Button(){Content = "%",Uid = "%"});
            ListButtonAction.Add(new Button(){Content = "CE",Uid = "CE"});
            ListButtonAction.Add(new Button(){Content = "C",Uid = "C"});
            ListButtonAction.Add(new Button(){Content = "⌫",Uid = "⌫"});
            ListButtonAction.Add(new Button(){Content = "1/x",Uid = "1/x"});
            ListButtonAction.Add(new Button(){Content = "x²",Uid = "^2"});
            ListButtonAction.Add(new Button(){Content = "√",Uid = "root"});
            ListButtonAction.Add(new Button(){Content = "÷",Uid = "÷"});
            ListButtonAction.Add(new Button(){Content = "x",Uid = "*"});
            ListButtonAction.Add(new Button(){Content = "-",Uid = "-"});
            ListButtonAction.Add(new Button(){Content = "+",Uid = "+"});
            column = 0;
            row = 2;
            foreach (var button in ListButtonAction)
            {
                Grid.SetRow(button,row);
                Grid.SetColumn(button,column);
                row += row>=4?1:column == 3 ? 1 : 0;
                column = row>=4?3:column == 3 ?  0 : column+1;
                button.Margin = new Thickness(1.5);
                button.Background = (Brush)new BrushConverter().ConvertFrom("#dedcdc");
                button.FontSize = 20;
                button.Opacity = 0.75;
                button.Click += buttonEvents[button.Uid];
                mainGrid.Children.Add(button);
            }
            Button Equally = new Button(){Content = "=",Uid = "=",FontSize = 20, Opacity = 0.75,
                Margin = new Thickness(1.5),Background = (Brush)new BrushConverter().ConvertFrom("#ffb8c6"),
            };
            Grid.SetRow(Equally,7);
            Grid.SetColumn(Equally,3);
            Equally.Click += ButtonEqually_OnClick;
            mainGrid.Children.Add(Equally);    
        }

        public void CreateEngineering()
        {
            var buttonEvents = new Dictionary<string, RoutedEventHandler>()
            {
                {"sin", LocalAction_OnClick},
                {"pi", LocalAction_OnClick},
                {"e", LocalAction_OnClick},
                {"C", Erase_OnClick},
                {"⌫", Erase_OnClick},
                {"^2", LocalAction_OnClick},
                {"1/x", LocalAction_OnClick},
                {"abs", LocalAction_OnClick},
                {"cos", LocalAction_OnClick},
                {"tg", LocalAction_OnClick},
                {"root", LocalAction_OnClick},
                {"(", Action_OnClick},
                {")", Action_OnClick},
                {"fact", LocalAction_OnClick},
                {"^", Action_OnClick},
                {"10^", LocalAction_OnClick},
                {"log", LocalAction_OnClick},
                {"ln", LocalAction_OnClick},
                {"÷", Action_OnClick},
                {"*", Action_OnClick},
                {"-", Action_OnClick},
                {"+", Action_OnClick},
            };
            for (int i = 0; i < 9; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 5; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            Grid.SetRow(LabelExample,0);
            Grid.SetColumn(LabelExample,2);
            Grid.SetColumnSpan(LabelExample,3);
            Grid.SetRow(LabelNumber,1);
            Grid.SetColumn(LabelNumber,3);
            Grid.SetColumnSpan(LabelNumber,2);
            LabelNumber.FontSize = 25;
            
            var ListNumber = new List<Button>();
            ListNumber.Add(new Button(){Content = "+/-",Uid = "+/-"});
            ListNumber.Add(new Button(){Content = "0",Uid = "0"});
            ListNumber.Add(new Button(){Content = ",",Uid = ","});
            ListNumber.Add(new Button(){Content = "1",Uid = "1"});
            ListNumber.Add(new Button(){Content = "2",Uid = "2"});
            ListNumber.Add(new Button(){Content = "3",Uid = "3"});
            ListNumber.Add(new Button(){Content = "4",Uid = "4"});
            ListNumber.Add(new Button(){Content = "5",Uid = "5"});
            ListNumber.Add(new Button(){Content = "6",Uid = "6"});
            ListNumber.Add(new Button(){Content = "7",Uid = "7"});
            ListNumber.Add(new Button(){Content = "8",Uid = "8"});
            ListNumber.Add(new Button(){Content = "9",Uid = "9"});
            
            var column = 1;
            var row = 8;
            foreach (var button in ListNumber)
            {
                Grid.SetRow(button,row);
                Grid.SetColumn(button,column);
                row -= column == 3 ? 1 : 0;
                column = column == 3 ?  1 : column+1;
                button.Margin = new Thickness(1.5);
                button.Background = (Brush)new BrushConverter().ConvertFrom("#ffffff");
                button.FontSize = 20;
                button.Opacity = 0.75;
                if (button.Uid!="+/-")
                {
                    button.Click += Number_OnClick;
                }
                else
                {
                    button.Click += Action_OnClick;
                }
                mainGrid.Children.Add(button);
            }
            var ListButtonAction = new List<Button>();
            ListButtonAction.Add(new Button(){Content = "sin",Uid = "sin"});
            ListButtonAction.Add(new Button(){Content = "π",Uid = "pi"});
            ListButtonAction.Add(new Button(){Content = "e",Uid = "e"});
            ListButtonAction.Add(new Button(){Content = "C",Uid = "C", Name="buttonErase"});
            ListButtonAction.Add(new Button(){Content = "⌫",Uid = "⌫"});
            ListButtonAction.Add(new Button(){Content = "x²",Uid = "^2"});
            ListButtonAction.Add(new Button(){Content = "1/x",Uid = "1/x"});
            ListButtonAction.Add(new Button(){Content = "|x|",Uid = "abs"});
            ListButtonAction.Add(new Button(){Content = "cos",Uid = "cos"});
            ListButtonAction.Add(new Button(){Content = "tg",Uid = "tg"});
            ListButtonAction.Add(new Button(){Content = "√",Uid = "root"});
            ListButtonAction.Add(new Button(){Content = "(",Uid = "("});
            ListButtonAction.Add(new Button(){Content = ")",Uid = ")"});
            ListButtonAction.Add(new Button(){Content = "x!",Uid = "fact"});
            ListButtonAction.Add(new Button(){Content = "÷",Uid = "÷"});
            ListButtonAction.Add(new Button(){Content = "x^y",Uid = "^"});
            ListButtonAction.Add(new Button(){Content = "x",Uid = "*"});
            ListButtonAction.Add(new Button(){Content = "10^x",Uid = "10^"});
            ListButtonAction.Add(new Button(){Content = "-",Uid = "-"});
            ListButtonAction.Add(new Button(){Content = "log",Uid = "log"});
            ListButtonAction.Add(new Button(){Content = "+",Uid = "+"});
            ListButtonAction.Add(new Button(){Content = "ln",Uid = "ln"});
            column = 0;
            row = 2;
            foreach (var button in ListButtonAction)
            {
                Grid.SetRow(button,row);
                Grid.SetColumn(button,column);
                
                    row += column == 4 ? 1 : 0;
                    column = column == 4 ?  0 : row<5?column+1:4;
                
                button.Margin = new Thickness(1.5);
                button.Background = (Brush)new BrushConverter().ConvertFrom("#dedcdc");
                button.FontSize = 20;
                button.Opacity = 0.75;
                button.Click += buttonEvents[button.Uid];
                mainGrid.Children.Add(button);
            }
            
            Button Equally = new Button(){Content = "=",Uid = "=",FontSize = 20, Opacity = 0.75,
                Margin = new Thickness(1.5),Background = (Brush)new BrushConverter().ConvertFrom("#ffb8c6"),
            };
            Grid.SetRow(Equally,8);
            Grid.SetColumn(Equally,4);
            Equally.Click += ButtonEqually_OnClick;
            mainGrid.Children.Add(Equally);  
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