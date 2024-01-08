using CodeCampRestora.Domain.Entities.BookingOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IBookingOrderRepository : IRepository<BookingOrder,Guid>
    {
    }
}
