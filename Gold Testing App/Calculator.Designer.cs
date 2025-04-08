namespace Gold_Testing_App
{
    partial class Calculator
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
            panelCal = new Panel();
            btnDiv = new Button();
            btnInvert = new Button();
            btnCut = new Button();
            btnClr = new Button();
            btnResult = new Button();
            btnDot = new Button();
            btn0 = new Button();
            btnMod = new Button();
            btnAdd = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            btnSub = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btnMul = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            textBoxResult = new TextBox();
            label1 = new Label();
            panelCal.SuspendLayout();
            SuspendLayout();
            // 
            // panelCal
            // 
            panelCal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCal.BorderStyle = BorderStyle.FixedSingle;
            panelCal.Controls.Add(btnDiv);
            panelCal.Controls.Add(btnInvert);
            panelCal.Controls.Add(btnCut);
            panelCal.Controls.Add(btnClr);
            panelCal.Controls.Add(btnResult);
            panelCal.Controls.Add(btnDot);
            panelCal.Controls.Add(btn0);
            panelCal.Controls.Add(btnMod);
            panelCal.Controls.Add(btnAdd);
            panelCal.Controls.Add(btn3);
            panelCal.Controls.Add(btn2);
            panelCal.Controls.Add(btn1);
            panelCal.Controls.Add(btnSub);
            panelCal.Controls.Add(btn6);
            panelCal.Controls.Add(btn5);
            panelCal.Controls.Add(btn4);
            panelCal.Controls.Add(btnMul);
            panelCal.Controls.Add(btn9);
            panelCal.Controls.Add(btn8);
            panelCal.Controls.Add(btn7);
            panelCal.Controls.Add(textBoxResult);
            panelCal.Location = new Point(109, 77);
            panelCal.Name = "panelCal";
            panelCal.Size = new Size(457, 642);
            panelCal.TabIndex = 0;
            // 
            // btnDiv
            // 
            btnDiv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDiv.BackColor = Color.FromArgb(192, 255, 255);
            btnDiv.Cursor = Cursors.Hand;
            btnDiv.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnDiv.Location = new Point(340, 142);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(65, 57);
            btnDiv.TabIndex = 20;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = false;
            btnDiv.Click += btnDiv_Click;
            // 
            // btnInvert
            // 
            btnInvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnInvert.BackColor = Color.FromArgb(192, 255, 255);
            btnInvert.Cursor = Cursors.Hand;
            btnInvert.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnInvert.Location = new Point(244, 142);
            btnInvert.Name = "btnInvert";
            btnInvert.Size = new Size(65, 57);
            btnInvert.TabIndex = 19;
            btnInvert.Text = "+/-";
            btnInvert.UseVisualStyleBackColor = false;
            btnInvert.Click += btnInvert_Click;
            // 
            // btnCut
            // 
            btnCut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCut.BackColor = Color.FromArgb(255, 192, 128);
            btnCut.Cursor = Cursors.Hand;
            btnCut.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnCut.Location = new Point(146, 142);
            btnCut.Name = "btnCut";
            btnCut.Size = new Size(65, 57);
            btnCut.TabIndex = 18;
            btnCut.Text = "Cut";
            btnCut.UseVisualStyleBackColor = false;
            btnCut.Click += btnCut_Click;
            // 
            // btnClr
            // 
            btnClr.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClr.BackColor = Color.FromArgb(255, 128, 128);
            btnClr.Cursor = Cursors.Hand;
            btnClr.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnClr.Location = new Point(54, 142);
            btnClr.Name = "btnClr";
            btnClr.Size = new Size(65, 57);
            btnClr.TabIndex = 17;
            btnClr.Text = "AC";
            btnClr.UseVisualStyleBackColor = false;
            btnClr.Click += btnClr_Click;
            // 
            // btnResult
            // 
            btnResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnResult.BackColor = Color.FromArgb(192, 255, 192);
            btnResult.Cursor = Cursors.Hand;
            btnResult.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnResult.Location = new Point(340, 502);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(65, 57);
            btnResult.TabIndex = 16;
            btnResult.Text = "=";
            btnResult.UseVisualStyleBackColor = false;
            btnResult.Click += btnResult_Click;
            // 
            // btnDot
            // 
            btnDot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDot.BackColor = Color.FromArgb(192, 255, 255);
            btnDot.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnDot.Location = new Point(244, 502);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(65, 57);
            btnDot.TabIndex = 15;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = false;
            btnDot.Click += btnDot_Click;
            // 
            // btn0
            // 
            btn0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn0.BackColor = SystemColors.GradientInactiveCaption;
            btn0.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn0.Location = new Point(146, 502);
            btn0.Name = "btn0";
            btn0.Size = new Size(65, 57);
            btn0.TabIndex = 14;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = false;
            btn0.Click += btn0_Click;
            // 
            // btnMod
            // 
            btnMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnMod.BackColor = Color.FromArgb(192, 255, 255);
            btnMod.Cursor = Cursors.Hand;
            btnMod.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnMod.Location = new Point(54, 502);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(65, 57);
            btnMod.TabIndex = 13;
            btnMod.Text = "%";
            btnMod.UseVisualStyleBackColor = false;
            btnMod.Click += btnMod_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(192, 255, 255);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnAdd.Location = new Point(340, 408);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(65, 57);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btn3
            // 
            btn3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn3.BackColor = SystemColors.GradientInactiveCaption;
            btn3.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn3.Location = new Point(244, 408);
            btn3.Name = "btn3";
            btn3.Size = new Size(65, 57);
            btn3.TabIndex = 11;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn2.BackColor = SystemColors.GradientInactiveCaption;
            btn2.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn2.Location = new Point(146, 408);
            btn2.Name = "btn2";
            btn2.Size = new Size(65, 57);
            btn2.TabIndex = 10;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn1.BackColor = SystemColors.GradientInactiveCaption;
            btn1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn1.Location = new Point(54, 408);
            btn1.Name = "btn1";
            btn1.Size = new Size(65, 57);
            btn1.TabIndex = 9;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // btnSub
            // 
            btnSub.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSub.BackColor = Color.FromArgb(192, 255, 255);
            btnSub.Cursor = Cursors.Hand;
            btnSub.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnSub.Location = new Point(340, 313);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(65, 57);
            btnSub.TabIndex = 8;
            btnSub.Text = "-";
            btnSub.UseVisualStyleBackColor = false;
            btnSub.Click += btnSub_Click;
            // 
            // btn6
            // 
            btn6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn6.BackColor = SystemColors.GradientInactiveCaption;
            btn6.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn6.Location = new Point(244, 313);
            btn6.Name = "btn6";
            btn6.Size = new Size(65, 57);
            btn6.TabIndex = 7;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = false;
            btn6.Click += btn6_Click;
            // 
            // btn5
            // 
            btn5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn5.BackColor = SystemColors.GradientInactiveCaption;
            btn5.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn5.Location = new Point(146, 313);
            btn5.Name = "btn5";
            btn5.Size = new Size(65, 57);
            btn5.TabIndex = 6;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = false;
            btn5.Click += btn5_Click;
            // 
            // btn4
            // 
            btn4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn4.BackColor = SystemColors.GradientInactiveCaption;
            btn4.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn4.Location = new Point(54, 313);
            btn4.Name = "btn4";
            btn4.Size = new Size(65, 57);
            btn4.TabIndex = 5;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = false;
            btn4.Click += btn4_Click;
            // 
            // btnMul
            // 
            btnMul.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnMul.BackColor = Color.FromArgb(192, 255, 255);
            btnMul.Cursor = Cursors.Hand;
            btnMul.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btnMul.Location = new Point(340, 225);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(65, 57);
            btnMul.TabIndex = 4;
            btnMul.Text = "*";
            btnMul.UseVisualStyleBackColor = false;
            btnMul.Click += btnMul_Click;
            // 
            // btn9
            // 
            btn9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn9.BackColor = SystemColors.GradientInactiveCaption;
            btn9.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn9.Location = new Point(244, 225);
            btn9.Name = "btn9";
            btn9.Size = new Size(65, 57);
            btn9.TabIndex = 3;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = false;
            btn9.Click += btn9_Click;
            // 
            // btn8
            // 
            btn8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn8.BackColor = SystemColors.GradientInactiveCaption;
            btn8.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn8.Location = new Point(146, 225);
            btn8.Name = "btn8";
            btn8.Size = new Size(65, 57);
            btn8.TabIndex = 2;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = false;
            btn8.Click += btn8_Click;
            // 
            // btn7
            // 
            btn7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn7.BackColor = SystemColors.GradientInactiveCaption;
            btn7.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            btn7.Location = new Point(54, 225);
            btn7.Name = "btn7";
            btn7.Size = new Size(65, 57);
            btn7.TabIndex = 1;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = false;
            btn7.Click += btn7_Click;
            // 
            // textBoxResult
            // 
            textBoxResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxResult.Cursor = Cursors.No;
            textBoxResult.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxResult.Location = new Point(54, 48);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ReadOnly = true;
            textBoxResult.Size = new Size(351, 38);
            textBoxResult.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(268, 21);
            label1.Name = "label1";
            label1.Size = new Size(149, 38);
            label1.TabIndex = 1;
            label1.Text = "Calculator";
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(708, 791);
            Controls.Add(label1);
            Controls.Add(panelCal);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Calculator";
            Text = "Calculator";
            panelCal.ResumeLayout(false);
            panelCal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCal;
        private TextBox textBoxResult;
        private Button btnResult;
        private Button btnDot;
        private Button btn0;
        private Button btnMod;
        private Button btnAdd;
        private Button btn3;
        private Button btn2;
        private Button btn1;
        private Button btnSub;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btnMul;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btnDiv;
        private Button btnInvert;
        private Button btnCut;
        private Button btnClr;
        private Label label1;
    }
}