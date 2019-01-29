using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Queries.GetAllRooms
{
    class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, RoomsListViewModel>
    {
        private readonly NorthiwindDbContext _context;

        public GetAllRoomsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RoomsListViewModel> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Rooms.ToListAsync(cancellationToken);
            var model = new RoomsListViewModel
            {
                Products = products,
                CreateEnabled = true
            };

            return model;
        }
    }
}
