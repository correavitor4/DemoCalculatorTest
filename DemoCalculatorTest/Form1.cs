using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCalculatorTest
{
    public partial class Form1 : Form
    {

        
    string[] operations = new string[50];
    decimal[] numbersToCalculate = new decimal[100];
    int operationsIndex =0;
    int numbersIndex=0;
    string labelText = "";
    bool lockForOperators = true;
    


    public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertNumber(7);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertNumber(8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertNumber(9);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            insertOperation("/");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            insertNumber(4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            insertNumber(5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            insertNumber(6);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            insertOperation("*");
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            insertNumber(1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            insertNumber(2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            insertOperation("/");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            insertOperation("-");
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            insertNumber(0);
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            insertOperation("+");
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }


        private void UpdateTextlabel(string text)
        {
            textBox1.Text += text;
        }

        private void insertNumber(decimal number)
        {
            if (numbersIndex < numbersToCalculate.Length)
            {

                numbersToCalculate[numbersIndex] = 1;
                numbersIndex++;
                UpdateTextlabel(number.ToString());
                lockForOperators=false
            }
            else
            {
                MessageBox.Show("O número máximo de números a serem inseridos excedeu o limite!");
            }
        }

        private void insertOperation(string operation)
        {
            

            if (operationsIndex > 0)
            {
                if (lockForOperators==false)
                {
                    if (operationsIndex < operations.Length)
                    {
                        operations[operationsIndex] = operation;
                        operationsIndex++;
                        UpdateTextlabel(operation);
                        lockForOperators = true;
                    }
                    
                    else
                    {
                        MessageBox.Show("Número decaracteres operados máximo foi excedido");
                    }
                }
                else
                {
                    MessageBox.Show("Não pode inserir operador agora atrás de outro, primeiro insira um número");
                }
            }
            else
            {
                MessageBox.Show("Não pode começar um operador, e sim com um número!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }






}
