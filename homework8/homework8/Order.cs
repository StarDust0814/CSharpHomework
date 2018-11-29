using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace homework8
{
    [Serializable]
    //订单类，存储订单明细、用户和订单号
    public class Order
    {
        [Key]
        public long orderNumber { get; set; }
        public string guestName { get; set; }
        public List<OrderDetail> orderDetail { get; set; }
        public long guestPhone { get; set; }
        public Order() {
            orderDetail = new List<OrderDetail>();
        }
       
        public Order(long orderNumber, string guestName, long guestPhone, List<OrderDetail>orderdetail)
        {
            this.orderNumber = orderNumber;
            this.guestName = guestName;
            this.guestPhone = guestPhone;
            this.orderDetail = orderdetail;
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
    
    //订单服务类，实现订单的增删改查

}
