using CNS_SampleProject.Objects;
using CNS_SampleProject.Resources;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace CNS_SampleProject.Tests
{
    internal class Tests_API
    {
        public static RestResponse? response;
        public static RestClient clientOrangeCRM = new RestClient("https://opensource-demo.orangehrmlive.com");
        public static RestClient clientFakeStoreAPI = new RestClient("https://fakestoreapi.com/");
        public static double expectedRateSum = 71.2;
        public static double expectedPriceOfProductIdThree = 55.99;

        [Test]
        public static void Login()
        {
            RestRequest request = new RestRequest("/web/index.php/auth/validate", Method.Post);

            request.AddParameter("username", AccountCreds.adminUserLogin);
            request.AddParameter("password", AccountCreds.adminUserPass);

            response = clientOrangeCRM.Execute(request);

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode), "Status code is not OK (200)");
        }


        [Test]
        public static void FakeStoreAPI_GetAllItems()
        {
            RestRequest request = new RestRequest("/products");
            RestResponse response = clientFakeStoreAPI.Get(request);

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode), "Status code is not OK (200)");
        }


        [Test]
        public static void FakeStoreAPI_GetThirdItem()
        {
            RestRequest request = new RestRequest("/products");
            RestResponse response = clientFakeStoreAPI.Get(request);

            string? responseString = response.Content;

            List<Product>? products = JsonConvert.DeserializeObject<List<Product>>(responseString); //deserialize json into list 

            Product? itemThree = products?.FirstOrDefault(i => i.Id == 3); //save item with id=3 
            Assert.That(itemThree != null, "Product with Id=3 not found");

            double? price = Convert.ToDouble(itemThree?.Price);
            Assert.That(expectedPriceOfProductIdThree, Is.EqualTo(price));
        }


        [Test]
        public static void FakeStoreAPI_SumRating()
        {
            var client = new RestClient("https://fakestoreapi.com/");
            var request = new RestRequest("/products");

            RestResponse response = client.Get(request);
            string? responseString = response.Content;

            List<Product>? products = JsonConvert.DeserializeObject<List<Product>>(responseString); //deserialize json into list 
            List<Rating> ratings = products.Select(i => i.Rating).ToList(); //save list of ratings

            double rating = Math.Round(ratings.Select(i => i.Rate).Sum(), 1); //get sum of Rates values 
            Assert.That(expectedRateSum, Is.EqualTo(rating));
        }
    }
}
