using System;

using System.Windows.Forms;
using System.Drawing;

namespace program2
{
    static class Program
    {
        public class Form1 : Form
        {
            TextBox txt1 = new TextBox();
            TextBox txt2 = new TextBox();
            Button btn = new Button();
            Label lbl = new Label();

            public void init()
            {
                this.Controls.Add(txt1);
                this.Controls.Add(txt2);
                this.Controls.Add(btn);
                this.Controls.Add(lbl);

                txt1.Dock = System.Windows.Forms.DockStyle.Left;
                txt2.Dock = System.Windows.Forms.DockStyle.Right;
                lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
                btn.Dock = System.Windows.Forms.DockStyle.Fill;
                btn.Text = "计算两数的乘积";
                lbl.Text = "结果为";
                this.Size = new Size(500,500);

                btn.Click += new System.EventHandler(this.button_Click);

            }
            public void button_Click(object sender, EventArgs e)
            {

                string s1 = txt1.Text;
                string s2 = txt2.Text;
                double x = double.Parse(s1);
                double y = double.Parse(s2);
                double xy = x * y;
                lbl.Text = x + "和" + y + "的乘积为" + xy;
            }
        }
        

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 f = new Form1();
            f.Text = "multiply";
            f.init();
            
            Application.Run(f);
        }
    }
}
