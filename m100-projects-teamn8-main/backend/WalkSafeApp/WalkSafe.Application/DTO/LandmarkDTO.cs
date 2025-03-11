namespace WalkSafe.Application.DTO
{
    public record class LandmarkDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
    }
}
