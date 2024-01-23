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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            result.Text = Input.Text;
        }

        public static void Convert(String str, int index)
        {

            char[] upperCase = new char[26];
            char[] lowerCase = new char[26];

            int lowIndex = 0;
            char low = 'a';
            while (lowIndex <= 25)
            {
                lowerCase[lowIndex] = low;
                low++;
                lowIndex++;
            }

            int upIndex = 0;
            char up = 'A';
            while (upIndex <= 25)
            {
                upperCase[upIndex] = up;
                up++;
                upIndex++;
            }

            char[] chars = str.ToCharArray();

            int i = 0;
            int j = 0;
            while (i < chars.Length)
            {
                while (j < 26)
                {
                    if (chars[i] == upperCase[j])
                    {
                        if (j + index > 25)
                        {
                            chars[i] = upperCase[j + index - 26];
                            i++;
                            break;

                        }
                        else
                        {
                            chars[i] = upperCase[j + index];
                            i++;
                            break;
                        }
                    }
                    else if (chars[i] == lowerCase[j])
                    {
                        if (j + index > 25)
                        {
                            chars[i] = lowerCase[j + index - 26];
                            i++;
                            break;
                        }
                        else
                        {
                            chars[i] = lowerCase[j + index];
                            i++;
                            break;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }

            }
            String temp = new String(chars);
            
        }
    }
}
