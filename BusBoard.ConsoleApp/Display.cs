using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class Display
    {
        public static string GetPostCode()
        {
            //ie: NW5 1TL
            Console.Write("Please enter your postcode: ");
                var input = Console.ReadLine().ToLower();
                return input;
        }

        public static void DisplayBusResult(IEnumerable<Bus> busData)
        {
            foreach (Bus bus in busData)
            {
                int timeInSecs = bus.TimeToStation;
                int seconds = bus.TimeToStation % 60;
                int minutes = bus.TimeToStation / 60;
                string eta = $"{minutes} mins:{seconds} secs";
                
                Console.WriteLine(
                    $"At Stop: {bus.StationName} -- Bus Number: {bus.LineName}, ETA: {eta}, Heading to: {bus.DestinationName}");
            }
        }
    }
}