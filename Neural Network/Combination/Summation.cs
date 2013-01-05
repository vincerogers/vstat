using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Combination
{
    class Summation : ICombination
    {
        public static double evaluate(double[] values, double[] weights)
        {
            double returnValue = 0;
            for(int x = 0; x < values.Length; x++)
                returnValue += values[x] * weights[x];
            return returnValue; 
        }
    }
}
