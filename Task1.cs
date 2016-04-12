using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TriangleArea
{
    public class TriangleMath
    {    
        public static double Area(double val1, double val2, double val3)
        {
            if (val1 <= 0 || val2 <= 0 || val3<= 0)
            { throw new NegativeOrNullException(); }

            double[] sortar = new double[] { val1,val2,val3};
            Array.Sort(sortar);

            val3 = sortar[0];
            val2 = sortar[1];
            val1 = sortar[2];
            double eps = val3 / (1e+6);

            if (Math.Abs(val1-Math.Sqrt((val2)*(val2)+(val3)*(val3)))>= eps)
            { throw new NotRightTriangleException(); }

            return 0.5 * val2 * val3;
        }

        // EXCEPTIONS
       
        public class NegativeOrNullException : Exception
        {
            public NegativeOrNullException() : base("Отрицательная или нулевая длина стороны")
            {
            }        
        }

        public class NotRightTriangleException : Exception
        {
            public NotRightTriangleException():base("Треугольник не прямоугольный")
            {
            }
        }
    }
  
}
