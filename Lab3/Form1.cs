using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculate(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculate(2);
        }

        public void Calculate(int system_number)
        {
            int N = 6;
            double C;
            double[] e = { 1, 0.3, 0.6 };
            //double[] mu = { (double)10/8, (double)10/3, (double)10 /12 };
            double[] mu = { 0.8, 0.3, 1.2 };
            int[] r = { 1, 1, 3 };
            double[] p1 = new double[7];

            C = getC();

            textBox1.Text = Li(system_number).ToString();
            textBox2.Text = Ri(system_number).ToString();
            textBox3.Text = Mi(system_number).ToString();
            textBox4.Text = lambda_i(system_number).ToString();
            textBox5.Text = Ti(system_number).ToString();
            textBox6.Text = Qi(system_number).ToString();


            double getC()
            {
                double sum7 = 0, sum6 = 0, sum5 = 0, sum4 = 0, sum3 = 0, sum2 = 0, sum1 = 0;

                double[] system1 = new double[7];
                double[] system2 = new double[7];
                double[] system3 = new double[7];

                double[] first = new double[1];
                double[] second = new double[2];
                double[] third = new double[3];
                double[] fourth = new double[4];
                double[] fifth = new double[5];
                double[] sixth = new double[6];
                double[] seventh = new double[7];

                for (int k = 0; k <= N; k++)
                {
                    system1[k] = pi(k, e[0], mu[0], r[0]);
                    system2[k] = pi(k, e[1], mu[1], r[1]);
                    system3[k] = pi(k, e[2], mu[2], r[2]);
                }

                for (int counter = 0; counter <= N; counter++)                
                {
                    seventh[counter] = system2[counter] * system3[N - counter];
                    sum7 += seventh[counter];
                }

                for (int counter = 0; counter <= N - 1; counter++)
                {
                    sixth[counter] = system2[counter] * system3[N - 1 - counter];
                    sum6 += sixth[counter];
                }

                for (int counter = 0; counter <= N - 2; counter++)
                {
                    fifth[counter] = system2[counter] * system3[N - 2 - counter];
                    sum5 += fifth[counter];
                }

                for (int counter = 0; counter <= N - 3; counter++)
                {
                    fourth[counter] = system2[counter] * system3[N - 3 - counter];
                    sum4 += fourth[counter];
                }

                for (int counter = 0; counter <= N - 4; counter++)
                {
                    third[counter] = system2[counter] * system3[N - 4 - counter];
                    sum3 += third[counter];
                }

                for (int counter = 0; counter <= N - 5; counter++)
                {
                    second[counter] = system2[counter] * system3[N - 5 - counter];
                    sum2 += second[counter];
                }
                
                first[0] = system2[0] * system3[0];
                sum1 += first[0];

                double[] summaries = {sum7, sum6, sum5, sum4, sum3, sum2, sum1 };
                double main_sum = 0;

                for (int i = 0; i <= N; i++)
                {
                    p1[i] = system1[i] * summaries[i];
                    main_sum += p1[i];
                }

                C = Math.Pow(main_sum, -1);

                return C;
            }

            double pi(int k, double ei, double mui, int ri)
            {
                double number = (double)(ei / mui);
                double multiplier = (double)Math.Pow(number, k);
                if (k > ri)
                {
                    int factorial_ri = Enumerable.Range(1, ri).Aggregate(1, (p, item) => p * item);
                    return Math.Pow((double)(ei / mui), k) / (factorial_ri * Math.Pow(ri, k-ri));
                }
                else
                {
                    int factorial_k = Enumerable.Range(1, k).Aggregate(1, (p, item) => p * item);
                    return Math.Pow((double)(ei / mui), k) / factorial_k;
                }
            }

            double p_smo(int i, int j)
            {
                double result = 0;
                if (i == 0)
                {
                    for (int a = 0; a <= N - j; a++)
                    {
                        result += pi(j, e[0], mu[0], r[0]) * pi(a, e[1], mu[1], r[1]) *
                            pi(N - j - a, e[2], mu[2], r[2]);
                    }
                }
                if (i == 1)
                {
                    for (int a = 0; a <= N - j; a++)
                    {
                        result += pi(a, e[0], mu[0], r[0]) * pi(j, e[1], mu[1], r[1]) *
                            pi(N - j - a, e[2], mu[2], r[2]);
                    }
                }
                if (i == 2)
                {
                    for (int a = 0; a <= N - j; a++)
                    {
                        result += pi(a, e[0], mu[0], r[0]) * pi(N - j - a, e[1], mu[1], r[1]) *
                            pi(j, e[2], mu[2], r[2]);
                    }
                }
                return result * C;
            }

            double Li(int i)
            {
                double sum = 0;
                for (int j = r[i] + 1; j <= N; j++)
                {
                    sum += (j - r[i]) * p_smo(i, j);
                }
                return sum;
            }

            double Ri(int i)
            {
                double sum = 0;
                for (int j = 0; j <= r[i] - 1; j++)
                {
                    sum += (r[i] - j) * p_smo(i, j);
                }
                return r[i] - sum;
            }

            double Mi(int i)
            {
                return Li(i) + Ri(i);
            }

            double lambda_i(int i)
            {
                return (double)(Ri(i) / mu[i]);
            }

            double Ti(int i)
            {
                return (double)(Mi(i) / lambda_i(i));
            }

            double Qi(int i)
            {
                return (double)(Li(i) / lambda_i(i));
            }
        }
    }
}
