namespace CustomControls.SwissQRBill {
    
    public static class FieldValidation {
        public static void Validate(string value, int maxLength, string fieldName) {
            if(string.IsNullOrEmpty(value))
                return;
            if(value.Length > maxLength)
                throw ValidationError.FieldException(fieldName, $"Maximum {maxLength} characters permitted.");
            foreach(char c in value) {
                if(!IsAllowedCharacter(c))
                    throw ValidationError.FieldException(fieldName, $"Character '{c}' is not part of the character set allowed in the Swiss QR Code (chapter 4.1.1).");
            }
        }

        public static void ValidateCombinedLength(string first, string second, int maxLength, string fieldName) {
            int length = (first?.Length ?? 0) + (second?.Length ?? 0);
            if(length > maxLength)
                throw ValidationError.FieldException(fieldName, $"Maximum {maxLength} characters permitted in total.");
        }

        static bool IsAllowedCharacter(char c) {
            if(c >= ' ' && c <= '~')
                return true;
            if(c >= ' ' && c <= 'ÿ')
                return true;
            if(c >= 'Ā' && c <= 'ſ')
                return true;
            switch(c) {
                case 'Ș':
                case 'ș':
                case 'Ț':
                case 'ț':
                case '€':
                    return true;
                default:
                    return false;
            }
        }
    }
}
