using Northwind.Domain.Entities;
using MediatR;

namespace Northwind.Application.Rooms.Queries.GetRoom
{
    class GetRoomQuery : IRequest<Room>
    { 
        public int Id { get; set; }
    }
}
