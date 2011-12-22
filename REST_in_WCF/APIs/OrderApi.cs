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
        public HttpResponseMessage<Order> PlaceOrder(HttpRequestMessage<Order> request, Order customerOrder)
        {
            HttpResponseMessage<Order> response = null;
            
            try
            {
                if (!String.IsNullOrEmpty(customerOrder.Status))
                {
                    response = new HttpResponseMessage<Order>(HttpStatusCode.BadRequest);
                }
                else
                {
                    customerOrder.Status = "pending";
                    response = new HttpResponseMessage<Order>(customerOrder, HttpStatusCode.Created);
                    response.Headers.Location = new Uri(request.RequestUri, "order/12345");
                }

                return response;
            }
            catch (Exception)
            {
                return response = new HttpResponseMessage<Order>(HttpStatusCode.InternalServerError);
            }
        }

        [WebGet(UriTemplate = "{id}")]
        public HttpResponseMessage<Order> GetOrderDetails(int id)
        {
            HttpResponseMessage<Order> response = null;

            try
            {
                // For brevity, I'm assuming that there is only one order in the database - 12345
                if (id != 12345)
                {
                    response = new HttpResponseMessage<Order>(HttpStatusCode.NotFound);
                }
                else
                {
                    Order existingOrder = new Order();
                    existingOrder.Location = "takeAway";
                    existingOrder.Items = new List<Item>();
                    existingOrder.Items.Add(new Item() { Milk = "whole", Quantity = 1, Name = "lattee", Size = "small" });
                    existingOrder.Status = "served";
                    response = new HttpResponseMessage<Order>(existingOrder, HttpStatusCode.OK);
                }

                return response;
            }
            catch (Exception)
            {
                return response = new HttpResponseMessage<Order>(HttpStatusCode.InternalServerError);
            }
        }  

    }
}