using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.EnviormentalDataAggregate
{
    public class EnvironmentalData : MapData
    {
        public int AirQualityIndex { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public EnvironmentalData(string latitude, string longitude, DateTime timeStamp, int airQualityIndex, double temperature, double humidity) : base(longitude, latitude, timeStamp)
        {
            Longitude = latitude;
            Latitude = longitude;
            TimeStamp = timeStamp;
            AirQualityIndex = airQualityIndex;
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}
