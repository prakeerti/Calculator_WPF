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

namespace Calculator_WPF
{
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }


        #region Equal button handler 
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
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
            }
            resultLable.Content = result.ToString();

        }
        #endregion


        #region percent button handler 
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLable.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if(lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                    resultLable.Content = tempNumber.ToString();

                }
            }
        }
        #endregion

        #region point button handler 
        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLable.Content.ToString().Contains("."))
            {
                //do nothing if there exist a point else you can append a point in the end
            }
            else
            {
                resultLable.Content = $"{resultLable.Content}.";
            }

        }
        #endregion

        #region Negative button handler 
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            double number;
            if (double.TryParse(resultLable.Content.ToString(), out number))
            {
                number = number * (-1);
                resultLable.Content = number.ToString();
            }
        }
        #endregion


        #region AC button handler 
        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLable.Content = "0";
            result = 0;
            lastNumber = 0;
        }
        #endregion


        #region Number buttons handler 
        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            /*int selectedValue=0;

            if(sender== zeroButton)
            {
                selectedValue = 0;
            }
            if(sender== oneButton)
            { 
                selectedValue = 1;
            }if(sender== twoButton)
            {
                selectedValue = 2;
            }
            if(sender== threeButton)
            {

                selectedValue = 3;
            }
            if(sender== fourButton)
            {
                selectedValue = 4;
            }
            if(sender== fiveButton)
            {
                selectedValue = 5;
            }
            if(sender== sixButton)
            {
                selectedValue = 6;
            }
            if(sender== sevenButton)
            {
                selectedValue = 7;
            }
            if (sender== eightButton)
            {
                selectedValue = 8;
            }
            if(sender==nineButton)
            {
                selectedValue = 9;
            }
            
             rather than doing so manu if else operation we can directly use the number inside Button Content
            as the Content is in string we can parse it into int to get it integer value and then assign that integer value to the button clicks*/
            int selectedValue = int.Parse((sender as Button).Content.ToString()); // we make our sender our usable button only and assign value to it
            if (resultLable.Content.ToString() == "0")
            {
                /*resultLable.Content = $"{selectedValue}";*/

                resultLable.Content = selectedValue.ToString();
            }
            else
            {
                resultLable.Content = $"{resultLable.Content}{selectedValue}";
            }
        }

        #endregion

        #region operations button handler   

        private void operationButton_click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(resultLable.Content.ToString(), out lastNumber))
            {
                //lastnumber here is alreadyy assigned so when you click a operation button 
                //the value inside the resultLable should become zero

                resultLable.Content = "0";

                if (sender == multiplyButton)
                {
                    selectedOperator = SelectedOperator.Multiplication;
                }
                if (sender == divideButton)
                {
                    selectedOperator = SelectedOperator.Division;
                }
                if (sender == plusButton)
                {
                    selectedOperator = SelectedOperator.Addition;
                }
                if (sender == minusButton)
                {
                    selectedOperator = SelectedOperator.Substraction;
                }



            }
        }
        #endregion


    }
}
