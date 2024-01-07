using CodeCampRestora.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.BookingOrders
{
    public class BookingOrder : AuditableEntity<Guid>
    {
        public DateTime BookingTime { get; set; }
        public BookingType BookingType { get; set; }
        public int NoOfSeats { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int OrderTrackingNumber { get; set; }
        public string? SpecialNote { get; set; }
        public string? TimeNeededForServing { get; set; }
        public double SubTotal { get; set; }
        public double VAT {  get; set; }
        public double DeliveryCharge { get; set; }
        public double Discount { get; set; }
        public double TotalPrice {  get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
    }

    public enum BookingType
    {
        Dining,
        Takeout
    }

    public enum OrderStatus
    {
        Placed,
        InProgress,
        Served,
        Calcelled
    }
}
