namespace Gold_Testing_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            progressBar1 = new ProgressBar();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(121, 614);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(667, 35);
            progressBar1.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Gadugi", 10F, FontStyle.Bold);
            label3.Location = new Point(361, 222);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 7;
            label3.Text = "developed by";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Gadugi", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(305, 146);
            label1.Name = "label1";
            label1.Size = new Size(262, 36);
            label1.TabIndex = 6;
            label1.Text = "Gold Testing App";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Gadugi", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 275);
            label2.Name = "label2";
            label2.Size = new Size(342, 40);
            label2.TabIndex = 5;
            label2.Text = "Rushikesh B. Chavan";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Gadugi", 10F, FontStyle.Bold);
            label4.Location = new Point(387, 439);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 8;
            label4.Text = "7756065160";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Gadugi", 10F, FontStyle.Bold);
            label5.Location = new Point(323, 376);
            label5.Name = "label5";
            label5.Size = new Size(244, 20);
            label5.TabIndex = 9;
            label5.Text = "chavanrushi1246@gmail.com";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Aqua;
            ClientSize = new Size(916, 661);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gold Testing App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
    }
}
