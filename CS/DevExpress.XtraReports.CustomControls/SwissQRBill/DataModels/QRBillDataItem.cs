using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class QRBillDataItem {
        public static Version Version = Version.V2_0;
        private double? amount = null;

        public Currency Currency { get; set; } = Currency.CHF;
        public double? Amount { get { return amount; } set { amount = CoerceAmount(value); } }
        public AccountNumber CreditorAccountNumber { get; set; } = new AccountNumber();

        public Address CreditorInformation { get; set; } = new Address();

        public AccountNumber Reference { get; set; } = new AccountNumber();

        public Address DebtorInformation { get; set; } = new Address();

        public string AdditionalInformation { get; set; } = string.Empty;

        public string StructuredInformation { get; set; } = string.Empty;
        
        public AlternativeProcedures AlternativeProcedures { get; } = new AlternativeProcedures();

        public string QRCodeData {
            get { return ConvertToQRCodeDataString(); }
            set {
                ResetQRCodeData();
                ConvertFromQRCodeDataString(value); 
            }
        }
        void ResetQRCodeData() {
            Amount = null;
            Currency = Currency.CHF;
            CreditorAccountNumber.Reset();
            CreditorInformation.Reset();
            DebtorInformation.Reset();
            AlternativeProcedures.Reset();
            AdditionalInformation = string.Empty;
            StructuredInformation = string.Empty;
        }

        public ReferenceType ReferenceType {
            get {
                if(CreditorAccountNumber == null)
                    return ReferenceType.NON;
                if(CreditorAccountNumber.NumberFormat == AccountNumberFormat.IBAN && Reference == null)
                    return ReferenceType.NON;
                if(Reference == null)
                    return ReferenceType.NON;
                if(CreditorAccountNumber.NumberFormat == AccountNumberFormat.QR_IBAN && Reference.NumberFormat == AccountNumberFormat.QRReference)
                    return ReferenceType.QRR;
                if(CreditorAccountNumber.NumberFormat == AccountNumberFormat.IBAN || Reference.NumberFormat == AccountNumberFormat.CreditorReference)
                    return ReferenceType.SCOR;
                return ReferenceType.NON;
            }
        }

        void ConvertFromQRCodeDataString(string value) {
            var rawData = Regex.Split(value, Environment.NewLine);
            if((rawData.Length < 31 || rawData.Length > 34) && !(rawData.Length == 35 && string.IsNullOrEmpty(rawData[34])))
                ValidationError.ThrowValidationException(ValidationCode.InvalidData);
            if(rawData[0] != "SPC")
                ValidationError.ThrowValidationException(ValidationCode.InvalidQRCodeType);
            if(rawData[1] != Version.VersionCode)
                ValidationError.ThrowValidationException(ValidationCode.InvalidVersion);
            if(rawData[2] != "1")
                ValidationError.ThrowValidationException(ValidationCode.InvalidCodingType);
            CreditorAccountNumber.ConvertFromQRCodeDataString(new string[] { rawData[3] });
            CreditorInformation.ConvertFromQRCodeDataString(rawData.Skip(4).Take(7).ToArray());
            if(rawData[18].Length > 0) {
                double amount;
                if(double.TryParse(rawData[18], out amount)) {
                    Amount = amount;
                } else {
                    ValidationError.ThrowValidationException(ValidationCode.InvalidAmount);
                }
            }
            Currency currency;
            if(Enum.TryParse(rawData[19], out currency)) {
                Currency = currency;
            }

            DebtorInformation.ConvertFromQRCodeDataString(rawData.Skip(20).Take(7).ToArray());
            Reference.ConvertFromQRCodeDataString(new string[] { rawData[28] });
            AdditionalInformation = rawData[29];
            if(rawData[30] != "EPD")
                ValidationError.ThrowValidationException(ValidationCode.InvalidFieldTrailer);
            StructuredInformation = rawData.Length > 31 ? rawData[31] : string.Empty;
            if(rawData.Length - 32 > 0)
                AlternativeProcedures.ConvertFromQRCodeDataString(rawData.Skip(32).Take(2).ToArray());
        }

        string ConvertToQRCodeDataString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SPC");
            stringBuilder.AppendLine(Version.VersionCode);
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine(CreditorAccountNumber.ConvertToQRCodeDataString());
            stringBuilder.AppendLine(CreditorInformation.ConvertToQRCodeDataString());
            stringBuilder.AppendLine(new Address().ConvertToQRCodeDataString());
            stringBuilder.AppendLine(Amount == null ? string.Empty : Amount.Value.ToString("#0.00"));
            stringBuilder.AppendLine(Currency.ToString());
            stringBuilder.AppendLine(DebtorInformation.ConvertToQRCodeDataString());
            stringBuilder.AppendLine(ReferenceType.ToString());
            stringBuilder.AppendLine(Reference == null ? string.Empty : Reference.ConvertToQRCodeDataString());
            stringBuilder.AppendLine(AdditionalInformation);
            stringBuilder.AppendLine("EPD");
            stringBuilder.Append(StructuredInformation);
            AddIfNotEmpty(stringBuilder, AlternativeProcedures.ConvertToQRCodeDataString());
            return stringBuilder.ToString();
        }

        void AddIfNotEmpty(StringBuilder stringBuilder, string dataField) {
            if(!string.IsNullOrEmpty(dataField)) {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(dataField);
            }
        }

        double? CoerceAmount(double? amount) {
            if(amount == null) {
                return amount;
            } else {
                return amount.Value == 0d ? 0.1d : amount;
            }
        }
    }
}
