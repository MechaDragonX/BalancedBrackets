using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(isBalanced("[8 / {78 / 13}] * 3"));
            Console.WriteLine(isBalanced("45(4^2 + 5)^2"));
            Console.WriteLine(isBalanced("3+[6(11+1-4)]/8"));
            Console.WriteLine(isBalanced("(()>[}"));
            Console.ReadKey();
        }
        private static bool isBalanced(string expression)
        {
            string onlyBrackets = removeNonBrackets(expression);
            Stack<char> front = new Stack<char>();
            Stack<char> back = new Stack<char>();
            if(onlyBrackets.Length % 2 == 0)
            {
                for(int i = 0; i < onlyBrackets.Length / 2; i++)
                {
                    front.Push(onlyBrackets[i]);
                }
                for(int i = onlyBrackets.Length - 1; i > ((onlyBrackets.Length / 2) - 1); i--)
                {
                    back.Push(onlyBrackets[i]);
                }
            }
            else return false;

            char currentF;
            char currentB;
            while(front.Count != 0 && back.Count != 0)
            {
                currentF = front.Pop();
                currentB = back.Pop();
                switch(currentF)
                {
                    case '\x0028':
                        if(currentB != '\x0029') return false;
                        break;
                    case '\x003C':
                        if (currentB != '\x003E') return false;
                        break;
                    case '\x005B':
                        if (currentB != '\x005D') return false;
                        break;
                    case '\x007B':
                        if (currentB != '\x007D') return false;
                        break;
                }
            }

            return true;
        }
        private static string removeNonBrackets(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if ( // If not a bracket character
                    !(expression[i] == '\x0028' || // (
                      expression[i] == '\x0029' || // )
                      expression[i] == '\x003C' || // <
                      expression[i] == '\x003E' || // >
                      expression[i] == '\x005B' || // [
                      expression[i] == '\x005D' || // ]
                      expression[i] == '\x007B' || // {
                      expression[i] == '\x007D')   // }
                )
                {
                    expression = expression.Remove(i, 1);
                    i--;
                }
            }
            return expression;
        }
    }
}
