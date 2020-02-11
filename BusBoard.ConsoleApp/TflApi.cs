using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TflApi
    {
        public static IEnumerable<Bus> GetBusStopData(string input)
        {
            //get request to tfl api 
            RestClient tflClient = new RestClient("https://api.tfl.gov.uk/");
            RestRequest tflRequest = new RestRequest($"StopPoint/{input}/Arrivals?app_id=f7aa3bf5&app_key=b9eb9b0ca98ee8ce2ccf974e17594c0f", Method.GET);
            IRestResponse<List<Bus>> tflResponse = tflClient.Get<List<Bus>>(tflRequest);
            var fiveBuses = tflResponse.Data.OrderBy(x => x.TimeToStation).Take(5);
            return fiveBuses;
        }

        public static Location GetPostCodeData()
        {
            //get request to postcodes.io
            var postcode = "NW5 1TL";
            RestClient postcodesClient = new RestClient("http://api.postcodes.io/");
            IRestRequest postcodesRequest = new RestRequest($"/postcodes/{postcode}", Method.GET);
            IRestResponse<Location> postcodesResponse = postcodesClient.Get<Location>(postcodesRequest);
            return postcodesResponse.Data;
        }

        public static StopRadius GetStopPointData(decimal latitude, decimal longitude)
        {
            var lat = latitude.ToString();
            var lon = longitude.ToString();
            
            //get request to tfl stop point radius api
            RestClient stopRadiusClient = new RestClient("https://api.tfl.gov.uk/");
            IRestRequest stopRadiusRequest = new RestRequest("StopPoint", Method.GET)
                .AddQueryParameter("stopTypes", "NaptanPublicBusCoachTram")
                .AddQueryParameter("lat", lat)
                .AddQueryParameter("lon", lon);
            IRestResponse<StopRadius> stopRadiusResponse = stopRadiusClient.Get<StopRadius>(stopRadiusRequest);
            return stopRadiusResponse.Data;
        }
    }
}