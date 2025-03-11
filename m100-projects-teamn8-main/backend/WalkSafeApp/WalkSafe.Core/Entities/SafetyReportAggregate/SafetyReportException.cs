namespace WalkSafe.Core.Entities.SafetyReportAggregate
{
    public class SafetyReportException : Exception
    {
        public SafetyReportException() { }
        public SafetyReportException(string message) : base(message) { }
        public SafetyReportException(string message, Exception inner) : base(message, inner) { }
    }
}
