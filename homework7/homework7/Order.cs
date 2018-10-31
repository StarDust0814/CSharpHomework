using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    //订单类，包含订单号、用户名、多条订单明细
    [Serializable]
    public class Order
    {
        private int _orderNumber;
        private string _guestName;
        OrderDetail[] _orderDetails;
        public Order() { }
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
    [Serializable]
    public class OrderDetail
    {
        public string _goodName;
        public int _goodNumber;
        public double _singlePrice;
        public OrderDetail() { }
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

    public class OrderService
    {
        public bool deserialize = false;
        //存储所有订单数据
        public List<Order> orders = new List<Order>();
        ////展示订单信息
        //public void showOrder()
        //{
        //    foreach (Order o in orders)
        //    {
        //        int orderDetailLength = o.orderDetail.Length;
        //        Console.WriteLine(o.orderNumber + "   " + o.guestName);
        //        for (int count = 0; count < orderDetailLength; count++)
        //        {
        //            Console.WriteLine(o.orderDetail[count].goodName + "   " + o.orderDetail[count].goodNumber + "   " + o.orderDetail[count].singlePrice);
        //        }
        //        Console.Write("\n"); ;
        //    }
        //}
        //删除订单
        public List<Order> removeOrder(int orderNumber)
        {
            bool have = false;//判断是否有该订单号的订单
            foreach (Order o in orders)
            {
                if (o.orderNumber == orderNumber)
                {
                    have = true;
                    orders.Remove(o);
                    return orders;
                }
            }
            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you don't need to remove it.", "remove wrong");
            }
            return orders;
            
        }
        //修改订单内容
        public List<Order> changeOrders(int changeNumber, int orderNumber, string guestName, OrderDetail[] orderDetails)
        {
            bool exit = false;//判断是否有该订单号的订单
            foreach (Order o in orders)
            {
                if (o.orderNumber == changeNumber)
                {
                    exit = true;
                    orders[changeNumber - 1] = new Order(orderNumber, guestName, orderDetails);
                    return orders;
                }
            }
            if (exit == false) { throw new MyOrderException("The order doesn't exit, you have to input new one.", "change wrong"); }
            return orders;
        }
        //通过订单号查询订单
        public Order findOrderByOrderNumber(int orderNumber)
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
                    return o;
                }
            }

            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you have to input a new ordernumber.", "findByNumber wrong");
            }
            return null;
        }
        //通过商品名查询订单
        public int findOrderByGoodName(string goodName)
        {
            bool have = false;
            int ordersLength = orders.Count;
            int number = 0;
            int a = 0;
            while (number < ordersLength)
            {
                int orderDetailLength = orders[number].orderDetail.Length;
                for (int count = 0; count < orderDetailLength; count++)
                {
                    if (orders[number].orderDetail[count].goodName == goodName)
                    {
                        have = true;
                        Console.WriteLine(orders[number].orderNumber + "   " + orders[number].guestName);
                        Console.WriteLine(orders[number].orderDetail[count].goodName + "   " + orders[number].orderDetail[count].goodNumber + "   " + orders[number].orderDetail[count].singlePrice);
                        a++;
                    }

                }
                number++;
            }

            if (have == false) { throw new MyOrderException("The order doesn't exit, you have to input a new goodname.", "findByName wrong"); }
            return a;
        }
        //通过用户名查询订单
        public bool findOrderByGuestName(string guestName)
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
                    return true;
                }
            }
            if (have == false)
            {
                throw new MyOrderException("The order doesn't exit, you have to input a new guestName.", "findByGuest wrong");
            }
            return false;
        }
        ////将订单序列化
        //public bool Export(string xmlName, List<Order> o)
        //{

        //    XmlSerializer xmlOrders = new XmlSerializer(typeof(List<Order>));
        //    using (FileStream fs = new FileStream(xmlName, FileMode.Create))
        //    {
        //        xmlOrders.Serialize(fs, o);
        //    }
        //    Console.WriteLine("Export done!!!");
        //    return true;
        //}
        ////将订单反序列化
        //public object Import(string name)
        //{
        //    XmlSerializer xmlOrders = new XmlSerializer(typeof(List<Order>));
        //    FileStream fs = new FileStream(name, FileMode.Open);
        //    object obj = xmlOrders.Deserialize(fs);
        //    Console.WriteLine(obj);
        //    fs.Close();
        //    Console.WriteLine("Import done!!!");
        //    deserialize = true;
        //    return obj;
        //}
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
}
