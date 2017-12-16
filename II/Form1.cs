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
        double  LerningRate = 0.5,
                Moment = 0.3;

        double  Deltaw1 = 0,
                Deltaw2 = 0,
                Deltaw3 = 0,
                Deltaw4 = 0,
                Deltaw5 = 0,
                Deltaw6 = 0;

        double  w1 = 0.45,
                w2 = 0.78,
                w3 = -0.12,
                w4 = 0.13,
                w5 = 1.5,
                w6 = -2.3;


        int i, j;
        int MaxEpoch = 501, TrainSet = 4;

        int ErrorValue = 0;
        double ErrorBuff;
        double[] PredictionError = new double[4];

        public Form1()
        {
            InitializeComponent();
        }

        public double Sigmoid (double a)
        {
            return 1 / (1 + Math.Exp(-a));
        }

        public double Error(double IdealResult, double Result)
        {
            PredictionError[ErrorValue] = Math.Pow(IdealResult - Result, 2);
            ErrorBuff += PredictionError[ErrorValue];
            ErrorValue++;
            return (ErrorBuff) / (ErrorValue);
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

                    textBox1.Text = "" + n1;
                    textBox2.Text = "" + n2;
                    //====================================
                    textBox3.Text = Convert.ToString(w1);
                    textBox4.Text = Convert.ToString(w2);
                    textBox5.Text = Convert.ToString(w3);
                    textBox6.Text = Convert.ToString(w4);

                    textBox9.Text = Convert.ToString(w5);
                    textBox10.Text = Convert.ToString(w6);

                    double  s1 = Sigmoid(n1 * w1 + n2 * w3),
                            s2 = Sigmoid(n1 * w2 + n2 * w4);

                    textBox7.Text = Convert.ToString(s1);
                    textBox8.Text = Convert.ToString(s2);

                    double ResultSigmoid = Sigmoid(s1 * w5 + s2 * w6);
                    textBox11.Text = Convert.ToString(ResultSigmoid);

                    double ErrorPercent;
                    double MOR;
                    if (n1 + n2 == 1)
                    {
                        ErrorPercent = Error(1, ResultSigmoid);
                        MOR = 1 - ResultSigmoid;
                    }
                    else
                    {
                        ErrorPercent = Error(0, ResultSigmoid);
                        MOR = 0 - ResultSigmoid;
                    }

                    textBox12.Text = Convert.ToString(ErrorPercent + "%");

                    MOR *= (1 - MOR) * MOR;

                    textBox13.Text = Convert.ToString(MOR);

                    double  DeltaH1 = ((1 - s1) * s1) * (w5 * MOR),
                            DeltaH2 = ((1 - s2) * s2) * (w6 * MOR);

                    textBox14.Text = Convert.ToString(DeltaH1);
                    textBox15.Text = Convert.ToString(DeltaH2);

                    double Gradw5 = s1 * MOR,
                            Gradw6 = s2 * MOR;

                    Deltaw5 = LerningRate * Gradw5 + Deltaw5 * Moment;
                    Deltaw6 = LerningRate * Gradw6 + Deltaw6 * Moment;
                    w5 += Deltaw5;
                    w6 += Deltaw6;

                    double  Gradw1 = n1 * DeltaH1,
                            Gradw2 = n1 * DeltaH2,
                            Gradw3 = n2 * DeltaH1,
                            Gradw4 = n2 * DeltaH2;

                    Deltaw1 = LerningRate * Gradw1 + Deltaw1 * Moment;
                    Deltaw2 = LerningRate * Gradw2 + Deltaw2 * Moment;
                    Deltaw3 = LerningRate * Gradw3 + Deltaw3 * Moment;
                    Deltaw4 = LerningRate * Gradw4 + Deltaw4 * Moment;

                    w1 += Deltaw1;
                    w2 += Deltaw2;
                    w3 += Deltaw3;
                    w4 += Deltaw4;

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
                    //System.Threading.Thread.Sleep(500);
                    //====================================
                }
                j = 0;
                ErrorBuff = 0;
                ErrorValue = 0;
                label9.Text = "" + i;
                label9.Refresh();
            }
        }
    }
}
