using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using VStats.Data;

namespace VStats.Models
{
    [Serializable()]
    public abstract class Model
    {
        public abstract ModelResults process(double[] record);

        public int clampOutput(double value)
        {
            if (value >= 0.9)
                return 1;
            return 0;
        }
    }
}
