namespace DemoMixer
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
            button1 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            checkBox1 = new CheckBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            label5 = new Label();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 137);
            button1.Name = "button1";
            button1.Size = new Size(218, 23);
            button1.TabIndex = 0;
            button1.Text = "Open File(s)...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(535, 49);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(188, 30);
            label1.TabIndex = 2;
            label1.Text = "Demo Audio Mixer";
            // 
            // button2
            // 
            button2.Location = new Point(12, 176);
            button2.Name = "button2";
            button2.Size = new Size(218, 23);
            button2.TabIndex = 3;
            button2.Text = "Play... (fade in at initial playback)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 214);
            button3.Name = "button3";
            button3.Size = new Size(218, 23);
            button3.TabIndex = 5;
            button3.Text = "Fade to Next";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 252);
            button4.Name = "button4";
            button4.Size = new Size(218, 23);
            button4.TabIndex = 4;
            button4.Text = "Stop with fade";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 290);
            button5.Name = "button5";
            button5.Size = new Size(218, 23);
            button5.TabIndex = 6;
            button5.Text = "Pause/Resume";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(249, 153);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(168, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Repeat Current Playing File";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 321);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(563, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(81, 17);
            toolStripStatusLabel1.Text = "Playing: None";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 252);
            label3.Name = "label3";
            label3.Size = new Size(212, 15);
            label3.TabIndex = 12;
            label3.Text = "Fade to next fade duration (in seconds)";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(511, 205);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(36, 23);
            numericUpDown2.TabIndex = 11;
            numericUpDown2.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 213);
            label4.Name = "label4";
            label4.Size = new Size(256, 15);
            label4.TabIndex = 14;
            label4.Text = "Crossfade between tracks duration (in seconds)";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(511, 244);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(36, 23);
            numericUpDown3.TabIndex = 13;
            numericUpDown3.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(511, 284);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(36, 23);
            numericUpDown4.TabIndex = 16;
            numericUpDown4.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(249, 292);
            label5.Name = "label5";
            label5.Size = new Size(198, 15);
            label5.TabIndex = 15;
            label5.Text = "Stop with fade duration (in seconds)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 343);
            Controls.Add(numericUpDown4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown3);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(statusStrip1);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Demo BASS Mixer Program";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private Label label5;
    }
}
