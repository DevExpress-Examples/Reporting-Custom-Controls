using System;
using System.Collections.Generic;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class QRCodeSections {
        public const string Header = "Header";
        public const string QRType = "QRType";
        public const string Version = "Version";
        public const string CodingType = "Coding Type";
        public const string CreditorInformation = "Creditor information";
        public const string IBAN = "IBAN";
        public const string Creditor = "Creditor";
        public const string AddressType = "Address type";
        public const string CreditorName = "Creditor Name";
        public const string StreetOrAddressLine1 = "Street or address line 1";
        public const string StreetOrAddressLine2 = "StreetOrAddressLine2";
        public const string PostalCode = "PostalCode";
        public const string Town = "Town";
        public const string Country = "Country";
        public const string UltimateCreditor = "Ultimate Creditor";
        public const string PaymentAmountInformation = "Payment amount information";
        public const string Amount = "Amount";
        public const string Currency = "Currency";
        public const string UltimateDebtor = "Ultimate Debtor";
        public const string PaymentReference = "Payment reference";
        public const string ReferenceType = "Reference type";
        public const string Reference = "Reference";
        public const string AdditionalInformation = "Additional information";
        public const string UnstructuredMessage = "Payment reference";
        public const string Trailer = "Trailer";
        public const string BillInformation = "Bill information";
    }
    public enum ValidationCode {
        InvalidData,
        InvalidQRCodeType,
        InvalidVersion,
        InvalidCodingType,
        InvalidAmount,
        InvalidFieldTrailer,
        InvalidAccountNumber,
    }
    public static class ValidationError {
        static Dictionary<ValidationCode, string> validationCodeSections = new Dictionary<ValidationCode, string>() {
            { ValidationCode.InvalidData, QRCodeSections.Header },
            { ValidationCode.InvalidQRCodeType, QRCodeSections.QRType },
            { ValidationCode.InvalidVersion, QRCodeSections.Version },
            { ValidationCode.InvalidCodingType, QRCodeSections.CodingType },
            { ValidationCode.InvalidAmount, QRCodeSections.Amount },
            { ValidationCode.InvalidFieldTrailer, QRCodeSections.Trailer },
            { ValidationCode.InvalidAccountNumber, QRCodeSections.IBAN },
        };

        static Dictionary<ValidationCode, string> validationStringConstants = new Dictionary<ValidationCode, string>() {
            { ValidationCode.InvalidData, @"Valid data structure consists of 32 to 34 lines of text" },
            { ValidationCode.InvalidQRCodeType, "Valid data structure starts with SPC" },
            { ValidationCode.InvalidVersion, $"Invalid Version only {QRBillDataItem.Version} is supported" },
            { ValidationCode.InvalidCodingType, "Coding type 1 is supported only" },
            { ValidationCode.InvalidAmount, "Valid number required EN culture and (#.##) format" },
            { ValidationCode.InvalidFieldTrailer, "Valid data structure contains EPD field trailer" },
            { ValidationCode.InvalidAccountNumber, "Account Number must have valid format" },
        };

        public static void ThrowValidationException(ValidationCode validationCode) {
            throw new Exception(validationStringConstants[validationCode] + " Section: " + validationCodeSections[validationCode]);
        }
    }
}
