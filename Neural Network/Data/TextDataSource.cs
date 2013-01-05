using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VStats.Data
{
    
    public class TextDataSource : DataSource
    {
        private char delimiter = ',';
        private bool header = false;
        private System.IO.StreamReader file;

        private int numRows = 0;
        public TextDataSource(string fileName, int numInputs, int numOutputs, bool header = false, char delimiter = ',') : base(numInputs, numOutputs)
        {
            this.delimiter = delimiter;
            this.header = header;
            this.file = new System.IO.StreamReader(fileName);//FileStream(fileName, FileMode.Open);
        }


        public override void loadData()
        {
            string[] columns;
            double[] record;
            if (this.header)
                this.file.ReadLine(); //discard data header
            while (!file.EndOfStream)
            {
                columns = file.ReadLine().Split(this.delimiter);
                record = new double[columns.Length];
                for (int x = 0; x < columns.Length; x++)
                    record[x] = double.Parse(columns[x]);
                this.addRecord(record);
            }
            this.prepareData();
        }
    }
}
