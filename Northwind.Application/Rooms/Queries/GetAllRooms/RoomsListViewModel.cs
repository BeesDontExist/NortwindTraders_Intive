using System.Collections.Generic;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Queries.GetAllRooms
{
    class RoomsListViewModel
    {
        public IEnumerable<Room> Rooms;
        public bool CreateEnabled { get; set; }
    }
}
