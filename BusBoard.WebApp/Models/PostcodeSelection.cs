namespace BusBoard.WebApp.Models
{
    public class PostcodeSelection
    {
        public string Postcode { get; set; }

        public StopRadius GetNearestStops => TflApi.GetStopsNearPostcode(Postcode);

    }
}