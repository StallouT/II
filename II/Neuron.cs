using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II
{
    class Neuron
    {
        public double Value;



        public double Sigmoid(double a)
        {
            return 1 / (1 + Math.Exp(-a));
        }


        public Neuron(double n1, double n2, double w1, double w2)
        {
            Value = Sigmoid(n1 * w1 + n2 * w2);
        }

        public Neuron(double[] Network, double[] HiddenWeight, bool logic)
        {
            if (logic)
            {
                Value = Sigmoid(Network[0] * HiddenWeight[0] +
                                Network[1] * HiddenWeight[2] +
                                Network[2] * HiddenWeight[4] +
                                Network[3] * HiddenWeight[6]);
            }
            else
            {
                Value = Sigmoid(Network[0] * HiddenWeight[1] +
                                Network[1] * HiddenWeight[3] +
                                Network[2] * HiddenWeight[5] +
                                Network[3] * HiddenWeight[7]);
            }
        }
    }
}
