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

namespace Bmi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            weightinput.GotFocus += change;
            heightinput.GotFocus += change;

            weightinput.LostFocus += changeBack;
            heightinput.LostFocus += changeBack;

            weightinput.KeyDown += enter;
            heightinput.KeyDown += enter;
        }

        void change(object s, EventArgs e)
        {
            TextBox textB = s as TextBox;
            if (textB.Text == textB.Tag.ToString())
            {
                textB.Text = "";
            }

        }

        void changeBack(object s, EventArgs e)
        {
            TextBox textB = s as TextBox;

            if (textB.Text == "")
            {
                textB.Text = textB.Tag.ToString();
            }
        }

        void enter(object s, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                label.Content = int.Parse(weightinput.Text) / (int.Parse(heightinput.Text) / 100);
            }
        }
    }
}
