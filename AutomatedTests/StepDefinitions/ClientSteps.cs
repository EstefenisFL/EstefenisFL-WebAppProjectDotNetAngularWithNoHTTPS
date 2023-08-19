using Azure;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft;
using Newtonsoft.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace AutomatedTest.Steps
{
    [Binding]
    public class ClientSteps : BaseSteps
    {
        private const string ACCESS_API_ENDPOINT = "/api/Client";
        public int COUNT;
        private HttpResponseMessage RESPONSE;
        public ClientDTO NEWCLIENT = new ClientDTO();
        public ClientSteps() { }

        [Given("I want to create new client with (.*)")]
        public void GivenIWantToCreateNewClientWithName(string name)
        {
            NEWCLIENT.Name = name;
        }
        [Given("the phoneNumber is (.*)")]
        public void GivenIWantToCreateNewClientWithPhoneNumber(string phoneNumber)
        {
            NEWCLIENT.PhoneNumber = phoneNumber;
        }
        [Given("the cep is (.*)")]
        public void GivenIWantToCreateNewClientWithCEP(string cep)
        {
            NEWCLIENT.CEP = cep;
        }
        [Given("the registrationNumber is (.*)")]
        public void GivenIWantToCreateNewClientWithRegistrationNumber(string registrationNumber)
        {
            NEWCLIENT.RegistrationNumber = registrationNumber;
        }
        [Given("the state is (.*)")]
        public void GivenIWantToCreateNewClientWithState(string state)
        {
            NEWCLIENT.State = state;
        }
        [Given("the city is (.*)")]
        public void GivenIWantToCreateNewClientWithCity(string city)
        {
            NEWCLIENT.Name = city;
        }

        [When(@"the object for newClient was created")]
        public async Task GoingToCreateClient()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, string.Concat(HOST_API_LOCAL_TESTS, ACCESS_API_ENDPOINT));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(NEWCLIENT), Encoding.UTF8, Application.Json);
            requestMessage.Headers.Add("Accept", "application/json");
            var response = await _httpClient.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                RESPONSE = response;
            }
        }

        [Then(@"I verify if the status code for this operation request is: (.*)")]
        public void Thenverifythestatuscode(HttpStatusCode statusCode)
        {
            statusCode.Should().Be(RESPONSE.StatusCode);
        }
        [When(@"going to bring data from DB")]
        public async Task WhenTheDataWasBring()
        {
            var response = await _httpClient.GetAsync(string.Concat(HOST_API_LOCAL_TESTS, ACCESS_API_ENDPOINT));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var clientRecord = JsonConvert.DeserializeObject<IList<ClientDTO>>(responseString);
                var result = new List<ClientDTO>();
                if (clientRecord != null)
                {
                    result.AddRange(clientRecord);
                }
                COUNT = result.Count();
            }
        }

        [Then(@"verify if number of records is (.*)")]
        public void thenverifythenumberofrecords(int result)
        {
            COUNT.Should().Be(result);
        }
    }
}
