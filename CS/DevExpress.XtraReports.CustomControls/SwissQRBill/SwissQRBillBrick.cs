using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.BrickExporters;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System;
using DevExpress.Utils.Serializing;
using DevExpress.XtraReports.CustomControls.Properties;
using System.Diagnostics;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [BrickExporter(typeof(SwissQRBillBrickExporter))]
    public partial class SwissQRBillBrick : PanelBrick {
        static PanelBrick CreatePanelBrick(RectangleF mmBounds) {
            PanelBrick panelBrick = new PanelBrick() {
                BackColor = Color.Transparent,
                Sides = BorderSide.None,
                BorderStyle = BrickBorderStyle.Inset,
                Rect = MmToDocConverter.Convert(mmBounds)
            };
            return panelBrick;
        }
        static TextBrick CreateTextBrick(string text, Font font, RectangleF bounds) {
            return new TextBrick(CreateBrickStyle(font)) {
                Rect = bounds,
                Text = text,
            };
        }
        static TextBrick CreateBestSizeTextBrick(string text, Font font, float maxWidth) {
            var style = CreateBrickStyle(font);
            var bestBounds = BestSizeEstimator.GetBoundsToFitText(text, style, maxWidth, GraphicsDpi.Document);

            return new TextBrick() { Text = text, Style = style, Rect = bestBounds };
        }
        static BrickStyle CreateBrickStyle(Font font) {
            return new XRControlStyle() {
                Font = font,
                Padding = new PaddingInfo(1, 1, 0, 0, 96),
                StringFormat = BrickStringFormat.Create(TextAlignment.TopLeft, true, StringTrimming.EllipsisCharacter, false)
            };
        }
        static float GetFontHeight(Font font) {
            var metrics = new DevExpress.XtraPrinting.Native.FontMetrics(font, GraphicsUnit.Document);
            var height = metrics.CalculateHeight(1);
            return height;
        }
        static Font CreateFont(string fontFamily, int fontSize, FontStyle fontStyle) {
            return new Font(fontFamily, fontSize, fontStyle);
        }

        internal QRBillDataItem BillDataItem { get; set; }

        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public BillOptions BillOptions { get; } = new BillOptions();

        [XtraSerializableProperty]
        public QRBillKind BillKind { get; set; }

        Language Language { get { return BillOptions.Language; } }
        string FontFamily { get { return BillOptions.FontFamily.ToString(); } }

        public override string BrickType => nameof(SwissQRBillBrick);

        public SwissQRBillBrick() : this(null) {

        }
        public SwissQRBillBrick(IBrickOwner brickOwner) : base(brickOwner) {
            BackColor = Color.Transparent;
            Sides = BorderSide.None;
        }
        public void GenerateContent(QRBillDataItem qrBillDataItem) {
            BillDataItem = qrBillDataItem;

            VisualBrick paymentPart = CreatePaymentPart();
            Bricks.Add(paymentPart);

            if(BillKind == QRBillKind.PaymentAndReceipt) {
                VisualBrick receiptPartBrick = CreateReceiptPart();
                Bricks.Add(receiptPartBrick);
            }
        }

        TextBrick CreateTitleTextBrick(RectangleF bounds, int fontSize, SectionId localizationKey) {
            string text = LocalizationData.Instance[Language, localizationKey];
            Font font = new Font(FontFamily, fontSize, Constants.HeaderFontStyle);
            return new TextBrick(CreateBrickStyle(font)) {
                Rect = MmToDocConverter.Convert(bounds),
                Text = text,
            };
        }

        VisualBrick CreatePaymentPart() {
            PanelBrick panelBrick = CreatePanelBrick(BoundsCalculator.GetPaymentBounds(this));
            panelBrick.Bricks.Add(CreatePaymentTitle());
            panelBrick.Bricks.Add(CreatePaymentSwissQRCode());
            panelBrick.Bricks.Add(CreatePaymentInformation());
            panelBrick.Bricks.Add(CreatePaymentAmount());
            panelBrick.Bricks.Add(CreatePaymentFurtherInformation());

            return panelBrick;
        }
        VisualBrick CreatePaymentTitle() {
            return CreateTitleTextBrick(Constants.PaymentTitleBounds, Constants.PaymentTitleFontSize, SectionId.PaymentPart);
        }
        VisualBrick CreatePaymentInformation() {
            float sectionBlockOffset = GetFontHeight(CreateFont(FontFamily, Constants.PaymentValueFontSize, Constants.ContentFontStyle));

            var panelBrick = CreatePanelBrick(Constants.PaymentInformationBounds);

            string creditorString = GetCreditorString();
            AddRequiredInformationSection(panelBrick, SectionId.AccountPayableTo, creditorString,
                Constants.PaymentHeadingFontSize, Constants.PaymentValueFontSize, sectionBlockOffset);

            string creditorReferenceString = GetCreditorReferenceString();
            if(!string.IsNullOrWhiteSpace(creditorReferenceString))
                AddRequiredInformationSection(panelBrick, SectionId.Reference, creditorReferenceString,
                    Constants.PaymentHeadingFontSize, Constants.PaymentValueFontSize, sectionBlockOffset);

            string additinalInformationString = GetAdditinalInformationString();
            if(!string.IsNullOrWhiteSpace(additinalInformationString))
                AddRequiredInformationSection(panelBrick, SectionId.AdditionalInformation, additinalInformationString,
                    Constants.PaymentHeadingFontSize, Constants.PaymentValueFontSize, sectionBlockOffset);

            string debtorInformationString = GetDebtorInformationString();
            AddOptionalInformationSection(panelBrick, SectionId.PayableByNameAddress, debtorInformationString,
                Constants.PaymentHeadingFontSize, Constants.PaymentValueFontSize, sectionBlockOffset, MmToDocConverter.Convert(Constants.PaymentPayableToCornerSize));

            return panelBrick;
        }
        string GetAdditinalInformationString() {
            return string.Join(Environment.NewLine,
                BillDataItem.AdditionalInformation, BillDataItem.StructuredInformation);
        }

        void TrySetIncludeQuietZone(QRCodeGenerator generator) {
            var includeQuietZone = generator.GetType().GetProperties().FirstOrDefault(a => a.Name == "IncludeQuietZone");
            includeQuietZone?.SetValue(generator, false);
        }

        VisualBrick CreatePaymentSwissQRCode() {
            var panelBrick = CreatePanelBrick(Constants.QRCodeBounds);
            var generator = new QRCodeGenerator() {
                Version = QRCodeVersion.Version10,
                CompactionMode = QRCodeCompactionMode.Byte,
            };
            TrySetIncludeQuietZone(generator); //This property is available in version 20.1.5 or later
            var barCodeBrick = new BarCodeBrick() {
                Size = panelBrick.Size,
                Sides = BorderSide.None,
                AutoModule = true,
                BinaryData = Encoding.UTF8.GetBytes(BillDataItem.QRCodeData),
                ShowText = false,
                Generator = generator,
            };
            ImageBrick logoBrick = new ImageBrick() {
                Size = panelBrick.Size,
                Sides = BorderSide.None,
                BackColor = Color.Transparent,
                SizeMode = ImageSizeMode.Normal,
                ImageAlignment = ImageAlignment.MiddleCenter,
                ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(Resources.SwissLogo, true),
                UseImageResolution = true,
            };
            panelBrick.Bricks.Add(barCodeBrick);
            panelBrick.Bricks.Add(logoBrick);
            return panelBrick;
        }
        VisualBrick CreatePaymentAmount() {
            return CreateAmountSection(Constants.PaymentAmountBounds, Constants.PaymentHeadingFontSize, Constants.PaymentAmountFontSize,
                Constants.PaymentPayableToCurrencyWidth, Constants.PaymentAmountCornerSize, true);
        }
        VisualBrick CreatePaymentFurtherInformation() {
            return CreateAlternativeProceduresSectionBrick(BillDataItem.AlternativeProcedures);
        }
        VisualBrick CreateAlternativeProceduresSectionBrick(AlternativeProcedures procedures) {
            if(procedures.IsEmpty)
                return null;
            PanelBrick panelBrick = CreatePanelBrick(Constants.ReceiptPartFurtherInformationBounds);

            Font headerFont = CreateFont(FontFamily, Constants.PaymentFurtherInformationFontSize, Constants.HeaderFontStyle);
            Font instructionFont = CreateFont(FontFamily, Constants.PaymentFurtherInformationFontSize, Constants.ContentFontStyle);

            AddAlternativeProceduresSectionPart(panelBrick, procedures.Name1, procedures.Instruction1, headerFont, instructionFont, 0);

            if(!procedures.IsSecondPairEmpty) {
                float y = panelBrick.Bricks.First().Rect.Bottom;
                AddAlternativeProceduresSectionPart(panelBrick, procedures.Name2, procedures.Instruction2, headerFont, instructionFont, y);

                List<Brick> instructions = new List<Brick>(panelBrick.Bricks.Where(x => x.Location.X != 0));
                float maxX = instructions.Max(x => x.Location.X);
                instructions.ForEach(x => x.Location = new PointF(maxX, x.Location.Y));
            }

            return panelBrick;
        }
        void AddAlternativeProceduresSectionPart(PanelBrick container, string name, string instruction, Font headerFont, Font instructionFont, float y) {
            VisualBrick nameHeaderBrick = CreateBestSizeTextBrick($"{name}:", headerFont, container.Size.Width);
            VisualBrick instructionBrick = CreateBestSizeTextBrick($"{instruction}", instructionFont, container.Size.Width);
            nameHeaderBrick.Location = new PointF(0, y);
            instructionBrick.Location = new PointF(nameHeaderBrick.Rect.Right, y);
            container.Bricks.Add(nameHeaderBrick);
            container.Bricks.Add(instructionBrick);
        }

        VisualBrick CreateReceiptPart() {
            PanelBrick panelBrick = CreatePanelBrick(BoundsCalculator.GetReceiptBounds(this));

            panelBrick.Bricks.Add(CreateReceiptTitle());
            panelBrick.Bricks.Add(CreateReceiptInformation());
            panelBrick.Bricks.Add(CreateReceiptAmount());
            panelBrick.Bricks.Add(CreateReceiptAcceptancePoint());

            return panelBrick;
        }

        VisualBrick CreateReceiptTitle() {
            return CreateTitleTextBrick(Constants.ReceiptTitleBounds, Constants.ReceiptTitleFontSize, SectionId.Receipt);
        }
        VisualBrick CreateReceiptInformation() {
            float sectionBlockOffset = GetFontHeight(CreateFont(FontFamily, Constants.ReceiptValueFontSize, Constants.ContentFontStyle));
            var panelBrick = CreatePanelBrick(Constants.ReceiptInformationBounds);

            string creditorString = GetCreditorString();
            AddRequiredInformationSection(panelBrick, SectionId.AccountPayableTo, creditorString,
                Constants.ReceiptHeadingFontSize, Constants.ReceiptValueFontSize, sectionBlockOffset);

            string creditorReferenceString = GetCreditorReferenceString();
            if(!string.IsNullOrWhiteSpace(creditorReferenceString))
                AddRequiredInformationSection(panelBrick, SectionId.Reference, creditorReferenceString,
                    Constants.ReceiptHeadingFontSize, Constants.ReceiptValueFontSize, sectionBlockOffset);

            string debtorInformationString = GetDebtorInformationString();
            AddOptionalInformationSection(panelBrick, SectionId.PayableByNameAddress, debtorInformationString,
                Constants.ReceiptHeadingFontSize, Constants.ReceiptValueFontSize, sectionBlockOffset, MmToDocConverter.Convert(Constants.ReceiptPayableToCornerSize));

            return panelBrick;
        }
        VisualBrick CreateReceiptAmount() {
            return CreateAmountSection(Constants.ReceiptAmountBounds, Constants.ReceiptHeadingFontSize, Constants.ReceiptAmountFontSize,
                Constants.ReceiptPayableToCurrencyWidth, Constants.ReceiptAmountCornerSize, false);
        }
        VisualBrick CreateReceiptAcceptancePoint() {
            string text = LocalizationData.Instance[Language, SectionId.AcceptancePoint];
            Font font = CreateFont(FontFamily, Constants.ReceiptAcceptancePointFontSize, Constants.HeaderFontStyle);

            TextBrick acceptanceStringBrick = CreateTextBrick(text, font, MmToDocConverter.Convert(Constants.PaymentAcceptancePointBounds));
            acceptanceStringBrick.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            return acceptanceStringBrick;
        }

        VisualBrick CreateAmountSection(RectangleF bounds, int headerFontSize, int contentFontSize, float mmCurrencyWidth, SizeF cornerSize, bool applyOffsetOnCorner) {
            PanelBrick panelBrick = CreatePanelBrick(bounds);

            Font headerFont = new Font(FontFamily, headerFontSize, Constants.HeaderFontStyle);
            Font contentFont = new Font(FontFamily, contentFontSize, Constants.ContentFontStyle);

            float currencyWidth = MmToDocConverter.Convert(mmCurrencyWidth);
            float headerHeight = GetFontHeight(headerFont) + GraphicsUnitConverter.Convert(3, GraphicsDpi.Point, GraphicsDpi.Document);

            AddAmountSectionHeaders(panelBrick, headerFont, currencyWidth, headerHeight);
            AddAmountSectionContent(panelBrick, contentFont, currencyWidth, MmToDocConverter.Convert(cornerSize), headerHeight, applyOffsetOnCorner);

            return panelBrick;
        }
        void AddAmountSectionHeaders(PanelBrick container, Font headerFont, float currencyWidth, float headerHeight) {
            string currencyHeaderText = LocalizationData.Instance[Language, SectionId.Currency];
            VisualBrick currencyHeaderBrick = CreateTextBrick(currencyHeaderText, headerFont, new RectangleF(0, 0, currencyWidth, headerHeight));

            float amountWidth = container.Size.Width - currencyWidth;
            string amountHeaderText = LocalizationData.Instance[Language, SectionId.Amount];
            VisualBrick amountHeaderBrick = CreateTextBrick(amountHeaderText, headerFont, new RectangleF(currencyWidth, 0, amountWidth, headerHeight));

            container.Bricks.Add(currencyHeaderBrick);
            container.Bricks.Add(amountHeaderBrick);
        }
        void AddAmountSectionContent(PanelBrick container, Font contentFont, float currencyWidth, SizeF cornerSize, float verticalOffset, bool applyOffsetOnCorner) {
            float contentFontHeight = GetFontHeight(contentFont);

            string currencyContentText = BillDataItem.Currency.ToString();
            VisualBrick currencyContentBrick = CreateTextBrick(currencyContentText, contentFont, new RectangleF(0, verticalOffset, currencyWidth, contentFontHeight));
            container.Bricks.Add(currencyContentBrick);

            string amountString = GetAmountString();
            if(string.IsNullOrEmpty(amountString)) {
                VisualBrick cornerBrick = new CornerRectangleBrick {
                    Rect = new RectangleF(new PointF(container.Rect.Width - cornerSize.Width, applyOffsetOnCorner ? verticalOffset : 0), cornerSize)
                };
                container.Bricks.Add(cornerBrick);
            } else {
                float amountWidth = container.Size.Width - currencyWidth;
                VisualBrick amountContentBrick = CreateTextBrick(amountString, contentFont, new RectangleF(currencyWidth, verticalOffset, amountWidth, contentFontHeight));
                container.Bricks.Add(amountContentBrick);
            }
        }
        string GetAmountString() {
            return BillDataItem.Amount == null ? "" : BillDataItem.Amount.Value.ToString("#0.00");
        }

        void AddRequiredInformationSection(PanelBrick container, SectionId headerLocalizationKey, string contextText, int headerFontSize, int contentFontSize, float startOffset) {
            string headerText = LocalizationData.Instance[Language, headerLocalizationKey];

            var headerBrick = CreateBestSizeTextBrick(headerText, new Font(FontFamily, headerFontSize, Constants.HeaderFontStyle), container.Rect.Width);
            var contentBrick = CreateBestSizeTextBrick(contextText, new Font(FontFamily, contentFontSize, Constants.ContentFontStyle), container.Rect.Width);

            AddSectionPartToContainer(container, headerBrick, contentBrick, startOffset);
        }
        void AddOptionalInformationSection(PanelBrick container, SectionId headerLocalizationKey, string contentText, int headerFontSize, int contentFontSize, float startOffset, SizeF cornerSize) {
            string headerText = LocalizationData.Instance[Language, headerLocalizationKey];
            VisualBrick headerBrick = CreateBestSizeTextBrick(headerText, new Font(FontFamily, headerFontSize, Constants.HeaderFontStyle), container.Rect.Width);
            VisualBrick contentBrick = string.IsNullOrWhiteSpace(contentText)
                ? new CornerRectangleBrick() { Rect = new RectangleF(PointF.Empty, cornerSize) }
                    : (VisualBrick)CreateBestSizeTextBrick(contentText, new Font(FontFamily, contentFontSize, Constants.ContentFontStyle), container.Rect.Width);

            AddSectionPartToContainer(container, headerBrick, contentBrick, startOffset);
        }
        void AddSectionPartToContainer(PanelBrick container, VisualBrick headerBrick, VisualBrick contentBrick, float offset) {
            float actualY = container.Bricks.Any() ? container.Bricks.Last().Rect.Bottom + offset : 0;
            headerBrick.Location = new PointF(0, actualY);
            contentBrick.Location = new PointF(0, headerBrick.Rect.Bottom);

            container.Bricks.Add(headerBrick);
            container.Bricks.Add(contentBrick);
        }

        string GetCreditorString() {
            return string.Join(Environment.NewLine,
                BillDataItem.CreditorAccountNumber.ConvertToPresentationString(), BillDataItem.CreditorInformation.ConvertToPresentationString());
        }

        string GetDebtorInformationString() {
            return BillDataItem.DebtorInformation.ConvertToPresentationString();
        }

        string GetCreditorReferenceString() {
            return BillDataItem.Reference == null ? "" : BillDataItem.Reference.ConvertToPresentationString();
        }
    }
}
