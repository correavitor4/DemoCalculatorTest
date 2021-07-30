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
    string[] numbersToCalculate = new string[100];
    int operationsIndex =0;
    int numbersIndex=0;
    string labelText = "";
    bool lockForOperators = true;
    bool fisrtCharacter = true;
    string actuallyNumber = "";
    


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
            insertNumber(3);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            insertOperation("-");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bool conditions = false;
            closeActuallyNumber();
            conditions = verifyConditionsToCalc();
            if (conditions == true)
            {
                executeCalc();
            }
            else
            {
                MessageBox.Show("Não foi possível realizar o cálculo. Verifique e tente novamente");
            }
            
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



        private bool verifyConditionsToCalc()
        {
            int nOperations = 0, nNumbers = 0;

            for(int i=0; i < this.operations.Length; i++)
            {
                if(this.operations[i]!=null)
                {
                    nOperations++;
                   
                }
                if (this.numbersToCalculate[i] != null)
                {
                    nNumbers++;
                }
            }
            if (nOperations == nNumbers)
            {
                System.Diagnostics.Debug.WriteLine("É impossível realizar o cálculo. nOparations="+nOperations+", nNumbers="+nNumbers);
                return false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("É possível realizar o cálculo");
                return true;
            }
        }

        private void UpdateTextlabel(string text)
        {
            textBox1.Text += text;
        }

        private void clearLabelText()
        {
            textBox1.Text = "";
        }

        private void insertNumber(decimal number)
        {
            if (this.numbersIndex < this.numbersToCalculate.Length)
            {
                this.actuallyNumber += number.ToString(); 
                
                //Incrementa o número digitado no label (textView)
                UpdateTextlabel(number.ToString());
                this.lockForOperators = false;
                //this.fisrtCharacter
                
            }
            else
            {
                MessageBox.Show("O número máximo de números a serem inseridos excedeu o limite!");
            }
        }
        

        private void closeActuallyNumber()
        {
            this.numbersToCalculate[numbersIndex] = this.actuallyNumber;
            System.Diagnostics.Debug.WriteLine("Número atual fechado: "+this.numbersToCalculate[numbersIndex]);
            this.numbersIndex++;
            actuallyNumber = "";

        }
        private void insertOperation(string operation)
        {
            

            if (this.lockForOperators==false)
            {
                
                if (this.operationsIndex < operations.Length)
                {
                    this.operations[operationsIndex] = operation;
                    this.operationsIndex++;
                    UpdateTextlabel(operation);
                    closeActuallyNumber();
                    this.lockForOperators = true;
                }
                    
                else
                {
                    MessageBox.Show("Número decaracteres operados máximo foi excedido");
                }
            }
            else
            {
                MessageBox.Show("Não pode inserir operador agora atrás de outro, e nem começar o cálculo com um operador, primeiro insira um número");
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void executeCalc()
        {
            executeDivisions();
            executeMultiplications();
            executeAddictions();
            executeSubtractions();

            clearLabelText();
            UpdateTextlabel(this.numbersToCalculate[0]);
            
        }
        

       
        private void executeDivisions()
        {
            for(int i=0; i < this.operations.Length; i++)
            {
                if (this.operations[i] == "")
                {
                    System.Diagnostics.Debug.WriteLine("Nenhuma divisão a mais a ser feita");
                    break;
                }
                if (this.operations[i] == "/")
                {
                    
                    //Se encontrar uma operação do tipo divisão, vai fazê-la e limpar campos desnecessários, que serão posteriormente re-organizados
                    this.numbersToCalculate[i+1]= (decimal.Parse(this.numbersToCalculate[i]) / decimal.Parse(this.numbersToCalculate[i + 1])).ToString();
                    this.numbersToCalculate[i] = "";
                    this.operations[i] = "";
                    organizeStrings();
                }
            }
        }

        private void executeMultiplications()
        {
            for (int i = 0; i < this.operations.Length; i++)
            {
                if (this.operations[i] == "")
                {
                    System.Diagnostics.Debug.WriteLine("Nenhuma multiplicação mais a ser feita");
                    break;
                }
                if (this.operations[i] == "*")
                {

                    //Se encontrar uma operação do tipo multiplicação, vai fazê-la e limpar campos desnecessários, que serão posteriormente re-organizados
                    this.numbersToCalculate[i+1] = (decimal.Parse(this.numbersToCalculate[i]) * decimal.Parse(this.numbersToCalculate[i + 1])).ToString();
                    this.numbersToCalculate[i] = "";
                    this.operations[i] = "";
                    organizeStrings();
                }
            }
        }

        private void executeAddictions()
        {
            for (int i = 0; i < this.operations.Length; i++)
            {
                if (this.operations[i] == "")
                {
                    System.Diagnostics.Debug.WriteLine("Nenhuma adição a mais a ser feita");
                    break;
                }
                if (this.operations[i] == "+")
                {

                    //Se encontrar uma operação do tipo adição, vai fazê-la e limpar campos desnecessários, que serão posteriormente re-organizados
                    this.numbersToCalculate[i+1] = (decimal.Parse(this.numbersToCalculate[i]) + decimal.Parse(this.numbersToCalculate[i + 1])).ToString();
                    this.numbersToCalculate[i] = "";
                    this.operations[i] = "";
                    organizeStrings();
                }
            }
        }

        private void executeSubtractions()
        {
            for (int i = 0; i <this.operations.Length; i++)
            {
                if (this.operations[i] == "")
                {
                    System.Diagnostics.Debug.WriteLine("Nenhuma subtração a mais a ser feita");
                    break;
                }
                if (this.operations[i] == "-")
                {

                    //Se encontrar uma operação do tipo subtração, vai fazê-la e limpar campos desnecessários, que serão posteriormente re-organizados
                    this.numbersToCalculate[i+1] = (decimal.Parse(this.numbersToCalculate[i]) - decimal.Parse(this.numbersToCalculate[i + 1])).ToString();
                    this.numbersToCalculate[i] = "";
                    this.operations[i] = "";
                    organizeStrings();
                } 
            }
        }
        private void organizeStrings()
        {
            for(int i = 0; i < this.operations.Length-1; i++)
            {
                if (this.numbersToCalculate[i]=="")
                {
                    this.numbersToCalculate[i] = this.numbersToCalculate[i + 1];
                    this.numbersToCalculate[i + 1] = "";
                }
                if (this.operations[i] == "")
                {

                    this.operations[i] = this.operations[i + 1];
                    this.operations[i + 1] = "";
                }
            }
        }
    }






}
