using System;

namespace Lab01
{
    public class ReadOperandA : CalculatorState
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

                    if ((character == "0" && calculator.OperandA == "0")
                        || (character == "." && calculator.OperandA.EndsWith(".")))
                    {
                        break;
                    }

                    if (!string.IsNullOrEmpty(calculator.Operation))
                    {
                        calculator.OperandA = character;
                        calculator.OperandB = string.Empty;
                        calculator.Operation = string.Empty;
                        calculator.Result = calculator.OperandA;
                    }
                    else
                    {
                        if (calculator.OperandA == "" && character == ".")
                        {
                            calculator.OperandA = "0.";
                        }
                        else if (calculator.OperandA == "0" && character != ".")
                        {
                            calculator.OperandA = character;
                        }
                        else
                        {
                            calculator.OperandA += character;
                        }

                        calculator.Result = calculator.OperandA;
                    }

                    break;
                case "+":
                case "-":
                case "*":
                case "/":

                    if (!string.IsNullOrEmpty(calculator.Operation))
                    {
                        calculator.OperandB = string.Empty;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(calculator.OperandA))
                        {
                            calculator.OperandA = "0";
                        }
                    }

                    calculator.Operation = character;
                    calculator.State = new ReadOperandB();

                    break;
                case "=":

                    if (!string.IsNullOrEmpty(calculator.Operation))
                    {
                        calculator.Calculate();
                        calculator.OperandA = calculator.Result;
                    }
                    else
                    {
                        calculator.OperandA = string.Empty;
                    }

                    break;
                default:
                    throw new ArgumentException($"Unknown character: {character}");
            }
        }
    }
}
