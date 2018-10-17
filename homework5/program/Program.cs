using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1
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
        //根据订单明细计算订单的总金额
        public double SumPrice(OrderDetail[] o)
        {
            double sum = 0;
            for (int b = 0; b < o.Length; b++)
            {
                sum += o[b].sumPrice();
            }
            return sum;
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
        //获取订单明细的总金额
        public double sumPrice()
        {
            return _goodNumber * _singlePrice;
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
            OrderDetail detail1OfA = new OrderDetail("A", 2, 1000);
            OrderDetail detail2OfA = new OrderDetail("A", 1, 1000);
            OrderDetail detail3OfA = new OrderDetail("A", 3, 1000);
            OrderDetail detail1OfB = new OrderDetail("B", 3, 1500);
            OrderDetail detail2OfB = new OrderDetail("B", 2, 1500);
            OrderDetail detail3OfB = new OrderDetail("B", 3, 1500);
            OrderDetail detail1OfC = new OrderDetail("C", 3, 2000);
            OrderDetail detail2OfC = new OrderDetail("C", 2, 2000);
            OrderDetail detail3OfC = new OrderDetail("C", 1, 2000);
            OrderDetail[] orderDetail1 = { detail1OfA, detail1OfB, detail1OfC };
            Order order1 = new Order(1, "Frank", orderDetail1);
            OrderService.orders.Add(order1);
            OrderService.showOrder();
            Console.WriteLine("Add");
            OrderDetail[] orderDetail2 = { detail2OfA, detail2OfB, detail2OfC };
            OrderDetail[] orderDetail3 = { detail3OfA, detail3OfB, detail3OfC };
            Order order2 = new Order(2, "Jack", orderDetail2);
            Order order3 = new Order(3, "William", orderDetail2);
            OrderService.orders.Add(order2);
            OrderService.showOrder();
            Order[] orders = { order1, order2, order3 };
            Console.WriteLine('\n');
            //使用linq语句按照订单金额检索
            Console.WriteLine("Find by sumPrice > 10000: ");
            double[] ordersSumPrice = { order1.SumPrice(orderDetail1), order2.SumPrice(orderDetail2), order3.SumPrice(orderDetail3) };
            var sumPriceSelected = from n in orders where n.SumPrice(n.orderDetail) > 10000 select n;
            foreach (var i in sumPriceSelected)
            {
                int orderDetailLength = i.orderDetail.Length;
                int count;
                Console.WriteLine(i.orderNumber + "   " + i.guestName);
                for (count = 0; count < orderDetailLength; count++)
                {
                    Console.WriteLine(i.orderDetail[count].goodName + "   " + i.orderDetail[count].goodNumber + "   " + i.orderDetail[count].singlePrice);
                }
                Console.WriteLine('\n');
            }
            Console.WriteLine('\n');
            //使用linq语句按照商品名称检索
            Console.WriteLine("Find by goodName: ");
            var goodnameSelected = from m in orders where m.orderDetail[0].goodName == "A" select m;
            foreach (var i in goodnameSelected)
            {
                int orderDetailLength = i.orderDetail.Length;
                int count;
                Console.WriteLine(i.orderNumber + "   " + i.guestName);
                for (count = 0; count < orderDetailLength; count++)
                {
                    Console.WriteLine(i.orderDetail[count].goodName + "   " + i.orderDetail[count].goodNumber + "   " + i.orderDetail[count].singlePrice);
                }
                Console.WriteLine('\n');
            }
            Console.WriteLine('\n');
            //使用Linq语句按照客户字段检索
            Console.WriteLine("Find by guestName: ");
            var guestnameSelected = from a in orders where a.guestName == "Jack" select a;
            foreach (var i in guestnameSelected)
            {
                int orderDetailLength = i.orderDetail.Length;
                int count;
                Console.WriteLine(i.orderNumber + "   " + i.guestName);
                for (count = 0; count < orderDetailLength; count++)
                {
                    Console.WriteLine(i.orderDetail[count].goodName + "   " + i.orderDetail[count].goodNumber + "   " + i.orderDetail[count].singlePrice);
                }
                Console.WriteLine('\n');
            }

            Console.Write("Done!!!");
        }
    }
}


