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

namespace CyfryRzymskie
{
    public partial class MainWindow : Window
    {
        IntToRomanNumber con = new IntToRomanNumber();

        bool buttonPressed = false;

        public MainWindow()
        {
            InitializeComponent();
            List<string> r = new List<string>();
            for (int i = 1; i <= 100; i++)
            {
                r.Add(con.ConvertToRoman(i));
            }

            Console.WriteLine(r.OrderByDescending(n=>n.Length).First());

        }

        private void txtCyfra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!buttonPressed)
            {
                int liczba;
                if (int.TryParse(txtCyfra.Text, out liczba))
                {
                    if (liczba >= 0)
                        txtRzymska.Text = con.ConvertToRoman(liczba);
                    else
                    {
                        txtRzymska.Text = "-" + con.ConvertToRoman(Math.Abs(liczba));
                    }
                }
                else if (txtCyfra.Text == "")
                {
                    txtRzymska.Text = "";
                }
                else
                {
                    txtRzymska.Text = "Błąd";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Random rn = new Random();

            if (buttonPressed == true)
            {
                txtRzymska.IsEnabled = false;
                txtCyfra.IsEnabled = true;
                lblFirst.Visibility = Visibility.Visible;
                lblSecond.Visibility = Visibility.Hidden;

                txtCyfra.Text = "";
                txtRzymska.Text = "";


                buttonPressed = false;
                //txtCyfra.Text = rn.Next(1, 85).ToString();
            }
            else
            {
                txtCyfra.IsEnabled = false;
                txtRzymska.IsEnabled = true;
                lblSecond.Visibility = Visibility.Visible;
                lblFirst.Visibility = Visibility.Hidden;


                txtRzymska.Text = "";
                txtCyfra.Text = "";
                //txtCyfra.Text = rn.Next(1, 85).ToString();

                buttonPressed = true;
            }


        }

        private void txtRzymska_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (buttonPressed)
            {
                txtRzymska.Text = new string(txtRzymska.Text.Where(n => con.Chars().Contains(n.ToString().ToUpper())).ToArray()).ToUpper();
                txtRzymska.Select(txtRzymska.Text.Length, 0);


                txtCyfra.Text = con.ConvertToNumber(txtRzymska.Text.ToUpper().Trim());
            }
        }
    }
}
