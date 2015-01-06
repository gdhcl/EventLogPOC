using System.Web.Mvc;
using WebApplication1.Common_Methods;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    public class EventLogController : Controller
    {
        //
        // GET: /EventLog/
        public ActionResult GetEventLogs(EventLogWrapper objWrapper)
        {
            EventLogConnection obj = new EventLogConnection();
            obj.GetEvents(objWrapper);
            return View(objWrapper);
        }


        public ActionResult PagingControl(EventLogWrapper objWrapper)
        {  
            objWrapper.lstPageNumber = Common.GetPageNumbers(objWrapper.TotalRecords, objWrapper.PageSize);
            return PartialView(objWrapper);
        }

    }
}