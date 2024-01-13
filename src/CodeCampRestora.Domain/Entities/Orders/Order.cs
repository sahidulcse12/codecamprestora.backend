using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCampRestora.Domain.Entities.Orders
{
    public class Order : AuditableEntity<Guid>
    {
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public string CustomerName { get; set; } = default!;
        public string CustomerMobileNumber { get; set; } = default!;
        public DateTime BookingTime { get; set; }
        public BookingType BookingType { get; set; }
        public int NoOfSeats { get; set; }
        public OrderStatus OrderStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderTrackingNumber { get; set; }
        public string SpecialNote { get; set; } = string.Empty;
        public string TimeNeededForServing { get; set; } = string.Empty;
        public double SubTotal { get; set; }
        public double VAT {  get; set; }
        public double DeliveryCharge { get; set; }
        public double Discount { get; set; }
        public double TotalPrice {  get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        // public List<Payment> Payments { get; set; }
        // public User User { get; set; }
        // public Branch Branch { get; set; }
    }
}
