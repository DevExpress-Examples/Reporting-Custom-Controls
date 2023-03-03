using DevExpress.Drawing;
using System.Reflection;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class Images {
        public static DXImage SwissLogo { get; } = GetImageFromResource("SwissLogo.png");
        public static DXImage HorizontalScissors { get; } = GetImageFromResource("HorizontalScissors.png");
        public static DXImage VerticalScissors { get; } = GetImageFromResource("VerticalScissors.png");

        static DXImage GetImageFromResource(string name) {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetFullName(name));
            return DXImage.FromStream(stream);
        }
        static string GetFullName(string name) {
            return string.Concat(typeof(Images).Namespace, ".Resources.", name);
        }
    }
}
