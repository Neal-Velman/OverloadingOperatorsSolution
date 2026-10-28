using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OverloadingOperators
{
    public struct Fraction
    {
        public int WholeNumber { get; set; } = 0;
        public int Numerator { get; set; } = 0;
        public int Denominator
        {
            get;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator may NEVER be 0");
                }
                else
                {
                    field = value;
                }
            }
        } = 1;
        public Fraction(int whole = 0, int numerator = 0, int denominator = 1)
        {
            WholeNumber = whole;
            Numerator = numerator;
            Denominator = denominator;
        }

        #region Static Functions



        #endregion

        public void Reduce()
        {

            int gcd = GCD(Numerator, Denominator);
            Numerator = Numerator / gcd;
            Denominator = Denominator / gcd;
        }

        public static int GCD(int m, int n)
        {
            while (n != 0)
            {
                int temp = n;
                n = m % n;
                m = temp;
            }
            return m;
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            first.MakeImproper();
            second.MakeImproper();
            int thingToMultiply = first.Denominator * second.Denominator;
            Fraction tempFraction = new Fraction
            {
                Numerator = (first.Numerator * second.Denominator) + (second.Numerator * first.Denominator),
                Denominator = thingToMultiply
            };
            tempFraction.Simplify();
            return tempFraction;
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            first.MakeImproper();
            second.MakeImproper();
            int thingToMultiply = first.Denominator * second.Denominator;
            Fraction tempFraction = new Fraction
            {
                Numerator = (first.Numerator * second.Denominator) - (second.Numerator * first.Denominator),
                Denominator = thingToMultiply
            };
            tempFraction.Simplify();
            return tempFraction;
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            first.MakeImproper();
            second.MakeImproper();
            Fraction tempFraction = new Fraction
            {
                Numerator = first.Numerator * second.Numerator,
                Denominator = first.Denominator * second.Denominator
            };
            tempFraction.Simplify();
            return tempFraction;
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            first.MakeImproper();
            second.MakeImproper();
            Fraction tempFraction = new Fraction
            {
                Numerator = first.Numerator * second.Denominator,
                Denominator = first.Denominator * second.Numerator
            };
            tempFraction.Simplify();
            return tempFraction;
        }

        public static bool operator ==(Fraction first, Fraction second)
        {
            first.Simplify();
            second.Simplify();
            return (first.WholeNumber == second.WholeNumber) && (first.Numerator == second.Numerator) && (first.Denominator == second.Denominator);
        }

        public static bool operator !=(Fraction first, Fraction second)
        {
            return !(first == second);
        }

        public void MakeProper()
        {
            while (Numerator >= Denominator)
            {
                Numerator -= Denominator;
                WholeNumber++;
            }
        }

        public void MakeImproper()
        {
            while (WholeNumber > 0)
            {
                WholeNumber--;
                Numerator += Denominator;
            }

            //ALTERNATE METHOD
            //if (WholeNumber != 0)
            //{
            //    Numerator += WholeNumber * Denominator;
            //    WholeNumber = 0;
            //}
        }

        public void Simplify()
        {
            MakeProper();
            Reduce();
        }

        public override string ToString()
        {
            if (WholeNumber == 0)
            {
                return $"{Numerator}/{Denominator}";
            }
            else if (Numerator == 0)
            {
                return $"{WholeNumber}";
            }
            else
            {
                return $"{WholeNumber} {Numerator}/{Denominator}";
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
