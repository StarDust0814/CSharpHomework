using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    //订单类，包含订单号、用户名、多条订单明细
    class Order
    {
        private int _orderNumber;
        private string _guestName;
        OrderDetail[] _orderDetails;
        public Order(int orderNumber, string guestName, OrderDetail[] orderDetails)
        {
            this._orderNumber = orderNumber;
            this._guestName = guestName;
            this._orderDetails = orderDetails;
        }
        public string guestName
        {
            get { return _guestName; }
        }
        public int orderNumber
        {
            get { return _orderNumber; }
        }
        public OrderDetail[] orderDetail
        {
            get { return _orderDetails; }
        }
    }
    //订单明细，即一个用户所需的所有商品、数量、单价
    class OrderDetail
    {
        private string _goodName;
        private int _goodNumber;
        private double _singlePrice;
        public OrderDetail(string goodName, int goodNumber, double singlePrice)
        {
            this._goodName = goodName;
            this._goodNumber = goodNumber;
            this._singlePrice = singlePrice;
        }
        public string goodName
        {
            get { return _goodName; }
        }
        public int goodNumber
        {
            get { return _goodNumber; }
        }
        public double singlePrice
        {
            get { return _singlePrice; }
        }
    }
    //订单服务
    class OrderService
    {
        //存储所有订单数据
        public static List<Order> orders = new List<Order>();
        //展示订单信息
        public static void showOrder()
        {
            foreach (Order o in orders)
            {
                int orderDetailLength = o.orderDetail.Length;
                Console.WriteLine(o.orderNumber + "   " + o.guestName);
                for (int count = 0; count < orderDetailLength; count++)
                {
                    Console.WriteLine(o.orderDetail[count].goodName + "   " + o.orderDetail[count].goodNumber + "   " + o.orderDetail[count].singlePrice);
                }
                Console.Write("\n"); ;
            }
        }
        //删除订单
        public static void removeOrder(int orderNumber)
        {
            bool have = false;//判断是否有该订单号的订单
            foreach (Order o in orders)
            {
                if (o.orderNumber == orderNumber)
                {
                    have = true;
                    orders.Remove(o);
                    break;
                }
            }
            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you don't need to remove it.", "remove wrong");
            }
        }
        //修改订单内容
        public static void changeOrders(int changeNumber, int orderNumber, string guestName, OrderDetail[] orderDetails)
        {
            bool exit = false;//判断是否有该订单号的订单
            foreach (Order o in orders)
            {
                if (o.orderNumber == changeNumber)
                {
                    exit = true;
                    orders[changeNumber - 1] = new Order(orderNumber, guestName, orderDetails);
                    break;
                }
            }
            if (exit == false) { throw new MyOrderException("The order doesn't exit, you have to input new one.", "change wrong"); }
        }
        //通过订单号查询订单
        public static void findOrderByOrderNumber(int orderNumber)
        {
            bool have = false;//判断是否有该订单号的订单
            foreach (Order o in orders)
            {
                if (o.orderNumber == orderNumber)
                {
                    have = true;
                    int orderDetailLength = o.orderDetail.Length;
                    Console.WriteLine(o.orderNumber + "   " + o.guestName);
                    for (int count = 0; count < orderDetailLength; count++)
                    {
                        Console.WriteLine(o.orderDetail[count].goodName + "   " + o.orderDetail[count].goodNumber + "   " + o.orderDetail[count].singlePrice);
                    }
                    break;
                }
            }
            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you have to input a new ordernumber.", "findByNumber wrong");
            }
        }
        //通过商品名查询订单
        public static void findOrderByGoodName(string goodName)
        {
            bool have = false;
            foreach (Order o in orders)
            {
                int orderDetailLength = o.orderDetail.Length;
                for (int count = 0; count < orderDetailLength; count++)
                {
                    if (o.orderDetail[count].goodName == goodName)
                    {
                        have = true;
                        Console.WriteLine(o.orderNumber + "   " + o.guestName);
                        Console.WriteLine(o.orderDetail[count].goodName + "   " + o.orderDetail[count].goodNumber + "   " + o.orderDetail[count].singlePrice);
                    }
                }
            }
            if (have == false) { throw new MyOrderException("The order doesn't exit, you have to input a new goodname.", "findByName wrong"); }
        }
        //通过用户名查询订单
        public static void findOrderByGuestName(string guestName)
        {
            bool have = false;
            foreach (Order o in orders)
            {
                if (o.guestName == guestName)
                {
                    have = true;
                    int orderDetailLength = o.orderDetail.Length;
                    Console.WriteLine(o.orderNumber + "   " + o.guestName);
                    for (int count = 0; count < orderDetailLength; count++)
                    {
                        Console.WriteLine(o.orderDetail[count].goodName + "   " + o.orderDetail[count].goodNumber + "   " + o.orderDetail[count].singlePrice);
                    }
                    break;
                }
            }
            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you have to input a new guestName.", "findByGuest wrong");
            }
        }
    }
    //异常处理类
    public class MyOrderException : ApplicationException
    {
        private string information;
        public MyOrderException(string message, string information) : base(message)
        {
            this.information = information;
        }
        public string getInformation()
        {
            return information;
        }
    }
    class program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to use the order system!");
            OrderDetail[] orderDetail1 = { new OrderDetail("A", 5, 20), new OrderDetail("B", 6, 30), new OrderDetail("C", 7, 40) };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderService.orders.Add(order1);
            OrderService.showOrder();
            Console.WriteLine("Add");
            OrderDetail[] orderDetail2 = { new OrderDetail("A", 5, 30), new OrderDetail("B", 6, 40) };
            Order order2 = new Order(2, "Jack", orderDetail2);
            OrderService.orders.Add(order2);
            OrderService.showOrder();
            Console.WriteLine("Change and please input the number of order you need to change: ");
            try
            {
                string c = Console.ReadLine();
                int changeNumber = int.Parse(c);
                OrderDetail[] orderDetail3 = { new OrderDetail("A", 50, 50), new OrderDetail("C", 60, 60) };
                OrderService.changeOrders(changeNumber, 3, "William", orderDetail3);
                OrderService.showOrder();
            }
            catch (MyOrderException e)
            {
                Console.WriteLine("Fail to change!" + e.getInformation());
            }
            Console.WriteLine("Remove and please input the number of order you need to remove: ");
            try
            {
                string r = Console.ReadLine();
                int removeNumber = int.Parse(r);
                OrderService.removeOrder(removeNumber);
                OrderService.showOrder();
            }
            catch (MyOrderException e)
            {
                Console.WriteLine("Fail to remove!" + e.getInformation());
            }
            Console.WriteLine("Find by orderNumber: ");
            try
            {
                string fo = Console.ReadLine();
                int findNumber = int.Parse(fo);
                OrderService.findOrderByOrderNumber(findNumber);
            }
            catch (MyOrderException e)
            {
                Console.WriteLine("Fail to find!" + e.getInformation());
            }
            //如上同理，不再多做异常信息输出
            Console.WriteLine("Find by goodName: ");
            OrderService.findOrderByGoodName("A");
            Console.WriteLine("Find by guestName: ");
            string fg = Console.ReadLine();
            OrderService.findOrderByGuestName(fg);
            Console.Write("Done!!!");
        }
    }
}
