using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Queries.GetRoom
{
    class GetRoomQueryHandler : MediatR.IRequestHandler<GetRoomQuery, Room>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms
                .Where(p => p.RoomId == request.Id)
                .SingleOrDefaultAsync(cancellationToken);
            if(room = null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            
            return room;
        }
    }
}
