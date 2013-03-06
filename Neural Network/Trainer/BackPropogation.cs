//#define TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VStats.Trainer;
using VStats.Models;
using VStats.Data;

namespace VStats.Trainer
{
    public class BackPropogation : Trainer
    {
        protected double[][] errorResp;
        double[][][] prevDelta;

        public BackPropogation(BasicNetwork network) : base((BasicNetwork)network)
        {
            Layer[] layers = network.getLayers();
            errorResp = new double[layers.Length][]; //will hold current node error responsibility
            prevDelta = new double[layers.Length][][]; //used to store the previous weight delta values for momentum
            for (int x = 0; x < errorResp.Length; x++)
            {
                errorResp[x] = new double[layers[x].countNodes()]; //used to track the error resp. of each node
                prevDelta[x] = new double[layers[x].countNodes()][];
                for (int i = 0; i < layers[x].countNodes(); i++)
                {
                    errorResp[x][i] = 0;
                    if (x != layers.Length - 1)
                    {
                        prevDelta[x][i] = new double[layers[x + 1].countNodes()];
                        for (int k = 0; k < layers[x + 1].countNodes(); k++)
                        {                            
                            prevDelta[x][i][k] = 0;
                        }
                    }
                }
            }
        }

        protected override void trainRecord(Data.TrainingRecord record)
        {
            Layer[] layers = ((BasicNetwork)model).getLayers();
            Node node; //will hold current node
            double outputValue; //will hold current node value
            double downStreamSum;
            double deltaWeight;

            for (int x = layers.Length - 1; x >= 0; x--)
            {
                int numNodes = layers[x].countNodes();
                for (int i = 0; i < numNodes; i++)
                {
                    node = layers[x].getNode(i);
                    outputValue = node.getValue();

                    if (node.isOutputNode())
                    {
#if TEST
                        Console.WriteLine("OUTPUT VALUE IS " + outputValue);
#endif
                        this.errorResp[x][i] = outputValue * (1 - outputValue) * (record.outputValues[i] - outputValue);
#if TEST
                        Console.WriteLine(node + ": " + Math.Round(outputValue, 4) + " * (1 - " + Math.Round(outputValue, 4) + ") * (" + Math.Round(record.outputValues[i], 4) + " - " + Math.Round(outputValue, 4) + ") = " + Math.Round(errorResp[x][i], 4));
#endif
                    }
                    else
                    {
                        
                        Connection[] conns = node.getOutputConnections();
                        downStreamSum = 0;
                        string debugString = "";

                        /*
                         * Do two things here:
                         * 1. Compute the error resp for current node
                         * 2. compute delta for current node and adjust weights
                         */
                        for (int k = 0; k < conns.Length; k++)
                        {
                            downStreamSum += conns[k].getWeight() * errorResp[x + 1][k];
                            debugString += Math.Round(conns[k].getWeight(),4)+" * " + Math.Round(errorResp[x + 1][k],4) + " + ";

                            deltaWeight = learningRate * outputValue * errorResp[x + 1][k] + momentum * prevDelta[x][i][k];
                            #if TEST
                            Console.WriteLine(node + " Delta to " +k+ ": " + learningRate + " * " + Math.Round(node.getValue(),4) + "*" + Math.Round(errorResp[x + 1][k],4) + " + " + momentum + " * " + prevDelta[x][i][k] + " = " + Math.Round(deltaWeight,4));
                            #endif
                            conns[k].setWeight(conns[k].getWeight() + deltaWeight);
                            prevDelta[x][i][k] = deltaWeight; //load current delta for momentum use during next training iteration
                        }
                        errorResp[x][i] = outputValue * (1 - outputValue) * downStreamSum;
                        #if TEST
                        Console.WriteLine(node + ": " + Math.Round(outputValue, 4) + " * (1 - " + Math.Round(outputValue, 4) + ") " +" * ("+debugString+") = " + Math.Round(errorResp[x][i], 4));
                        #endif

                    }
                    #if TEST
                    Console.WriteLine("Error resp for layer {0}, node {1} ({3}) is {2} \n", x, i, errorResp[x][i], node.getBias() ? "Bias" : "");
                    #endif                  
                }
            }
            #if TEST
            Console.ReadLine();
            #endif

        }
    }
}
