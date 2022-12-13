using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;

namespace CustomControlExample.AspNetCore.PredefinedReports {
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["TestReport"] = () => new Report()
        };
    }
}
