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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Units { feet, meters };

        double width;
        double length;
        double square;

        Units _units;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            TextBox_Length.Focus();


        }

        private void Button_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Button_ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            string cost = ComboBox_Cost.SelectionBoxItem as string;
            bool hardwood = false;
            double answer;
            Label_FeedbackMessageLength.Content = "";
            Label_FeedbackMessageWidth.Content = "";
            if (NumValid(out string userFeedback))
            {
                
                width = Convert.ToDouble(TextBox_Width.Text);
                length = Convert.ToDouble(TextBox_Length.Text);

                square = width * length;

                switch (cost)
                {
                    case "Hardwood Flooring":
                        hardwood = true;
                        break;
                    case "Carpeting":
                        hardwood = false;
                        break;
                }
                if ((bool)RadioButton_Feet.IsChecked)
                {
                    if (hardwood)
                    {
                        answer = square * 17;
                        TextBox_Calculate.Text = "$" + answer.ToString();
                    }
                    else
                    {
                        answer = square * 6;
                        TextBox_Calculate.Text = "$" + answer.ToString();
                    }

                }
                else if ((bool)RadioButton_Meters.IsChecked)
                {
                    if (hardwood)
                    {
                        answer = square * 51;
                        TextBox_Calculate.Text = "$" + answer.ToString();
                    }
                    else
                    {
                        answer = square * 18;
                        TextBox_Calculate.Text = "$" + answer.ToString();
                    }
                }
                
            }
            else
            {
                Label_FeedbackMessageLength.Content = "Enter a Valid Number for Length";
                Label_FeedbackMessageWidth.Content = "Enter a Valid Number for Width";
            }
        }

        private bool NumValid(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            if (!double.TryParse(TextBox_Length.Text, out double tempLength))
            {
                validInputs = false;
            }
            if (!double.TryParse(TextBox_Width.Text, out double tempWidth))
            {
                validInputs = false;
            }
            return validInputs;
        }

        private void RadioButton_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateUnits();
            }
        }
        private void UpdateUnits()
        {
        }


    }
}

