using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VStats.Data;

namespace VStats.Data
{
    public struct TrainingSet
    {
        public TrainingRecord[]  trainingSet, validationSet;

        public override string ToString()
        {
            string toString = "";
            for (int x = 0; x < this.trainingSet.Length; x++)
            {
                toString += "Training Set" + Environment.NewLine;
                toString += this.trainingSet[x];
            }

            for (int x = 0; x < this.validationSet.Length; x++)
            {
                toString += Environment.NewLine + "Validation Set" + Environment.NewLine;
                toString += validationSet[x];
            }

            return toString;
        }

        public int traingSetLength()
        {
            return this.trainingSet.Length;
        }

        public int validationSetLength()
        {
            return validationSet.Length;
        }
    }
}
