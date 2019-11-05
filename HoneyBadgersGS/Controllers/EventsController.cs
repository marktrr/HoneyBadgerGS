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
        private readonly HoneyBadgerDBContext _context;
        private IEventLogic _eventLogic;

        public EventsController(IEventLogic eventLogic)
        {
            _eventLogic = eventLogic;
        }


        [HttpGet("getevent")]
        [Route("api/Event")]
        public IEnumerable<Event> GetEvent()
        {
            return _eventLogic.GetAll();
        }

        //Creates new event instance
        [HttpPost]
        [Route("api/Event/Add")]
        public int Add(Event _event)
        {
            return _eventLogic.Add(_event);
        }

        //Updates event in record
        [HttpPut]
        [Route("api/Event/Update")]
        public int Update(Event _event)
        {
            return _eventLogic.Update(_event);
        }

        //Get Single Event Details
        [HttpGet("getevent/{id}")]
        [Route("api/Event/Details/{id}")]
        public Event Details(int id)
        {
            return _eventLogic.Details(id);
        }

        //Delete Event from records
        [HttpDelete]
        [Route("api/Event/Delete")]
        public int Delete(int id)
        {
            return _eventLogic.Delete(id);
        }
    }
}
