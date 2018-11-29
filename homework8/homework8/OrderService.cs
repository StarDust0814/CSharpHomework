using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.Entity;

namespace homework8
{
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
            using(var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
            //if (orderDictionary.ContainsKey(order.orderNumber))
            //    throw new Exception("Order has existed.");
            //orderDictionary[order.orderNumber] = order;
        }
        //删除订单
        public void RemoveOrder(long ordernumber)
        {
            using(var db = new OrderDB())
            {
                var order = db.Order.Include("orderDetails").SingleOrDefault(o => o.orderNumber == ordernumber);
                db.OrderDetail.RemoveRange(order.orderDetail);
                db.Order.Remove(order);
                db.SaveChanges();
            }
            //orderDictionary.Remove(ordernumber);
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.orderDetail.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        //通过订单号查找相应订单
        public Order FindByOrderNumber(long ordernumber)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("OrderDetail").
                  SingleOrDefault(o => o.orderNumber == ordernumber);
            }
        }
        //输出所有订单
        public List<Order> FindAll()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails").ToList<Order>();
            }
        }
        //通过货物名查找相应订单
        public List<Order> FindByGoodName(string goodname)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("OrderDetail")
                  .Where(o => o.orderDetail.Where(
                    item => item.goodName.Equals(goodname)).Count() > 0);
                return query.ToList<Order>();
            }
        }
        //通过用户名查找相应订单
        public List<Order> FindByGuestName(string guestname)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("OrderDetail")
                  .Where(o => o.guestName.Equals(guestname)).ToList<Order>();
            }
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
