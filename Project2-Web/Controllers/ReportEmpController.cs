using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_Web.Controllers
{
    public class ReportEmpController : Controller
    {
        // GET: ReportEmp
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        XtraReportEmp report = new XtraReportEmp();

        [Authorize]
        public ActionResult DocumentViewerPartial()
        {
            return PartialView("_DocumentViewerPartial", report);
        }

        [Authorize]
        public ActionResult DocumentViewerPartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}