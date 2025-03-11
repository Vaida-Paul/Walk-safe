using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.RouteAggregate
{
    public class RouteRequest
    {
        public List<float> Start { get; set; }
        public List<float> End { get; set; }
    }
}
