using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyfryRzymskie
{
    public class IntToRomanNumber
    {
        public Dictionary<int, string> rzymskie { get; set; }


        public IntToRomanNumber()
        {
            rzymskie = new Dictionary<int, string>();

            rzymskie.Add(1, "I");
            rzymskie.Add(4, "IV");
            rzymskie.Add(5, "V");
            rzymskie.Add(9, "IX");
            rzymskie.Add(10, "X");
            rzymskie.Add(40, "XL");
            rzymskie.Add(50, "L");
            rzymskie.Add(90, "XC");
            rzymskie.Add(100, "C");
            rzymskie.Add(400, "CD");
            rzymskie.Add(500, "D");
            rzymskie.Add(900, "CM");
            rzymskie.Add(1000, "M");
        }

        public string ConvertToRoman(int number)
        {
            string wynik = "";

            // txtRzymska.Text = ((Rzymska)liczba).ToString()+"   "+(int)((Rzymska)liczba);
            int zerowanie = number;

            //Console.WriteLine(zerowanie);

            while (zerowanie > 0)
            {
                KeyValuePair<int,string> keyValuePair = rzymskie.Where(k => k.Key <= zerowanie).OrderByDescending(n => n.Key).First();

                zerowanie -= keyValuePair.Key;

                wynik += keyValuePair.Value;
            }


            return wynik;
        }

        public string ConvertToNumber(string roman)
        {
            int ret = 0;


            for (int i = 0; i < roman.Length; i++)
            {
                try {
                    char next = roman[i + 1];
                    char pre = roman[i];

                    var N = rzymskie.Where(n => n.Value == next.ToString()).First();
                    var P = rzymskie.Where(n => n.Value == pre.ToString()).First();

                    if (N.Key > P.Key)
                    {
                        ret -= P.Key;
                    }
                    else
                    {
                        ret += P.Key;
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    ret += rzymskie.Where(n => n.Value == roman[i].ToString()).First().Key;
                }
            }




            return ret.ToString();
        }

        public string[] Chars()
        {
            return rzymskie.Values.ToArray();
        }

    }
}
