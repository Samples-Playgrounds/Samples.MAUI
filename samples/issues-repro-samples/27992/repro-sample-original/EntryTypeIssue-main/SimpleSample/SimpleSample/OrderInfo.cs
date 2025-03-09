using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSample
{
    public class OrderInfo
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }

        public string Customer {  get; set; }

        public string ShipCity {  get; set; }

        public string ShipCountry { get; set; }

        public OrderInfo(string orderId, string customerId, string country, string customer, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.Customer = customer;
            this.ShipCountry = country;
            this.ShipCity = shipCity;
        }
    }
}
