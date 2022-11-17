using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.CustomControls.SwissQRBill;

namespace DevExpress.XtraReports.CustomControls {
    public static class SwissQRBillCustomControl {
        public static void EnsureCustomBrick() {
            BrickFactory.BrickResolve += OnBrickResolve;
        }

        private static void OnBrickResolve(object sender, BrickResolveEventArgs args) {
            if(args.Brick != null)
                return;
            CreateBrick<SwissQRBillBrick>(args);
            CreateBrick<CornerRectangleBrick>(args);
        }

        static void CreateBrick<T>(DevExpress.XtraPrinting.BrickResolveEventArgs args) where T : class, new() {
            if(args.Name == typeof(T).Name) {
                args.Brick = new T() as Brick;
            }
        }
    }
}

