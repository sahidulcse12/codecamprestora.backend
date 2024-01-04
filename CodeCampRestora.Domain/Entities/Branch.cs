using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeCampRestora.Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public int id { get; set; }
    }
}