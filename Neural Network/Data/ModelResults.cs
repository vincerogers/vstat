using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Data
{
    public class ModelResults
    {
        protected double[] rawValues;
        protected int[] clampedValues = null;
        protected double clampThreshold = 0.5;

        public int Length
        {
            get { return this.rawValues.Length; }
        }

        public ModelResults(double[] values)
        {
            this.rawValues = values;
        }

        /*
         * Calculated based on SPSS clementine documentation
         */
        public double confidence()
        {
            if (this.rawValues.Length > 1)
            {
                double[] tempArray = this.rawValues.OrderByDescending(c => c).ToArray();
                return tempArray[tempArray.Length - 1] - tempArray[tempArray.Length - 2];
            }
            else
                return Math.Abs(0.5 - rawValues[0]) * 2;
        }

        public int getWinningClassIndex()
        {
            int maxIndex = 0;
            double maxValue = 0;
            for (int x = 0; x < this.rawValues.Length; x++)
            {
                if (this.rawValues[x] > maxValue)
                {
                    maxValue = this.rawValues[x];
                    maxIndex = x;
                }
            }
            return maxIndex;
        }

        public int[] getClampedValues(bool oneWinner = true)
        {
            if(this.clampedValues == null)
            {
                this.clampedValues = new int[this.rawValues.Length];
                if (oneWinner)
                {
                    int winner = this.getWinningClassIndex();
                    for (int x = 0; x < this.rawValues.Length; x++)
                        this.clampedValues[x] = x == winner ? 1 : 0;
                }
                else
                {
                    for (int x = 0; x < this.rawValues.Length; x++)
                        this.clampedValues[x] = this.rawValues[x] >= this.clampThreshold ? 1 : 0;
                }
            }
            return this.clampedValues;
        }

        public double[] getRawValues()
        {
            return this.rawValues;
        }


    }
}
