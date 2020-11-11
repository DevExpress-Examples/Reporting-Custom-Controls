using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.CustomControls.SwissQRBill;

namespace DevExpress.XtraReports.CustomControls {
    public static class CustomControl {
        public static void EnsureSwissQRBillBrick() {
            BrickFactory.BrickResolve += BrickFactory_BrickResolve;
        }
        private static void BrickFactory_BrickResolve(object sender, DevExpress.XtraPrinting.BrickResolveEventArgs args) {
            if(args.Brick != null)
                return;
            if(args.Name == nameof(SwissQRBillBrick))
                args.Brick = new SwissQRBillBrick();
            else if(args.Name == nameof(CornerRectangleBrick))
                args.Brick = new CornerRectangleBrick();
        }
    }
}
