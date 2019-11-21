using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? DateOfEvent { get; set; }
        public string EventDescription { get; set; }
        public string Location { get; set; }
    }
}
