using System.Linq;

namespace CustomControls.SwissQRBill {
    
    public static class ChecksumValidator {
        static readonly int[][] Mod10RecursiveTable = new int[][] {
            new[] {0,9,4,6,8,2,7,1,3,5},
            new[] {9,4,6,8,2,7,1,3,5,0},
            new[] {4,6,8,2,7,1,3,5,0,9},
            new[] {6,8,2,7,1,3,5,0,9,4},
            new[] {8,2,7,1,3,5,0,9,4,6},
            new[] {2,7,1,3,5,0,9,4,6,8},
            new[] {7,1,3,5,0,9,4,6,8,2},
            new[] {1,3,5,0,9,4,6,8,2,7},
            new[] {3,5,0,9,4,6,8,2,7,1},
            new[] {5,0,9,4,6,8,2,7,1,3},
        };

        public static bool IsValidMod10Recursive(string reference) {
            if(reference == null || reference.Length != 27 || !reference.All(c => c >= '0' && c <= '9'))
                return false;

            int carry = 0;
            for(int i = 0; i < 26; i++)
                carry = Mod10RecursiveTable[carry][reference[i] - '0'];

            int checkDigit = (10 - carry) % 10;
            return checkDigit == reference[26] - '0';
        }

        public static bool IsValidIso7064Mod97(string value) {
            if(value == null || value.Length < 5)
                return false;

            string rearranged = value.Substring(4) + value.Substring(0, 4);
            int remainder = 0;
            foreach(char c in rearranged) {
                int numericValue;
                if(c >= '0' && c <= '9') {
                    numericValue = c - '0';
                    remainder = (remainder * 10 + numericValue) % 97;
                } else if(char.IsLetter(c)) {
                    numericValue = char.ToUpperInvariant(c) - 'A' + 10;
                    remainder = (remainder * 100 + numericValue) % 97;
                } else {
                    return false;
                }
            }
            return remainder == 1;
        }
    }
}
