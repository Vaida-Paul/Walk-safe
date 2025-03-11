using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.LandmarkAggregate
{
    public class Landmark : BaseClass
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Longitude { get; set; } = 0f;
        public float Latitude { get; set; } = 0f;
        public Landmark(string name, string description, float longitude, float latitude) 
        {
            Name = name;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
