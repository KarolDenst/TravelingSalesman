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
            this.runButton = new System.Windows.Forms.Button();
            this.mutationComboBox = new System.Windows.Forms.ComboBox();
            this.matingComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.runButton);
            this.groupBox1.Controls.Add(this.mutationComboBox);
            this.groupBox1.Controls.Add(this.matingComboBox);
            this.groupBox1.Location = new System.Drawing.Point(825, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 175);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(70, 126);
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
            this.mutationComboBox.Location = new System.Drawing.Point(27, 80);
            this.mutationComboBox.Name = "mutationComboBox";
            this.mutationComboBox.Size = new System.Drawing.Size(151, 28);
            this.mutationComboBox.TabIndex = 1;
            // 
            // matingComboBox
            // 
            this.matingComboBox.FormattingEnabled = true;
            this.matingComboBox.Location = new System.Drawing.Point(29, 31);
            this.matingComboBox.Name = "matingComboBox";
            this.matingComboBox.Size = new System.Drawing.Size(151, 28);
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
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox canvas;
        private GroupBox groupBox1;
        private ComboBox mutationComboBox;
        private ComboBox matingComboBox;
        private Button runButton;
    }
}