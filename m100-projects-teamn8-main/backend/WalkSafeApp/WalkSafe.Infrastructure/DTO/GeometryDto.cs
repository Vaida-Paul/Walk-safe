using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Infrastructure.DTO
{
    internal class GeometryDto
    {
        public string Type { get; set; }
        public List<float> Coordinates { get; set; }
    }
}
