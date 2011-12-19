using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using REST_in_WCF.Resources;
using System.ServiceModel;
using System.Net.Http;
using System.Net;

namespace REST_in_WCF.APIs
{
    [ServiceContract]
    public class OrderApi
    {
         [WebInvoke(UriTemplate = "", Method = "POST")]
        public HttpResponseMessage<Order> Post(Order customerOrder)
         {
             if (!String.IsNullOrEmpty(customerOrder.Status))
             {
                return new HttpResponseMessage<Order>(HttpStatusCode.BadRequest);
             }
             else
             {
                 customerOrder.Status = "pending";
                 return new HttpResponseMessage<Order>(customerOrder, HttpStatusCode.Created);
             }
             
         }  
    }
}