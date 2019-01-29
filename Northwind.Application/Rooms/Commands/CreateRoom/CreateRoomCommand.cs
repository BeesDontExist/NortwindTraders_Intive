using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Coomands.CreateRoom
{
    class CreateRoomCommand : IRequest<int>
    {
        public string Calendar { get; set; }

        public int Number { get; set; }
        
        public int Price { get; set; }
    }
}
