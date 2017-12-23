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
        double  LerningRate = 3,
                Moment = 0.7;

        double  Deltaw1 = 0,
                Deltaw2 = 0,
                Deltaw3 = 0,
                Deltaw4 = 0,
                Deltaw5 = 0,
                Deltaw6 = 0;                       

        int i, j;
        int MaxEpoch = 500001, TrainSet = 4;

        //int ErrorValue = 0;
        //double ErrorBuff;
        double[] PredictionError = new double[4];
        double sum = 0;

        public Form1()
        {
            InitializeComponent();
            Synapse.w1 = 9.50281530957557;
            Synapse.w2 = 0.970518993278058;
            Synapse.w3 = 9.50154606154639;
            Synapse.w4 = 0.961203246532013;
            Synapse.w5 = 39.8237701124492;
            Synapse.w6 = -49.6861620879739;
        }

        public double Sigmoid (double a)
        {
            return 1 / (1 + Math.Exp(-a));
        }

        public void ErrorArray(double IdealResult, double Result, int TrainSet)
        {
            switch (TrainSet)
            {
                case 0:
                    sum = 0;
                    PredictionError[0] = Math.Pow(IdealResult - Result, 2);
                    break;
                case 1:
                    PredictionError[1] = Math.Pow(IdealResult - Result, 2);
                    break;
                case 2:
                    PredictionError[2] = Math.Pow(IdealResult - Result, 2);
                    break;
                case 3:
                    PredictionError[3] = Math.Pow(IdealResult - Result, 2);
                    break;
            }
            sum += PredictionError[TrainSet];
            TrainSet++;
            if (TrainSet == 4)
            {
                int i = 0;
                while (i < PredictionError.Length)
                {
                    PredictionError[i] = 0;
                    i++;
                }

            }
        }
        

        public double Error()
        {
            return sum / 4; //4 - count трейнсетовs
            /*
            PredictionError[ErrorValue] = Math.Pow(IdealResult - Result, 2);
            ErrorBuff += PredictionError[ErrorValue];
            ErrorValue++;
            return (ErrorBuff) / (ErrorValue);
            */
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n1, n2;

            for (i = 0; i < MaxEpoch; i++)
            {
                for (j = 0; j < TrainSet; j++)
                {
                    if (j == 0)
                    {
                        n1 = 0;
                        n2 = 0;
                    }
                    else if (j == 1)
                    {
                        n1 = 1;
                        n2 = 0;
                    }
                    else if (j == 2)
                    {
                        n1 = 1;
                        n2 = 1;
                    }
                    else
                    {
                        n1 = 0;
                        n2 = 1;
                    }

                    //textBox1.Text = "" + n1;
                    //textBox2.Text = "" + n2;
                    //====================================
                    //textBox3.Text = Convert.ToString(Synapse.w1);
                    //textBox4.Text = Convert.ToString(Synapse.w2);
                    //textBox5.Text = Convert.ToString(Synapse.w3);
                    //textBox6.Text = Convert.ToString(Synapse.w4);

                    //textBox9.Text = Convert.ToString(Synapse.w5);
                    //textBox10.Text = Convert.ToString(Synapse.w6);

                    double  s1 = Sigmoid(n1 * Synapse.w1 + n2 * Synapse.w3),
                            s2 = Sigmoid(n1 * Synapse.w2 + n2 * Synapse.w4);

                    //textBox7.Text = Convert.ToString(s1);
                    //textBox8.Text = Convert.ToString(s2);

                    double ResultSigmoid = Sigmoid(s1 * Synapse.w5 + s2 * Synapse.w6);
                    //textBox11.Text = Convert.ToString(ResultSigmoid);

                    //double ErrorPercent;
                    double MOR;
                    if (n1 + n2 == 1)
                    {
                        ErrorArray(1, ResultSigmoid, j);
                        MOR = (1 - ResultSigmoid) * (1 - ResultSigmoid) * ResultSigmoid;
                    }
                    else
                    {
                        ErrorArray(0, ResultSigmoid, j);
                        MOR = (0 - ResultSigmoid) * (1 - ResultSigmoid) * ResultSigmoid;
                    }

                    //textBox13.Text = Convert.ToString(MOR);

                    double  DeltaH1 = ((1 - s1) * s1) * (Synapse.w5 * MOR),
                            DeltaH2 = ((1 - s2) * s2) * (Synapse.w6 * MOR);

                    //textBox14.Text = Convert.ToString(DeltaH1);
                    //textBox15.Text = Convert.ToString(DeltaH2);

                    double  Gradw5 = s1 * MOR,
                            Gradw6 = s2 * MOR;

                    //Deltaw5 = LerningRate * Gradw5 + Deltaw5 * Moment;
                    //Deltaw6 = LerningRate * Gradw6 + Deltaw6 * Moment;
                    Synapse.w5 += Deltaw5;
                    Synapse.w6 += Deltaw6;

                    double  Gradw1 = n1 * DeltaH1,
                            Gradw2 = n1 * DeltaH2,
                            Gradw3 = n2 * DeltaH1,
                            Gradw4 = n2 * DeltaH2;

                    Deltaw1 = LerningRate * Gradw1 + Deltaw1 * Moment;
                    Deltaw2 = LerningRate * Gradw2 + Deltaw2 * Moment;
                    Deltaw3 = LerningRate * Gradw3 + Deltaw3 * Moment;
                    Deltaw4 = LerningRate * Gradw4 + Deltaw4 * Moment;
                    
                    Synapse.w1 += Deltaw1;
                    Synapse.w2 += Deltaw2;
                    Synapse.w3 += Deltaw3;
                    Synapse.w4 += Deltaw4;
                    
                    /*
                    textBox1.Refresh();
                    textBox2.Refresh();
                    textBox3.Refresh();
                    textBox4.Refresh();
                    textBox5.Refresh();
                    textBox6.Refresh();
                    textBox7.Refresh();
                    textBox8.Refresh();
                    textBox9.Refresh();
                    textBox10.Refresh();
                    textBox11.Refresh();
                    textBox12.Refresh();
                    textBox13.Refresh();
                    textBox14.Refresh();
                    textBox15.Refresh();
                    */
                    //System.Threading.Thread.Sleep(500);
                    //====================================
                    Console.WriteLine(String.Format("{0} {1} Сигмоида ответа: {2}",n1, n2, ResultSigmoid));
                }
                /*
                Synapse.w1 = w1;
                Synapse.w2 = w2;
                Synapse.w3 = w3;
                Synapse.w4 = w4;
                Synapse.w5 = w5;
                Synapse.w6 = w6;
                */
                //Error();
                textBox12.Text = Convert.ToString(Error() + "%");
                textBox12.Refresh();
                j = 0;
                //ErrorBuff = 0;
                //ErrorValue = 0;
                label9.Text = "" + i;
                label9.Refresh();
            }
            Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5}", Synapse.w1, Synapse.w2, Synapse.w3, Synapse.w4, Synapse.w5, Synapse.w6));
        }
    }
}
