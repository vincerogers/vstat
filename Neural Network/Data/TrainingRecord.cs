using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Data
{
    public struct TrainingRecord
    {
        public double[] inputValues, outputValues;
        public TrainingRecord(double[] inputValues, double[] outputValues)
        {
            this.inputValues = inputValues;
            this.outputValues = outputValues;
        }

        public override string ToString()
        {
            string toString = "Intput Values:" + Environment.NewLine;
            for (int x = 0; x < this.inputValues.Length; x++)
                toString += this.inputValues[x] + ", ";
            toString += Environment.NewLine + "Output Values:" + Environment.NewLine;
            for (int x = 0; x < this.outputValues.Length; x++)
                toString += this.outputValues[x] + ", ";
            return toString;

        }
    }
}
