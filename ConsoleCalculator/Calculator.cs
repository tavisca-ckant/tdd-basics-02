using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleCalculator
{
    public class Calculator
    {
        StringBuilder firstNumber = new StringBuilder(string.Empty);
        StringBuilder secondNumber = new StringBuilder(string.Empty);
        StringBuilder answer = new StringBuilder(string.Empty);
        int flag = 0;
        char _operator = 'z';
        List<char> OperatorList = new List<char>() { 'x', 'X', 'c', 'C', 's', 'S', '-', '+', '/', '='};

        public string SendKeyPress(char key)
        {
            if (IsValidKey(key))
            {
                if (IsOperator(key))
                {
                    DoArithmeticCalculation(key);
                }
                else if (key == '.')
                {
                    HandleDecimalAsInput('.');
                }
                else if (key == '0')
                {
                    HandleZeroAsInput('0');
                }
                else
                {
                    WriteOnConsole(key);
                }
            }
            return answer.ToString();
        }
        private bool IsValidKey(char key)
        {
            if (char.IsDigit(key) || IsOperator(key) || key == '.')
                return true;
            else
                return false;
        }
        private bool IsOperator(char key)
        {
            if (OperatorList.Contains(key))
                return true;
            else
                return false;
        }
        private void DoArithmeticCalculation(char key)
        {
            var OperatorList = new List<char>() { '+', '-', '/', 'x', 'X' };
            if (OperatorList.Contains(key))
            {
                DoArithmeticCalculation('=');
                firstNumber.Clear();
                firstNumber.Append(answer.ToString());
                flag = 1;
                _operator = key;
            }
            else
            {
                switch (key)
                {
                    case '=':
                        if (_operator != 'z')
                        {
                            secondNumber.Clear();
                            secondNumber.Append(answer.ToString());
                            PerformCalculation();
                            _operator = 'z';
                            flag = 1;
                        }
                        break;
                    case 's':
                    case 'S':
                        decimal result = decimal.Multiply(-1, decimal.Parse(answer.ToString()));
                        answer.Clear();
                        answer.Append(result.ToString());
                        break;
                    case 'c':
                    case 'C':
                        ClearConsole();
                        break;
                }
            }
        }
        private void PerformCalculation()
        {
            decimal result;
            bool firstCondition = decimal.TryParse(firstNumber.ToString(), out decimal num1);
            bool secondContition = decimal.TryParse(secondNumber.ToString(), out decimal num2);
            if (firstCondition && secondContition)
            {
                result = CalculateResult(num1, num2);
                if (result != decimal.MinValue)
                {
                    answer.Clear();
                    if (decimal.Ceiling(result) - decimal.Floor(result) == 0)
                    {
                        answer.Append(decimal.ToInt32(result).ToString());
                    }
                    else
                        answer.Append(result.ToString());
                }
            }
            else
            {
                answer.Clear();
                answer.Append("-E-");
            }
        }
        private decimal CalculateResult(decimal num1, decimal num2)
        {
            decimal result = decimal.MinValue;
            switch (_operator)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case 'x':
                case 'X':
                    return num1 * num2;
                case '/':
                    try
                    {
                        result = num1 / num2;
                    }
                    catch (DivideByZeroException)
                    {
                        answer.Clear();
                        answer.Append("-E-");
                    }
                    break;
            }
            return result;
        }
        private void ClearConsole()
        {
            _operator = 'z';
            firstNumber.Clear();
            secondNumber.Clear();
            answer.Clear();
            answer.Append('0');
        }
        private void HandleDecimalAsInput(char key)
        {
            if (answer.Length == 0 || answer.ToString().Equals("0"))
            {
                answer.Clear();
                answer.Append("0.");
            }
            else if (answer[answer.Length - 1] != '.')
            {
                WriteOnConsole(key);
            }
        }
        private void HandleZeroAsInput(char key)
        {
            if (answer.Length == 1)
            {
                if (answer[0] == '0')
                    return;
            }
            WriteOnConsole(key);
        }
        private void WriteOnConsole(char key)
        {
            if (flag == 1)
            {
                answer.Clear();
                flag = 0;
            }
            if (answer.ToString().Equals("0"))
                answer.Clear();
            answer.Append(key);
        }    
    }
}
