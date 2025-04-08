using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gold_Testing_App
{
    public partial class Calculator : Form
    {
        private double result;
        private double num1;
        private double num2;
        private string res;
        private string operation;
        private string val;

        public Calculator()
        {
            InitializeComponent();
            res = string.Empty;
            operation = string.Empty;
            val = string.Empty;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            val = val + 1;
            textBoxResult.Text = val;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            val = val + 2;
            textBoxResult.Text = val;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            val = val + 3;
            textBoxResult.Text = val;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            val = val + 4;
            textBoxResult.Text = val;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            val = val + 5;
            textBoxResult.Text = val;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            val = val + 6;
            textBoxResult.Text = val;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            val = val + 7;
            textBoxResult.Text = val;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            val = val + 8;
            textBoxResult.Text = val;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            val = val + 9;
            textBoxResult.Text = val;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            val = val + 0;
            textBoxResult.Text = val;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            val = val + '.';
            textBoxResult.Text = val;
        }
        private void btnClr_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            num1 = 0;
            num2 = 0;
            result = 0;
            res = "";
            operation = "";
            val = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(val);
            val = "";
            operation = "+";
            textBoxResult.Text = "";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(val);
            val = "";
            operation = "-";
            textBoxResult.Text = "";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(val);
            val = "";
            operation = "*";
            textBoxResult.Text = "";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(val);
            val = "";
            operation = "/";
            textBoxResult.Text = "";
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            num1 = -1 * (Convert.ToDouble(val));
            val = "" + num1;
            textBoxResult.Text = val;
            //operation = "+";
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(val);
            val = "";
            operation = "%";
            textBoxResult.Text = "";
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(val))
            {
                val = val.Substring(0, val.Length - 1);
                textBoxResult.Text = val;
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(val))
                {
                    num2 = Convert.ToDouble(val);

                    switch (operation)
                    {
                    case "+":
                        result = num1 + num2;
                        res = "" + result;
                        textBoxResult.Text = res;
                        val = res;
                        break;
                    case "-":
                        result = num1 - num2;
                        res = "" + result;
                        textBoxResult.Text = res;
                        val = res;
                        break;
                    case "/":
                        result = num1 / num2;
                        res = "" + result;
                        textBoxResult.Text = res;
                        val = res;
                        break;
                    case "*":
                        result = num1 * num2;
                        res = "" + result;
                        textBoxResult.Text = res;
                        val = res;
                        break;
                    case "%":
                        result = num1 % num2;
                        res = "" + result;
                        textBoxResult.Text = res;
                        val = res;
                        break;
                    }
                
                }
                else
                {
                    MessageBox.Show("Enter a number first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //textBoxResult.Text = "";
            num1 = result;
            num2 = 0;
            result = 0;
            res = "";
            operation = "";
            //val = "";
        }
       
    }
}
