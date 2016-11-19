/**************************************
 *          Geoff Overfield           *
 *           April 20, 2016           *
 *  Math class created to substitute  *
 *     for some of Microsoft's        * 
 *      predefined functions          *
 *************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    
    class MyMath
    {
        //constant variables for pi and e
        private const double pi = 3.141592653589793;
        private const double e = 2.718281828459045;

        //performs exponential exquations and returns the value
        public double pow(double x, double y)
        {
            double answer = Math.Pow(x, y);
            return answer;
        }
        //squares a given number and returns the value
        public double squared(double x)
        {
            double answer = x * x;
            return answer;
        }
        //cubes a given number and returns the value
        public double cubed(double x)
        {
            double answer = x;
            for (int i = 1; i < 3; i++)
                answer = answer * x;
            return answer;
        }
        //finds square root of a given number and returns the value
        public double sqrt(double x)
        {
            double answer = Math.Sqrt(x);
            return answer;
        }
        //fins the cubed root of a given number and returns the value
        public double cbdrt(double x)
        {
            double answer = Math.Pow(x, (1.0 / 3.0));
            return answer;
        }
        //finds the y-root of a given number and returns the value
        //users input a base number and the roots for which they would like to find
        //x represents the base, and y represents the root-of
        public double yRoot(double x, double y)
        {
            double answer = Math.Pow(x, (1.0 / y));
            return answer;
        }
        //adds two numbers together and returns the value
        public double add(double x, double y)
        {
            double answer = x + y;
            return answer;
        }
        //subracts two numbers and returns the value
        public double subtract(double x, double y)
        {
            double answer = x - y;
            return answer;
        }
        //multiplies two numbers and returns the value
        public double multiply(double x, double y)
        {
            double answer = x * y;
            return answer;
        }
        //divides x by y and returns the value
        public double divide(double x, double y)
        {
            double answer = x / y;
            return answer;
        }
        //inverses the input number and returns the value
        public double PosNeg(double x)
        {
            double answer = x * -1;
            return answer;
        }
        //finds the decimal or percentage of a given number and returns the value
        public double Percentage(double x)
        {
            double answer = x / 100;
            return answer;
        }
        //performs logarithmic equations with a base-10 and returns the value 
        //works of the formula of (log10)result = t  ||  10^t = result
        public double log10(double result)
        {
            double t = Math.Log10(result);
            return t;
        }
        //performs logarithmic equations with a base-2 and returns the value 
        //works of the formula of (log2)result = t  ||  2^t = result
        public double log2(double result)
        {
            double t = Math.Log(result, 2);
            return t;
        }
        //performs logarithmic equations with a base-3 and returns the value 
        //works of the formula of (log3)result = t  ||  3^t = result
        public double log3(double result)
        {
            double t = Math.Log(result, 3);
            return t;
        }
        //performs logarithmic equations with a base-e and returns the value 
        //works of the formula of (log-e)result = t  ||  e^t = result
        public double naturalLog(double result)
        {
            double t = Math.Log(result);
            return t;
        }
        //performs logarithmic equations with a base-x and returns the value 
        //works of the formula of (log-x)result = t  ||  x^t = result
        public double logXofY(double b, double result)
        {
            double t = Math.Log(result, b);
            return t;
        }
        //function to run factorials for any given number and returns the value
        //factorials mulitply a number by it's following number, begining at 1
        //for example, a Factorial of 10 computes 1*2*3*4*5*6*7*8*9*10 = 3,628,800
        public int Factorial(int x)
        {
            int answer = 1;
            for (int i = 1; i < x+1; i++)
                answer = answer * i;
            return answer;
        }
        //finds decimal/fractional value of a number and returns said value
        //for example, if the user inputs 20, it will return the value of 1-twentieth or .05
        public double Fraction(double x)
        {
            double answer = 1 / x;
            return answer;
        }
        //returns value for scientific notation of x
        //for example, if the user inputs the number 10, if will return a value of 10 * 10^10
        public double EE(double x)
        {
            double answer = x * (pow(10, x));
            return answer;
        }
        

    }
}

