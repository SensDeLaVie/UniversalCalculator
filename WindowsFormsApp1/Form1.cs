using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //Ввод основных переменных
        char sign;
        double a;
        int fromBase1;
        int fromBase2;
        int from;
        int to;
        int ansBase;
        double b;
        double result;
        public bool isFocused_textbox1 = false;
        public bool isFocused_CC = false;
        public bool isCalc = true;

        public bool IsCalc
        {
            get { return isCalc; }
        }

        /////////////////////НЕ ТРОГАТЬ!!!///////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
            //KeyDown += new KeyEventHandler(Form1_KeyDown);
            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(Signs);
            textBox1.LostFocus += new EventHandler(textbox1_unFocused);
            textBox1.GotFocus += new EventHandler(textbox1_Focused);
            tb_fromBase1.GotFocus += new EventHandler(fromBase1_Focused);
            tb_fromBase2.GotFocus += new EventHandler(fromBase2_Focused);
            tb_ansBase.GotFocus += new EventHandler(ansBase_Focused);
            fromBase.GotFocus += new EventHandler(fromBase_Focused);
            toBase.GotFocus += new EventHandler(toBase_Focused);
            acc.GotFocus += new EventHandler(acc_Focused);
        }
        //////////////////////////////////////////////////////////////////////////

        //При запуске программы происходит след.
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }
        #region Focused textboxes

        //Если основная строка без фокуса
        private void textbox1_unFocused (object sender, EventArgs e)
        {
            isFocused_textbox1 = false;
        }

        //Если основная строка с фокусом
        private void textbox1_Focused (object sender, EventArgs e)
        {
            isFocused_textbox1 = true;
        }

        private void fromBase1_Focused (object sender, EventArgs e)
        {
            if (tb_fromBase1.Text == "Исходная СС1")
                tb_fromBase1.Text = "";
            tb_fromBase1.ForeColor = System.Drawing.Color.Black;
        }

        private void fromBase2_Focused(object sender, EventArgs e)
        {
            if (tb_fromBase2.Text == "Исходная СС2")
                tb_fromBase2.Text = "";
            tb_fromBase2.ForeColor = System.Drawing.Color.Black;
        }
        private void ansBase_Focused(object sender, EventArgs e)
        {
            if (tb_ansBase.Text == "СС ответа")
                tb_ansBase.Text = "";
            tb_ansBase.ForeColor = System.Drawing.Color.Black;
        }

        private void fromBase_Focused(object sender, EventArgs e)
        {
            if (fromBase.Text == "Из какой системы счисления перевести")
            {
                fromBase.Text = "";
            }
            fromBase.ForeColor = System.Drawing.Color.Black;
        }

        private void toBase_Focused(object sender, EventArgs e)
        {
            if (toBase.Text == "В какую систему счисления перевести")
            {
                toBase.Text = "";
            }
            toBase.ForeColor = System.Drawing.Color.Black;
        }

        private void acc_Focused(object sender, EventArgs e)
        {
            if (acc.Text == "acc")
            {
                acc.Text = "";
            }
            acc.ForeColor = System.Drawing.Color.Black;
        }

        #endregion

        private void Signs(object sender, KeyPressEventArgs e)
        {
            if(isFocused_textbox1 == true)
            {
                if (e.KeyChar == '*')
                {
                    try
                    {
                        sign = '*';
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }

                if (e.KeyChar == '/')
                {
                    try
                    {
                        sign = '/';
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                if (e.KeyChar == '+')
                {
                    try
                    {
                        sign = '+';
                        
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }

                if (e.KeyChar == '-')
                {
                    try
                    {
                        sign = '-';
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
            }
        }

        /*// Функции по нажатию на клавишы

        private void Signs(object sender, KeyPressEventArgs e)
        {
            if(!isFocused_CC && !isFocused_textbox1)
            {
                if (Char.ToUpper(e.KeyChar) >= 'A' && Char.ToUpper(e.KeyChar) <= 'Z')
                    textBox1.Text += Char.ToUpper(e.KeyChar);

                if (e.KeyChar == '*')
                {
                    try
                    {
                        sign = '*';

                        textBox1.Text += "*";
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }

                if (e.KeyChar == '/')
                {
                    try
                    {
                        sign = '/';

                        textBox1.Text += "/";
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                if (e.KeyChar == '+')
                {
                    try
                    {
                        sign = '+';

                        textBox1.Text += "+";
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }

                if (e.KeyChar == '-')
                {
                    try
                    {
                        sign = '-';

                        textBox1.Text += "-";
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    textBox1.Text += e.KeyChar;
                }
            }
        }

        //Равно, цифры
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isFocused_textbox1 && !isFocused_CC)
            {
                if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
                {
                    textBox1.Text += '0';
                }
                if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                {
                    textBox1.Text += '1';
                }
                if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                {
                    textBox1.Text += '2';
                }
                if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                {
                    textBox1.Text += '3';
                }
                if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                {
                    textBox1.Text += '4';
                }
                if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                {
                    textBox1.Text += '5';
                }
                if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
                {
                    textBox1.Text += '6';
                }
                if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
                {
                    textBox1.Text += '7';
                }
                if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
                {
                    textBox1.Text += '8';
                }
                if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
                {
                    textBox1.Text += '9';
                }
            }
        }
        */

        #region Virtual keyboard
        // Обработка нажатий на экранную клавиатуру
        private void One_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';
        }

        private void two_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';
        }

        private void Three_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';
        }

        private void four_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';
        }

        private void five_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';
        }

        private void six_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';
        }

        private void seven_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';
        }

        private void eight_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';
        }

        private void nine_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';
        }

        private void twoZeros_Click(object sender, EventArgs e)
        {
            textBox1.Text += "00";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '+';

                textBox1.Text += "+";
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '-';

                textBox1.Text += "-";
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void multiplyer_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '*';

                textBox1.Text += "*";
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void division_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '/';
                textBox1.Text += "/";
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void eq_Click(object sender, EventArgs e)
        {
            string[] t = new string[2];

            string[] n = new string[2];
            n = textBox1.Text.Split(sign);
            string temp1;
            string temp2;
            fromBase1 = int.Parse(tb_fromBase1.Text);
            fromBase2 = int.Parse(tb_fromBase2.Text);
            ansBase = int.Parse(tb_ansBase.Text);

            string f_foreDot = n[0].Substring(0, n[0].IndexOf(',') - 1);
            string f_aftDot = n[0].Substring(n[0].IndexOf(',') + 1);
            string s_foreDot = n[1].Substring(0, n[0].IndexOf(',') - 1);
            string s_aftDot = n[1].Substring(n[0].IndexOf(',') + 1);

            BaseConverter.TryToBase(f_foreDot, fromBase1, 10, out temp1);
            RealConverter.TryToBase(f_aftDot, fromBase1, 10, out temp2, int.Parse(acc.Text));
            MessageBox.Show(temp1 + ',' + temp2);
            a = double.Parse(temp1 + ',' + temp2);
            BaseConverter.TryToBase(s_foreDot, fromBase1, 10, out temp1);
            RealConverter.TryToBase(s_aftDot, fromBase1, 10, out temp2, int.Parse(acc.Text));
            b = double.Parse(temp1 + ',' + temp2);
            
            try
            {
                switch(sign)
                {
                    case '+':
                        result = a + b;
                        t = result.ToString().Split(',');
                        BaseConverter.TryToBase(t[0], 10, ansBase, out temp1);
                        RealConverter.TryToBase(t[1], 10, ansBase, out temp2, int.Parse(acc.Text));
                        textBox1.Text = temp1 + ',' + temp2;
                        break;
                    case '-':
                        result = a - b;
                        t = result.ToString().Split(',');
                        BaseConverter.TryToBase(t[0], 10, ansBase, out temp1);
                        RealConverter.TryToBase(t[1], 10, ansBase, out temp2, int.Parse(acc.Text));
                        textBox1.Text = temp1 + ',' + temp2;
                        break;
                    case '*':
                        result = a * b;
                        t = result.ToString().Split(',');
                        BaseConverter.TryToBase(t[0], 10, ansBase, out temp1);
                        RealConverter.TryToBase(t[1], 10, ansBase, out temp2, int.Parse(acc.Text));
                        textBox1.Text = temp1 + ',' + temp2;
                        break;
                    case '/':
                        result = a / b;
                        t = result.ToString().Split(',');
                        BaseConverter.TryToBase(t[0], 10, ansBase, out temp1);
                        RealConverter.TryToBase(t[1], 10, ansBase, out temp2, int.Parse(acc.Text));
                        textBox1.Text = temp1 + ',' + temp2;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            sign = ' ';
            a = 0;
            fromBase1 = 0;
            fromBase2 = 0;
            ansBase = 0;
            b = 0;
            result = 0;
            textBox1.Text = "";
            tb_fromBase1.Text = "";
            tb_fromBase2.Text = "";
            tb_ansBase.Text = "";
            fromBase.Text = "";
            toBase.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            catch
            {
                
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            textBox1.Text = "";
            //CC.Text = "";
            sign = ' ';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            isCalc = true;
            fromBase.Visible = true;
            toBase.Visible = true;
            tb_fromBase1.Visible = false;
            tb_fromBase2.Visible = false;
            tb_ansBase.Visible = false;
            Conv_button.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            isCalc = false;
            fromBase.Visible = false;
            toBase.Visible = false;
            tb_fromBase1.Visible = true;
            tb_fromBase2.Visible = true;
            tb_ansBase.Visible = true;
            Conv_button.Visible = false;
        }

        private void Conv_button_Click(object sender, EventArgs e)
        {
            string temp1;
            string temp2 = "";
            from = int.Parse(fromBase.Text);
            to = int.Parse(toBase.Text);
            string[] input = new string[2];
            input = textBox1.Text.Split(',');
            string intPart = input[0];
            string realPart = input[1];
            BaseConverter.TryToBase(intPart, from, to, out temp1);
            RealConverter.TryToBase(realPart, from, to, out temp2, int.Parse(acc.Text));
            textBox1.Text = temp1 + "," + temp2;
        }
        #endregion
    }
}
/*
            try
            {
                sign = '/';
                a = double.Parse(textBox1.Text);
                textBox1.Text = "";
            }
            catch
            {
                if (textBox1.Text[textBox1.Text.Length - 1] == '/')
                {
                    sign = '/';
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
*/