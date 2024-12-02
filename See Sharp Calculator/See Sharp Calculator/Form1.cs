using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace See_Sharp_Calculator
{
    public partial class Form1 : Form
    {

        double ans, temp;
        String op;
        bool firstNumber=true, alreadyhaveoperation=false,operationlastclicked=false,equallastclicked=false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 7;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 0;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }


            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (!textDisplay.Text.Contains("."))
            {
                if (textDisplay.Text == "0")
                {
                    textDisplay.Text = "0.";
                }
                else
                {
                    textDisplay.Text = textDisplay.Text + ".";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(textDisplay.Text.Length == 1)
            {
                textDisplay.Text = "0";
            }
            else
            {
                textDisplay.Text = textDisplay.Text.Substring(0, textDisplay.Text.Length - 1);
            }
            if (textDisplay.Text == "-")
            {
                textDisplay.Text = "0";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 9;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 6;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (equallastclicked)
            {
                equallastclicked = false;
                textDisplay.Text = "0";
                ans = 0;
                op = "";
                firstNumber = true;
            }
            if (operationlastclicked)
            {
                operationlastclicked = false;
                textDisplay.Text = "0";
            }
            if (textDisplay.Text == "0")
            {
                textDisplay.Text = "";
            }
            textDisplay.Text = textDisplay.Text + 3;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ans = 0;
            firstNumber = true;
            alreadyhaveoperation = false;
            operationlastclicked = false;
            equallastclicked = false;
            op = "";
            textDisplay.Text = "0";
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (firstNumber)
            {
                ans = double.Parse(textDisplay.Text);
                firstNumber = false;
            }
            else
            {
                if (equallastclicked)
                {
                    equallastclicked = false;
                    operationlastclicked = true;
                }
                else if (!operationlastclicked)
                {
                    if (op == "+")
                    {
                        ans = ans + double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "-")
                    {
                        ans = ans - double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "*")
                    {
                        ans = ans * double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "/")
                    {
                        ans = ans / double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                }
            }
            op = "-";
            operationlastclicked = true;
            alreadyhaveoperation = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (firstNumber)
            {
                ans = double.Parse(textDisplay.Text);
                firstNumber = false;
            }
            else
            {
                if (equallastclicked)
                {
                    equallastclicked = false;
                    operationlastclicked = true;
                }
                else if (!operationlastclicked)
                {
                    if (op == "+")
                    {
                        ans = ans + double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "-")
                    {
                        ans = ans - double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "*")
                    {
                        ans = ans * double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "/")
                    {
                        ans = ans / double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                }
            }
            op = "*";
            operationlastclicked = true;
            alreadyhaveoperation = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (firstNumber)
            {
                ans = double.Parse(textDisplay.Text);
                firstNumber = false;
            }
            else
            {
                if (equallastclicked)
                {
                    equallastclicked = false;
                    operationlastclicked = true;
                }
                else if (!operationlastclicked)
                {
                    if (op == "+")
                    {
                        ans = ans + double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "-")
                    {
                        ans = ans - double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "*")
                    {
                        ans = ans * double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "/")
                    {
                        ans = ans / double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                }
            }
            op = "/";
            operationlastclicked = true;
            alreadyhaveoperation = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (!equallastclicked)
            {
                if (!textDisplay.Text.Contains("-"))
                {
                    if (!(textDisplay.Text == "0"))
                    {
                        textDisplay.Text = "-" + textDisplay.Text;
                    }
                }
                else if (textDisplay.Text.Contains("-"))
                {
                    textDisplay.Text = textDisplay.Text.Remove(0, 1);
                }
            }
        }

        private void btnClearEq_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!equallastclicked)
            {
                if (!operationlastclicked)
                {
                    if (op == "+")
                    {
                        ans = ans + double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "-")
                    {
                        ans = ans - double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "*")
                    {
                        ans = ans * double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "/")
                    {
                        ans = ans / double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                }
                else
                {
                    alreadyhaveoperation = false;
                }
                equallastclicked = true;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (firstNumber)
            {
                ans = double.Parse(textDisplay.Text);
                firstNumber = false;
            }
            else
            {
                if (equallastclicked)
                {
                    equallastclicked = false;
                    operationlastclicked = true;
                }
                else if (!operationlastclicked)
                {
                    if (op == "+")
                    {
                        ans = ans + double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "-")
                    {
                        ans = ans - double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "*")
                    {
                        ans = ans * double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                    if (op == "/")
                    {
                        ans = ans / double.Parse(textDisplay.Text);
                        textDisplay.Text = ans.ToString();
                    }
                }
            }
            op = "+";
            operationlastclicked = true;
            alreadyhaveoperation = true;
        }
    }
}
