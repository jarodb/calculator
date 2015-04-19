using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {

        Double result = 0;
        String operation = "";
        bool operationPerformed = false;
        bool answer = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                button10.PerformClick();
            }
            operation = button.Text;
            result = Double.Parse(resultBox.Text);
            operationPerformed = true;
            label.Text = result + " " + operation;
            answer = false;

        }

        private void numButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultBox.Text == "0" || operationPerformed || answer)
            {
                resultBox.Clear();
                answer = false;
            }
            if (button.Text == ".")
            {
                if (!resultBox.Text.Contains("."))
                {
                    resultBox.Text = resultBox.Text + button.Text;
                }
            }
            else
            {
                resultBox.Text = resultBox.Text + button.Text;
            }
            operationPerformed = false;
            
        }

        private void clearEntry_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            result = 0;
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            result = 0;
            label.Text = "";
            operation = "";
        }

        private void equals_Click(object sender, EventArgs e)
        {
            Console.WriteLine(operation);
            switch (operation)
            {
                case "+":
                    resultBox.Text = (result + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (result - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "*":
                    resultBox.Text = (result * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "/":
                    resultBox.Text = (result / Double.Parse(resultBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(resultBox.Text);
            label.Text = "";
            answer = true;
            operation = "";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (Double.Parse(resultBox.Text) > 0)
            {
                resultBox.Text = Math.Sqrt(Double.Parse(resultBox.Text)).ToString();
            }
            else
            {
                resultBox.Text = "ERR";
            }
        }
    
    }

    
}
