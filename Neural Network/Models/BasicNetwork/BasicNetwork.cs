using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VStats.Data;

namespace VStats.Models
{
    [Serializable()]
    public class BasicNetwork : VStats.Models.Model
    {
        private Layer[] layers;

        public BasicNetwork(int numLayers = 3)
        {
            this.layers = new Layer[numLayers];
        }

        public BasicNetwork(int numInputs, int numOutputs, int numHiddenNodes = 10)
        {
            this.createNetwork( numInputs, numOutputs, 1, new int[] {numHiddenNodes});
        }

        public BasicNetwork(int numInputs, int numOutputs, int hiddenLayers, int[] hiddenLayerNodes)
        {
            this.createNetwork(numInputs, numOutputs, hiddenLayers, hiddenLayerNodes);
        }

        protected void createNetwork(int numInputs, int numOutputs, int hiddenLayers, int[] hiddenLayerNodes)
        {
            this.layers = new Layer[2 + hiddenLayers];
            this.layers[0] = new Layer(numInputs, true, "input");
            for(int x = 0; x < hiddenLayers; x++)
                this.layers[x + 1] = new Layer(hiddenLayerNodes[x], true, "hidden " + x);

            this.layers[this.layers.Length - 1] = new Layer(numOutputs, false, "output");
            this.initialize();
        }

        public void initialize()
        {
            for (int x = 0; x < this.layers.Length - 1; x++)
            {
                BasicNetwork.connectLayers(this.layers[x], this.layers[x + 1]);
            }

        }

        public static void connectLayers(Layer fromLayer, Layer toLayer)
        {
            for (int x = 0; x < fromLayer.countNodes(); x++)
                for (int i = 0; i < toLayer.countNodes(); i++)
                {
                    //don't want to connect to bias node in child layer
                    if (!toLayer.getNode(i).getBias())
                    {
                        new Connection(fromLayer.getNode(x), toLayer.getNode(i));
                    }
                }
        }

        public Layer[] getLayers()
        {
            return layers;
        }

        public Layer getInputLayer()
        {
            return this.layers[0];
        }

        public Layer getOutputLayer()
        {
            return this.layers[this.layers.Length - 1];
        }

        public override ModelResults process(double[] record)
        {
            Layer input = getInputLayer();
            Layer output = getOutputLayer();

            if (record.Length != input.countNodes() - 1) //account for bias node that we don't want populated from record
                throw new Exception("Number of input values (" + record.Length + ") does not match number of input layer nodes (" + (
                    input.countNodes() - 1) + ")");
            //set all the input values into the input layer
            for (int x = 0; x < record.Length; x++)
            {
                Node node = input.getNode(x);
                node.setValue(record[x]);
                node.fire();
            }

            foreach (Layer layer in this.getLayers()) //trip all bias nodes
                if (layer.hasBiasNode())
                    layer.getBiasNode().fire();

            double[] returnValues = new double[output.countNodes()];
            for (int x = 0; x < output.countNodes(); x++)
            {
                returnValues[x] = output.getNode(x).getValue();
            }
            return new ModelResults(returnValues);
        }

        public void printConnections()
        {
            for (int x = 0; x < layers.Length; x++)
            {
                foreach (Node node in layers[x].getNodes())
                {
                    foreach (Connection conn in node.getOutputConnections())
                        Console.WriteLine(conn.getFromNode() + " -> " + conn.getToNode() + " (" + Math.Round(conn.getWeight(), 4) +")");
                }
            }
        }

        public int numLayers()
        {
            return layers.Length;
        }

    }
}
