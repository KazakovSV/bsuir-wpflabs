using System;

namespace Lab01
{
    public class Calculator
    {
        public CalculatorState State { get; set; }

        public string OperandA { get; set; }

        public string OperandB { get; set; }

        public string Operation { get; set; }

        public string Result { get; set; }

        public Calculator(CalculatorState state)
        {
            State = state;
            OperandA = string.Empty;
            OperandB = string.Empty;
            Operation = string.Empty;
            Result = string.Empty;
        }

        public void Read(string character)
        {
            State.Read(this, character);
        }

        public void Calculate()
        {
            switch (Operation)
            {
                case "+":
                    Sum();
                    break;

                case "-":
                    Sub();
                    break;

                case "*":
                    Mul();
                    break;

                case "/":
                    Div();
                    break;

                case "pow":
                    Pow();
                    break;

                case "sqrt":
                    Sqrt();
                    break;

                case "sin":
                    Sin();
                    break;

                default:
                    throw new ArgumentException($"Unknown operation {Operation}");
            }
        }

        private void Sum()
        {
            var op1 = GetValueFromString(OperandA);
            var op2 = GetValueFromString(OperandB);

            Result = (op1 + op2).ToString();
        }

        private void Sub()
        {
            var op1 = GetValueFromString(OperandA);
            var op2 = GetValueFromString(OperandB);

            Result = (op1 - op2).ToString();
        }

        private void Mul()
        {
            var op1 = GetValueFromString(OperandA);
            var op2 = GetValueFromString(OperandB);

            Result = (op1 * op2).ToString();
        }

        private void Div()
        {
            var op1 = GetValueFromString(OperandA);
            var op2 = GetValueFromString(OperandB);

            if (op2 == 0)
            {
                Result = "0";
            }
            else
            {
                Result = (op1 / op2).ToString();
            }
        }

        private void Pow()
        {
            var op1 = GetValueFromString(OperandA);
            var op2 = GetValueFromString(OperandB);

            Result = Math.Pow(op1, op2).ToString();
        }

        private void Sqrt()
        {
            var op1 = GetValueFromString(OperandA);

            Result = Math.Sqrt(op1).ToString();
        }

        private void Sin()
        {
            var op1 = GetValueFromString(OperandA);

            Result = Math.Sin(op1).ToString();
        }

        private double GetValueFromString(string source)
        {
            if (double.TryParse(source, out double result))
            {
                return result;
            }

            return 0D;
        }
    }
}
