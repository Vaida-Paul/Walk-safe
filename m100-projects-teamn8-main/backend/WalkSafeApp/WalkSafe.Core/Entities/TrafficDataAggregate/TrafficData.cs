using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.TrafficData
{
    internal class TrafficData : MapData
    {
        public int TrafficDensity { get; set; }
        public TrafficData(string longitude, string latitude, DateTime timeStamp, int trafficDensity) : base(longitude, latitude, timeStamp)
        {
            TrafficDensity = trafficDensity;
        }
    }
}
