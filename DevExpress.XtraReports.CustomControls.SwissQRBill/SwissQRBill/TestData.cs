using System.Collections.Generic;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class TestData {
        public const string BillWithoutAdditionalInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\n\r\nEPD\r\n";
        public const string BillWithAdditionalInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n";
        public const string BillWithEmptySenderInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information";
        public const string BillWithFullBillInfo = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information";
        public const string BillWithFullSectionFieldsEmpty = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\n\r\nEPD\r\n";
        public const string BillWithTwoProcedures = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information\r\nName AV1: UV;UltraPay005;12345\r\nName AV2: XY;XYService;54321";
        public const string BillWithOneProcedure = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n//bill information\r\nName AV1: XY;XYService;54321";
        public const string BillFromRealData = "SPC\r\n0200\r\n1\r\nCH4444995599000899901\r\nS\r\nHenri Schmid Service Switzerland AG\r\nMuseumstrasse\r\n258\r\n2501\r\nBiel\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n8690.00\r\nCHF\r\nS\r\nPia-Maria Rutschmann-Schnyder\r\nGrosse Marktgasse\r\n28\r\n9400\r\nRorschach\r\nCH\r\nSCOR\r\n210000000003139471430009017\r\nAuftrag vom 25.10.2019##S1/01/20170309/11/10201409/20/14000/22/36958/30/CH10646546/40/1020/41/3010\r\nEPD\r\n";

        public static List<QRBillDataItem> CreateData() {
            return new List<QRBillDataItem>() {
                new QRBillDataItem() { QRCodeData = BillWithoutAdditionalInfo },
                new QRBillDataItem() { QRCodeData = BillWithAdditionalInfo },
                new QRBillDataItem() { QRCodeData = BillWithEmptySenderInfo },
                new QRBillDataItem() { QRCodeData = BillWithFullBillInfo },
                new QRBillDataItem() { QRCodeData = BillWithFullSectionFieldsEmpty },
                new QRBillDataItem() { QRCodeData = BillWithTwoProcedures },
                new QRBillDataItem() { QRCodeData = BillWithOneProcedure },
            };
        }

        public static QRBillDataItem Create_Test_BillWithoutAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_BillWithAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithBillInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Simon Glarner", BuildingNumber = 55, PostalCode = 8184, Street = "Bachliwis", Town = "Bachenbulach" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithEmptySenderInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithoutAdditionalInfo() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_EmptyItem() {
            return new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Currency = Currency.EUR,
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
        }

        public static QRBillDataItem Create_Test_Item_WithTwoAlternativeProcedures() {
            var result = new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
            result.AlternativeProcedures.Assign(new AlternativeProcedures() { Name1 = "Name AV1", Instruction1 = "UV;UltraPay005;12345", Name2 = "Name AV2", Instruction2 = "XY;XYService;54321" });
            return result;
        }

        public static QRBillDataItem Create_Test_Item_WithOneAlternativeProcedures() {
            var result = new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CHXXXXXXXXXXXXXXXXXXA"),
                Amount = 287.30d,
                Currency = Currency.EUR,
                Reference = new PaymentReferenceAccountNumber("RFXXXXXXXXXXXXXX"),
                AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987",
                StructuredInformation = "//bill information",
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Schreinerei Habegger & Sohne", BuildingNumber = 138, PostalCode = 8045, Street = "Uetlibergstrasse", Town = "Zuric" },
            };
            result.AlternativeProcedures.Assign(new AlternativeProcedures() { Name1 = "Name AV1", Instruction1 = "XY;XYService;54321" });
            return result;
        }

        public static QRBillDataItem Create_Test_Item_FromRealData() {
            var result = new QRBillDataItem() {
                CreditorAccountNumber = new CreditorAccountNumber("CH4444995599000899901"),
                Amount = 8690,
                Currency = Currency.CHF,
                Reference = new PaymentReferenceAccountNumber("210000000003139471430009017"),
                AdditionalInformation = "Auftrag vom 25.10.2019##S1/01/20170309/11/10201409/20/14000/22/36958/30/CH10646546/40/1020/41/3010",
                DebtorInformation = new Address() { CountryCode = "CH", Name = "Pia-Maria Rutschmann-Schnyder", BuildingNumber = 28, PostalCode = 9400, Street = "Grosse Marktgasse", Town = "Rorschach" },
                CreditorInformation = new Address() { CountryCode = "CH", Name = "Henri Schmid Service Switzerland AG", BuildingNumber = 258, PostalCode = 2501, Street = "Museumstrasse", Town = "Biel" },
            };
            return result;
        }
    }
}
