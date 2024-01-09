using CodeCampRestora.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.Reviews
{
    public class Review : AuditableEntity<Guid>
    {
        public string Description { set; get; }
        public int Rating { set; get; }
        public Guid OrderId {  set; get; }

    }
}
