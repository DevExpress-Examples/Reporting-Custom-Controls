using System;
using System.Linq;
using System.ComponentModel;
using DevExpress.Utils.Serializing;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [TypeConverter(typeof(AddressTypeConverter))]
    public class Address : QRCodeDataElement {
        static string ToChar(AddressType addressType) {
            switch(addressType) {
                case AddressType.Structured:
                    return "S";
                case AddressType.Combined:
                    return "K";
            }
            return null;
        }

        [DisplayName("Address Type")]
        [Description("Address Type desription")]
        [XtraSerializableProperty]
        [DefaultValue(AddressType.Structured)]
        [RefreshProperties(RefreshProperties.All)]
        public AddressType AddressType { get; set; } = AddressType.Structured;

        [DisplayName("Country Code")]
        [Description("Country Code description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string CountryCode { get; set; } = string.Empty;

        [DisplayName("Building Number")]
        [Description("Building Number description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string BuildingNumber { get; set; } = string.Empty;

        [DisplayName("Address Line 1")]
        [Description("Address Line 1 description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string AddressLine1 { get; set; } = string.Empty;

        [DisplayName("Address Line 2")]
        [Description("Address Line 2 description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string AddressLine2 { get; set; } = string.Empty;

        [DisplayName("Name")]
        [Description("Name description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Postal Code")]
        [Description("Postal Code description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string PostalCode { get; set; } = string.Empty;

        [DisplayName("Street")]
        [Description("Street description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Street { get; set; } = string.Empty;

        [DisplayName("Town")]
        [Description("Town description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Town { get; set; } = string.Empty;

        public override void ConvertFromQRCodeDataString(string[] rawString) {
            AddressType = rawString[0] == "K" ? AddressType.Combined
                : AddressType.Structured; //real value is empty or structured
            Name = rawString[1];
            if(AddressType == AddressType.Structured) {
                Street = rawString[2];
                BuildingNumber = rawString[3];
                PostalCode = rawString[4];
                Town = rawString[5];
                CountryCode = rawString[6];
            } else {
                AddressLine1 = rawString[2];
                AddressLine2 = rawString[3];
                CountryCode = rawString[6];
            }
        }

        public override string ConvertToPresentationString() {
            if(IsEmpty())
                return string.Empty;
            if(AddressType == AddressType.Structured)
                return string.Join(Environment.NewLine, Name, $"{Street} {BuildingNumber}", $"{PostalCode} {Town}");
            else
                return string.Join(Environment.NewLine, Name, AddressLine1, AddressLine2);
        }

        public override string ConvertToQRCodeDataString() {
            if(IsEmpty())
                return string.Join(Environment.NewLine, Enumerable.Range(0, 7).Select(a => string.Empty));

            if(AddressType == AddressType.Structured) {
                return string.Join(Environment.NewLine, ToChar(AddressType), Name, Street, BuildingNumber, PostalCode, Town, CountryCode);
            } else {
                return string.Join(Environment.NewLine, ToChar(AddressType), Name, AddressLine1, AddressLine2, string.Empty, string.Empty, CountryCode);
            }
        }

        bool IsEmpty() {
            if(!string.IsNullOrEmpty(Name))
                return false;

            return AddressType == AddressType.Combined
                ? string.IsNullOrEmpty(AddressLine1) && string.IsNullOrEmpty(AddressLine2)
                : string.IsNullOrEmpty(Street) && string.IsNullOrEmpty(Town)
                    && string.IsNullOrEmpty(PostalCode) && string.IsNullOrEmpty(BuildingNumber);
        }

        public override void Reset() {
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            Street = string.Empty;
            Town = string.Empty;
            CountryCode = string.Empty;
            PostalCode = string.Empty;
            BuildingNumber = string.Empty;
        }
    }
}
