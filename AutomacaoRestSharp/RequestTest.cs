using System;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoRestSharp
{
    class RequestTest
    {

        [Test]
        public void AddPetSucess()
        {
            //params
            RestClient client = new RestClient("https://petstore.swagger.io");
            RestRequest request = new RestRequest("v2/pet", Method.POST);

            string body = @"{
                ""id"": 900658,
                ""category"": {
                    ""id"": 0
                },
                ""name"": ""zarat"",
                ""status"": ""available""    
            }";

            //act
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public void AddPetIDMax()
        {
            //params
            RestClient client = new RestClient("https://petstore.swagger.io");
            RestRequest request = new RestRequest("v2/pet", Method.POST);

            string body = @"{
                ""id"": 999500999654455584658,
                ""category"": {
                    ""id"": 0
                },
                ""name"": ""zarat"",
                ""status"": ""available""    
            }";

            //act
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public void AddPetIDAlphaN()
        {
            //params
            RestClient client = new RestClient("https://petstore.swagger.io");
            RestRequest request = new RestRequest("v2/pet", Method.POST);

            string body = @"{
                ""id"": 55etsdx55,
                ""category"": {
                    ""id"": 0
                },
                ""name"": ""zarat"",
                ""status"": ""available""    
            }";

            //act
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.That(response, Is.Not.Null);
        }


        [Test]
        public void AddPetIDNegative()
        {
            //params
            RestClient client = new RestClient("https://petstore.swagger.io");
            RestRequest request = new RestRequest("v2/pet", Method.POST);

            string body = @"{
                ""id"": -99,
                ""category"": {
                    ""id"": 0
                },
                ""name"": ""zarat"",
                ""status"": ""available""    
            }";

            //act
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public void AddPetNoBody()
        {
            //params
            RestClient client = new RestClient("https://petstore.swagger.io");
            RestRequest request = new RestRequest("v2/pet", Method.POST);

            string body ="" ;

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //act
            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.UnsupportedMediaType, response.StatusCode);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public void SearchPet()
        {
            //parms
            RestClient client = new RestClient("https://petstore.swagger.io/");
            RestRequest request = new RestRequest("v2/pet/900658", Method.GET);

            //act
            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            //test
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Requisição apresentou status Divergente");
            Assert.That(response, Is.Not.Null);
            Assert.AreEqual("900658", response.Data["id"].ToString(), "Id é igual");
            Assert.AreEqual("available", response.Data["status"].ToString(), "Status é available");
            Assert.AreEqual("zarat", response.Data["name"].ToString(), "O nome é valido");
            Assert.That(response, Is.Not.Null);
        }
        
    }
}
