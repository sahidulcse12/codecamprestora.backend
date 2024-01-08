using CodeCampRestora.Domain.Entities.BookingOrders;
using CodeCampRestora.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.DTOs;

public class BookingOrderDTO
{
    public BookingOrderDTO()
    {
        OrderItems = new List<OrderItemDTO>();
    }
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
    public double VAT { get; set; }
    public double DeliveryCharge { get; set; }
    public double Discount { get; set; }
    public double TotalPrice { get; set; }
    public List<OrderItemDTO>? OrderItems { get; set; }
    // public List<Payment> Payments { get; set; }
    // public User User { get; set; }
    // public Branch Branch { get; set; }
}

public class OrderItemDTO
{
    public int Quantity { get; set; }
    public double Price { get; set; }
    public Guid BookingOrderId { get; set; }
    public Guid MenuItemId { get; set; }
    // public BookingOrderDTO? BookingOrder { get; set; }
    // public MenuItem MenuItem { get; set; }
}

