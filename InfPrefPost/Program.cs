using System;
using System.Text;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        InfijoAPrefijo("8+9");
        InfijoAPrefijo("3*(4+5)");
        InfijoAPrefijo("3*(4+5)");
        InfijoAPrefijo("3-4+5");
        InfijoAPrefijo("3*(2+1*5)+6");
        InfijoAPrefijo("(1+2)+(5-3)");
        Console.ReadKey();
    }

    //Time Complexity: O(n) Space Complexity: O(n)
    public static void InfijoAPrefijo(string ExpresionInfija)
    {

        if (ExpresionInfija == null || ExpresionInfija.Length == 0)
            return;

        Console.WriteLine("");
        Console.WriteLine("Expresión Infija = {0}", ExpresionInfija);

        string CadenaVolteadaInfija = VoltearCadena(ExpresionInfija);
        Console.WriteLine("Expresión Infija Volteada = {0}", CadenaVolteadaInfija);
        string CadenaPostFijaVolteada = InfijaAPostFijaVolteada(CadenaVolteadaInfija);
        Console.WriteLine("Expresión PostFijaVolteada = {0}", CadenaPostFijaVolteada);
        string preFixStr = VoltearCadena(CadenaPostFijaVolteada);

        Console.WriteLine("Expresión Prefija = {0}", preFixStr);
        Console.WriteLine("");
    }

    //Time Complexity: O(n) Space Complexity: O(n)
    public static string InfijaAPostFijaVolteada(string ExpresionInfija)
    {
        if (ExpresionInfija == null || ExpresionInfija.Length == 0)
            return string.Empty;

        StringBuilder strBuilder = new StringBuilder();
        Stack<char> s = new Stack<char>();

        for (int i = 0; i <= ExpresionInfija.Length - 1; i++)
        {
            if (ExpresionInfija[i] >= '0' && ExpresionInfija[i] <= '9')
            {
                strBuilder.Append(ExpresionInfija[i]);
            }
            else if (ExpresionInfija[i] == '(')
            {
                s.Push(ExpresionInfija[i]);
            }
            else if (ExpresionInfija[i] == ')')
            {
                while (s.Count > 0 && s.Peek() != '(')
                {
                    strBuilder.Append(s.Pop());
                }
                s.Pop();
            }
            else if (ExpresionInfija[i] == '+' || ExpresionInfija[i] == '-'
                     || ExpresionInfija[i] == '/' || ExpresionInfija[i] == '*')
            {

                while (s.Count > 0 && TieneElMismoPrecediente(ExpresionInfija[i], s.Peek()) == true)
                {
                    strBuilder.Append(s.Pop());
                }

                while (s.Count > 0 && IncomingSymbol_IsLowPrecedent(ExpresionInfija[i], s.Peek()) == true)
                {
                    strBuilder.Append(s.Pop());
                }

                s.Push(ExpresionInfija[i]);
            }
            //Console.WriteLine("Builder: " + strBuilder);
            //Stack<char> sban = new Stack<char>();
            //sban = s;
            //while (sban.Count != 0)
            //{
            //    Console.WriteLine("pila: " + sban.Pop());
            //}
        }

        while (s.Count != 0)
        {
            strBuilder.Append(s.Pop());
        }

        return strBuilder.ToString();
    }

    // opA = Incoming Symbol , opB = Top item on stack
    public static bool TieneElMismoPrecediente(char opA, char opB)
    {
        if ((opA == '+' || opA == '-') && (opB == '+' || opB == '-'))
        {
            return true;
        }
        else if ((opA == '*' || opA == '/') && (opB == '*' || opB == '/'))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // opA = Incoming Symbol , opB = Top item on stack
    public static bool IncomingSymbol_IsLowPrecedent(char opA, char opB)
    {
        if ((opA == '+' || opA == '-') && (opB == '*' || opB == '/'))
        {
            return true;
        }
        else
            return false;
    }


    public static string VoltearCadena(string str)
    {
        char[] inputarray = str.ToCharArray();
        Array.Reverse(inputarray);
        for (int i = 0; i <= inputarray.Length - 1; i++)
        {
            if (inputarray[i] == '(')
            {
                inputarray[i] = ')';
            }
            else if (inputarray[i] == ')')
            {
                inputarray[i] = '(';
            }
            else
            {
                continue;
            }
        }
        return new string(inputarray);
    }
}