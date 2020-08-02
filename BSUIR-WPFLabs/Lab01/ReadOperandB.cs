using System;

namespace Lab01
{
    public class ReadOperandB : CalculatorState
    {
        protected override void ChangeState(Calculator calculator, string character)
        {
            switch (character)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ".":

                    if ((character == "0" && calculator.OperandB == "0")
                        || (character == "." && calculator.OperandB.EndsWith(".")))
                    {
                        return;
                    }

                    if (calculator.OperandB == "" && character == ".")
                    {
                        calculator.OperandB = "0.";
                    }
                    else if (calculator.OperandB == "0" && character != ".")
                    {
                        calculator.OperandB = character;
                    }
                    else if (calculator.OperandB == "-0" && character != ".")
                    {
                        calculator.OperandB = $"-{character}";
                    }
                    else
                    {
                        calculator.OperandB += character;
                    }

                    calculator.Result = calculator.OperandB;

                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                case "pow":

                    if (string.IsNullOrEmpty(calculator.OperandB))
                    {
                        calculator.OperandB = "0";
                    }

                    calculator.Calculate();
                    calculator.OperandA = calculator.Result;
                    calculator.OperandB = string.Empty;
                    calculator.Operation = character;

                    break;
                case "=":

                    if (string.IsNullOrEmpty(calculator.OperandB))
                    {
                        calculator.OperandB = "0";
                    }

                    calculator.Calculate();
                    calculator.OperandA = calculator.Result;
                    calculator.State = new ReadOperandA();

                    break;
                case "sqrt":
                    calculator.Operation = character;
                    calculator.Calculate();
                    calculator.OperandA = calculator.Result;
                    calculator.State = new ReadOperandA();

                    break;
                case "sign":

                    if (string.IsNullOrEmpty(calculator.OperandB))
                    {
                        calculator.OperandB = "-0";
                    }
                    else if (calculator.OperandB.StartsWith("-"))
                    {
                        calculator.OperandB = calculator.OperandB.Remove(0, 1);
                    }
                    else
                    {
                        calculator.OperandB = calculator.OperandB.Insert(0, "-");
                    }

                    calculator.Result = calculator.OperandB;

                    break;
                case "sin":

                    break;
                default:
                    throw new ArgumentException($"Unknown character: {character}");
            }
        }
    }
}