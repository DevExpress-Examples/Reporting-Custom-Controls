using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Expressions;
using DevExpress.Utils.Design;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraPrinting.BarCode;
using System.Linq;
using System.Diagnostics;
using System;
using DevExpress.Utils;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [ToolboxItem(true)]
    [ToolboxBitmap("DevExpress.XtraReports.CustomControls.Resources.SwissQRBillToolboxImage.bmp,DevExpress.XtraReports.CustomControls")]
    [ToolboxSvgImage("DevExpress.XtraReports.CustomControls.Resources.SwissQRBillToolboxSvgImage.svg,DevExpress.XtraReports.CustomControls")]
    [XRDesigner("DevExpress.XtraReports.CustomControls.Design.SwissQRBill.XRSwissQRBillDesigner, DevExpress.XtraReports.CustomControls.Design")]
    [Designer("DevExpress.XtraReports.CustomControls.Design.SwissQRBill._XRSwissQRBillDesigner, DevExpress.XtraReports.CustomControls.Design")]
    [XRToolboxSubcategory(0, 7)]
    [DefaultBindableProperty(nameof(StringData))]
    public partial class XRSwissQRBill : XRControl {
        QRBillDataItem qrBillDataItem = new QRBillDataItem();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text { get => base.Text; set => base.Text = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string TextFormatString { get => base.TextFormatString; set => base.TextFormatString = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string XlsxFormatString { get => base.XlsxFormatString; set => base.XlsxFormatString = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool WordWrap { get => base.WordWrap; set => base.WordWrap = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool KeepTogether { get => base.KeepTogether; set => base.KeepTogether = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override HorizontalAnchorStyles AnchorHorizontal { get => base.AnchorHorizontal; set => base.AnchorHorizontal = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override VerticalAnchorStyles AnchorVertical { get => base.AnchorVertical; set => base.AnchorVertical = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool CanPublish { get => base.CanPublish; set => base.CanPublish = value; }

        //Apperance
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BorderColor { get => base.BorderColor; set => base.BorderColor = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderDashStyle BorderDashStyle { get => base.BorderDashStyle; set => base.BorderDashStyle = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override float BorderWidth { get => base.BorderWidth; set => base.BorderWidth = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderSide Borders { get => base.Borders; set => base.Borders = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font { get => base.Font; set => base.Font = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override PaddingInfo Padding { get => base.Padding; set => base.Padding = value; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override StylePriority StylePriority => base.StylePriority;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override XRControlStyles Styles => base.Styles;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override TextAlignment TextAlignment { get => base.TextAlignment; set => base.TextAlignment = value; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event BindingEventHandler EvaluateBinding { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PrintOnPageEventHandler PrintOnPage { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PreviewMouseEventHandler PreviewMouseMove { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PreviewMouseEventHandler PreviewMouseDown { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PreviewMouseEventHandler PreviewMouseUp { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PreviewMouseEventHandler PreviewClick { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event PreviewMouseEventHandler PreviewDoubleClick { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event DrawEventHandler Draw { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event HtmlEventHandler HtmlItemCreated { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event EventHandler TextChanged { add { } remove { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override event UI.ChangeEventHandler SizeChanged { add { } remove { } }

        [DXDescription("Swiss QR Bill Scripts description"),
        DisplayName("Swiss QR Bill Scripts"),
        Category("Behavior"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public new XRSwissQRBillScripts Scripts { get { return (XRSwissQRBillScripts)fEventScripts; } }

        [DisplayName("Bill Kind")]
        [Description("Bill Kind description")]
        [Category("Data")]
        [XtraSerializableProperty]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(QRBillKind.PaymentAndReceipt)]
        public QRBillKind BillKind { get; set; } = QRBillKind.PaymentAndReceipt;

        public override RectangleF BoundsF {
            get { return AdaptBounds(base.BoundsF); }
            set { base.BoundsF = value; }
        }
        RectangleF AdaptBounds(RectangleF rect) {
            if(RootReport != null) {
                rect.Size = GraphicsUnitConverter.Convert(GetActualSize(), GraphicsDpi.Millimeter, Dpi);
            }
            return rect;
        }

        [DisplayName("String Data")]
        [Description("String Data description")]
        [Category("Data")]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        [Editor(ControlConstants.MultilineStringEditor, ControlConstants.UITypeEditor)]
        public string StringData {
            get { return qrBillDataItem.QRCodeData; }
            set { qrBillDataItem.QRCodeData = value; }
        }
        bool ShouldSerializeStringData() => false;

        [DisplayName("Bill Options")]
        [Description("Bill Options description")]
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public BillOptions BillOptions { get; } = new BillOptions();

        [DisplayName("Creditor Information")]
        [Description("Creditor Information description")]
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public Address CreditorInformation { get { return qrBillDataItem.CreditorInformation; } }

        [DisplayName("Creditor IBAN")]
        [Description("Creditor IBAN description")]
        [Category("Data")]
        [XtraSerializableProperty]
        public string CreditorIBAN {
            get { return qrBillDataItem.CreditorAccountNumber.Number; }
            set { qrBillDataItem.CreditorAccountNumber.Number = value; }
        }

        [DisplayName("Reference")]
        [Description("Reference description")]
        [Category("Data")]
        [XtraSerializableProperty]
        public string Reference {
            get { return qrBillDataItem.Reference.Number; }
            set { qrBillDataItem.Reference.Number = value; }
        }

        [DisplayName("Debtor Information")]
        [Description("Debtor Information description")]
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public Address DebtorInformation { get { return qrBillDataItem.DebtorInformation; } }

        [DisplayName("Amount")]
        [Description("Amount description")]
        [Category("Data")]
        [DefaultValue(null)]
        [XtraSerializableProperty]
        public double? Amount {
            get { return qrBillDataItem.Amount; }
            set { qrBillDataItem.Amount = value; }
        }

        [DisplayName("Currency")]
        [Description("Currency description")]
        [Category("Data")]
        [DefaultValue(Currency.CHF)]
        [XtraSerializableProperty]
        public Currency Currency {
            get { return qrBillDataItem.Currency; }
            set { qrBillDataItem.Currency = value; }
        }

        [DisplayName("Additional Information")]
        [Description("Additional Information description")]
        [Category("Data")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string AdditionalInformation {
            get { return qrBillDataItem.AdditionalInformation; }
            set { qrBillDataItem.AdditionalInformation = value; }
        }

        [DisplayName("Structured Information")]
        [Description("Structured Information description")]
        [Category("Data")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string StructuredInformation {
            get { return qrBillDataItem.StructuredInformation; }
            set { qrBillDataItem.StructuredInformation = value; }
        }

        [DisplayName("Alternative Procedures")]
        [Description("Alternative Procedures description")]
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public AlternativeProcedures AlternativeProcedures {
            get { return qrBillDataItem.AlternativeProcedures; }
        }

        static XRSwissQRBill() {
            ExpressionBindingDescriptor.SetPropertyDescription(typeof(XRSwissQRBill), nameof(StringData), new ExpressionBindingDescription(new string[] { "BeforePrint" }, 1000, new string[0]));
            ValidateIncludeQuietZone();
        }
        static void ValidateIncludeQuietZone() {
            var includeQuietZoneProperty = typeof(QRCodeGenerator).GetProperties().FirstOrDefault(a => a.Name == "IncludeQuietZone");
            if(includeQuietZoneProperty == null)
                Debug.Fail("IncludeQuietZone property is not available. The control may not draw correctly");
        }

        public XRSwissQRBill() {
        }
        protected override XRControlScripts CreateScripts() {
            return new XRSwissQRBillScripts(this);
        }
        protected override int DefaultHeight => ConvertFromMMToDpi(Constants.PaymentAndReceiptBounds.Height, GraphicsDpi.HundredthsOfAnInch);
        protected override int DefaultWidth => ConvertFromMMToDpi(Constants.PaymentAndReceiptBounds.Width, GraphicsDpi.HundredthsOfAnInch);

        int ConvertFromMMToDpi(float mmValue, float targetDpi) {
            return (int)GraphicsUnitConverter.Convert(mmValue, GraphicsDpi.Millimeter, targetDpi);
        }

        SizeF GetActualSize() {
            RectangleF actualRect = BillKind == QRBillKind.PaymentOnly ? Constants.PaymentBounds : Constants.PaymentAndReceiptBounds;
            if(BillOptions.IntegratedMode)
                actualRect.Height += Constants.IntegratedModeOffset;
            return actualRect.Size;
        }
        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            return new SwissQRBillBrick(this);
        }
        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            base.PutStateToBrick(brick, ps);
            SwissQRBillBrick swissQRBillBrick = brick as SwissQRBillBrick;
            swissQRBillBrick.BillKind = BillKind;
            swissQRBillBrick.BillOptions.Assign(BillOptions);
            swissQRBillBrick.GenerateContent(qrBillDataItem);
        }
        protected override void GetStateFromBrick(VisualBrick brick) {
            base.GetStateFromBrick(brick);
        }
    }
}
