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
using System.IO;

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

            weightinput.KeyUp += enter;
            heightinput.KeyUp += enter;
        }

        void change(object s, EventArgs e)
        {
            TextBox textB = s as TextBox;
            if (textB.Text == textB.Tag.ToString())
            {
                textB.Clear();
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
                int weight;
                int height;
                if (int.TryParse(weightinput.Text.Trim(), out weight) && int.TryParse(heightinput.Text.Trim(), out height))
                {
                    double BMI = weight / Math.Pow(((double)height/100),2);
                    Everything.Children.Add(new Label() { Content = "BMI: " + BMI.ToString("0.00") + " vagyis: " + Overweight(BMI) });
                }
            }
        }
        string Overweight(double BMI)
        {
            if (BMI < 18.5)
            {
                return "Sovány";
            }
            if (BMI < 25)
            {
                return "Normál";
            }
            if (BMI < 30)
            {
                return "Kicsit dagadt";
            }
            if (BMI < 35) 
            {
                return "Egészen dagadt";
            }
            if (BMI < 40)
            {
                return "Majdnem teljesen dagadt";
            }
            return "Túl dagadt";
        }
    }
}
