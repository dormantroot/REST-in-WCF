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
    public class ContactsApi
    {
        [WebGet(UriTemplate = "")]
        public IEnumerable<Contact> Get()
        {
            var contacts = new List<Contact>()
            {
                new Contact {ContactId = 1, Name = "Phil Haack"},
                new Contact {ContactId = 2, Name = "HongMei Ge"},
                new Contact {ContactId = 3, Name = "Glenn Block"},
                new Contact {ContactId = 4, Name = "Howard Dierking"},
                new Contact {ContactId = 5, Name = "Jeff Handley"},
                new Contact {ContactId = 6, Name = "Yavor Georgiev"}
            };
            return contacts;
        }


      [WebInvoke(UriTemplate = "", Method = "POST")]
        public IEnumerable<Contact> Post(Contact k)
        {
            Contact y = k;
            var contacts = new List<Contact>()
            {
                new Contact {ContactId = 1, Name = "Phil Haack"},
                new Contact {ContactId = 2, Name = "HongMei Ge"},
                new Contact {ContactId = 3, Name = "Glenn Block"},
                new Contact {ContactId = 4, Name = "Howard Dierking"},
                new Contact {ContactId = 5, Name = "Jeff Handley"},
                new Contact {ContactId = 6, Name = "Yavor Georgiev"}
            };
            return contacts;
        }    
    }
}