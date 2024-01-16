using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Orders
{
    public class OrderItem : AuditableEntity<Guid>
    {
        public string ItemName { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        // public Order? Order { get; set; }
        // public MenuItem MenuItem { get; set; }
    }
}
