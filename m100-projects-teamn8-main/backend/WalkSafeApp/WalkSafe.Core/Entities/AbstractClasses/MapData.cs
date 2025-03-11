namespace WalkSafe.Core.Entities.AbstractClasses
{
    public abstract class MapData : BaseClass
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public MapData(string longitude, string latitude, DateTime timeStamp)
        {
            Longitude = longitude;
            Latitude = latitude;
            TimeStamp = timeStamp;
        }
    }
}
