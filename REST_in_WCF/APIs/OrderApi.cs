using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using REST_in_WCF.Resources;
using System.ServiceModel;

namespace REST_in_WCF.APIs
{
    [ServiceContract]
    public class OrderApi
    {
         [WebInvoke(UriTemplate = "", Method = "POST")]
         public Order Post(Order customerOrder)
         {
             customerOrder.Status = "pending";
             return customerOrder;
         }  
    }
}