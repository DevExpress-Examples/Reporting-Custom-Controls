using DevExpress.XtraReports.CustomControls.SwissQRBill;
using Microsoft.AspNetCore.Mvc;
using DevExpress.XtraReports.Web.ReportDesigner.Services;
using DevExpress.XtraReports.Web.ReportDesigner;

namespace CustomControlExample.AspNetCore.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Error() {
            Models.ErrorModel model = new Models.ErrorModel();
            return View(model);
        }

        public IActionResult Designer([FromServices] IReportDesignerModelBuilder reportDesignerModelBuilder) {
            ReportDesignerModel model = reportDesignerModelBuilder
                .Report("TestReport")
                .CustomControls(typeof(XRSwissQRBill))
                .BuildModel();
            return View(model);
        }

        public IActionResult Viewer() {
            return View();
        }
    }
}
