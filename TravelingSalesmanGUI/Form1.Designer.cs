namespace TravelingSalesmanGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            canvas = new PictureBox();
            groupBox1 = new GroupBox();
            plotCheckBox = new CheckBox();
            resultTextBox = new TextBox();
            resetButton = new Button();
            mutationProbUpDown = new NumericUpDown();
            matingProbUpDown = new NumericUpDown();
            maxIterationUpDown = new NumericUpDown();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            populationUpDown = new NumericUpDown();
            textBox1 = new TextBox();
            runButton = new Button();
            mutationComboBox = new ComboBox();
            matingComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mutationProbUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matingProbUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxIterationUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)populationUpDown).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(1020, 568);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.MouseClick += canvas_MouseClick;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(plotCheckBox);
            groupBox1.Controls.Add(resultTextBox);
            groupBox1.Controls.Add(resetButton);
            groupBox1.Controls.Add(mutationProbUpDown);
            groupBox1.Controls.Add(matingProbUpDown);
            groupBox1.Controls.Add(maxIterationUpDown);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(populationUpDown);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(runButton);
            groupBox1.Controls.Add(mutationComboBox);
            groupBox1.Controls.Add(matingComboBox);
            groupBox1.Location = new Point(804, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(216, 305);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // plotCheckBox
            // 
            plotCheckBox.AutoSize = true;
            plotCheckBox.Location = new Point(6, 269);
            plotCheckBox.Name = "plotCheckBox";
            plotCheckBox.Size = new Size(57, 24);
            plotCheckBox.TabIndex = 13;
            plotCheckBox.Text = "Plot";
            plotCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultTextBox
            // 
            resultTextBox.Enabled = false;
            resultTextBox.Location = new Point(69, 267);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(135, 27);
            resultTextBox.TabIndex = 12;
            resultTextBox.Text = "Result:";
            resultTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(113, 232);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(94, 29);
            resetButton.TabIndex = 11;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // mutationProbUpDown
            // 
            mutationProbUpDown.DecimalPlaces = 2;
            mutationProbUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            mutationProbUpDown.Location = new Point(138, 199);
            mutationProbUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            mutationProbUpDown.Name = "mutationProbUpDown";
            mutationProbUpDown.Size = new Size(69, 27);
            mutationProbUpDown.TabIndex = 10;
            mutationProbUpDown.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // matingProbUpDown
            // 
            matingProbUpDown.DecimalPlaces = 2;
            matingProbUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            matingProbUpDown.Location = new Point(138, 166);
            matingProbUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            matingProbUpDown.Name = "matingProbUpDown";
            matingProbUpDown.Size = new Size(69, 27);
            matingProbUpDown.TabIndex = 9;
            matingProbUpDown.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            // 
            // maxIterationUpDown
            // 
            maxIterationUpDown.Location = new Point(138, 133);
            maxIterationUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            maxIterationUpDown.Name = "maxIterationUpDown";
            maxIterationUpDown.Size = new Size(69, 27);
            maxIterationUpDown.TabIndex = 8;
            maxIterationUpDown.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 199);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            textBox4.Text = "Mutation Prob";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 166);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            textBox3.Text = "Mating Prob";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            textBox2.Text = "Max Iterations";
            // 
            // populationUpDown
            // 
            populationUpDown.Location = new Point(138, 100);
            populationUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            populationUpDown.Name = "populationUpDown";
            populationUpDown.Size = new Size(69, 27);
            populationUpDown.TabIndex = 4;
            populationUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "Population Size";
            // 
            // runButton
            // 
            runButton.Location = new Point(6, 232);
            runButton.Name = "runButton";
            runButton.Size = new Size(94, 29);
            runButton.TabIndex = 2;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // mutationComboBox
            // 
            mutationComboBox.FormattingEnabled = true;
            mutationComboBox.Location = new Point(6, 65);
            mutationComboBox.Name = "mutationComboBox";
            mutationComboBox.Size = new Size(201, 28);
            mutationComboBox.TabIndex = 1;
            // 
            // matingComboBox
            // 
            matingComboBox.FormattingEnabled = true;
            matingComboBox.Location = new Point(6, 31);
            matingComboBox.Name = "matingComboBox";
            matingComboBox.Size = new Size(201, 28);
            matingComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 568);
            Controls.Add(groupBox1);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mutationProbUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)matingProbUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxIterationUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)populationUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox canvas;
        private GroupBox groupBox1;
        private ComboBox mutationComboBox;
        private ComboBox matingComboBox;
        private Button runButton;
        private NumericUpDown populationUpDown;
        private TextBox textBox1;
        private TextBox textBox2;
        private NumericUpDown mutationProbUpDown;
        private NumericUpDown matingProbUpDown;
        private NumericUpDown maxIterationUpDown;
        private TextBox textBox4;
        private TextBox textBox3;
        private Button resetButton;
        private TextBox resultTextBox;
        private CheckBox plotCheckBox;
    }
}