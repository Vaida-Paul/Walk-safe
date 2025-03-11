using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.WeatherForecastAggregate
{
    public class WeatherForecast : MapData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string Conditions { get; set; }

        public WeatherForecast(string longitude, string latitude, DateTime timeStamp, double temperature, double humidity, string conditions) :
            base(longitude, latitude, timeStamp)
        {
            Temperature = temperature;
            Humidity = humidity;
            Conditions = conditions;
        }
    }
}
