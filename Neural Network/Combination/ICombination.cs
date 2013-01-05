using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Combination
{
    abstract class ICombination
    {
        public static double evaluate(double[] values)
        {
            throw new Exception("Must implement static evaluate at the child level");
        }
    }
}
