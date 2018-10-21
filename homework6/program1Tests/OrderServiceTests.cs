using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        //删除订单信息（正确输入）
        public void removeOrderTestT()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            OrderService orderservice2 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            orderservice2.orders.Add(order2);
            orderservice1.removeOrder(1);
            Assert.AreEqual(orderservice1.orders[0].guestName, orderservice2.orders[0].guestName);
        }
        [TestMethod()]
        //删除订单信息（错误输入）
        public void removeOrderTestF()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            OrderService orderservice2 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            orderservice2.orders.Add(order2);
            orderservice1.removeOrder(9);
            Assert.AreEqual(orderservice1.orders[0].guestName, orderservice2.orders[0].guestName);
        }
        
        [TestMethod()]
        //通过订单号查询订单信息（正确输入）
        public void findOrderByOrderNumberTestT()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            bool exist = orderservice1.findOrderByOrderNumber(1);
            Assert.AreEqual(exist, true);
        }
        [TestMethod()]
        //通过订单号查询订单信息（错误输入）
        public void findOrderByOrderNumberTestF()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            bool exist = orderservice1.findOrderByOrderNumber(5);
            Assert.AreEqual(exist, true);
        }
        [TestMethod()]
        //通过商品名查询订单信息（正确输入）
        public void findOrderByGoodNameTestT()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);

            Assert.IsTrue(orderservice1.findOrderByGoodName("A") > 0);
        }

        [TestMethod()]
        //通过商品名查询订单信息（错误输入）
        public void findOrderByGoodNameTestF()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            Assert.IsTrue(orderservice1.findOrderByGoodName("J") > 0);

        }
        [TestMethod()]
        //通过用户名查询订单信息（正确输入）
        public void findOrderByGuestNameTestT()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            bool exist = orderservice1.findOrderByGuestName("Frank");
            Assert.AreEqual(exist, true);
        }
        [TestMethod()]
        //通过用户名查询订单信息（错误输入）
        public void findOrderByGuestNameTestF()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            bool exist = orderservice1.findOrderByGuestName("William");
            Assert.AreEqual(exist, true);
        }
        [TestMethod()]
        public void ExportTest()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            string xmlFileName = "ordersXml.xml";
            bool success = orderservice1.Export(xmlFileName, orderservice1.orders);
            Assert.AreEqual(success, true);
        }
        [TestMethod()]
        //反序列化（正确输入）
        public void ImportTestT()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            string xmlFileName = "ordersXml.xml";
            orderservice1.Export(xmlFileName, orderservice1.orders);
            object obj = orderservice1.Import(xmlFileName);
            Assert.AreEqual(orderservice1.deserialize, true);
        }
        [TestMethod()]
        //反序列化（错误输入）
        public void ImportTestF()
        {
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService orderservice1 = new OrderService();
            orderservice1.orders.Add(order1);
            orderservice1.orders.Add(order2);
            string xmlFileName = "ordersXml.xml";
            string xmlFileName1 = "ordersXml1.xml";
            orderservice1.Export(xmlFileName, orderservice1.orders);
            object obj = orderservice1.Import(xmlFileName1);
            Assert.AreEqual(orderservice1.deserialize, true);
        }
    }
}