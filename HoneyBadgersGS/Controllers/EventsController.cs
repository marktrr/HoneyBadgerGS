using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventLogic _eventLogic;

        public EventsController(IEventLogic eventLogic)
        {
            _eventLogic = eventLogic;
        }


        [HttpGet("getevents")]
        [Route("api/Events")]
        public IEnumerable<Event> GetEvent()
        {
            return _eventLogic.GetAll();
        }

        //Creates new event instance
        [HttpPost]
        [Route("api/Events/Add")]
        public int Add(Event _event)
        {
            return _eventLogic.Add(_event);
        }

        //Updates event in record
        [HttpPut]
        [Route("api/Events/Update")]
        public int Update(Event _event)
        {
            return _eventLogic.Update(_event);
        }

        //Get Single Event Details
        [HttpGet("getevents/{id}")]
        [Route("api/Events/Details/{id}")]
        public Event Details(int id)
        {
            return _eventLogic.Details(id);
        }

        //Delete Event from records
        [HttpDelete]
        [Route("api/Events/Delete")]
        public int Delete(int id)
        {
            return _eventLogic.Delete(id);
        }
    }
}
