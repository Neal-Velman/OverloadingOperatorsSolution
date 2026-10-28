using OverloadingOperators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverloadingOperatorsProject
{
    internal class Testing
    {
        public static void Run()
        {
            Test();
        }

        private static void Test()
        {
            Fraction f1 = new Fraction() { WholeNumber = 2, Numerator = 3, Denominator = 4};
            Fraction f2 = new Fraction() { WholeNumber = 0, Numerator = 11, Denominator = 4};
            Fraction f3 = f1 / f2;
            Console.WriteLine(f1 == f2);
        }
    }
}
