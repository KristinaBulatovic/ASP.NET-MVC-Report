using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_Web.Controllers
{
    public class ReportTerrController : Controller
    {
        // GET: ReportTerr
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        XtraReportTerr report = new XtraReportTerr();

        [Authorize]
        public ActionResult DocumentViewer1Partial()
        {
            return PartialView("_DocumentViewer1Partial", report);
        }

        [Authorize]
        public ActionResult DocumentViewer1PartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}