//#define DEBUG
#undef DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VStats.Models;
using VStats.Data;
using VStats.Trainer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace VStat_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fileName = "C:\\Users\\Vince\\Documents\\Dropbox\\Dev\\VStat\\letter-recognition-2.csv";//"C:\\Users\\Vince\\Documents\\Dropbox\\Dev\\Neural Network\\iris_converted_normalized.csv";
            //int inputs = 16;
            //int outputs = 3;
            string fileName = "C:\\Users\\Vince\\Documents\\Dropbox\\Dev\\VStat\\iris_converted_normalized.csv";//"C:\\Users\\Vince\\Documents\\Dropbox\\Dev\\Neural Network\\iris_converted_normalized.csv";
            int inputs = 4;
            int outputs = 3;

            //create the data source off of an existing file
            TextDataSource dataSource = new TextDataSource(fileName, inputs, outputs, true);
            dataSource.setValidationMode(ValidationMode.Holdout, .5);//(ValidationMode.KFold, 3);
           // dataSource.setValidationMode(ValidationMode.KFold, 4);
            dataSource.loadData();

            //create the neural network
            //BasicNetwork nn = new BasicNetwork( 4, 3, 1, new int[] {10});
            BasicNetwork nn = new BasicNetwork(inputs, outputs, 1, new int[1] {10});

            nn.printConnections();

            //train the NN
            Console.ReadLine();
            VStats.Trainer.BackPropogation trainer = new BackPropogation(nn);
            trainer.train(dataSource);

            //serialize and save the model
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, nn);
            stream.Close();

            Console.ReadLine();
        }
    }
}
