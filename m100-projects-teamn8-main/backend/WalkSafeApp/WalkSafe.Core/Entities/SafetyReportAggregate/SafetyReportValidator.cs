using WalkSafe.Core.Entities.AbstractClasses;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Core.Entities.SafetyReportAggregate
{
    public class SafetyReportValidator
    {
        public SafetyReportValidator() { }

        /*        public bool ValidateSafetyReport(SafetyReport safetyReport)
                {
                    return ValidateCoordinates(safetyReport.Location) && ValidateSeverity(safetyReport.Severity) &&
                        ValidateUser(safetyReport.ReportedBy);
                }
                private bool ValidateCoordinates(SpatialPoint geoCoordinate) { return true; }
                private bool ValidateSeverity(int severity) { return true; }
                private bool ValidateUser(UserAccount user) { return true; }
            }*/
    }
}
