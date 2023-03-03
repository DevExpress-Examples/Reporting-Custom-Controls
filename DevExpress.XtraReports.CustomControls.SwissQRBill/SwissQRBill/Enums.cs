using System;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    //public
    public enum QRBillKind {
        PaymentOnly,
        PaymentAndReceipt
    }
    public enum Currency {
        EUR,
        CHF,
    }
    public enum AddressType {
        Structured,
        Combined,
    }
    public enum Language {
        English,
        German,
        French,
        Italian,
    }
    public enum FontFamily {
        Arial,
        Frutiger,
        Helvetica,
        LiberationSans
    }
    [Flags]
    public enum SeparatorKind {
        None = 0,
        [Browsable(false)]
        Scissors = 1,
        [Browsable(false)]
        Text = 2,

        SolidLine = 4,
        DottedLine = 8,
        DashedLine = 16,

        SolidLineWithScissors = SolidLine | Scissors,
        DottedLineWithScissors = DottedLine | Scissors,
        DashedLineWithScissors = DashedLine | Scissors,

        SolidLineWithText = SolidLine | Text,
        DottedLineWithText = DottedLine | Text,
        DashedLineWithText = DashedLine | Text,
    }
    //internal
    public enum ReferenceType {
        QRR,
        SCOR,
        NON,
    }
    public enum AccountNumberFormat {
        None,
        IBAN,
        QR_IBAN,
        QRReference,
        CreditorReference
    }
    public enum SectionId {
        PaymentPart,
        Receipt,
        AccountPayableTo,
        Reference,
        AdditionalInformation,
        PayableBy,
        PayableByNameAddress,
        Currency,
        Amount,
        AcceptancePoint,
        SeparateBeforePayingIn,
    }
}
