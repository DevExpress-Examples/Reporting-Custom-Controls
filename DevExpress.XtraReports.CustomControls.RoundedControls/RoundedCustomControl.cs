using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.CustomControls.RoundBordersControls;

namespace DevExpress.XtraReports.CustomControls {
    public static class RoundedCustomControl {
        public static void EnsureCustomBrick() {
            BrickFactory.BrickResolve += OnBrickResolve;
        }

        private static void OnBrickResolve(object sender, BrickResolveEventArgs args) {
            if(args.Brick != null)
                return;
            CreateBrick<RoundLabelBrick>(args);
            CreateBrick<RoundPanelBrick>(args);
        }

        static void CreateBrick<T>(DevExpress.XtraPrinting.BrickResolveEventArgs args) where T : class, new() {
            if(args.Name == typeof(T).Name) {
                args.Brick = new T() as Brick;
            }
        }
    }
}
