namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public struct Version {
        public static Version V2_0 = new Version("2.0", "0200");
        public static Version V2_2 = new Version("2.2", "0200");

        public string VersionCode { get; }

        public string VersionNumber { get; }

        public Version(string version, string versionCode) {
            VersionNumber = version;
            VersionCode = versionCode;
        }
    }
}
