using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'poisonousPlants' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY p as parameter.
     */

    public static int poisonousPlants(List<int> p)
    {
         Stack<(int pesticide, int days)> stack = new Stack<(int, int)>();
        int maxDays = 0;

        foreach (int pesticide in p)
        {
            int days = 0;

          
            while (stack.Count > 0 && pesticide <= stack.Peek().pesticide)
            {
                days = Math.Max(days, stack.Pop().days);
            }

           
            if (stack.Count > 0)
            {
                days += 1;
            }
            else
            {
                days = 0;
            }

            maxDays = Math.Max(maxDays, days);
            stack.Push((pesticide, days));
        }

        return maxDays;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> p = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt32(pTemp)).ToList();

        int result = Result.poisonousPlants(p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
