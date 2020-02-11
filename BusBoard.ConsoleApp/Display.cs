using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class Display
    {
        // public static string GetBusStopCode()
        // {
        //     //ie: 490008660N
        //     Console.Write("Please enter your bus stop code: ");
        //     var input = Console.ReadLine();
        //     return input;
        // }

        public static void DisplayBusResult(IEnumerable<Bus> busData)
        {
            foreach (Bus bus in busData)
            {
                Console.WriteLine(
                    $"Bus Number: {bus.LineName}, ETA: {(bus.TimeToStation / 60)} min, Heading to: {bus.DestinationName}");
            }
        }
        
        public static string GetPostCode()
        {
            //ie: NW5 1TL
            Console.Write("Please enter your postcode: ");
            var input = Console.ReadLine();
            return input;
        }

        public static void DisplayPostCodeResult(Location postCodeData)
        {
            Console.WriteLine("Lat: {0}, Lon: {1}, Region: {2}", postCodeData.Result.Latitude, postCodeData.Result.Longitude, postCodeData.Result.Region);
        }
        
        // public static void DisplayStopRadiusResult()
    }
}