using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.Branchs
{
    public class Address : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Division { get; set; }

        public string District { get; set; }
        public string Thana { get; set; }
        public string AreaDetails { get; set; }
    }
}
