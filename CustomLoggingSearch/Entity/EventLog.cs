using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomLoggingSearch.Entity
{
    public class EventLog
    {
        public string RowNumber { get; set; }

        public string Date
        {
            get;
            set;
        }
        public string Thread
        {
            get;
            set;
        }
        public string Level
        {
            get;
            set;
        }
        public string Logger
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public string Exceptions
        {
            get;
            set;
        }

    }
}