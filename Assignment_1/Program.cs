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
            var b = "";
            var result = new List<string>();
            foreach (var x in input)
            {
                if (Char.IsDigit(x))
                {
                    b += x;
                }
                else
                { 
                    if (! (x == ' '))
                    {
                        if (b.Length > 0)
                        {
                            result.Add(b);
                            b = "";
                        }
                        result.Add(x.ToString());
                    }
                }
            }

            if (b.Length > 0)
            {
                result.Add(b);
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
                    var b =
