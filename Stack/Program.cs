using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Stack
{
    internal class Program
    {
        static bool checkBalance(string expression)
        {
            string opensymbol = "({[";
            string closesymbol = ")}]";
            string symbol = opensymbol + closesymbol;
            Stack<char> stack = new Stack<char>();
            for (int i = 0, n = expression.Length; i < n; i++)
            {
                if (symbol.IndexOf(expression[i]) < 0)
                {
                    continue;
                }

                if (opensymbol.IndexOf(expression[i]) >= 0)
                {
                    stack.Push(expression[i]);
                }
                if (closesymbol.IndexOf(expression[i]) >= 0)
                {
                    if (stack.Count <= 0)
                    {
                        return false;
                    }
                    int vt1 = opensymbol.IndexOf(stack.Peek());
                    int vt2 = closesymbol.IndexOf(expression[i]);
                    if (vt1 == vt2)
                    {
                        stack.Pop();
                    }
                    else return false;
                }
            }
            if (stack.Count > 0) return false;
            return true;
        }
        static string InfixToPostfix(string expression)
        {
            string Postfix = "";
            Stack<char> stack = new Stack<char>();
            string operants = "0123456789", Operators = "+-*/";
            int[] priority = { 1, 1, 2, 2 };
            stack.Push('(');
            for (int i = 0, n = expression.Length; i < n; i++)
            {
                char c = expression[i];
                if (c == ' ') continue;
                if (operants.IndexOf(c) >= 0)
                {
                    Postfix += c;
                }
                else if (c == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        Postfix += stack.Pop();
                    }
                    stack.Pop();
                    // break;
                }
                else
                {
                    if (Operators.IndexOf(c) >= 0)
                        while (stack.Count > 0 && stack.Peek() != '(' &&
                            priority[Operators.IndexOf(stack.Peek())] >= priority[Operators.IndexOf(c)])
                        {
                            Postfix += stack.Pop();
                            
                        }
                    stack.Push(c);
                }
            }
            while (stack.Count > 1)
            {
                Postfix += stack.Pop();
            }
            return Postfix;
        }
        static int perform(char operate, int operant1, int operant2)
        {
            int rv = 0;
            switch (operate)
            {
                case '+':
                    {
                        rv = operant1 + operant2;
                        break;
                    }
                case '-':
                    {
                        rv = operant1 -operant2;
                        break;
                    }
                case '*':
                    {
                        rv = operant1 * operant2;
                        break;
                    }
                case '/':
                    {
                        rv = operant1 / operant2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return rv;
        }
        static int EvaluatePostfix(string postfix)
        {
            string operants = "0123456789", Operators = "+-*/";
            string[] ass = { "ADD", "SUB", "MUL", "DIV" };
            Stack<int> stack = new Stack<int>();
            int rv = 0, a, b;
            for (int i = 0, n = postfix.Length; i < n; i++)
            {
                char c= postfix[i];
                if (operants.IndexOf(c) >=0)
                {
                    stack.Push(c-'0');
                }
                if (Operators.IndexOf(c) >= 0)
                {
                    b= stack.Pop();
                    a= stack.Pop();
                    Console.WriteLine("{0} {1}  {2}", ass[Operators.IndexOf(c)],a,b);
                    rv=perform(c,a,b);
                    stack.Push(rv);
                }
            }
            rv = stack.Pop();
            return rv;
        }

        static int EvaluateInfix(string infix)
        {
            
            if(!checkBalance(infix))
            {
                return -1;
            }
            string postfix=InfixToPostfix(infix);
            return EvaluatePostfix(postfix);
        }

        static void Main(string[] args)
        {
            //string expression = "(a+b)+[v+k(g+h)]";
            //Console.WriteLine((checkBalance(expression)?"Balance":"Not balance"));

            string exp = "(1-3+5+1)";

            Console.WriteLine("ket qua:{0}",EvaluateInfix(exp));
            //string s= InfixToPostfix(exp);
            //Console.WriteLine((checkBalance(exp) ?s : ""));

            //Console.WriteLine("Ket qua {0}",EvaluatePostfix(s));
        }
    }
}
