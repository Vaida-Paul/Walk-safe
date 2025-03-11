using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Infrastructure.DTO
{
    internal class GreenSpaceDto
    {
        public string Id { get; set; }        
        public string Type { get; set; }       
        public PropertyDto Properties { get; set; } 
        public GeometryDto Geometry { get; set; }
    }
}
