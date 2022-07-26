using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class BillOptionsTypeConverter : ExpandableObjectConverter {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if(destinationType == typeof(string) && value is BillOptions)
                return "(Options)";
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    public class SwissQRBillScriptsTypeConverter : ExpandableObjectConverter {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if(destinationType == typeof(string) && value is XRSwissQRBillScripts)
                return "(Swiss QR Bill Scripts)";
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class AlternativeProceduresTypeConverter : ExpandableObjectConverter {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if(destinationType == typeof(string) && value is AlternativeProcedures)
                return $"({(value).GetType().Name})";
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class AddressTypeConverter : ExpandableObjectConverter {
        readonly string[] CombinedSpecificProps = new string[] { nameof(Address.AddressLine1), nameof(Address.AddressLine2) };
        readonly string[] StructuredSpecificProps = new string[] { nameof(Address.CountryCode), nameof(Address.BuildingNumber),
            nameof(Address.PostalCode), nameof(Address.Street), nameof(Address.Town) };

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if(destinationType == typeof(string) && value is Address address)
                return $"({address.AddressType})";
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
            Address address = value as Address;
            if(address != null) {
                var propertiesCollection = base.GetProperties(context, value, attributes).Cast<PropertyDescriptor>().ToList();
                if(address.AddressType == AddressType.Structured)
                    propertiesCollection.RemoveAll(p => CombinedSpecificProps.Contains(p.Name));
                else
                    propertiesCollection.RemoveAll(p => StructuredSpecificProps.Contains(p.Name));
                return new PropertyDescriptorCollection(propertiesCollection.ToArray());
            }
            return base.GetProperties(context, value, attributes);
        }
    }
}
