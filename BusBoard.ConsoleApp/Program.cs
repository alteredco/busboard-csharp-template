using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;


namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            //ie: 490008660N
            Console.Write("Please enter your bus stop code: ");
            var input = Console.ReadLine();
            RestClient client = new RestClient("https://api.tfl.gov.uk/");
            RestRequest request = new RestRequest($"StopPoint/{input}/Arrivals?app_id=f7aa3bf5&app_key=b9eb9b0ca98ee8ce2ccf974e17594c0f", Method.GET);
            IRestResponse response = client.Get(request);
            var jsonConvert = JsonConvert.DeserializeObject<List<JObject>>(response.Content);
            
            foreach (var o in jsonConvert)
            {
                Console.WriteLine("Bus Number: {0}, ETA: {1}, Heading to: {2}", o.Property("lineName").Value, o.Property("expectedArrival").Value, o.Property("towards").Value);
            }

        }
    }
}