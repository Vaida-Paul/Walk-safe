using WalkSafe.Core.Entities.AbstractClasses;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Core.Entities.SafetyReportAggregate
{
    public class SafetyReport : BaseClass
    {
        public List<float> Location { get; set; } = new List<float>(2);
        public string Description { get; set; }
        public int Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public UserAccount ReportedBy { get; set; }
        public SafetyReport(float longitude, float latitude, string description, int severity, UserAccount user)
        {
            Location.Add(longitude);
            Location.Add(latitude);
            Description = description;
            Severity = severity;
            Timestamp = DateTime.Now;
            ReportedBy = user;
        }
    }
}
