namespace Lab4
{
    partial class Form1
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxQueue1 = new System.Windows.Forms.TextBox();
            this.textBoxQueue2 = new System.Windows.Forms.TextBox();
            this.labelQueue1 = new System.Windows.Forms.Label();
            this.labelQueue2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(208, 366);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxQueue1
            // 
            this.textBoxQueue1.Location = new System.Drawing.Point(287, 233);
            this.textBoxQueue1.Name = "textBoxQueue1";
            this.textBoxQueue1.Size = new System.Drawing.Size(100, 20);
            this.textBoxQueue1.TabIndex = 1;
            // 
            // textBoxQueue2
            // 
            this.textBoxQueue2.Location = new System.Drawing.Point(634, 233);
            this.textBoxQueue2.Name = "textBoxQueue2";
            this.textBoxQueue2.Size = new System.Drawing.Size(100, 20);
            this.textBoxQueue2.TabIndex = 2;
            // 
            // labelQueue1
            // 
            this.labelQueue1.AutoSize = true;
            this.labelQueue1.Location = new System.Drawing.Point(205, 240);
            this.labelQueue1.Name = "labelQueue1";
            this.labelQueue1.Size = new System.Drawing.Size(45, 13);
            this.labelQueue1.TabIndex = 3;
            this.labelQueue1.Text = "Queue1";
            // 
            // labelQueue2
            // 
            this.labelQueue2.AutoSize = true;
            this.labelQueue2.Location = new System.Drawing.Point(565, 240);
            this.labelQueue2.Name = "labelQueue2";
            this.labelQueue2.Size = new System.Drawing.Size(45, 13);
            this.labelQueue2.TabIndex = 4;
            this.labelQueue2.Text = "Queue2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 558);
            this.Controls.Add(this.labelQueue2);
            this.Controls.Add(this.labelQueue1);
            this.Controls.Add(this.textBoxQueue2);
            this.Controls.Add(this.textBoxQueue1);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxQueue1;
        private System.Windows.Forms.TextBox textBoxQueue2;
        private System.Windows.Forms.Label labelQueue1;
        private System.Windows.Forms.Label labelQueue2;
    }
}

