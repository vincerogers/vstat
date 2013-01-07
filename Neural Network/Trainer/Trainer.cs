using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using VStats.Models;
using VStats.Data;

namespace VStats.Trainer
{
    public abstract class Trainer
    {
        //events
        public delegate void EpochIterationComplete(Trainer sender, EventArgs e);
        public event EpochIterationComplete epochIterationComplete;

        //training parameters
        private int epochs = 0;
        protected double learningRate = 0.02;
        protected double momentum = 0.9;

        //training statistics
        protected double correctTraining = 0;
        protected double correctValidation = 0;
        protected double validationAccuracy = 0;
        public double ValidationAccuracy { get{ return validationAccuracy; } }
        protected double trainingAccuracy = 0;
        public double TrainingAccuracy { get { return trainingAccuracy; } }
        protected double bestAccuracy = 0;
        public double BestAccuracy { get { return bestAccuracy; } }

        protected double trainingSSE = 0;
        protected double validationSSE = 0;
        protected double trainingMSE = 0;
        protected double validationMSE = 0;
        public string currentLogLine;

        //stopping conditions
        StopConditions stopCondition = StopConditions.maxEpochs;
        Stopwatch trainingTimer;
        bool stopTraining = false;
        double stopParameter;
        //int maxEpochs = 1000;
        //int maxTimeMinutes = -1;
        //int maxValidationAccuarcy = -1;

        protected Models.Model model;

        public Trainer(Model network)
        {
            this.model = network;
            this.setStopCondition(StopConditions.maxEpochs, 1500);
            //setStopCondition(StopConditions.minValidationAccuarcy, 0.80);
        }

        public void setStopCondition(StopConditions condition, double parameter)
        {
            if (parameter <= 0)
                throw new Exception("Stop condition parameter must be greater than 0");
            this.stopParameter = parameter;
            this.stopCondition = condition;
        }

        public void setStopFlag(bool flag = true)
        {
            this.stopTraining = flag;
        }

        public void train(Data.DataSource source)
        {
            trainingTimer = new Stopwatch();
            trainingTimer.Start();

            for(int x = 0; !stopConditionMet(); x++)
            {
                long iterationStartTime = trainingTimer.ElapsedMilliseconds;
                Data.TrainingSet set = source.getTrainingEpoch();

                for(int i = 0; i < set.traingSetLength(); i++)
                {
                    this.processRecord(set.trainingSet[i], true);
                    this.trainRecord(set.trainingSet[i]);
                }
                //Console.WriteLine("Training - Epoch {0} SSE: {1} MSE: {2} Accuracy {3}%", epochs, trainingSSE, Math.Round(trainingSSE / set.traingSetLength(), 6), Math.Round(correctTraining / set.traingSetLength() * 100, 2));
                for (int i = 0; i < set.validationSetLength(); i++)
                {
                    this.processRecord(set.validationSet[i], false);
                }

                this.validationAccuracy = correctValidation / set.validationSetLength();
                this.trainingAccuracy = correctTraining / set.traingSetLength();
                this.bestAccuracy = Math.Max(this.validationAccuracy, this.bestAccuracy);

                string logLine = String.Format("Epoch {0} ({8} records)  - Training SSE: {1} MSE: {2} Accuracy {3}%, Validation SSE: {4} MSE: {5} Accuracy {6}% ({7} seconds)", 
                    epochs, 
                    trainingSSE, 
                    Math.Round(trainingSSE / set.traingSetLength(), 4), 
                    Math.Round(this.trainingAccuracy * 100, 2), 
                    validationSSE, 
                    Math.Round(validationSSE / set.validationSetLength(), 4), 
                    Math.Round(this.validationAccuracy * 100, 2),
                    (trainingTimer.ElapsedMilliseconds - iterationStartTime)/1000,
                    set.traingSetLength()
                );
                Console.WriteLine(logLine);
                currentLogLine = logLine;
                epochs++;
                correctValidation = 0;
                correctTraining = 0;
                trainingSSE = 0;
                validationSSE = 0;
                if(epochIterationComplete != null)
                    epochIterationComplete(this, EventArgs.Empty);
            }
            trainingTimer.Stop();
            Console.WriteLine("Training took {0} seconds", trainingTimer.ElapsedMilliseconds / 1000);
        }

        protected bool stopConditionMet()
        {
            switch (this.stopCondition)
            {
                case StopConditions.maxEpochs:
                    return epochs > stopParameter;
                case StopConditions.maxTimeMinutes:
                    return this.trainingTimer.ElapsedMilliseconds * 60 * 1000 > stopParameter;
                case StopConditions.minValidationAccuarcy:
                    return validationAccuracy > stopParameter;
                default:
                    throw new Exception("Invalid stop condition type");
            }
        }

        public void processRecord(Data.TrainingRecord record, bool training = true)
        {
            ModelResults output = this.model.process(record.inputValues);
            int[] clampedOutputs = output.getClampedValues();
            bool correct = true;
            for (int x = 0; x < output.Length; x++)
            {
                if(training)
                    this.trainingSSE += Math.Pow(clampedOutputs[x] - record.outputValues[x], 2);
                else
                    this.validationSSE += Math.Pow(clampedOutputs[x] - record.outputValues[x], 2);
                if (clampedOutputs[x] != record.outputValues[x])
                    correct = false;

                #if DEBUG
                //Console.WriteLine("Output " + x + ": Expected " + record.outputValues[x] + ", Actual " + output[x]);
                #endif
            }
            if (correct)
                if(training)
                    this.correctTraining++;
                else 
                    this.correctValidation++;

        }

        protected abstract void trainRecord(Data.TrainingRecord record);

        public void incrementEpochs()
        {
            epochs++;
        }

        public int getEpochs()
        {
            return epochs;
        }
    }
}
