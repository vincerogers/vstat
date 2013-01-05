using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace VStats.Models
{
    [Serializable()]
    public class Layer
    {
        private Node[] nodes;
        private int numNodes;
        private bool bias;
        protected static int layerCount = 0;
        protected string label;
        /*
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
        }*/
        public string getLabel()
        {
            return this.label;
        }

        public void setLabel(string label)
        {
            this.label = label;
        }

        //public Layer(int numNodes, bool bias) : this(numNodes, bias, ""){}
        public Layer(int numNodes, bool bias, string label = null)
        {
            this.label = label;
            if (label == null)
                label = layerCount.ToString();
            layerCount++;

            this.numNodes = numNodes;
            if (bias)
                numNodes++;
            this.bias = bias;
            this.nodes = new Node[numNodes];
            for (int x = 0; x < numNodes; x++)
                this.addNode(new Node(), x);
            if (bias)
            {
                this.nodes[numNodes-1].setBias(true);
            }
        }

        private void addNode(Node newNode, int index)
        {
            this.nodes[index] = newNode;
            this.nodes[index].Label = this + "Node[" + index + "]";
        }

        public int countNodes()
        {
            return this.nodes.Length;
        }

        public Node getNode(int index)
        {
            return this.nodes[index];
        }

        public Node[] getNodes()
        {
            return nodes;
        }

        public bool hasBiasNode()
        {
            return bias;
        }

        public Node getBiasNode()
        {
            if (this.bias)
                return nodes[numNodes];
            throw new Exception("Attempt to access non existant bias node");
        }

        public override string ToString()
        {
            //base.ToString() + ": " + 
            return "Layer (" + this.label + "):";
        }

    }
}
