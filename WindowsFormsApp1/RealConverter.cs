using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    static class RealConverter
    {
        public static double ToDec(string n, double p)
        {
            double result = 0;
            double cur = 1;
            foreach (var d in n)
            {
                cur *= p;
                var i = d < '0' || d > '9' ? char.ToUpper(d) - 'A' + 10 : d - '0';
                result += i / cur;
            }
            return result;
        }

        public static string FromDec (double n, double p, int acc)
        {
            string result = "";
            string temp1 = n.ToString();
            if (!temp1.Contains(","))
            {
                temp1 = "0," + temp1;
            }
            string temp2;
            string afterDot;
            for(int i = 0; i < acc; i++)
            {
                n = double.Parse(temp1);
                n *= p;
                temp2 = n.ToString();
                temp2 = temp2.Remove(temp2.IndexOf(","));
                afterDot = n.ToString().Remove(0, n.ToString().IndexOf(",") + 1);
                temp1 = "0," + afterDot;
                if (int.Parse(temp2) > 9)
                {
                    char c = (char)('A' + (int.Parse(temp2) - 10));
                    temp2 = "";
                    temp2 += c;
                }
                result += temp2;
            }
            return result;
        }

        private static bool Check(string input, int fromBase)
        {
            var allowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, fromBase);
            return Regex.IsMatch(input, string.Format("^[{0}]+$", allowedChars), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static bool TryToBase(string input, int fromBase, int toBase, out string result, int acc)
        {
            var check = Check(input, fromBase);
            if (check)
                result = fromBase == toBase ? input : FromDec(ToDec(input, fromBase), toBase, acc);
            else
                result = string.Empty;
            return check;
        }
    }
}
