using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;

namespace SimpleTests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        int SymbolLejandrYakobi(int a, int n)
        {
            if (BigInteger.GreatestCommonDivisor(a, n) == 1)
            {
                int r = 1;
                if (a < 0)
                {
                    a = -a;
                    if (n % 4 == 3)
                    {
                        r = -r;
                    }
                }

                while (true)
                {
                    int t = 0;
                    while (a % 2 == 0)
                    {
                        t++;
                        a = a / 2;
                    }

                    if (t % 2 != 0)
                    {
                        if (n % 8 == 3 || n % 8 == 5)
                        {
                            r = -r;
                        }
                    }

                    if (a % 4 == n % 4 && n % 4 == 3)
                    {
                        r = -r;
                    }

                    int c = a;
                    a = n % c;
                    n = c;

                    if (a == 0)
                        break;
                }

                return r;

            }
            else
            {
                return 0;
            }
        }

        string LTF(int n)
        {
            string result = "Неизвестно";

            for (int i = 0; i < Convert.ToInt32(txb_Count.Text); i++)
            {
                int a = r.Next(2, n);

                if (BigInteger.GreatestCommonDivisor(a, n) != 1)
                {
                    return "Составное";
                }
                else
                {
                    if (BigInteger.ModPow(a, n - 1, n) != 1)
                    {
                        return "Составное";
                    }
                }
            }

            return result;
        }

        string Slv_Shtrsn(int n)
        {
            string result = "Неизвестно";

            for (int i = 0; i < Convert.ToInt32(txb_Count.Text); i++)
            {
                int a = r.Next(2, n);

                if (BigInteger.GreatestCommonDivisor(a, n) != 1)
                {
                    return "Составное";
                }
                else
                {
                    int r = SymbolLejandrYakobi(a, n);

                    if(r<0)
                    {
                        r += n;
                    }

                    if (BigInteger.ModPow(a, (n - 1)/2, n) != r)
                    {
                        return "Составное";
                    }
                }
            }

            return result;
        }

        string Rabbin_Miller(int number)
        {
            BigInteger d = number - 1;
            BigInteger s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < Convert.ToInt32(txb_Count.Text); i++)
            {
                BigInteger a = r.Next(2,number);
                BigInteger x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < s; j++)
                    {
                        x = BigInteger.ModPow(x, 2, number);
                        if (x == number - 1)
                        {
                            break;
                        }
                        else
                        {
                            return "Составное";
                        }
                    }
                }
            }
            return "Неизвестно";
        }

        private void btn_Check_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txb_Number.Text);

            txb_LTF.Text = LTF(n);
            txb_Slv_Shtrsn.Text = Slv_Shtrsn(n);
            txb_Rbn_Mlr.Text = Rabbin_Miller(n);
        }
    }
}
