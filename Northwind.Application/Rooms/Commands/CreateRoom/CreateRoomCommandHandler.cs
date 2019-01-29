using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Coomands.CreateRoom
{
    class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly NorthwindDbContext _context;

        CreateRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancelationToken)
        {
            var entity = new Room
            {
                Calendar = request.Calendar,
                Number = request.Calendar,
                Price = request.Price
            };

            _context.Add(entity);
            await _context.SaveChangesAsync(cancelationToken);

            return entity.RoomId;
        }
    }
}
