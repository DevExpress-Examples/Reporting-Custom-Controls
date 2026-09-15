using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using DevExpress.Utils.Serializing;

namespace CustomControls.SwissQRBill {
    [TypeConverter(typeof(AddressTypeConverter))]
    public class Address : QRCodeDataElement {
        static string ToChar(AddressType addressType) {
            switch(addressType) {
                case AddressType.Structured:
                    return "S";
#pragma warning disable CS0618
                case AddressType.Combined:
#pragma warning restore CS0618
                    return "K";
            }
            return null;
        }
        const string Switzerland = "CH";

        string countryCode = string.Empty;
        string buildingNumber = string.Empty;
        string name = string.Empty;
        string postalCode = string.Empty;
        string street = string.Empty;
        string town = string.Empty;

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
        public string CountryCode {
            get => countryCode;
            set {
                if(!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, "^[A-Za-z]{2}$"))
                    throw ValidationError.FieldException("Country", "Must be a two-letter country code (ISO 3166-1).");
                countryCode = value ?? string.Empty;
            }
        }

        [DisplayName("Building Number")]
        [Description("Building Number description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string BuildingNumber {
            get => buildingNumber;
            set { FieldValidation.Validate(value, 16, "BuildingNumber"); buildingNumber = value ?? string.Empty; }
        }

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
        public string Name {
            get => name;
            set { FieldValidation.Validate(value, 70, "Name"); name = value ?? string.Empty; }
        }

        [DisplayName("Postal Code")]
        [Description("Postal Code description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string PostalCode {
            get => postalCode;
            set { FieldValidation.Validate(value, 16, "PostalCode"); postalCode = value ?? string.Empty; }
        }

        [DisplayName("Street")]
        [Description("Street description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Street {
            get => street;
            set { FieldValidation.Validate(value, 70, "Street"); street = value ?? string.Empty; }
        }

        [DisplayName("Town")]
        [Description("Town description")]
        [DefaultValue("")]
        [XtraSerializableProperty]
        public string Town {
            get => town;
            set { FieldValidation.Validate(value, 35, "Town"); town = value ?? string.Empty; }
        }

        public override void ConvertFromQRCodeDataString(string[] rawString) {
#pragma warning disable CS0618
            AddressType = rawString[0] == "K" ? AddressType.Combined
                : AddressType.Structured;
#pragma warning restore CS0618
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
                CountryCode = Switzerland;
            }
        }

        public override string ConvertToPresentationString() {
            if(IsEmpty())
                return string.Empty;
            if(AddressType == AddressType.Structured) {
                string streetLine = string.IsNullOrEmpty(BuildingNumber) ? Street : $"{Street} {BuildingNumber}";
                if(CountryCode == Switzerland) {
                    return string.Join(Environment.NewLine, Name, streetLine, $"{PostalCode} {Town}");
                } else {
                    return string.Join(Environment.NewLine, Name, streetLine, $"{CountryCode} {PostalCode} {Town}");
                }
            }
            else
                return string.Join(Environment.NewLine, Name, AddressLine1, AddressLine2);
        }

        public override string ConvertToQRCodeDataString() {
            if(IsEmpty())
                return string.Join(Environment.NewLine, Enumerable.Range(0, 7).Select(a => string.Empty));

            if(AddressType == AddressType.Structured) {
                return string.Join(Environment.NewLine, ToChar(AddressType), Name, Street, BuildingNumber, PostalCode, Town, CountryCode);
            }
            throw ValidationError.FieldException("AddressType",
                "Combined address type ('K') is no longer part of the Swiss QR Code data structure since Implementation Guidelines v2.3 (valid from 21 November 2025, mandatory since 30 September 2026). Use AddressType.Structured instead.");
        }

        bool IsEmpty() {
            if(!string.IsNullOrEmpty(Name))
                return false;

#pragma warning disable CS0618
            return AddressType == AddressType.Combined
                ? string.IsNullOrEmpty(AddressLine1) && string.IsNullOrEmpty(AddressLine2)
                : string.IsNullOrEmpty(Street) && string.IsNullOrEmpty(Town)
                    && string.IsNullOrEmpty(PostalCode) && string.IsNullOrEmpty(BuildingNumber);
#pragma warning restore CS0618
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
