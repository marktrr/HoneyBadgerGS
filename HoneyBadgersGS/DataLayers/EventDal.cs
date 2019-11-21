using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public class EventDal : IEventDal
    {
        private HoneyBadgerContext _db;

        public EventDal(HoneyBadgerContext db)
        {
            _db = db;
        }

        public IEnumerable<Event> GetAll()
        {
            return _db.Event.ToList();
        }

        public int Add(Event _event)
        { 
            _db.Event.Add(_event);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Event _event)
        {
            _db.Event.Update(_event);
            _db.SaveChangesAsync();
            return 1;
        }

        public Event GetData(int id)
        {
            Event _event = _db.Event.Find(id);
            return _event;
        }

        public int Delete(int id)
        {
            Event _event = _db.Event.Find(id);
            _db.Event.Remove(_event);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}
