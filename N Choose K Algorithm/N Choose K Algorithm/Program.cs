// See https://aka.ms/new-console-template for more information
using System;

namespace NChooseK
{

    public class Program
    {
        static int numberOfPossibleCombinations()
        {
            if (  k == 0 || k == n )
            {
                return 1;
            }
            else
            {
                return numberOfPossibleCombinations( n - 1, k ) + numberOfPossibleCombinations( n - 1, k - 1 );
            }
        }
    }
    
    public static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        System.Diagnostics.Debug.WriteLine(numberOfPossibleCombinations(3, 2));
    }

}

