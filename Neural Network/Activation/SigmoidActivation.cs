using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VStats.Activation
{
    class SigmoidActivation : IActivation
    {
        new public static double evaluate(double value)
        {
            return 1/(1 + Math.Exp(-value));
        }   
    }
}
