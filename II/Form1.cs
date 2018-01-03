using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace II
{
    public partial class Form1 : Form
    {
        double[] Input = new double[2];     // 0,0; 0,1; 1,0; 1,1; 
        double[] InputWeight = new double[8] { 3, 4, 8, 4, 5, 6, 7, 8 };
        double[] HiddenWeight = new double[8] { 6, 5, 7, 9, 6, 4, 1, 5 };

       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0, j = 12;
            j = 4;
            
            Neuron N1 = new Neuron(Input[0], Input[1], InputWeight[0], InputWeight[1]);
            Neuron N2 = new Neuron(Input[0], Input[1], InputWeight[2], InputWeight[3]);
            Neuron N3 = new Neuron(Input[0], Input[1], InputWeight[4], InputWeight[5]);
            Neuron N4 = new Neuron(Input[0], Input[1], InputWeight[6], InputWeight[7]);
            

                
            while (i < j)
            {
                int step = i % 4;
                switch (step)
                {
                    case 0:
                        N1 = new Neuron(0, 0, InputWeight[0], InputWeight[1]);
                        Console.WriteLine("Step " + (1 + i) + "\tNeuron 1 value: " + N1.Value);
                        break;
                    case 1:
                        N2 = new Neuron(0, 1, InputWeight[2], InputWeight[3]);
                        Console.WriteLine("Step " + (1 + i) + "\tNeuron 2 value: " + N2.Value);
                        break;
                    case 2:
                        N3 = new Neuron(1, 0, InputWeight[4], InputWeight[5]);
                        Console.WriteLine("Step " + (1 + i) + "\tNeuron 3 value: " + N3.Value);
                        break;
                    case 3:;
                        N4 = new Neuron(1, 1, InputWeight[6], InputWeight[7]);
                        Console.WriteLine("Step " + (1 + i) + "\tNeuron 4 value: " + N4.Value);
                        Console.WriteLine("==========================================");
                        break;
                }
                i++;
            }

            double[] Network = new double[4] {
                N1.Value,
                N2.Value,
                N3.Value,
                N4.Value };

            Neuron Output1 = new Neuron(Network, HiddenWeight, true);
            Neuron Output2 = new Neuron(Network, HiddenWeight, false);
            Console.WriteLine("Neuron Output 1 value: " + Output1.Value);
            Console.WriteLine("Neuron Output 2 value: " + Output2.Value);
            Console.WriteLine("==========================================");


            /*
            Neuron N1 = new Neuron(Input[0], Input[1], InputWeight[0], InputWeight[1]);
            Console.WriteLine(N1.Value);
            */

        }
    }
}
