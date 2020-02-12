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
            try
            {
                string input  = Display.GetPostCode();
                var nearbyStops = TflApi.GetStopsNearPostcode(input);
                
                
                getNearestStops(nearbyStops);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("You haven't entered a valid postcode. Are you in London?" + e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong... " + e.Message);
                throw;
            }
            
        }

        private static void getNearestStops(StopRadius stopPointData)
        {
            foreach (StopPoint stopPoint in stopPointData.stopPoints)
            {
                var busData = TflApi.GetBusStopData(stopPoint.NaptanId);
                Console.WriteLine("================================");
                Console.WriteLine($"{stopPoint.RoundedDistance} meters away:");
                Display.DisplayBusResult(busData);
            }
        }
        
    }
}