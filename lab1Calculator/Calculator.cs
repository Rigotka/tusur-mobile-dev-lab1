using System;
namespace lab1Calculator
{
    public static class Calculator
    {
        public static double Calculate(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    result = firstNumber / secondNumber;
                    break;
                case "m":
                    result = firstNumber % secondNumber;
                    break;
                case "//":
                    result = firstNumber / secondNumber;
                    result = Math.Truncate(result);
                    break;
            }
            return result;
        }

        public static double Calculate(double number, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+/-":
                    result = number * -1;
                    break;
                case "%":
                    result = number / 100;
                    break;
                case "√":
                    result = Math.Sqrt(number);
                    break;
            }
            return result;
        }
    }
}

