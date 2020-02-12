using System;
using System.Text.RegularExpressions;

namespace BusBoard
{
    public class StopPoint
    {
        public string NaptanId { get; set; }
        public double Distance { get; set; }

        public double RoundedDistance => Math.Round(Distance, 0);
    }
}