using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VStats;
using VStats.Data;

namespace VStatsInterface
{
    public partial class MainForm : Form
    {
        private System.IO.StreamReader dataFile;
        private TextDataSource dataSource;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openModel_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void trainStartButton_Click(object sender, EventArgs e)
        {
            dataSource = new TextDataSource(
                openFileDialog.FileName,
               (int) numericIn.Value,
               (int) numericOut.Value,
                headerCheckbox.Checked
            );
            
        }

        private void openDataFile_Click(object sender, EventArgs e)
        {
            fileNameText.Text = openFileDialog.FileName;
            /*
            dataSource = new TextDataSource(openFileDialog.FileName, 4, 3, true);
            dataFile = new System.IO.StreamReader(openFileDialog.FileName);
            while (!dataFile.EndOfStream)
            {
                this.logWindow.Text += dataFile.ReadLine();
            }
             */
        }

        private void numberOutputsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
