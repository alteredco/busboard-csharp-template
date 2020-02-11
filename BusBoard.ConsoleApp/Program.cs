﻿using System;
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
                var postcodeData = TflApi.GetPostCodeData(input);
                var stopPointData = TflApi.GetStopPointData(postcodeData.Result.Latitude, postcodeData.Result.Longitude);
            
                getNearestStops(stopPointData);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("You haven't entered your postcode correctly." + e.Message);
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
                Display.DisplayBusResult(busData);
                Console.WriteLine("================================");
            }
        }
    }
}