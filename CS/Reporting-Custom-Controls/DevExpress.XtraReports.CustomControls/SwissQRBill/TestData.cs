using System.Collections.Generic;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class TestData {
        public const string BillWithoutAdditionalInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\n\r\nEPD\r\n";
        public const string BillWithAdditionalInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n";
        public const string BillWithEmptySenderInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information";
        public const string BillWithFullBillInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information";
        public const string BillWithFullSectionFieldsEmpty = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\n\r\nEPD\r\n";
        public const string BillWithTwoSchemas = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information\r\nName AV1: UV;UltraPay005;12345\r\nName AV2: XY;XYService;54321";
        public const string BillWithOneSchema = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information\r\nName AV1: XY;XYService;54321";

        public static List<QRBillDataItem> CreateData() {
            return new List<QRBillDataItem>() {
                new QRBillDataItem() { QRCodeData = BillWithoutAdditionalInfo },
                new QRBillDataItem() { QRCodeData = BillWithAdditionalInfo },
                new QRBillDataItem() { QRCodeData = BillWithEmptySenderInfo },
                new QRBillDataItem() { QRCodeData = BillWithFullBillInfo },
                new QRBillDataItem() { QRCodeData = BillWithFullSectionFieldsEmpty },
                new QRBillDataItem() { QRCodeData = BillWithTwoSchemas },
                new QRBillDataItem() { QRCodeData = BillWithOneSchema },
            };
        }

        public static QRBillDataItem Create_Test_BillWithoutAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_BillWithAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithBillInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithEmptySenderInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithoutAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_EmptyItem() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Currency = Currency.EUR,
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithTwoAlternativeSchemas() {
            var result = new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
            result.AlternativeSchema.Assign(new AlternativeSchema() { Name1 = "Name AV1", Instruction1 = "UV;UltraPay005;12345", Name2 = "Name AV2", Instruction2 = "XY;XYService;54321" });
            return result;
        }

        public static QRBillDataItem Create_Test_Item_WithOneAlternativeSchemas() {
            var result = new QRBillDataItem() {
                CreditorAccountNumber = new AccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new AccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
            result.AlternativeSchema.Assign(new AlternativeSchema() { Name1 = "Name AV2", Instruction1 = "XY;XYService;54321" });
            return result;        
        }
    }
}
