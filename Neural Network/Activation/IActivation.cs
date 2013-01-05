using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Activation
{
    abstract class IActivation
    {
        public static double evaluate(double value)
        {
            throw new Exception("Must implement static evaluate at the child level");
        }
    }
}
