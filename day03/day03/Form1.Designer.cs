namespace day03
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
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(357, 262);
            button2.Name = "button2";
            button2.Size = new Size(27, 29);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
           
            // 
            // button1
            // 
            button1.Location = new Point(227, 262);
            button1.Name = "button1";
            button1.Size = new Size(26, 29);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            
            // 
            // button3
            // 
            button3.Location = new Point(472, 262);
            button3.Name = "button3";
            button3.Size = new Size(32, 29);
            button3.TabIndex = 1;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(79, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(594, 253);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(639, 166);
            label1.Name = "label1";
            label1.Size = new Size(34, 33);
            label1.TabIndex = 3;
            label1.Text = ">";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(79, 166);
            label2.Name = "label2";
            label2.Size = new Size(34, 33);
            label2.TabIndex = 4;
            label2.Text = "<";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private Button button3;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}
