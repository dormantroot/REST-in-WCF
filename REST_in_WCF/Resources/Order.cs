using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_in_WCF.Resources
{
    public class Order
    {
        public string Location { get; set; }
        public List<Item> Items { get; set; }
        public String Status { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Milk { get; set; }
        public string Size { get; set; }
    }
}