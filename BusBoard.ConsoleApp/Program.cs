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
            IRestResponse<List<Bus>> response = client.Get<List<Bus>>(request);

            foreach (Bus bus in response.Data)
            {
                Console.WriteLine($"Bus Number: {bus.LineName}, ETA: {bus.TimeToStation}, Heading to: {bus.DestinationName}");
            }

        }
    }
}