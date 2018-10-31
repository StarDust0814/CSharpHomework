using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        OrderService orderservice = new OrderService();
        
        public Form1()
        {

            //事先定义好两个客户订单组合成的订单
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            orderservice.orders.Add(order1);
            //orderservice.showOrder();
            Console.WriteLine("Add");
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            orderservice.orders.Add(order2);
            //orderservice.showOrder();

            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//添加一个订单
        {
            OrderDetail[] orderDetail3 = { new OrderDetail("A", 8, 20), new OrderDetail("B", 10, 30), new OrderDetail("C", 9, 40) };
            Order order3 = new Order(3, "William", orderDetail3);


            Form1 newForm = new Form1();
            newForm.orderservice.orders.Add(order3);
            
            newForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//显示订单的用户名和订单号
        {
            int inputNumber = int.Parse(label4.Text);
            orderBindingSource.DataSource = orderservice.orders[inputNumber];
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//显示订单明细
        {
            //int inputNumber = int.Parse(label4.Text);
            //orderDetailBindingSource.DataSource = orderservice.orders[inputNumber].orderDetail[0];

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int findNumber = int.Parse(textBox1.Text);

            orderBindingSource.DataSource = orderservice.findOrderByOrderNumber(findNumber);
            orderDetailBindingSource.DataSource = orderservice.findOrderByOrderNumber(findNumber).orderDetail;
        }

        private void button6_Click(object sender, EventArgs e)//删除订单
        {
            int removeNumber = int.Parse(textBox2.Text);
            Form1 newForm = new Form1();
            newForm.orderservice.removeOrder(removeNumber);
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)//，修改之前的订单的订单明细信息
        {
            Form1 newForm = new Form1();
            OrderDetail[] orderDetail4 = { new OrderDetail("A", 50, 30), new OrderDetail("B", 60, 40) };
            newForm.orderservice.changeOrders(1, 4, "John", orderDetail4);
            newForm.orderservice.orders[0].orderDetail[0]._goodNumber= 6;
            newForm.Show();
        }

        private void orderDetailBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
