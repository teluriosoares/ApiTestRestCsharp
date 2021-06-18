using System;
using RestSharp;
using Xunit;
using FluentAssertions;

namespace apiCorreios
{
    public class Program
    {
        private IRestResponse GetCEP(object CEP)
        {
            var client = new RestClient("http://viacep.com.br/ws/" + CEP + "/json/");
            var RSrequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return client.Execute(RSrequest);
        }

        [Fact]
        public void requestSucess()
        {
            var response = GetCEP("01150000");
            response.StatusCode.Should().Be(200);
        }
    }
}
