using System;
using Xamarin.Forms;

namespace lab1Calculator
{
    public partial class MainPage : ContentPage
    {
        private string _selectedOperation;

        private double _firstNumber = 0;

        private double _secondNumber = 0;

        private StateCalculator _currentState = StateCalculator.inputFirstNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private bool ChechLength()
        {
            string text = resultLabel.Text;
            text = text.Replace(".", "");
            return text.Length >= 9;
        }

        private double StringToNumber(string str)
        {
            str = str.Replace(".", ",");
            if (double.TryParse(str, out double result))
            {
                return result;
            }
            return 0;
        }

        private void dotButton_Clicked(object sender, EventArgs e)
        {
            if (resultLabel.Text.Contains(".") || ChechLength())
            {
                return;
            }
            resultLabel.Text += ".";
        }

        void numberButton_Clicked(object sender, EventArgs e)
        {
            if(ChechLength())
            {
                return;
            }

            if (_currentState == StateCalculator.inputSecondNumber)
            {
                _currentState = StateCalculator.None;
                resultLabel.Text = "0";
            }

            string number = resultLabel.Text;
            if (number == "0")
            {
                number = "";
            }


            Button btn = (Button)sender;
            number += btn.Text;
            resultLabel.Text = number;
        }

        private void operationButton_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _selectedOperation = btn.Text;
            _firstNumber = StringToNumber(resultLabel.Text);
            _currentState = StateCalculator.inputSecondNumber;
        }

        private void resultButton_Clicked(object sender, EventArgs e)
        {
            if (_currentState == StateCalculator.None)
            {
                _secondNumber = StringToNumber(resultLabel.Text);
            }

            double result = Calculator.Calculate(_firstNumber, _secondNumber, _selectedOperation);
            resultLabel.Text = result.ToString();

            _firstNumber = result;
            _currentState = StateCalculator.inputSecondNumber;
        }

        void otherButton_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double number = StringToNumber(resultLabel.Text);
            double result = Calculator.Calculate(number, btn.Text);
            resultLabel.Text = result.ToString();
        }

        private void clearButton_Clicked(object sender, EventArgs e)
        {
            resultLabel.Text = "0";
            _firstNumber = 0;
            _secondNumber = 0;
            _currentState = StateCalculator.inputFirstNumber;
        }

        private void switchButton_Clicked(object sender, EventArgs e)
        {
            invertButton.IsVisible = !invertButton.IsVisible;
            percentButton.IsVisible = !percentButton.IsVisible;
            divButton.IsVisible = !divButton.IsVisible;
        }
    }
}

