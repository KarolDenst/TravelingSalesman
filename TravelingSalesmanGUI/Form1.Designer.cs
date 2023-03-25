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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.mutationProbUpDown = new System.Windows.Forms.NumericUpDown();
            this.matingProbUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxIterationUpDown = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.populationUpDown = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.mutationComboBox = new System.Windows.Forms.ComboBox();
            this.matingComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProbUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matingProbUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1020, 568);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Controls.Add(this.resetButton);
            this.groupBox1.Controls.Add(this.mutationProbUpDown);
            this.groupBox1.Controls.Add(this.matingProbUpDown);
            this.groupBox1.Controls.Add(this.maxIterationUpDown);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.populationUpDown);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.runButton);
            this.groupBox1.Controls.Add(this.mutationComboBox);
            this.groupBox1.Controls.Add(this.matingComboBox);
            this.groupBox1.Location = new System.Drawing.Point(804, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 304);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(6, 267);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(198, 27);
            this.resultTextBox.TabIndex = 12;
            this.resultTextBox.Text = "Result:";
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(113, 232);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(94, 29);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // mutationProbUpDown
            // 
            this.mutationProbUpDown.DecimalPlaces = 2;
            this.mutationProbUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.mutationProbUpDown.Location = new System.Drawing.Point(138, 199);
            this.mutationProbUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mutationProbUpDown.Name = "mutationProbUpDown";
            this.mutationProbUpDown.Size = new System.Drawing.Size(69, 27);
            this.mutationProbUpDown.TabIndex = 10;
            this.mutationProbUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // matingProbUpDown
            // 
            this.matingProbUpDown.DecimalPlaces = 2;
            this.matingProbUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.matingProbUpDown.Location = new System.Drawing.Point(138, 166);
            this.matingProbUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.matingProbUpDown.Name = "matingProbUpDown";
            this.matingProbUpDown.Size = new System.Drawing.Size(69, 27);
            this.matingProbUpDown.TabIndex = 9;
            this.matingProbUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // maxIterationUpDown
            // 
            this.maxIterationUpDown.Location = new System.Drawing.Point(138, 133);
            this.maxIterationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxIterationUpDown.Name = "maxIterationUpDown";
            this.maxIterationUpDown.Size = new System.Drawing.Size(69, 27);
            this.maxIterationUpDown.TabIndex = 8;
            this.maxIterationUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 199);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 27);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "Mutation Prob";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 166);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(125, 27);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Mating Prob";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 133);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Max Iterations";
            // 
            // populationUpDown
            // 
            this.populationUpDown.Location = new System.Drawing.Point(138, 100);
            this.populationUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.populationUpDown.Name = "populationUpDown";
            this.populationUpDown.Size = new System.Drawing.Size(69, 27);
            this.populationUpDown.TabIndex = 4;
            this.populationUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Population Size";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(6, 232);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(94, 29);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // mutationComboBox
            // 
            this.mutationComboBox.FormattingEnabled = true;
            this.mutationComboBox.Location = new System.Drawing.Point(6, 65);
            this.mutationComboBox.Name = "mutationComboBox";
            this.mutationComboBox.Size = new System.Drawing.Size(201, 28);
            this.mutationComboBox.TabIndex = 1;
            // 
            // matingComboBox
            // 
            this.matingComboBox.FormattingEnabled = true;
            this.matingComboBox.Location = new System.Drawing.Point(6, 31);
            this.matingComboBox.Name = "matingComboBox";
            this.matingComboBox.Size = new System.Drawing.Size(201, 28);
            this.matingComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProbUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matingProbUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationUpDown)).EndInit();
            this.ResumeLayout(false);

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
    }
}