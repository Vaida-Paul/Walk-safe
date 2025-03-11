using System.Text.Json.Serialization;

namespace WalkSafe.Core.Entities.UserAggregate
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        Guest,
        User,
        Admin
    }
}
