using System.Linq;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public abstract class AccountNumber : QRCodeDataElement {

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

        string number;

        public AccountNumberFormat NumberFormat { get; protected set; }

        public string Number {
            get { return number; }
            set {
                if(!IsValid(value))
                    ValidationError.ThrowValidationException(ValidationCode.InvalidAccountNumber);
                number = value;
                IdentifyFormat();
            }
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

        protected abstract bool IsValid(string str);
        protected abstract void IdentifyFormat();
    }
}
