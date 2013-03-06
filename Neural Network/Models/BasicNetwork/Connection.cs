//#define TEST
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
        private Node fromNode;
        private Node toNode;
        private double weight;
        private double value;
        private double weightRange = .25;

        public static double tempWeight = 0.05; //used for debugging purposes

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
#if TEST            
            this.weight = tempWeight;
            tempWeight += 0.05;
#else
            //this.weight = (rand.NextDouble() * 2 * 4) - 4;
            this.weight = -weightRange + (rand.NextDouble() * (weightRange - -weightRange));
#endif
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
