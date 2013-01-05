namespace VStatsInterface
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modelSelectBox = new System.Windows.Forms.ComboBox();
            this.trainStartButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileOpenButton = new System.Windows.Forms.Button();
            this.logWindow = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modelOptionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.fileOptionTabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerCheckbox = new System.Windows.Forms.CheckBox();
            this.numberOutputsLabel = new System.Windows.Forms.Label();
            this.numericIn = new System.Windows.Forms.NumericUpDown();
            this.numericOut = new System.Windows.Forms.NumericUpDown();
            this.numInputsLabel = new System.Windows.Forms.Label();
            this.fileHeaderLabel = new System.Windows.Forms.Label();
            this.fileNameText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.modelOptionsTableLayout.SuspendLayout();
            this.fileOptionTabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOut)).BeginInit();
            this.SuspendLayout();
            // 
            // modelSelectBox
            // 
            this.modelSelectBox.FormattingEnabled = true;
            this.modelSelectBox.Location = new System.Drawing.Point(52, 73);
            this.modelSelectBox.Name = "modelSelectBox";
            this.modelSelectBox.Size = new System.Drawing.Size(121, 21);
            this.modelSelectBox.TabIndex = 0;
            // 
            // trainStartButton
            // 
            this.trainStartButton.Location = new System.Drawing.Point(607, 66);
            this.trainStartButton.Name = "trainStartButton";
            this.trainStartButton.Size = new System.Drawing.Size(75, 23);
            this.trainStartButton.TabIndex = 1;
            this.trainStartButton.Text = "Train Model";
            this.trainStartButton.UseVisualStyleBackColor = true;
            this.trainStartButton.Click += new System.EventHandler(this.trainStartButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openDataFile_Click);
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(274, 12);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(75, 23);
            this.fileOpenButton.TabIndex = 2;
            this.fileOpenButton.Text = "Select File";
            this.fileOpenButton.UseVisualStyleBackColor = true;
            this.fileOpenButton.Click += new System.EventHandler(this.openModel_Click);
            // 
            // logWindow
            // 
            this.logWindow.Location = new System.Drawing.Point(27, 219);
            this.logWindow.Name = "logWindow";
            this.logWindow.Size = new System.Drawing.Size(747, 198);
            this.logWindow.TabIndex = 4;
            this.logWindow.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.modelOptionsTableLayout);
            this.panel1.Controls.Add(this.fileOptionTabelPanel);
            this.panel1.Controls.Add(this.fileNameText);
            this.panel1.Controls.Add(this.fileOpenButton);
            this.panel1.Controls.Add(this.trainStartButton);
            this.panel1.Location = new System.Drawing.Point(27, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 140);
            this.panel1.TabIndex = 5;
            this.panel1.Tag = "";
            // 
            // modelOptionsTableLayout
            // 
            this.modelOptionsTableLayout.ColumnCount = 2;
            this.modelOptionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.modelOptionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.modelOptionsTableLayout.Controls.Add(this.comboBox2, 1, 1);
            this.modelOptionsTableLayout.Controls.Add(this.comboBox1, 1, 0);
            this.modelOptionsTableLayout.Location = new System.Drawing.Point(401, 37);
            this.modelOptionsTableLayout.Name = "modelOptionsTableLayout";
            this.modelOptionsTableLayout.RowCount = 2;
            this.modelOptionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.modelOptionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.modelOptionsTableLayout.Size = new System.Drawing.Size(200, 100);
            this.modelOptionsTableLayout.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(94, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // fileOptionTabelPanel
            // 
            this.fileOptionTabelPanel.ColumnCount = 2;
            this.fileOptionTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.5F));
            this.fileOptionTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.5F));
            this.fileOptionTabelPanel.Controls.Add(this.headerCheckbox, 0, 0);
            this.fileOptionTabelPanel.Controls.Add(this.numberOutputsLabel, 1, 2);
            this.fileOptionTabelPanel.Controls.Add(this.numericIn, 0, 1);
            this.fileOptionTabelPanel.Controls.Add(this.numericOut, 0, 2);
            this.fileOptionTabelPanel.Controls.Add(this.numInputsLabel, 1, 1);
            this.fileOptionTabelPanel.Controls.Add(this.fileHeaderLabel, 1, 0);
            this.fileOptionTabelPanel.Location = new System.Drawing.Point(14, 47);
            this.fileOptionTabelPanel.Name = "fileOptionTabelPanel";
            this.fileOptionTabelPanel.RowCount = 3;
            this.fileOptionTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fileOptionTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fileOptionTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.fileOptionTabelPanel.Size = new System.Drawing.Size(194, 73);
            this.fileOptionTabelPanel.TabIndex = 9;
            // 
            // headerCheckbox
            // 
            this.headerCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerCheckbox.AutoSize = true;
            this.headerCheckbox.Location = new System.Drawing.Point(31, 3);
            this.headerCheckbox.Name = "headerCheckbox";
            this.headerCheckbox.Size = new System.Drawing.Size(15, 18);
            this.headerCheckbox.TabIndex = 4;
            this.headerCheckbox.UseVisualStyleBackColor = true;
            // 
            // numberOutputsLabel
            // 
            this.numberOutputsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numberOutputsLabel.AutoSize = true;
            this.numberOutputsLabel.Location = new System.Drawing.Point(52, 54);
            this.numberOutputsLabel.Name = "numberOutputsLabel";
            this.numberOutputsLabel.Size = new System.Drawing.Size(96, 13);
            this.numberOutputsLabel.TabIndex = 8;
            this.numberOutputsLabel.Text = "Number of Outputs";
            this.numberOutputsLabel.Click += new System.EventHandler(this.numberOutputsLabel_Click);
            // 
            // numericIn
            // 
            this.numericIn.Location = new System.Drawing.Point(3, 27);
            this.numericIn.Name = "numericIn";
            this.numericIn.Size = new System.Drawing.Size(43, 20);
            this.numericIn.TabIndex = 5;
            // 
            // numericOut
            // 
            this.numericOut.Location = new System.Drawing.Point(3, 51);
            this.numericOut.Name = "numericOut";
            this.numericOut.Size = new System.Drawing.Size(43, 20);
            this.numericOut.TabIndex = 6;
            // 
            // numInputsLabel
            // 
            this.numInputsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numInputsLabel.AutoSize = true;
            this.numInputsLabel.Location = new System.Drawing.Point(52, 29);
            this.numInputsLabel.Name = "numInputsLabel";
            this.numInputsLabel.Size = new System.Drawing.Size(88, 13);
            this.numInputsLabel.TabIndex = 7;
            this.numInputsLabel.Text = "Number of Inputs";
            // 
            // fileHeaderLabel
            // 
            this.fileHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileHeaderLabel.AutoSize = true;
            this.fileHeaderLabel.Location = new System.Drawing.Point(52, 5);
            this.fileHeaderLabel.Name = "fileHeaderLabel";
            this.fileHeaderLabel.Size = new System.Drawing.Size(86, 13);
            this.fileHeaderLabel.TabIndex = 9;
            this.fileHeaderLabel.Text = "File Header Row";
            // 
            // fileNameText
            // 
            this.fileNameText.Location = new System.Drawing.Point(14, 12);
            this.fileNameText.Name = "fileNameText";
            this.fileNameText.ReadOnly = true;
            this.fileNameText.Size = new System.Drawing.Size(254, 20);
            this.fileNameText.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logWindow);
            this.Controls.Add(this.modelSelectBox);
            this.Name = "MainForm";
            this.Tag = "File";
            this.Text = "VStats - Machine Learning";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.modelOptionsTableLayout.ResumeLayout(false);
            this.fileOptionTabelPanel.ResumeLayout(false);
            this.fileOptionTabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox modelSelectBox;
        private System.Windows.Forms.Button trainStartButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button fileOpenButton;
        private System.Windows.Forms.RichTextBox logWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox headerCheckbox;
        private System.Windows.Forms.TextBox fileNameText;
        private System.Windows.Forms.Label numberOutputsLabel;
        private System.Windows.Forms.Label numInputsLabel;
        private System.Windows.Forms.NumericUpDown numericOut;
        private System.Windows.Forms.NumericUpDown numericIn;
        private System.Windows.Forms.TableLayoutPanel fileOptionTabelPanel;
        private System.Windows.Forms.Label fileHeaderLabel;
        private System.Windows.Forms.TableLayoutPanel modelOptionsTableLayout;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

