using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Pro1 calc = new Pro1();
        public MainWindow()
        {
            InitializeComponent();
            if (calc.Ban_Button == false)
            {
                if (calc.Correct_Enter == false)
                {
                    Box.Text = "";
                    calc.Correct_Enter = true;
                }
                Box.PreviewTextInput += new TextCompositionEventHandler(Box_PreviewTextInput);
                //если есть знак "бесконечность" - не даёт писать цифры после него
                if (Box.Text.IndexOf("∞") != -1)
                {
                    Box.Text = Box.Text.Substring(0, Box.Text.Length - 1);
                }
                //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
                if (Box.Text[0] == '0' && (Box.Text.IndexOf(",") != 1) && Box.Text.Length > 1)
                {
                    Box.Text = Box.Text.Remove(0, 1);
                }
                History_Box.Text = Box.Text;
            }
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            if (calc.Ban_Button == false)
            {
                if (calc.Correct_Enter == false)
                {
                    Box.Text = "";
                    calc.Correct_Enter = true;
                }
                Box.Text = Box.Text + (sender as Button).Content;

                //если есть знак "бесконечность" - не даёт писать цифры после него
                if (Box.Text.IndexOf("∞") != -1)
                {
                    Box.Text = Box.Text.Substring(0, Box.Text.Length - 1);
                }
                //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
                if (Box.Text[0] == '0' && (Box.Text.IndexOf(",") != 1) && Box.Text.Length > 1)
                {
                    Box.Text = Box.Text.Remove(0, 1);
                }
                
                calc.History += (sender as Button).Content; 
                History_Box.Text = calc.History;
            }
        }

        private void But_Plus(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Plus();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }

        private void But_Minus(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Minus();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }

        private void But_Ravno(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Ravno();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }
        private void But_Multiply(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Multiply();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }
        private void But_Divide(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Divide();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }

        private void But_Reverse(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Revers();
            Box.Text = calc.Work_String;
        }

        private void But_ChangeSign(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.ChangeSign();
            Box.Text = calc.Work_String;
        }

        private void But_Point(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Point();
            Box.Text = calc.Work_String;
        }

        private void But_Sqrt(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.Sqrt_Two();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }

        private void But_C(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.C();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }
        private void But_CE(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.CE();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }
        private void But_Delete_Last(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.DeleteLastChar();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;
        }

        private void But_MS(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.MSave_Number();
            Memory_Box.Text = "M";
        }
        private void But_MR(object sender, RoutedEventArgs e)
        {
            
            calc.MR();
            Box.Text = calc.Work_String;
            History_Box.Text = calc.History;

        }
        private void But_MC(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.MC();
            Memory_Box.Text = "";
            Box.Text = calc.Work_String;
        }
        private void But_M_Plus(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.MPlus();
        }
        private void But_M_Mimus(object sender, RoutedEventArgs e)
        {
            calc.Work_String = Box.Text;
            calc.MMinus();
        }

        private void Box_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Multiply)
            {
                calc.Work_String = Box.Text;
                calc.Multiply();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Divide)
            {
                calc.Work_String = Box.Text;
                calc.Divide();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Subtract)
            {
                calc.Work_String = Box.Text;
                calc.Minus();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Add)
            {
                calc.Work_String = Box.Text;
                calc.Plus();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Multiply)
            {
                calc.Work_String = Box.Text;
                calc.Multiply();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Divide)
            {
                calc.Work_String = Box.Text;
                calc.Divide();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Subtract)
            {
                calc.Work_String = Box.Text;
                calc.Minus();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }
            if (e.Key == Key.Add)
            {
                calc.Work_String = Box.Text;
                calc.Plus();
                Box.Text = calc.Work_String;
                History_Box.Text = calc.History;
            }

        }
    }
}
