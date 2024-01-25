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
        int upperIndex = -26;
        int lowerIndex = -26;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static string Encipher(string str)
        {
            Char[] chars = str.ToCharArray();
            //Creating a table and assign non-alphanumeric characters to each letter
            Char[] encodeTable =
            {
                '`','!','#','$','%',
                '^','&','*','(',')',
                '-','_','=','+','[',
                ']','{','}',';','<',
                '>','?',',','.','~',
                '@'
            };

            for (int i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetter(chars[i]))
                {
                    continue;
                }
                else
                {
                    if (char.IsUpper(chars[i]))
                    {
                        chars[i] = char.ToLower(chars[i]);
                        chars[i] = encodeTable[chars[i] - 'a'];
                    }
                    else
                    {
                        chars[i] = encodeTable[chars[i] - 'a'];
                    }
                }
            }

            String temp = new string(chars);
            return temp;
        }

        public static String Convert(String str, int uppercaseIndex, int lowercaseIndex)
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

            int j = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                while (j < 26)
                {
                    if (!char.IsLetter(chars[i]))
                    {
                        break;
                    }
                    else
                    {
                        if (chars[i] == upperCase[j])
                        {
                            if (j + uppercaseIndex > 25)
                            {
                                chars[i] = upperCase[j + uppercaseIndex - 26];
                                j = 0;
                                break;
                            }
                            else
                            {
                                chars[i] = upperCase[j + uppercaseIndex];
                                j = 0;
                                break;
                            }
                        }
                        else if (chars[i] == lowerCase[j])
                        {
                            if (j + lowercaseIndex > 25)
                            {
                                chars[i] = lowerCase[j + lowercaseIndex - 26];
                                j = 0;
                                break;
                            }
                            else
                            {
                                chars[i] = lowerCase[j + lowercaseIndex];
                                j = 0;
                                break;
                            }
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }

            String temp = new String(chars);
            return temp;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyStates == Keyboard.GetKeyStates(Key.Enter) && upperIndex != -26 && lowerIndex != -26) 
            {
                result.Text = Convert(Input.Text, upperIndex, lowerIndex);
                encodedResult.Text = Encipher(result.Text);

            }
        }

        private void upperIndexInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(upperIndexInput.Text, out int index))
            {
                upperIndex = Math.Abs(index);
            }
            else
            {
                upperWarning.Text = "Plese only input numbers!";
            }
        }

        private void lowerIndexInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(lowerIndexInput.Text, out int index))
            {
                lowerIndex = Math.Abs(index);
            }
            else
            {
                lowerWarning.Text = "Plese only input numbers!";
            }
        }
    }
}
