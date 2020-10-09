using DevExpress.Utils.Serializing;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [TypeConverter(typeof(BillOptionsTypeConverter))]
    public class BillOptions {
        [DisplayName("Integrated Mode")]
        [Description("Integrated Mode description")]
        [Category("Data")]
        [DefaultValue(true)]
        [XtraSerializableProperty]
        public bool IntegratedMode { get; set; } = true;

        [DisplayName("Font Family")]
        [Description("Font Family description")]
        [Category("Data")]
        [DefaultValue(FontFamily.Arial)]
        [XtraSerializableProperty]
        public FontFamily FontFamily { get; set; } = FontFamily.Arial;

        [DisplayName("Language")]
        [Description("Language description")]
        [Category("Data")]
        [DefaultValue(Language.English)]
        [XtraSerializableProperty]
        public Language Language { get; set; } = Language.English;

        [DisplayName("Preview Separator Kind")]
        [Description("Preview Separator Kind description")]
        [Category("Data")]
        [DefaultValue(SeparatorKind.DashedLineWithScissors)]
        [XtraSerializableProperty]
        public SeparatorKind PreviewSeparatorKind { get; set; } = SeparatorKind.DashedLineWithScissors;

        [DisplayName("Pdf Separator Kind")]
        [Description("Pdf Separator Kind description")]
        [Category("Data")]
        [DefaultValue(SeparatorKind.DashedLine)]
        [XtraSerializableProperty]
        public SeparatorKind PdfSeparatorKind { get; set; } = SeparatorKind.DashedLine;

        public BillOptions() {
        }

        public void Assign(BillOptions options) {
            IntegratedMode = options.IntegratedMode;
            FontFamily = options.FontFamily;
            Language = options.Language;
            PreviewSeparatorKind = options.PreviewSeparatorKind;
            PdfSeparatorKind = options.PdfSeparatorKind;
        }
    }
}
