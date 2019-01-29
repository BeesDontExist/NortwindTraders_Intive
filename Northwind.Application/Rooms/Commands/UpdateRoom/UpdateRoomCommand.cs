using MediatR;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    class UpdateRoomCommand
    {
        public int Id { get; set; }
        public string Calendar { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
    }
}
