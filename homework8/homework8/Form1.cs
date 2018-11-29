using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace homework8
{

    public partial class Form1 : Form
    {
        OrderService orderservice = new OrderService();
        //BindingSource fieldsBS = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            //init();
            orderbindingsource.DataSource = orderservice.FindAll();
        }
        //OrderDetail orderDetail1 = new OrderDetail(1, "Smoke && Mirror", 2, 95);
        //OrderDetail orderDetail2 = new OrderDetail(2, "Venus", 5, 78.8);
        //OrderDetail orderDetail3 = new OrderDetail(3, "Zone", 5, 108);
        //OrderDetail orderDetail4 = new OrderDetail(4, "Virtuoso2016", 3, 98.5);
        //Order order1 = new Order(20181111001, "Frank", 13876904583);
        //Order order2 = new Order(20181111002, "Jack", 13876904584);

        //public void init()
        //{

        //    order1.AddOrderDetail(orderDetail1);
        //    order1.AddOrderDetail(orderDetail2);
        //    order1.AddOrderDetail(orderDetail3);
        //    order2.AddOrderDetail(orderDetail1);
        //    order2.AddOrderDetail(orderDetail4);

        //    orderservice = new OrderService();
        //    orderservice.AddOrder(order1);
        //    orderservice.AddOrder(order2);

        //    orderbindingsource.DataSource = orderservice.FindAll();
        //}
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void orderdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderdetaildatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(null);
            addForm.ShowDialog();
            find();
            if (orderbindingsource.Current != null)
            {
                AddForm editForm = new AddForm((Order)orderbindingsource.Current);
                editForm.ShowDialog();
                find();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }

            ////正则表达式判断2018-2050年间输入的年月日是否正确
            //string orderPattern = "^20((1[8-9]|2[1235679]|3[01345789]|4[1235679]|50)((0[469]|11)(0[1-9]|(1|2)[0-9]|30)|(02(0[1-9]|1[0-9]|2[0-8]))|(0[13578]|1(0|2))(0[1-9]|(1|2)[0-9]|3(0|1))))|((2[048]|3[26]|4[048])((0[469]|11)(0[1-9]|(1|2)[0-9]|30)|(02(0[1-9]|1[0-9]|2[0-9])|(0[13578]|1(0|2))(0[1-9]|(1|2)[0-9]|3(0|1)))))[0-9]{3}$";
            ////判断电话号码是否正确
            //string phonePattern = "^1[0-9]{10}";

            //Order order3 = new Order(20480229003, "William", 13876904585);
            //order3.AddOrderDetail(orderDetail1);
            //order3.AddOrderDetail(orderDetail2);
            //string s3 = order3.orderNumber.ToString();
            //string p3 = order3.guestPhone.ToString();
            //if (Regex.IsMatch(p3, phonePattern)&& Regex.IsMatch(s3, orderPattern) && (!orderservice.orderDictionary.ContainsKey(order3.orderNumber)))
            //{
            //    orderservice.AddOrder(order3);
            //    orderbindingsource.DataSource = orderservice.FindAll();
            //}
            //else
            //{
            //    throw new Exception("You have add a wrong order.");
            //}

            //Order order4 = new Order(20190101004, "John", 13876904586);
            //order4.AddOrderDetail(orderDetail2);
            //order4.AddOrderDetail(orderDetail3);
            //string s4 = order4.orderNumber.ToString();
            //string p4 = order4.guestPhone.ToString();
            //if (Regex.IsMatch(p4, phonePattern) && Regex.IsMatch(s4, orderPattern) && (!orderservice.orderDictionary.ContainsKey(order4.orderNumber)))
            //{
            //    orderservice.AddOrder(order4);
            //    orderbindingsource.DataSource = orderservice.FindAll();
            //}
            //else
            //{
            //    throw new Exception("You have add a wrong order.");
            //}
        }

        private void findbutton_Click(object sender, EventArgs e)
        {
            find();
        }
        private void find()
        {
            switch (findComboBox.SelectedIndex)
            {
                case 0:
                    orderbindingsource.DataSource = orderservice.FindAll();
                    break;
                case 1:
                    orderbindingsource.DataSource = orderservice.FindByGoodName(textbox.Text);
                    break;
                case 2:
                    orderbindingsource.DataSource = orderservice.FindByGuestName(textbox.Text);
                    break;
                case 3:
                    string s = textbox.Text;
                    long ordernumber = long.Parse(s);
                    orderbindingsource.DataSource = orderservice.FindByOrderNumber(ordernumber);
                    break;
                case 4:
                    string d = textbox.Text;
                    double Sum = double.Parse(d);
                    orderbindingsource.DataSource = orderservice.FindBySumPrice(Sum);
                    break;

            }
            orderbindingsource.ResetBindings(false);
            orderdetailbindingsource.ResetBindings(false);
        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            if (orderbindingsource.Current != null)
            {
                Order order = (Order)orderbindingsource.Current;
                orderservice.RemoveOrder(order.orderNumber);
                find();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
            //orderservice.RemoveOrder(20181111002);
            //orderbindingsource.DataSource = orderservice.FindAll();
        }

        private void changebutton_Click(object sender, EventArgs e)
        {
            AddForm editForm = new AddForm(null);
            editForm.ShowDialog();
            find();
            //long goodId = 5;
            //string goodname = "Tally ho";
            //double singleprice = 13.5;
            //int number = 5;
            //orderDetail1.goodName = goodname;
            //orderDetail1.goodNumber = number;
            //orderDetail1.singlePrice = singleprice;
            //orderDetail1.goodId = goodId;
            //orderbindingsource.DataSource = orderservice.FindAll();
        }

        private void importbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderservice.Import(fileName);
                orderbindingsource.DataSource = orderservice.FindAll();
            }
        }

        private void exportbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderservice.Export(fileName);
            }
            //通过xml和xslt文件生成html文件
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\newone.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"..\..\newone.xslt");

                FileStream outFileStream = File.OpenWrite(@"..\..\newone.html");
                XmlTextWriter writer =
                new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);

            }
            catch (XmlException d)
            {
                Console.WriteLine("XML Exception:" + d.ToString());
            }
            catch (XsltException d)
            {
                Console.WriteLine("XSLT Exception:" + d.ToString());
            }
            
        }
    }
}
