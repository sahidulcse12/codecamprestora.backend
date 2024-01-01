using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace CodeCampRestora.Domain.Entities.Branchs
{
    public class Branch : BaseEntity
    {
        //public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        //public List<string> TagLine { get; set; }

        //public Guid ResturantId { get; set; }

         // Relationship 
        public Address? Address { get; set; }
        public PriceRange? PriceRange { get; set; }

        //public IList<BranchImage> BranchImages { get; set; }
        public IList<OpeningClosingTime> OpeningClosingTimes { get; set; }
        public Resturant Resturant { get; set; }
        public IList<CuisineType> CuisineTypes { get; set; }
     }
 

    }

     

