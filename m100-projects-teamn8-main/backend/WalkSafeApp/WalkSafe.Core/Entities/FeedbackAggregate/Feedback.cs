using WalkSafe.Core.Entities.AbstractClasses;
using WalkSafe.Core.Entities.RouteAggregate;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Core.Entities.FeedbackAggregate
{
    public class Feedback : BaseClass
    {
        public UserAccount User { get; set; }
        //public Route Route { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Feedback(UserAccount user, int rating, string comment)
        {
            User = user;
            //Route = route;
            Rating = rating;
            Comment = comment;
        }
    }
}
