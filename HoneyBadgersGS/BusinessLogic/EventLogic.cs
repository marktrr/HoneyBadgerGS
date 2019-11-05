using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class EventLogic : IEventLogic
    {
        private IEventDal _eventDal;

        public EventLogic(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventDal.GetAll();
        }

        public int Add(Event _event)
        {
            return _eventDal.Add(_event);
        }

        public int Update(Event _event)
        {
            return _eventDal.Update(_event);
        }

        public Event Details(int id)
        {
            return _eventDal.GetData(id);
        }

        public int Delete(int id)
        {
            return _eventDal.Delete(id);
        }
    }
}
