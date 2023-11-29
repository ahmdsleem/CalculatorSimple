using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorSimple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SelectedOperator selectedOperator;
        double lastNumber, result;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;

            plusMinusButton.Click += PlusMinusButton_Click;
            precentButton.Click += PrecentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLable.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustruction:
                        result = SimpleMath.Sustruction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }
            }
            resultLable.Content = result.ToString();
        }

        private void PrecentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if(double.TryParse(resultLable.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLable.Content = tempNumber.ToString();
            }
        }

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLable.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLable.Content = "0";
            result = 0;
            lastNumber = 0;
        }
        private void OperationButton_Click( object sender, RoutedEventArgs e)
        {
            double newResult;
            if(double.TryParse(resultLable.Content.ToString(), out newResult) )
            {
                resultLable.Content = "0";
            }

            
            if(newResult == 0)
            {
                lastNumber += newResult;
            }
            else
            {
                if (sender == multipleButton)
                {
                    selectedOperator = SelectedOperator.Multiplication;
                    if (lastNumber == 0)
                    {
                        lastNumber = newResult;
                    }
                    else
                    {
                        lastNumber *= newResult;
                    }
                }
                if (sender == DividButton)
                {
                    selectedOperator = SelectedOperator.Division;
                    if (lastNumber == 0)
                    {
                        lastNumber = newResult;
                    }
                    else
                    {
                        lastNumber /= newResult;
                    }
                }
                if (sender == plusButton)
                {
                    selectedOperator = SelectedOperator.Addition;
                    lastNumber += newResult;
                }
                if (sender == MinusButton)
                {
                    selectedOperator = SelectedOperator.Sustruction;
                    lastNumber -= newResult;
                }
            }
            
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLable.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                resultLable.Content += ".";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            //int selectedValue = int.Parse((sender as Button).Content.ToString());

            if(sender == zeroButton) selectedValue = 0;
            if(sender == oneButton) selectedValue = 1;
            if(sender == twoButton) selectedValue = 2;
            if(sender == threeButton) selectedValue = 3;
            if(sender == fourButton) selectedValue = 4;
            if(sender == fiveButton) selectedValue = 5;
            if(sender == sixButton) selectedValue = 6;
            if(sender == sevenButton)   selectedValue = 7;
            if(sender == eightButton) selectedValue = 8;
            if(sender == nineButton) selectedValue = 9;

            if(resultLable.Content.ToString() == "0")
            {
                resultLable.Content = $"{selectedValue}";
            }
            else
            {
                resultLable.Content += $"{selectedValue}";
            }
        }
    }
    public enum SelectedOperator
    {
        Addition,
        Sustruction,
        Multiplication,
        Division
    }
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sustruction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Division(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}