using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Data
{
    public abstract class DataSource
    {
        protected double holdoutSize = 0.1;
        private int numInputs;
        private int numOutputs;
        private int numRows;
        private int kSplits;
        private int currentHoldout;

        private List<double[]> rawData;
        private TrainingRecord[][] data;


        private bool prepared;

        ValidationMode mode;

        public DataSource(int numInputs, int numOutputs)
        {
            // TODO: Complete member initialization
            this.numInputs = numInputs;
            this.numOutputs = numOutputs;
            
            this.numRows = 0;
            this.kSplits = 0;
            this.currentHoldout = 0;
            this.prepared = false;
            this.rawData = new List<double[]>();
            this.setValidationMode(ValidationMode.Holdout, 0.1);
        }

        public void setValidationMode(ValidationMode mode, double parameter)
        {
            this.checkPrepared(true);
            this.mode = mode;
            
            switch (this.mode)
            {
                case (ValidationMode.Holdout):
                    this.kSplits = 2;
                    this.holdoutSize = parameter;
                    break;
                case (ValidationMode.KFold):
                    this.kSplits = (int) parameter;
                    this.currentHoldout = 0;
                    break;
                default:
                    throw new Exception("Invalid validation mode:" + mode);
            }
             

        }

        protected void prepareData()
        {
            this.prepared = true;

            int numRecords = this.rawData.Count;
            if (this.kSplits > numRecords) // can't have more K than there are actual records
                this.kSplits = numRecords;
            int[] countForK = new int[kSplits];
            if (this.mode == ValidationMode.Holdout)
            {
                countForK[0] = (int)Math.Round((1 - this.holdoutSize) * numRecords);
                countForK[1] = numRecords - countForK[0];
            }
            else if (this.mode == ValidationMode.KFold)
            {
                double div = numRecords / kSplits;
                int partition = (int) Math.Floor(div);
                int remainder = numRecords - (partition * kSplits);

                for (int x = 0; x < kSplits; x++)
                    countForK[x] = partition;
                if(remainder != 0)
                    countForK[kSplits - 1] = remainder;
                //for (int x = 0; x < kSplits; x++)
                  //  Console.WriteLine("{0} - {1}",x, countForK[x]);
                //Console.ReadLine();
            }

            this.data = new TrainingRecord[this.kSplits][];

            int index = 0;
            for (int x = 0; x < this.kSplits; x++)
            {
                //create a new Training record for each data split (training/validation, k-fold, etc)
                this.data[x] = new TrainingRecord[countForK[x]];

                for (int i = 0; i < countForK[x]; i++, index++)
                {
                    this.data[x][i].outputValues = new double[this.numOutputs];
                    this.data[x][i].inputValues = new double[this.numInputs];
                    Array.Copy(rawData.ElementAt(index), 0,this.data[x][i].inputValues, 0, this.numInputs);//new double[this.numInputs];
                    Array.Copy(rawData.ElementAt(index), this.numInputs, this.data[x][i].outputValues, 0, this.numOutputs);//new double[this.numInputs];
                }
            }
        }

        public TrainingSet getTrainingEpoch()
        { 
            TrainingSet set = new TrainingSet();
            if (this.mode == ValidationMode.Holdout)
            {
                set.trainingSet = this.data[0];
                set.validationSet = this.data[1];
            }
            else if (this.mode == ValidationMode.KFold)
            {
                //TODO cache the k training sets
                set.validationSet = this.data[currentHoldout];
               
                int length = 0;
                for (int x = 0; x < this.kSplits; x++)
                    if (x != this.currentHoldout)
                        length += this.data[x].Length;
                
                Data.TrainingRecord[] tempTrainSet = new Data.TrainingRecord[length];
                
                int index = 0;
                for (int x = 0; x < this.kSplits; x++)
                    if (x != this.currentHoldout)
                         for (int i = 0; i < this.data[x].Length; i++)
                            tempTrainSet[index++] = this.data[x][i];
                set.trainingSet = tempTrainSet;
                //Console.WriteLine("Current Holdout is {0}. Training size is {1}. Validation Size is {2}", currentHoldout, set.traingSetLength(), set.validationSetLength());
                //Console.ReadLine();
               // Console.WriteLine("Current holdout is {0}", this.currentHoldout);
                if (currentHoldout == this.kSplits - 1) //at the end
                    currentHoldout = 0;
                else
                    currentHoldout++;
                //Console.WriteLine("Current holdout after iteration is {0}", this.currentHoldout);

                
                
            }
            return set;
        }

        protected void addRecord(double[] record)
        {
            this.checkPrepared(true);
            this.rawData.Add(record);
        }

        protected bool checkPrepared(bool throwException = false)
        {
            if(throwException && this.prepared)
                throw new Exception("Cannot set validation mode after data has been prepared");
            return this.prepared;

        }
        public abstract void loadData();

    }
}
