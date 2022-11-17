using System;
using System.Collections.Generic;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public struct LocalizationKey : IEquatable<LocalizationKey> {
        public Language Language { get; set; }
        public SectionId SectionId { get; set; }

        public LocalizationKey(Language language, SectionId sectionId) {
            Language = language;
            SectionId = sectionId;
        }
        public override bool Equals(object obj) {
            if(!(obj is LocalizationKey))
                return false;
            return Equals((LocalizationKey)obj);
        }
        public bool Equals(LocalizationKey key) {
            return Language == key.Language && SectionId == key.SectionId;
        }
        public override int GetHashCode() {
            return Language.GetHashCode() ^ SectionId.GetHashCode();
        }
    }

    public class LocalizationData : Dictionary<LocalizationKey, string> {
        public static LocalizationData Instance = new LocalizationData();

        public string this[Language language, SectionId sectionId] {
            get { return this[new LocalizationKey(language, sectionId)]; }
            set { this[new LocalizationKey(language, sectionId)] = value; }
        }

        LocalizationData() {
            this[Language.English, SectionId.PaymentPart] = "Payment part";
            this[Language.English, SectionId.Receipt] = "Receipt";
            this[Language.English, SectionId.AccountPayableTo] = "Account / Payable to";
            this[Language.English, SectionId.Reference] = "Reference";
            this[Language.English, SectionId.AdditionalInformation] = "Additional information";
            this[Language.English, SectionId.PayableBy] = "Payable by";
            this[Language.English, SectionId.PayableByNameAddress] = "Payable by (name/address)";
            this[Language.English, SectionId.Currency] = "Currency";
            this[Language.English, SectionId.Amount] = "Amount";
            this[Language.English, SectionId.AcceptancePoint] = "Acceptance point";
            this[Language.English, SectionId.SeparateBeforePayingIn] = "Separate before paying in";

            this[Language.German, SectionId.PaymentPart] = "Zahlteil";
            this[Language.German, SectionId.Receipt] = "Empfangsschein";
            this[Language.German, SectionId.AccountPayableTo] = "Konto / Zahlbar an";
            this[Language.German, SectionId.Reference] = "Referenz";
            this[Language.German, SectionId.AdditionalInformation] = "Zusätzliche Informationen";
            this[Language.German, SectionId.PayableBy] = "Zahlbar durch";
            this[Language.German, SectionId.PayableByNameAddress] = "Zahlbar durch (Name / Adresse)";
            this[Language.German, SectionId.Currency] = "Währung";
            this[Language.German, SectionId.Amount] = "Betrag";
            this[Language.German, SectionId.AcceptancePoint] = "Annahmestelle";
            this[Language.German, SectionId.SeparateBeforePayingIn] = "Vor der Einzahlung abzutrennen";

            this[Language.French, SectionId.PaymentPart] = "Section paiement";
            this[Language.French, SectionId.Receipt] = "Récépissé";
            this[Language.French, SectionId.AccountPayableTo] = "Compte / Payable à";
            this[Language.French, SectionId.Reference] = "Référence";
            this[Language.French, SectionId.AdditionalInformation] = "Informations supplémentaires";
            this[Language.French, SectionId.PayableBy] = "Payable par";
            this[Language.French, SectionId.PayableByNameAddress] = "Payable par (nom / adresse)";
            this[Language.French, SectionId.Currency] = "Monnaie";
            this[Language.French, SectionId.Amount] = "Montant";
            this[Language.French, SectionId.AcceptancePoint] = "Point de dépôt";
            this[Language.French, SectionId.SeparateBeforePayingIn] = "A détacher avant le versement";

            this[Language.Italian, SectionId.PaymentPart] = "Sezione pagamento";
            this[Language.Italian, SectionId.Receipt] = "Ricevuta";
            this[Language.Italian, SectionId.AccountPayableTo] = "Conto / Pagabile a";
            this[Language.Italian, SectionId.Reference] = "Riferimento";
            this[Language.Italian, SectionId.AdditionalInformation] = "Informazioni supplementari";
            this[Language.Italian, SectionId.PayableBy] = "Pagabile da";
            this[Language.Italian, SectionId.PayableByNameAddress] = "Pagabile da (nome / indirizzo";
            this[Language.Italian, SectionId.Currency] = "Valuta";
            this[Language.Italian, SectionId.Amount] = "Importo";
            this[Language.Italian, SectionId.AcceptancePoint] = "Punto di accettazione";
            this[Language.Italian, SectionId.SeparateBeforePayingIn] = "Da staccare prima del versamento";
        }
    }
}
