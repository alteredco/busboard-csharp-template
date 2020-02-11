using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            // string input  = GetPostCode();
            var postcodeData = TflApi.GetPostCodeData();
            var stopPointData = TflApi.GetStopPointData(postcodeData.Result.Latitude, postcodeData.Result.Longitude);
            
            Display.DisplayStopRadiusResult(stopPointData);
        }
        
    }
}