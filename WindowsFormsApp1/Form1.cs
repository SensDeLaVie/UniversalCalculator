using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application::EnableVisualStyles();
            Application::SetCompatibleTextRenderingDefault(false); 
            Application.Run(new Form1());
        }

        //Ввод основных переменных
        char sign;
        double a;
        int cc;
        double b;
        double result;
        public bool isFocused_textbox1 = false;
        public bool isFocused_CC = false;
        
        //НЕ ТРОГАТЬ!!!
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Signs);
            this.textBox1.LostFocus += new EventHandler(textbox1_unFocused);
            this.textBox1.GotFocus += new EventHandler(textbox1_Focused);
            this.CC.GotFocus += new EventHandler(CC_Focused);
            this.CC.LostFocus += new EventHandler(CC_unFocused);
        }

        //При запуске программы происходит след.
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

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

        //Если сс строка без фокуса
        private void CC_unFocused (object sender, EventArgs e)
        {
            isFocused_CC = false;
        }

        //Если сс строка с фокусом
        private void CC_Focused(object sender, EventArgs e)
        {
            isFocused_CC = true;
        }


        // Функции по нажатию на клавишы
        private void Signs(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                sign = '+';
                try
                {
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }
            if (e.KeyChar == '-')
            {
                sign = '-';
                try
                {
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }
            if (e.KeyChar == '*')
            {
                sign = '*';
                try
                {
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }
            if (e.KeyChar == '/')
            {
                sign = '/';
                try
                {
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        //Равно, цифры. (Реализовать буквы)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    b = double.Parse(textBox1.Text);
                    switch (sign)
                    {
                        case '+':
                            result = a + b;
                            textBox1.Text = result.ToString();
                            break;
                        case '-':
                            result = a - b;
                            textBox1.Text = result.ToString();
                            break;
                        case '*':
                            result = a * b;
                            textBox1.Text = result.ToString();
                            break;
                        case '/':
                            result = a / b;
                            textBox1.Text = result.ToString();
                            break;
                    }
                    ActiveControl = null;
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }

            if (!isFocused_textbox1 && !isFocused_CC)
            {                
                if (e.KeyCode == Keys.Back)
                {
                    try
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    }
                    catch
                    {

                    }
                }
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

                
                if (e.KeyCode == Keys.Delete)
                {
                    textBox1.Text = "";
                }
            }
        }
        
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
                a = double.Parse(textBox1.Text);
                textBox1.Text = "";
            }
            catch
            {
                if (textBox1.Text[textBox1.Text.Length - 1] == '+')
                {
                    sign = '+';
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '-';
                a = double.Parse(textBox1.Text);
                textBox1.Text = "";
            }
            catch
            {
                if (textBox1.Text[textBox1.Text.Length - 1] == '-')
                {
                    sign = '-';
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void multiplyer_Click(object sender, EventArgs e)
        {
            try
            {
                sign = '*';
                if (textBox1.Text != "")
                {
                    a = double.Parse(textBox1.Text);
                }
                textBox1.Text = "";
            }
            catch
            {
                if (textBox1.Text[textBox1.Text.Length - 1] == '*')
                {
                    sign = '*';
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    a = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void division_Click(object sender, EventArgs e)
        {
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
        }

        private void eq_Click(object sender, EventArgs e)
        {
            try
            {
                b = double.Parse(textBox1.Text);
                switch(sign)
                {
                    case '+':
                        result = a + b;
                        textBox1.Text = result.ToString();
                        break;
                    case '-':
                        result = a - b;
                        textBox1.Text = result.ToString();
                        break;
                    case '*':
                        result = a * b;
                        textBox1.Text = result.ToString();
                        break;
                    case '/':
                        result = a / b;
                        textBox1.Text = result.ToString();
                        break;
                }
            }
            catch
            {
                if (textBox1.Text[textBox1.Text.Length - 1] == '=')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    b = double.Parse(textBox1.Text);
                    switch (sign)
                    {
                        case '+':
                            result = a + b;
                            textBox1.Text = result.ToString();
                            break;
                        case '-':
                            result = a - b;
                            textBox1.Text = result.ToString();
                            break;
                        case '*':
                            result = a * b;
                            textBox1.Text = result.ToString();
                            break;
                        case '/':
                            result = a / b;
                            textBox1.Text = result.ToString();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            string temp;
            if (int.Parse(CC.Text) > 36)
            {
                MessageBox.Show("Invalid Input");
            }
            else
            {
                BaseConverter.TryToBase(textBox1.Text, 10, cc, out temp);
                textBox1.Text = temp;
            }
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
            if (textBox1.Text == sign.ToString())
                textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (CC.Text != "")
            {
                cc = int.Parse(CC.Text);
            }
        }
    }
}
