using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Orders
{
    public class OrderItem : AuditableEntity<Guid>
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        // public Order? Order { get; set; }
        // public MenuItem MenuItem { get; set; }
    }
}
