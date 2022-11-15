using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonRaphson
{
    class Program
    {
        public static double func(double x)
        {
            return (Math.Sqrt(1.0 + Math.Pow(x, 2.0))) + Math.Exp(-2 * x);
        }
        public static double firstProizv(double x)
        {
            return (x/ (Math.Sqrt(1.0 + Math.Pow(x, 2.0)))) - 2.0 * Math.Exp(-2.0 * x);
        }
        public static double secondProizv(double x)
        {
            return (-(Math.Pow(x, 2.0) / (Math.Pow((Math.Pow(x, 2.0) + 1.0), (3.0 / 2.0))))) + 4.0 * Math.Exp(-2.0 * x) + (1.0/(Math.Sqrt(Math.Pow(2.0, x) + 1.0)));
        }

        public static double NewtonRaph(double a, double b)
        {
            double eps = 0.001;
            double x = Math.Abs(b) - Math.Abs(a);
            while (true)
            {
                var tao = Math.Pow(firstProizv(x), 2) / (Math.Pow(firstProizv(x), 2) + Math.Pow(firstProizv(x - firstProizv(x) / secondProizv(x)), 2));
                x = x - tao * firstProizv(x) / secondProizv(x);
                if (Math.Abs(firstProizv(x)) < eps)
                {
                    return x;
                }
            }
        }

        static void Main(string[] args)
        {
            double result = NewtonRaph(0, 1.0);
            Console.WriteLine(result);
            Console.WriteLine(func(result));
            Console.ReadKey();
        }
    }
}
