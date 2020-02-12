using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TflApi
    {
        public static Location GetPostCodeData(string input)
        {
            //get request to postcodes.io
            var postcode = input;
            RestClient postcodesClient = new RestClient("http://api.postcodes.io/");
            IRestRequest postcodesRequest = new RestRequest("/postcodes/{postcode}", Method.GET)
                .AddUrlSegment("postcode", postcode);
            IRestResponse<Location> postcodesResponse = postcodesClient.Get<Location>(postcodesRequest);
            return postcodesResponse.Data;
        }

        private static StopRadius GetStopPointData(decimal latitude, decimal longitude)
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
        
        public static IEnumerable<Bus> GetBusStopData(string input)
        {
            var app_id = "f7aa3bf5";
            var app_key = "b9eb9b0ca98ee8ce2ccf974e17594c0f";
            //get request to tfl api 
            RestClient tflClient = new RestClient("https://api.tfl.gov.uk/");
            RestRequest tflRequest =
                new RestRequest($"StopPoint/{input}/Arrivals?app_id={app_id}&app_key={app_key}",
                    Method.GET);
            IRestResponse<List<Bus>> tflResponse = tflClient.Get<List<Bus>>(tflRequest);
            var fiveBuses = tflResponse.Data.OrderBy(x => x.TimeToStation).Take(5);
            return fiveBuses;
        }

        public static StopRadius GetStopsNearPostcode(string input)
        {
            var postcodeData = TflApi.GetPostCodeData(input);
            var stopPointData = TflApi.GetStopPointData(postcodeData.Result.Latitude, postcodeData.Result.Longitude);
            return stopPointData;
        }
    }
}