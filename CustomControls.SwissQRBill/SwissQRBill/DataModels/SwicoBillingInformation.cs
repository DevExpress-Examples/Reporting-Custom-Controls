using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomControls.SwissQRBill {
    public class SwicoVatRateAmount {
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public SwicoVatRateAmount() { }
        public SwicoVatRateAmount(decimal rate, decimal amount) {
            Rate = rate;
            Amount = amount;
        }
    }

    public class SwicoPaymentCondition {
        public decimal DiscountRate { get; set; }
        public int Days { get; set; }
        public SwicoPaymentCondition() { }
        public SwicoPaymentCondition(decimal discountRate, int days) {
            DiscountRate = discountRate;
            Days = days;
        }
    }

    public class SwicoBillingInformation {
        const string Prefix = "//S1";

        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string CustomerReference { get; set; }

        public string VatNumber { get; set; }

        public DateTime? VatDate { get; set; }
        public DateTime? VatDateRangeEnd { get; set; }

        public decimal? VatRate { get; set; }
        public List<SwicoVatRateAmount> VatDetails { get; } = new List<SwicoVatRateAmount>();
        public List<SwicoVatRateAmount> ImportVatDetails { get; } = new List<SwicoVatRateAmount>();
        public List<SwicoPaymentCondition> PaymentConditions { get; } = new List<SwicoPaymentCondition>();

        public bool IsEmpty {
            get {
                return string.IsNullOrEmpty(InvoiceNumber) && InvoiceDate == null && string.IsNullOrEmpty(CustomerReference)
                    && string.IsNullOrEmpty(VatNumber) && VatDate == null && VatDateRangeEnd == null && VatRate == null
                    && VatDetails.Count == 0 && ImportVatDetails.Count == 0 && PaymentConditions.Count == 0;
            }
        }

        public string ConvertToQRCodeDataString() {
            if(IsEmpty)
                return string.Empty;
            if(VatRate != null && VatDetails.Count > 0)
                throw ValidationError.FieldException("SwicoBillingInformation.VatRate/VatDetails",
                    "VAT details must contain either a single overall rate (VatRate) or an itemized list (VatDetails), not both.");
            if(!string.IsNullOrEmpty(VatNumber) && !Regex.IsMatch(VatNumber, "^[0-9]{9}$"))
                throw ValidationError.FieldException("SwicoBillingInformation.VatNumber",
                    "Must be the 9-digit UID number, without the CHE prefix, separators or MWST/TVA/IVA/VAT suffix.");
            if(VatDate == null && VatDateRangeEnd != null)
                throw ValidationError.FieldException("SwicoBillingInformation.VatDateRangeEnd",
                    "VatDateRangeEnd requires VatDate to be set as the start of the range.");

            var tags = new List<Tuple<int, string>>();
            AddTag(tags, 10, Escape(InvoiceNumber));
            AddTag(tags, 11, FormatDate(InvoiceDate));
            AddTag(tags, 20, Escape(CustomerReference));
            AddTag(tags, 30, VatNumber);
            AddTag(tags, 31, FormatDateOrRange(VatDate, VatDateRangeEnd));
            AddTag(tags, 32, VatDetails.Count > 0 ? FormatList(VatDetails) : FormatRate(VatRate));
            AddTag(tags, 33, FormatList(ImportVatDetails));
            AddTag(tags, 40, FormatConditions(PaymentConditions));

            var builder = new StringBuilder(Prefix);
            foreach(var tag in tags)
                builder.Append($"/{tag.Item1}/{tag.Item2}");
            return builder.ToString();
        }

        static void AddTag(List<Tuple<int, string>> tags, int tag, string value) {
            if(!string.IsNullOrEmpty(value))
                tags.Add(Tuple.Create(tag, value));
        }

        static string Escape(string value) {
            return string.IsNullOrEmpty(value) ? value : value.Replace("\\", "\\\\").Replace("/", "\\/");
        }
        static string Unescape(string value) {
            return string.IsNullOrEmpty(value) ? value : value.Replace("\\/", "/").Replace("\\\\", "\\");
        }

        static string FormatDate(DateTime? date) {
            return date == null ? null : date.Value.ToString("yyMMdd", CultureInfo.InvariantCulture);
        }
        static string FormatDateOrRange(DateTime? start, DateTime? end) {
            if(start == null)
                return null;
            return end == null ? FormatDate(start) : FormatDate(start) + FormatDate(end);
        }
        static string FormatRate(decimal? rate) {
            return rate == null ? null : rate.Value.ToString("0.###", CultureInfo.InvariantCulture);
        }
        static string FormatList(List<SwicoVatRateAmount> items) {
            if(items == null || items.Count == 0)
                return null;
            return string.Join(";", items.Select(i =>
                $"{i.Rate.ToString("0.###", CultureInfo.InvariantCulture)}:{i.Amount.ToString("0.##", CultureInfo.InvariantCulture)}"));
        }
        static string FormatConditions(List<SwicoPaymentCondition> items) {
            if(items == null || items.Count == 0)
                return null;
            return string.Join(";", items.Select(i =>
                $"{i.DiscountRate.ToString("0.###", CultureInfo.InvariantCulture)}:{i.Days.ToString(CultureInfo.InvariantCulture)}"));
        }

        public static bool TryParse(string value, out SwicoBillingInformation result) {
            result = null;
            if(string.IsNullOrEmpty(value) || !value.StartsWith(Prefix, StringComparison.Ordinal))
                return false;

            var tags = SplitTags(value.Substring(Prefix.Length));
            if(tags == null)
                return false;

            var info = new SwicoBillingInformation();
            int? lastTag = null;
            foreach(var entry in tags) {
                int tag = entry.Item1;
                string raw = entry.Item2;
                if(lastTag != null && tag <= lastTag)
                    return false;
                lastTag = tag;

                DateTime parsedDate, rangeStart, rangeEnd;
                decimal rate;
                switch(tag) {
                    case 10:
                        info.InvoiceNumber = Unescape(raw);
                        break;
                    case 11:
                        if(!TryParseDate(raw, out parsedDate))
                            return false;
                        info.InvoiceDate = parsedDate;
                        break;
                    case 20:
                        info.CustomerReference = Unescape(raw);
                        break;
                    case 30:
                        if(!Regex.IsMatch(raw, "^[0-9]{9}$"))
                            return false;
                        info.VatNumber = raw;
                        break;
                    case 31:
                        if(raw.Length == 6) {
                            if(!TryParseDate(raw, out parsedDate))
                                return false;
                            info.VatDate = parsedDate;
                        } else if(raw.Length == 12) {
                            if(!TryParseDate(raw.Substring(0, 6), out rangeStart) || !TryParseDate(raw.Substring(6, 6), out rangeEnd))
                                return false;
                            info.VatDate = rangeStart;
                            info.VatDateRangeEnd = rangeEnd;
                        } else {
                            return false;
                        }
                        break;
                    case 32:
                        if(raw.Contains(":")) {
                            if(!TryParseList(raw, info.VatDetails))
                                return false;
                        } else if(TryParseDecimal(raw, out rate)) {
                            info.VatRate = rate;
                        } else {
                            return false;
                        }
                        break;
                    case 33:
                        if(!TryParseList(raw, info.ImportVatDetails))
                            return false;
                        break;
                    case 40:
                        if(!TryParseConditions(raw, info.PaymentConditions))
                            return false;
                        break;
                    default:
                        return false;
                }
            }
            result = info;
            return true;
        }

        public static SwicoBillingInformation Parse(string value) {
            SwicoBillingInformation result;
            if(!TryParse(value, out result))
                throw ValidationError.FieldException("SwicoBillingInformation", "Value is not a valid Swico 'Billing information' syntax (Annex D).");
            return result;
        }

        static bool TryParseDate(string raw, out DateTime date) {
            return DateTime.TryParseExact(raw, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        static bool TryParseDecimal(string raw, out decimal value) {
            if(!Regex.IsMatch(raw, @"^-?[0-9]+(\.[0-9]+)?$")) {
                value = default;
                return false;
            }
            return decimal.TryParse(raw, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out value);
        }
        static bool TryParseList(string raw, List<SwicoVatRateAmount> target) {
            foreach(string part in raw.Split(';')) {
                string[] pieces = part.Split(':');
                decimal rate, amount;
                if(pieces.Length != 2
                    || !TryParseDecimal(pieces[0], out rate)
                    || !TryParseDecimal(pieces[1], out amount))
                    return false;
                target.Add(new SwicoVatRateAmount(rate, amount));
            }
            return true;
        }
        static bool TryParseConditions(string raw, List<SwicoPaymentCondition> target) {
            foreach(string part in raw.Split(';')) {
                string[] pieces = part.Split(':');
                decimal rate;
                int days;
                if(pieces.Length != 2
                    || !TryParseDecimal(pieces[0], out rate)
                    || !int.TryParse(pieces[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out days))
                    return false;
                target.Add(new SwicoPaymentCondition(rate, days));
            }
            return true;
        }

        static List<Tuple<int, string>> SplitTags(string remainder) {
            var result = new List<Tuple<int, string>>();
            int i = 0;
            while(i < remainder.Length) {
                if(remainder[i] != '/')
                    return null;
                int tagEnd = remainder.IndexOf('/', i + 1);
                int tag;
                if(tagEnd < 0 || !int.TryParse(remainder.Substring(i + 1, tagEnd - i - 1), out tag))
                    return null;

                int valueStart = tagEnd + 1;
                int valueEnd = valueStart;
                while(valueEnd < remainder.Length) {
                    if(remainder[valueEnd] == '\\' && valueEnd + 1 < remainder.Length) {
                        valueEnd += 2;
                        continue;
                    }
                    if(remainder[valueEnd] == '/')
                        break;
                    valueEnd++;
                }
                result.Add(Tuple.Create(tag, remainder.Substring(valueStart, valueEnd - valueStart)));
                i = valueEnd;
            }
            return result;
        }
    }
}
