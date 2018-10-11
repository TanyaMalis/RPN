using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Stroka
    {
        string start;
        List<string> sortedString = new List<string>();
        double result;

        public string Start
        {
            set { start = value; }
        } 

        public double Result
        {
            get { return result; }
        }

        public Stroka(string s)
        {
            start = s;
        }

        /// <summary>
        /// Приоритет оператора
        /// </summary>
        /// <param оператор="s"></param>
        /// <returns></returns>
        private byte Priority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }

        }

        /// <summary>
        /// Метод получающий строку
        /// </summary>
        public List<string> OutString()
        {
            string output = "";
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < start.Length; i++)
            {
                // Если символ - цифра
                if (Char.IsDigit(start[i]))
                {
                    // считываем все число, если в нем больше, чем один разряд
                    while (Char.IsDigit(start[i]))
                    {
                        output += start[i];
                        i++;

                        if (i == start.Length) break;
                    }
                    // Записываем в выходную строку
                    sortedString.Add(output);
                    output = "";
                    i--;
                }

                // Если символ - оператор
                else
                {
                    // Если символ - открывающая скобка
                    if (start[i] == '(')
                        operStack.Push(start[i]); // записываем в стек
                    // Если - закрывающая
                    else if (start[i] == ')')
                    {
                        char s = operStack.Pop();
                        // достаем все операторы из стека до открывающей скобки
                        while (s != '(')
                        {
                            sortedString.Add(s.ToString());
                            s = operStack.Pop();
                        }
                    }
                    // Если другой оператор
                    else
                    {
                        if (operStack.Count > 0)
                            // если приоритет текущего оператора меньше или равен, добавляем его в строку
                            if (Priority(start[i]) <= Priority(operStack.Peek()))
                                sortedString.Add(operStack.Pop().ToString());
                        // добавляем операторов на вершину стека
                        operStack.Push(char.Parse(start[i].ToString()));
                    }

                }
                
            }

            while (operStack.Count > 0)
                sortedString.Add(operStack.Pop().ToString());

            return sortedString;
        }

        /// <summary>
        /// Метод, высчитывающий строку
        /// </summary>
        public double Calculate()
        {
            double rslt = 0;
            Stack<double> tmp = new Stack<double>();

            for (int i = 0; i < sortedString.Count; i++)
            {
                // Если элемент - число
                if (sortedString[i].All(char.IsDigit))
                {
                    tmp.Push(double.Parse(sortedString[i])); // добавяем в стек
                }
                // Если - оператор
                else
                {
                    double a = tmp.Pop(); 
                    double b = tmp.Pop();

                    char[] oper = sortedString[i].ToCharArray(); // выполянем действие
                    switch (oper[0])
                    {
                        case '+': rslt = b + a; break;
                        case '-': rslt = b - a; break;
                        case '*': rslt = b * a; break;
                        case '/': rslt = b / a; break;
                        case '^': rslt = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    tmp.Push(rslt);
                }
            }
           return result = tmp.Peek();
        }
    }
}
