using BusBoard.WebApp.Models;

namespace BusBoard.WebApp.ViewModel
{
    public class BusInfo
    {
        public StopRadius _nearestStops;

        public string Postcode { get; }

        public BusInfo (StopRadius nearestStops)
        {
            NearestStops :
            _nearestStops = nearestStops;
        }
    }
}