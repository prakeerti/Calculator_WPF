using System.Windows;

namespace Calculator_WPF
{
    public class SimpleMath
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Substract(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                MessageBox.Show("Division by zero is not possible", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return number1 / number2;
        }
    }

    
}
