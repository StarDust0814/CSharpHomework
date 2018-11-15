using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework8
{
    [Serializable]
    //订单类，存储订单明细、用户和订单号
    public class Order
    {
        private long _orderNumber;
        private string _guestName;
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        private long _guestPhone;
        public Order() { }
       
        public Order(long orderNumber, string guestName, long guestPhone)
        {
            this._orderNumber = orderNumber;
            this._guestName = guestName;
            this._guestPhone = guestPhone;
        }
        public long orderNumber
        {
            set { _orderNumber = value; }
            get { return _orderNumber; }
        }
        public string guestName
        {
            set { _guestName = value; }
            get { return _guestName; }
        }
        public long guestPhone
        {
            set { _guestPhone = value; }
            get { return _guestPhone; }
        }
        public List<OrderDetail> orderDetail
        {
            get { return this.orderDetails; }
        }
        public double Sum
        {
            get
            {
                //lambda表达式求总价
                return orderDetail.Sum(d => d.goodNumber * d.singlePrice);
            }
        }
        //添加订单明细
        public void AddOrderDetail(OrderDetail ot)
        {
            //如果已经包含则不需要添加
            if (this.orderDetail.Contains(ot))
            {
                throw new Exception("The orderdetail has existed, you don't need to add it.");
            }
            orderDetail.Add(ot);
        }
        //删除订单明细
        public void RemoveOrderdetail(long goodId)
        {
            bool have = false;//判断是否有该订单明细号的订单
            foreach (OrderDetail od in orderDetail)
            {
                if (od.goodId == goodId)
                {
                    have = true;
                    orderDetail.Remove(od);
                    break;
                }
            }
            if (have == false)
            {
                throw new Exception("The orderdetail doesn't exit, you don't need to remove it.");
            }
        }
        //重写ToString方法用于输出
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderNumber:{orderNumber}, guest:({guestName}),sum:{Sum}";
            //遍历所有orderdetail并输出
            orderDetails.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
    //订单明细类，存储相应的订单明细信息
    [Serializable]
    public class OrderDetail
    {
        private long _goodId;
        private string _goodName;
        private int _goodNumber;
        private double _singlePrice;

        public OrderDetail() { }
        public OrderDetail(long goodId, string goodName, int goodNumber, double singlePrice)
        {
            this._goodId = goodId;
            this._goodName = goodName;
            this._goodNumber = goodNumber;
            this._singlePrice = singlePrice;
        }
        public long goodId
        {
            set { _goodId = value; }
            get { return _goodId; }
        }
        public string goodName
        {
            set { _goodName = value; }
            get { return _goodName; }
        }
        public int goodNumber
        {
            set { _goodNumber = value; }
            get { return _goodNumber; }
        }
        public double singlePrice
        {
            set { _singlePrice = value; }
            get { return _singlePrice; }
        }
        public override string ToString()
        {
            string result = "";
            result += $"goodId:{goodId}:  ";
            result += $"goodname:{goodName}:  " + $", goodnumber:{goodNumber}" + $", singleprice:{singlePrice}";
            return result;
        }
    }
    //订单服务类，实现订单的增删改查
    public class OrderService
    {
        //创建一个订单的字典，用订单号作为Key，订单作为value
        public Dictionary<long, Order> orderDictionary;
        public OrderService()
        {
            orderDictionary = new Dictionary<long, Order>();
        }
        //添加订单
        public void AddOrder(Order order)
        {
            if (orderDictionary.ContainsKey(order.orderNumber))
                throw new Exception("Order has existed.");
            orderDictionary[order.orderNumber] = order;
        }
        //删除订单
        public void RemoveOrder(long ordernumber)
        {
            orderDictionary.Remove(ordernumber);
        }
        //通过订单号查找相应订单
        public Order FindByOrderNumber(long ordernumber)
        {
            if (orderDictionary.ContainsKey(ordernumber))
                return orderDictionary[ordernumber];
            return null;
        }
        //输出所有订单
        public List<Order> FindAll()
        {
            return orderDictionary.Values.ToList();
        }
        //通过货物名查找相应订单
        public List<Order> FindByGoodName(string goodname)
        {
            var find = orderDictionary.Values.Where(order => order.orderDetail.Where(d => d.goodName == goodname).Count() > 0);
            return find.ToList();
        }
        //通过用户名查找相应订单
        public List<Order> FindByGuestName(string guestname)
        {
            var find = orderDictionary.Values
                .Where(order => order.guestName == guestname);
            return find.ToList();
        }
        //通过订单总价查找相应订单
        public List<Order> FindBySumPrice(double sumprice)
        {
            var find = orderDictionary.Values.Where(order => order.Sum > sumprice);
            return find.ToList();
        }
        //反序列化
        public void Export(String filename)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xml.Serialize(fs, orderDictionary.Values.ToList());
            }
        }
        //序列化
        public List<Order> Import(string path)
        {
            //判断xml文件的后缀名是否为.xml
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException("This is not a regular xml.");
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            List<Order> newXml = new List<Order>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xml.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!orderDictionary.Keys.Contains(order.orderNumber))
                    {
                        orderDictionary[order.orderNumber] = order;
                        newXml.Add(order);
                    }
                });
            }
            return newXml;
        }
    }
}
