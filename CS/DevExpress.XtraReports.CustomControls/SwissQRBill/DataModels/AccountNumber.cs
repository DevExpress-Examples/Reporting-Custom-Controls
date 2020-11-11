using System;
using System.Linq;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class AccountNumber : QRCodeDataElement {
        static bool IsCreditorReference(string str) {
            return str.StartsWith("RF") && str.Length > 4 && str.Length <= 25;
        }
        static bool IsIban(string str) {
            return str.Length == 21;
        }
        static bool IsQR_IBAN(string str) {
            return str.Length == 21 && str[4] == '3';
        }
        static bool IsQR_Reference(string str) {
            return str.Length == 27;
        }
        static bool IsValid(string str) {
            return IsQR_IBAN(str) || IsQR_Reference(str) || IsIban(str) || IsCreditorReference(str);
        }

        static string SplitFromEnd(string str, int numbers) {
            var arr = str.ToList();
            var partsCount = str.Length / numbers;
            var count = arr.Count - 1;
            for(int i = 1; i <= partsCount; i++) {
                arr.Insert(count - numbers * i + 1, ' ');
            }
            return new string(arr.ToArray()).Trim();
        }
        static string SplitFromStart(string str, int numbers) {
            var arr = str.ToList();
            var partsCount = str.Length / numbers;
            for(int i = 1; i <= partsCount; i++) {
                arr.Insert(i * numbers + i - 1, ' ');
            }
            return new string(arr.ToArray()).Trim();
        }

        private const string DefaultNumber = "AA45XXXXXXXXXXXXXXXXA";
        string number;

        public AccountNumberFormat NumberFormat { get; private set; }

        public string Number {
            get { return number; }
            set {
                if(string.IsNullOrEmpty(value) || !IsValid(value))
                    ValidationError.ThrowValidationException(ValidationCode.InvalidAccountNumber);

                number = value;
                IdentifyFormat();
            }
        }

        public AccountNumber()
            : this(DefaultNumber) {
        }
        public AccountNumber(string ibanStr) {
            Number = ibanStr;
        }

        public override void ConvertFromQRCodeDataString(string[] rawString) {
            Number = rawString[0];
        }

        public override string ConvertToPresentationString() {
            switch(NumberFormat) {
                case AccountNumberFormat.QR_IBAN:
                case AccountNumberFormat.IBAN:
                case AccountNumberFormat.CreditorReference:
                    return SplitFromStart(Number, 4);
                case AccountNumberFormat.QRReference:
                    return SplitFromEnd(Number, 5);
                default:
                    break;
            }
            return string.Empty;
        }

        public override string ConvertToQRCodeDataString() {
            return Number;
        }

        public override string ToString() {
            return Number;
        }

        void IdentifyFormat() {
            if(IsQR_Reference(Number))
                NumberFormat = AccountNumberFormat.QRReference;
            if(IsIban(Number))
                NumberFormat = AccountNumberFormat.IBAN;
            if(IsCreditorReference(Number))
                NumberFormat = AccountNumberFormat.CreditorReference;
            if(IsQR_IBAN(Number))
                NumberFormat = AccountNumberFormat.QR_IBAN;
        }

        public override void Reset() {
            Number = DefaultNumber;
        }
    }
}
