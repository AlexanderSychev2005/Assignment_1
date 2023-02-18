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
    
    
