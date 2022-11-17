using System;
using System.ComponentModel;
using DevExpress.Utils.Serializing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [TypeConverter(typeof(AlternativeProceduresTypeConverter))]
    public partial class AlternativeProcedures : QRCodeDataElement {
        const string SplitterString = ": ";

        static Tuple<string, string> ParseProceduresString(string procedures) {
            string name = string.Empty;
            string instruction = string.Empty;
            var splitResult = Regex.Split(procedures, SplitterString);
            if(splitResult.Length > 0)
                name = splitResult[0];
            if(splitResult.Length > 1)
                instruction = splitResult[1];
            return new Tuple<string, string>(name, instruction);
        }

        [DisplayName("Name 1")]
        [Description("Name 1 description")]
        [XtraSerializableProperty]
        [DefaultValue("")]
        public string Name1 { get; set; } = "";

        [DisplayName("Instruction 1")]
        [Description("Instruction 1 description")]
        [XtraSerializableProperty]
        [DefaultValue("")]
        public string Instruction1 { get; set; } = "";

        [DisplayName("Name 2")]
        [Description("Name 2 description")]
        [XtraSerializableProperty]
        [DefaultValue("")]
        public string Name2 { get; set; } = "";

        [DisplayName("Instruction 2")]
        [Description("Instruction 2 description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Instruction2 { get; set; } = "";

        internal bool IsFirstPairEmpty => string.IsNullOrEmpty(Name1) || string.IsNullOrEmpty(Instruction1);
        internal bool IsSecondPairEmpty => string.IsNullOrEmpty(Name2) || string.IsNullOrEmpty(Instruction2);
        internal bool IsEmpty => IsFirstPairEmpty && IsSecondPairEmpty;

        public override void ConvertFromQRCodeDataString(string[] rawString) {
            if(rawString.Length > 0) {
                var splitResult = ParseProceduresString(rawString[0]);
                Name1 = splitResult.Item1;
                Instruction1 = splitResult.Item2;
            }
            if(rawString.Length > 1) {
                var splitResult = ParseProceduresString(rawString[1]);
                Name2 = splitResult.Item1;
                Instruction2 = splitResult.Item2;
            }
        }

        public override string ConvertToPresentationString() {
            return ConvertToQRCodeDataString();
        }

        public override string ConvertToQRCodeDataString() {
            List<string> result = new List<string>();
            if(!IsFirstPairEmpty)
                result.Add($"{Name1}{SplitterString}{Instruction1}");
            if(!IsSecondPairEmpty)
                result.Add($"{Name2}{SplitterString}{Instruction2}");
            return string.Join(Environment.NewLine, result);
        }

        public void Assign(AlternativeProcedures procedures) {
            Name1 = procedures.Name1;
            Name2 = procedures.Name2;
            Instruction1 = procedures.Instruction1;
            Instruction2 = procedures.Instruction2;
        }
        public override void Reset() {
            Name1 = string.Empty;
            Name2 = string.Empty;
            Instruction2 = string.Empty;
            Instruction1 = string.Empty;
        }
    }
}
