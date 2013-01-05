using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats
{
    [Serializable()]
    public class Node
    {
        private static int tabs = 0;
        private char tab = '-';

        protected delegate double ActivationFunction(double value);
        ActivationFunction activate;
        protected delegate double CombinationFunction(double[] values, double[] weights);
        CombinationFunction combine;

        private bool fired;
        private List<Connection> outConnections;
        private List<Connection> inConnections;
        private List<double> inValues;
        private List<double> inWeights;
        private double value;

        private bool bias;

        protected string label;
        public string Label
        {
            get
            {
                return label != null ? label : "Not Set";
            }
            set
            {
                label = value;
            }
        }

        public Node()
        {
            outConnections  = new List<Connection>();
            inConnections = new List<Connection>();
            inValues = new List<double>();
            inWeights = new List<double>();

            activate = Activation.SigmoidActivation.evaluate;
            combine = Combination.Summation.evaluate;
            fired = false;
            bias = false;
        }

        public void registerOutputConnection(Connection connection)
        {
            outConnections.Add(connection);
        }

        public void setValue(double value)
        {
            #if DEBUG
                //Console.WriteLine(new String(tab, tabs) + "Setting value for " + this + " to " + value);
            #endif
            
            if (!bias)
                this.value = value;
            else
                throw new Exception("Tried to set the value on a bias node");
        }

        public double getValue()
        {
            return value;
        }

        public void fire()
        {            
            //#if DEBUG
            //    //Console.WriteLine(new String(tab, tabs) + "Firing " + this);
            //    tabs++;    
            //#endif
            //if input layer node we'll assume the value was already set
            if (!isInputNode())
            {
                //Console.WriteLine(combine(inValues.ToArray(), inWeights.ToArray()) + "  " + activate(
                  //      combine(inValues.ToArray(), inWeights.ToArray())
                    //));
                setValue(
                    activate(
                        combine(inValues.ToArray(), inWeights.ToArray())
                    ));
            }

            int count = outConnections.Count;
            for (int x = 0; x < count; x++)
                outConnections.ElementAt(x).fire(this.value);

            clearInputs();
            //#if DEBUG
            //    tabs--;
            //    //Console.WriteLine(new String(tab, tabs) + "Done Firing " + this);                 
            //#endif
        }

        public void clearInputs()
        {
            inWeights.Clear();
            inValues.Clear();
        }

        public void registerInputConnection(Connection connection)
        {
            inConnections.Add(connection);
            //connection.signalHandler += new Connection.SignalHandler(acceptSignal);
        }

        public void acceptSignal(double value, double weight)
        {
            inValues.Add(value);
            inWeights.Add(weight);
            //check to see if all in values have fired
            //Console.WriteLine(this + ": " + inValues.Count()+" == "+inConnections.Count());
            if (inValues.Count() == inConnections.Count()) //we have registered connections from every input node
            {
                fire();
            }
        }

        public Connection[] getOutputConnections()
        {
            return outConnections.ToArray();
        }

        public Connection[] getInputConnections()
        {
            return inConnections.ToArray();
        }

        public bool isFired()
        {
            return fired;
        }

        public bool isInputNode()
        {
            return inConnections.Count() == 0;
        }

        public bool isOutputNode()
        {
            return outConnections.Count() == 0;
        }

        public void setBias(bool bias)
        {
            this.bias = bias;
            this.value = 1;
        }

        public bool getBias()
        {
            return bias;
        }

        public override string ToString()
        { //base.ToString() + ": " + 
            return label + (bias ? " (bias)" : "");
        }

    }
}
