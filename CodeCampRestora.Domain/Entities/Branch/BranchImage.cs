using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.Branch
{
    public class BranchImage : BaseEntity
    {

        public string ImageUrl { get; set; } = default!;

        public int ImageOrder { get; set; }
        
  
    }
}
