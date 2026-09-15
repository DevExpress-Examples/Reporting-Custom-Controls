using System.Linq;
using System.Text.RegularExpressions;

namespace CustomControls.SwissQRBill {
    public class PaymentReferenceAccountNumber : AccountNumber {
        const string DefaultNumber = "";

        public PaymentReferenceAccountNumber() : this(DefaultNumber) { }
        public PaymentReferenceAccountNumber(string ibanStr) : base(ibanStr) { }
        static bool IsCreditorReference(string str) {
            return str.Length >= 5 && str.Length <= 25
                && Regex.IsMatch(str, "^RF[0-9]{2}[A-Za-z0-9]+$");
        }
        static bool IsQR_Reference(string str) {
            return str.Length == 27 && str.All(char.IsDigit);
        }
        protected override bool IsValid(string str) {
            if(string.IsNullOrEmpty(str))
                return true;
            if(IsQR_Reference(str))
                return ChecksumValidator.IsValidMod10Recursive(str);
            if(IsCreditorReference(str))
                return ChecksumValidator.IsValidIso7064Mod97(str);
            return false;
        }
        protected override void IdentifyFormat() {
            if(IsCreditorReference(Number))
                NumberFormat = AccountNumberFormat.CreditorReference;
            if(IsQR_Reference(Number))
                NumberFormat = AccountNumberFormat.QRReference;
            if(string.IsNullOrEmpty(Number))
                NumberFormat = AccountNumberFormat.None;
        }
        public override void Reset() {
            Number = DefaultNumber;
        }
        public override string ConvertToQRCodeDataString() {
            return NumberFormat == AccountNumberFormat.None ? string.Empty : Number;
        }
    }
}
