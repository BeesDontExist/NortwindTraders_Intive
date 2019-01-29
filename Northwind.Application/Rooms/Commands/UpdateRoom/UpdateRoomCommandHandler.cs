using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;


namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly NorthwindDbContext _context;

        public UpdateRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Rooms.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.RoomId = request.Id;
            entity.Number = request.Number;
            entity.Price = request.Price;
            entity.Calendar = request.Calendar;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
  
    }
}

