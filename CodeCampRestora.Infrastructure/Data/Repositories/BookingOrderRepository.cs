using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.BookingOrders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    [ScopedLifetime]
    public class BookingOrderRepository : Repository<BookingOrder, Guid>, IBookingOrderRepository
    {
        public BookingOrderRepository(IApplicationDbContext applicationDbContext)
            : base((DbContext)applicationDbContext)
        {

        }

    }
}
