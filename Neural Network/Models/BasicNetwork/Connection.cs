using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VStats
{
    [Serializable()]
    public class Connection
    {
        public delegate void SignalHandler(Connection c, EventArgs e);
        public event SignalHandler signalHandler;
        public EventArgs e;
        private Node fromNode;
        private Node toNode;
        private double weight;
        private double value;

        public static double tempWeight = 0.05;

        private static Random rand = new Random();
        public Connection(VStats.Node fromNode, VStats.Node toNode)
        {
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.toNode.registerInputConnection(this);
            this.fromNode.registerOutputConnection(this);
            initializeWeight();
        }

        public void initializeWeight()
        {
            //this.weight = rand.NextDouble();
           // this.weight = -0.5 + (rand.NextDouble() * (0.5 - -0.5));
            this.weight = (rand.NextDouble() * 2 * 4) - 4;
            //this.weight = tempWeight;
            //tempWeight += 0.05;
        }

        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public double getWeight()
        {
            return this.weight;
        }

        public void setValue(double value)
        {
            this.value = value;
        }

        public double getValue()
        {
            return value;
        }

        public void fire(double value)
        {
            //setValue(value);
            //let all listeners know that we just fired
            //signalHandler(this, e);
            this.toNode.acceptSignal(value, this.weight);
        }

        public Node getFromNode()
        {
            return this.fromNode;
        }

        public Node getToNode()
        {
            return this.toNode;
        }

    }
}
