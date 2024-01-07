using CodeCampRestora.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.BookingOrders
{
    public class OrderItem : AuditableEntity<Guid>
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid BookingOrderId { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
