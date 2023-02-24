using System;
using System.Collections.Generic;

namespace Kse.Algorithms.Samples
{
    public class Stack
    {
        private const int Capacity = 50;
        private string[] _array = new string[Capacity];
        private int _pointer;

        public void Push(string value)
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("Stack overflowed");
            }

            _array[_pointer] = value;
            _pointer++;
        }

        public string Pull()
        {
            if (_pointer == 0)
            {
                return null;
            }

            var value = _array[_pointer - 1];
            _pointer--;
            return value;
        }
    }

    public class Calculator
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            // Tokenize the input
            var d = "";
            var result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var x = input[i];
                if (Char.IsDigit(x))
                {
                    d += x;
                }
                else
                {
                    if (!(x == ' '))
                    {
                        if (d.Length > 0)
                        {
                            result.Add(d);
                            d = "";
                        }

                        if (x == 't' && input.Length > i + 2 && input[i + 1] == 'a' && input[i + 2] == 'n')
                        {
                            result.Add("tan");
                            i += 2;
                        }
                        else
                        {
                            result.Add(x.ToString());
                        }
                    }
                }
            }

            if (d.Length > 0)
            {
                result.Add(d);
            }

                if (d.Length > 0)
                {
                    result.Add(d);
                }

                // Convert from infix to postfix notation
                var output = new List<string>();
                var stack = new Stack();
                foreach (var token in result)
                {
                    if (int.TryParse(token, out _))
                    {
                        output.Add(token);
                    }
                    else if (token == "tan") // добавляем оператор "tan"
                    {
                        while (stack.Pull() is string top && (top == "+" || top == "-" || top == "*" || top == "/"))
                        {
                            output.Add(top);
                        }

                        stack.Push(token);
                    }
                    else if (token == "+" || token == "-")
                    {
                        while (stack.Pull() is string top && (top == "+" || top == "-" || top == "*" || top == "/"))
                        {
                            output.Add(top);
                        }

                        stack.Push(token);
                    }
                    else if (token == "*" || token == "/")
                    {
                        while (stack.Pull() is string top && (top == "*" || top == "/"))
                        {
                            output.Add(top);
                        }

                        stack.Push(token);
                    }
                    else if (token == "(")
                    {
                        stack.Push(token);
                    }
                    else if (token == ")")
                    {
                        while (stack.Pull() is string top && top != "(")
                        {
                            output.Add(top);
                        }
                    }

                    else
                    {
                        throw new Exception("Invalid token: " + token);
                    }
                }

                while (stack.Pull() is string top)
                {
                    if (top == "(")
                    {
                        throw new Exception("Mismatched parentheses");
                    }

                    output.Add(top);
                }

                // Evaluate the expression
                stack = new Stack();
                foreach (var token in output)
                {
                    if (int.TryParse(token, out int number))
                    {
                        stack.Push(number.ToString());
                    }
                    else if (token == "+")
                    {
                        var a = int.Parse(stack.Pull());
                        var b = int.Parse(stack.Pull());
                        stack.Push((a + b).ToString());
                    }
                    else if (token == "-")
                    {
                        var a = int.Parse(stack.Pull());
                        var b = int.Parse(stack.Pull());
                        stack.Push((b - a).ToString());
                    }
                    else if (token == "*")
                    {
                        var a = int.Parse(stack.Pull());
                        var b = int.Parse(stack.Pull());
                        stack.Push((a * b).ToString());
                    }
                    else if (token == "/")
                    {
                        var a = int.Parse(stack.Pull());
                        var b = int.Parse(stack.Pull());
                        stack.Push((a / b).ToString());
                    }
                    else if (token == "tan")
                    {
                        var a = double.Parse(stack.Pull());
                        var angleInRadians = a * Math.PI / 180;
                        var tan = Math.Tan(angleInRadians);
                        stack.Push(tan.ToString());
                    }
                }

                Console.WriteLine(stack.Pull());

            }
        }
    }

