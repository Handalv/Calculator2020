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

namespace Calculator2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsDotWritten = false;

        float Num1, Num2;

        String Operator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void B_Num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TB_Input.Text += button.Content;
        }

        private void B_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDotWritten)
            {
                TB_Input.Text += ",";
                IsDotWritten = true;
            }
        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Input.Text.Length > 0)
            {
                Char lastSymbol = TB_Input.Text.Last();
                if (lastSymbol == '.')
                {
                    IsDotWritten = false;
                }
                TB_Input.Text = TB_Input.Text.Remove(TB_Input.Text.Length - 1);
            }
        }

        private void B_Operator_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == null)
            {
                Button button = (Button)sender;
                Operator = "" + button.Content;

                if (TB_Input.Text != "")
                {
                    Num1 = float.Parse(TB_Input.Text);
                }
                else
                {
                    Num1 = 0;
                }

                TB_Operation.Text = "" + Num1 + Operator;

                TB_Input.Text = null;
                IsDotWritten = false;
            }
            else
            {
                B_Equally_Click(sender, null);
                B_Operator_Click(sender, e);
            }
        }

        private void B_Clear_Click(object sender, RoutedEventArgs e)
        {
            IsDotWritten = false;
            Num1 = 0;
            Num2 = 0;
            Operator = null;
            TB_Input.Text = "";
            TB_Operation.Text = "";
        }

        private void B_ClearInput_Click(object sender, RoutedEventArgs e)
        {
            TB_Input.Text = "";
        }

        private void B_Equally_Click(object sender, RoutedEventArgs e)
        {
            if (Operator != null)
            {
                if (TB_Input.Text != "")
                {
                    Num2 = float.Parse(TB_Input.Text);
                }
                else
                {
                    Num2 = 0;
                }

                TB_Operation.Text += Num2 + "=";

                switch (Operator)
                {
                    case "+":
                        TB_Input.Text = "" + (Num1 + Num2);
                        break;
                    case "-":
                        TB_Input.Text = "" + (Num1 - Num2);
                        break;
                    case "*":
                        TB_Input.Text = "" + (Num1 * Num2);
                        break;
                    case "÷":
                        TB_Input.Text = "" + (Num1 / Num2);
                        break;
                    default:
                        TB_Input.Text = "Operator Error";
                        break;
                }
                Operator = null;
            }
        } 
    }
}
