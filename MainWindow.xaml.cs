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

namespace VICE_CALCULATOR_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Workspace.Text = "0";
            History.Text = "0";
        }

        string view_history = ""; // will be used to show the view history

        // first number and second number are the operators. After pressing equals button
        // the result will become first number and second number will become 0.

        // the str_x will store the input given
        // the f will store the parsed number from str_
        string str_first_number = "0", str_second_number = "0";
        float f_first_number = 0f, f_second_number = 0f;

        bool operational_symbol_added = false;
        string operational_symbol = ""; // stores the type of operation to do

        private void add_number(string input)
        {
            // ===============================================
            // ===============================================
            // adds number to first number
            if (!operational_symbol_added)
            {
                if (str_first_number[0] == '0')
                {
                    str_first_number = input;
                }
                else
                {
                    str_first_number += input;
                }
                f_first_number = float.Parse(str_first_number);
                view_history += input;
                return;
            }
            // ===============================================
            // ===============================================
            // adds number to second number
            if (str_second_number[0] == '0')
            {
                str_second_number = input;
            }
            else
            {
                str_second_number += input;
            }
            f_second_number = float.Parse(str_second_number);
            view_history += input;
        }

        private void add_operational_symbol(string symbol)
        {
            operational_symbol_added = true;
            operational_symbol = symbol;

            view_history += " " + symbol + " " + str_second_number;

            update_view();
        }

        private void update_view(string type = "adding number")
        {
            if (type == "adding number")
            {
                if (!operational_symbol_added)
                    Workspace.Text = str_first_number;
                else
                    Workspace.Text = str_first_number + " " + operational_symbol + " " + str_second_number;
            }
            else // clear all button pressed
            {

            }

            History.Text = view_history;
        }

        private void Digit_one(object sender, RoutedEventArgs e)
        {
            add_number("1");
            update_view();
        }

        private void Digit_two(object sender, RoutedEventArgs e)
        {
            add_number("2");
            update_view();
        }

        private void Digit_three(object sender, RoutedEventArgs e)
        {
            add_number("3");
            update_view();
        }

        private void Digit_four(object sender, RoutedEventArgs e)
        {
            add_number("4");
            update_view();
        }

        private void Digit_five(object sender, RoutedEventArgs e)
        {
            add_number("5");
            update_view();
        }

        private void Digit_six(object sender, RoutedEventArgs e)
        {
            add_number("6");
            update_view();
        }

        private void Digit_seven(object sender, RoutedEventArgs e)
        {
            add_number("7");
            update_view();
        }

        private void Digit_eight(object sender, RoutedEventArgs e)
        {
            add_number("8");
            update_view();
        }

        private void Digit_nine(object sender, RoutedEventArgs e)
        {
            add_number("9");
            update_view();
        }

        private void Digit_cero(object sender, RoutedEventArgs e)
        {
            add_number("0");
            update_view();
        }

        private void Digit_divide(object sender, RoutedEventArgs e)
        {
            add_operational_symbol("/");
        }

        private void Digit_multiply(object sender, RoutedEventArgs e)
        {
            add_operational_symbol("x");
        }

        private void Digit_minus(object sender, RoutedEventArgs e)
        {
            add_operational_symbol("-");
        }

        private void Digit_plus(object sender, RoutedEventArgs e)
        {
            add_operational_symbol("+");
        }

        private void Digit_equals(object sender, RoutedEventArgs e)
        {
            if (!(f_first_number > 0 && f_second_number > 0)) { return; }

            switch (operational_symbol)
            {
                case "+":
                    f_first_number = f_first_number + f_second_number;
                    break;
                case "-":
                    f_first_number = f_first_number - f_second_number;
                    break;
                case "x":
                    f_first_number = f_first_number * f_second_number;
                    break;
                case "/":
                    f_first_number = f_first_number / f_second_number;
                    break;
                default:
                    break;
            }

            str_first_number = "" + f_first_number;
            f_second_number = 0f;
            str_second_number = "0";
            operational_symbol_added = false;

            update_view();
        }

        private void Digit_clear(object sender, RoutedEventArgs e)
        {
            Workspace.Text = "0";
            History.Text = "0";
            f_first_number = 0f;
            f_second_number = 0f;
            str_first_number = "0";
            str_second_number = "0";
            operational_symbol_added = false;
        }
    }
}
