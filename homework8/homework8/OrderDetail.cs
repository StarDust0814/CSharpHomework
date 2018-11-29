using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
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
}
