using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTestCase
{
    public class Contacts
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime start_date { get; set; }
    }

    [TestClass]
    public class RestSharpTestCase
    {
        RestClient client;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
       
        /// <summary>
        /// Get the contact list.
        /// </summary>
        /// <returns></returns>
        public IRestResponse getContactList()
        {
            RestRequest request = new RestRequest("/Contact", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        
        /// <summary>
        /// Given the on calling when get API then return contact list.
        /// </summary>
        [TestMethod]
        public void GivenOnCalling_WhenGetApi_ThenReturnContactList()
        {
            IRestResponse response = getContactList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Contacts> dataResorce = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(2, dataResorce.Count);
            foreach (Contacts contact in dataResorce)
            {
                Console.WriteLine("firstName,: " +contact.firstName + ",lastName:" + contact.lastName + ",address:" + contact.address+ ",city:" + contact.city +
                ",state:" + contact.state + ",zip:" + contact.zip + ",phoneNumber:" + contact.phoneNumber + ",email:" + contact.email + ",start_date:" + contact.start_date);
            }
        }
    }
}
