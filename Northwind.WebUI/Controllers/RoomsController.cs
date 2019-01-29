using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Rooms.Commands.CreateRoom;
using Northwind.Application.Rooms.Commands.DeleteRoom;
using Northwind.Application.Rooms.Commands.UpdateRoom;
using Northwind.Application.Rooms.Queries.GetAllRooms;
using Northwind.Application.Rooms.Queries.GetRoom;
using Northwind.Domain.Entities;
using Northiwnd.Infrastructure;

namespace Northwind.WebUI.Controllers
{
    public class RoomsController : BaseController
    {
        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<RoomsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRoomsQuery()));
        }

        // GET api/rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            return Ok(await Mediatior.Send(new GetRoomQuery { Id = id}));
        }

        // POST api/rooms
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateRoomCommand command)
        {
            var message = new Message { From = "from@email", To = "to@email", Subject = "Notification", Body = "CREATED", Password = ""};
            var notificationService = new NotificationService();
            
            var roomId = await Mediator.Send(command);
            await notificationService.SendAsync(message);

            return Ok(roomId);
        }

        // PUT api/rooms/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> Update([FromRoute]int id, [FromBody]UpdateRoomCommand value)
        {
            var message = new Message { From = "from@email", To = "to@email", Subject = "Notification", Body = "UPDATED", Password = "" };
            var notificationService = new NotificationService();
            await notificationService.SendAsync(message);
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/rooms/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var message = new Message { From = "from@email", To = "to@email", Subject = "Notification", Body = "DELETED", Password = "" };
            var notificationService = new NotificationService();
            await Mediator.Send(new DeleteProductCommand { Id = id });
            await notificationService.SendAsync(message);

            return NoContent();
        }
    }
}
