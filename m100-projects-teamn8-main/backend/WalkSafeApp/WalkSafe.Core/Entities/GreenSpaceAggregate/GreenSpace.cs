using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.GreenSpaceAggregate
{
    public class GreenSpace : BaseClass
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Longitude { get; set; } = 0f;
        public float Latitude { get; set; } = 0f;

        public GreenSpace(string name, string description, float longitude, float latitude)
        {
            this.Name = name;
            this.Description = description;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
}
