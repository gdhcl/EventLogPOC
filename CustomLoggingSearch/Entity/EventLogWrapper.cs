using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomLoggingSearch.Entity
{
    public class EventLogWrapper : Paging
    {
        public List<EventLog> lstEventLog { get; set; }      
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Level { get; set; }
        public string Message  { get; set; }
        
    }
}