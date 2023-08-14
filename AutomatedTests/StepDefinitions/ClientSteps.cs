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

namespace AutomatedTest.Steps
{
    [Binding]
    public class ClientSteps : BaseSteps
    {
        private const string ACCESS_API_ENDPOINT = "/api/Client";
        public int COUNT;
        public ClientSteps() { }

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
