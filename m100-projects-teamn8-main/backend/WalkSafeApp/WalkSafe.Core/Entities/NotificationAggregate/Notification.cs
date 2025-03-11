using WalkSafe.Core.Entities.AbstractClasses;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Core.Entities.NotificationAggregate
{
    public class Notification : BaseClass
    {
        public UserAccount User { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool ReadStatus { get; set; }
        public Notification(UserAccount user, string message, DateTime date, bool readStatus)
        {
            User = user;
            Message = message;
            Date = date;
            ReadStatus = readStatus;
        }
    }
}
