using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTest.Steps
{
    public class BaseSteps
    {
        protected HttpClient _httpClient { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        protected const string HOST_API_LOCAL_TESTS = "http://localhost:5078";

        public BaseSteps() 
        {
            IServiceCollection services = new ServiceCollection();
            services.AddHttpClient("ApiTestClient");
            _httpClient = new HttpClient();                       
        }
    }
}
