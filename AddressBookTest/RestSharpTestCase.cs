using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
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
        
        /// <summary>
        /// Given the multiple contact to when on post then should return contact list.
        /// </summary>
        [TestMethod]
        public void GivenMultipleContactTo_WhenOnPost_ThenShouldReturnContactList()
        {
            List<Contacts> employeeListRestApi = new List<Contacts>();
            employeeListRestApi.Add(new Contacts { firstName = "dharmesh", lastName = "hudge", address="tawarja", city="latur",state="maha",
            zip="413512",phoneNumber="816372829",email="dharma@123",start_date=new DateTime(2020,01,01)});
            employeeListRestApi.Add(new Contacts { firstName = "akash", lastName = "sangale", address="mataji", city="bang",state="kar",
            zip="413522",phoneNumber="826372829",email="aka@123",start_date=new DateTime(2019,01,02)});
            employeeListRestApi.Add(new Contacts { firstName = "kajol", lastName = "pawar", address="gandi chowk", city="nagpur",state="maha",
            zip="513512",phoneNumber="816362829",email="kaje@123",start_date=new DateTime(2018,01,01)});
            employeeListRestApi.ForEach(employeeData =>
            {
                RestRequest request = new RestRequest("/Contact", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("firstName", employeeData.firstName);
                jObjectBody.Add("lastName", employeeData.lastName);
                jObjectBody.Add("address", employeeData.address);
                jObjectBody.Add("city", employeeData.city);
                jObjectBody.Add("state", employeeData.state);
                jObjectBody.Add("zip", employeeData.zip);
                jObjectBody.Add("phoneNumber", employeeData.phoneNumber);
                jObjectBody.Add("email", employeeData.email);
                jObjectBody.Add("start_date", employeeData.start_date);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Contacts dataResorce = JsonConvert.DeserializeObject<Contacts>(response.Content);
                Assert.AreEqual(employeeData.firstName, dataResorce.firstName);
                Assert.AreEqual(employeeData.lastName, dataResorce.lastName);
                Assert.AreEqual(employeeData.address, dataResorce.address);
                Assert.AreEqual(employeeData.city, dataResorce.city);
                Assert.AreEqual(employeeData.state, dataResorce.state);
                Assert.AreEqual(employeeData.zip, dataResorce.zip);
                Assert.AreEqual(employeeData.phoneNumber, dataResorce.phoneNumber);
                Assert.AreEqual(employeeData.email, dataResorce.email);
                Assert.AreEqual(employeeData.start_date, dataResorce.start_date);
                Console.WriteLine(response.Content);
            });
            IRestResponse response = getContactList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Contacts> dataResorce = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(5, dataResorce.Count);
        }
    }
}
