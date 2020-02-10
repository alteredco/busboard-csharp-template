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
            string input  = GetBusStopCode();
            var busData = TflApi.GetPostCodeData();

            //DisplayResult(busData);
        }

        private static string GetBusStopCode()
        {
            //ie: 490008660N
            Console.Write("Please enter your bus stop code: ");
            var input = Console.ReadLine();
            return input;
        }



        private static void DisplayResult(IEnumerable<Bus> busData)
        {
            foreach (Bus bus in busData)
            {
                Console.WriteLine($"Bus Number: {bus.LineName}, ETA: {(bus.TimeToStation/60)} min, Heading to: {bus.DestinationName}");
            }
        }
    }
}