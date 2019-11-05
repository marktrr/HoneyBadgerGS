using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IEventLogic
    {
        IEnumerable<Event> GetAll();
        int Add(Event _event);
        int Update(Event _event);
        Event Details(int id);
        int Delete(int id);
    }
}
