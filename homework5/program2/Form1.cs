using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        //输入CayleyTree的角度和长度
        TextBox angle1 = new TextBox() { Location = new Point(500, 20) };
        TextBox angle2 = new TextBox() { Location = new Point(500, 40) };
        TextBox length1 = new TextBox() { Location = new Point(500, 80) };
        TextBox length2 = new TextBox() { Location = new Point(500, 100) };
        Label labelOfAngle = new Label() { Width = 150, Location = new Point(500, 0) };
        Label labelOfLength = new Label() {Width=150, Location = new Point(500, 60) };

        public void init()
        {
            //添加控件
            VScrollBar vbar;
            vbar = new VScrollBar() { Location = new Point(300, 80) };
            vbar.Parent = this;
            vbar.Minimum = 0;
            vbar.Maximum = 100;
            vbar.SmallChange = 1;
            vbar.LargeChange = 10;
            vbar.Value = (vbar.Maximum - vbar.Minimum) / 2;
            vbar.ValueChanged += new EventHandler(vbar_OnValueChanged);
            this.Controls.Add(angle1);
            this.Controls.Add(angle2);
            this.Controls.Add(length1);
            this.Controls.Add(length2);
            this.Controls.Add(labelOfLength);
            this.Controls.Add(labelOfAngle);
            this.Controls.Add(vbar);
            labelOfAngle.Text = "请输入两个角度： ";
            labelOfLength.Text = "请输入两个长度： ";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        //控制粗细和颜色
        Pen blue = new Pen(Color.Blue, 3);
        Pen red = new Pen(Color.Red, 2);
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            //生长点（x1,y1）和（x2,y2）
            double x1 = x0 + leng *0.5* Math.Cos(th);
            double y1 = y0 + leng *0.5* Math.Sin(th);
            double x2 = x0 + leng *1.2* Math.Cos(th-0.2);
            double y2 = y0 + leng *1.2* Math.Sin(th-0.2);

            drawLine1(x0, y0, x1, y1);
            drawLine2(x0, y0, x2, y2);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);

        }
        void drawLine1(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(blue,(int)x0, (int)y0, (int)x1, (int)y1);
        }
        void drawLine2(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(red, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = angle1.Text;
            double d1 = double.Parse(s1);
            string s2 = angle2.Text;
            double d2 = double.Parse(s2);
            string s3 = length1.Text;
            double l1 = double.Parse(s3);
            string s4 = length2.Text;
            double l2 = double.Parse(s4);
            th1 = d1 * Math.PI / 180;
            th1 = d2 * Math.PI / 180;
            per1 = l1;
            per2 = l2;
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }


        private void vbar_OnValueChanged(object sender, EventArgs e)
        {
            //pb.Location = new Point(pb.Left, (pnl.Size.Height) * vbar.Value / (vbar.Maximum - vbar.LargeChange + 1));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
