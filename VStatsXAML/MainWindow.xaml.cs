using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VStats.Data;
using VStats.Models;
using VStats.Trainer;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Threading;

namespace VStatsXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public ObservableCollection<KeyValuePair<int, double>> holdoutAccuracyList { get; private set; }
        public ObservableCollection<KeyValuePair<int, double>> trainAccuracyList { get; private set; }
        public ObservableCollection<KeyValuePair<int, double>> bestAccuracyList { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            this.holdoutAccuracyList = new ObservableCollection<KeyValuePair<int, double>>();
            this.holdoutAccuracyList.Add(new KeyValuePair<int, double>(0, 0.0));
            ((LineSeries)accuracyChart.Series[0]).ItemsSource = this.holdoutAccuracyList;

            this.trainAccuracyList = new ObservableCollection<KeyValuePair<int, double>>();
            this.trainAccuracyList.Add(new KeyValuePair<int, double>(0, 0.0));
            ((LineSeries)accuracyChart.Series[1]).ItemsSource = this.trainAccuracyList;

            this.bestAccuracyList = new ObservableCollection<KeyValuePair<int, double>>();
            this.bestAccuracyList.Add(new KeyValuePair<int, double>(0, 0.0));
            ((LineSeries)accuracyChart.Series[2]).ItemsSource = this.bestAccuracyList;
            fileTextBox.Text = "C:\\Users\\Vince\\Documents\\Dropbox\\Dev\\Neural Network\\iris_converted_normalized.csv";
           // (LineSeries)accuracyChart.Axes.
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void fileButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "CSV (.csv)|*.csv|Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                fileTextBox.Text = filename;
            }
        }

        private void trainButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = fileTextBox.Text;
            bool header = (bool)headerCheckbox.IsChecked;
            trainButton.IsEnabled = false;
            System.Threading.Thread newThread;
            newThread = new System.Threading.Thread(
                delegate()
                {
                    logTextBlock.Dispatcher.Invoke(
                        DispatcherPriority.Normal,
                        new Action(
                            delegate()
                            {
                                logTextBlock.AppendText("Initializing file: " + fileTextBox.Text + "\n");
                            }
                        )
                    );

                    int inputs = 4;
                    int outputs = 3;
                    TextDataSource dataSource = new TextDataSource(
                        fileName,
                       inputs,
                       outputs,
                       header
                    );
                    dataSource.setValidationMode(ValidationMode.KFold, 4);
                    dataSource.loadData();
                    BasicNetwork nn = new BasicNetwork(inputs, outputs, 10);
                    BackPropogation trainer = new BackPropogation(nn);
                    trainer.epochIterationComplete += new Trainer.EpochIterationComplete(trainer_epochIterationComplete);
                    trainer.train(dataSource);
                    trainButton.Dispatcher.Invoke(
                        DispatcherPriority.Normal,
                        new Action(
                            delegate()
                            {
                                trainButton.IsEnabled = true;
                            }
                        )
                    );
                }
            );
            newThread.Start();
        }

        private void trainer_epochIterationComplete(Trainer trainer, EventArgs e)
        {
            
            logTextBlock.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                new Action(
                    delegate()
                    {
                        logTextBlock.AppendText(trainer.currentLogLine + "\n");
                        logTextBlock.ScrollToEnd();
                        if (trainer.getEpochs() % 10 == 0)
                        {
                            holdoutAccuracyList.Add(new KeyValuePair<int, double>(trainer.getEpochs(), trainer.ValidationAccuracy));
                            trainAccuracyList.Add(new KeyValuePair<int, double>(trainer.getEpochs(), trainer.TrainingAccuracy));
                            bestAccuracyList.Add(new KeyValuePair<int, double>(trainer.getEpochs(), trainer.BestAccuracy));
                        }
                    }
                )
            );
           //(LineSeries) accuracyChart.Series[0].

        }

        private void headerCheckbox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
