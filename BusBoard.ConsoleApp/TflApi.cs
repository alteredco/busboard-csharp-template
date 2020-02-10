using System.Collections.Generic;
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

        public static IEnumerable<Location> GetPostCodeData()
        {
            //get request to postcodes.io
            RestClient postcodesClient = new RestClient("http://api.postcodes.io/postcodes/");
            RestRequest postcodesRequest = new RestRequest("NW5 1TL", Method.GET);
            IRestResponse<List<Location>> postcodesResponse = postcodesClient.Get<List<Location>>(postcodesRequest);
            return postcodesResponse.Data;
        }
    }
}