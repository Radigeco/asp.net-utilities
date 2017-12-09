﻿using System.Collections.Generic;

namespace Utilities
{
    /// <summary>
    /// Currency helper
    /// </summary>
    public static class CurrencyHelper
    {
        private static readonly Dictionary<string, string> Currencies = new Dictionary<string, string>
        {
            {"AED", "د.إ.‏"},
            {"AFN", "؋ "},
            {"ALL", "Lek"},
            {"AMD", "դր."},
            {"ARS", "$"},
            {"AUD", "$"},
            {"AZN", "man."},
            {"BAM", "KM"},
            {"BDT", "৳"},
            {"BGN", "лв."},
            {"BHD", "د.ب.‏ "},
            {"BND", "$"},
            {"BOB", "$b"},
            {"BRL", "R$"},
            {"BYR", "р."},
            {"BZD", "BZ$"},
            {"CAD", "$"},
            {"CHF", "fr."},
            {"CLP", "$"},
            {"CNY", "¥"},
            {"COP", "$"},
            {"CRC", "₡"},
            {"CSD", "Din."},
            {"CZK", "Kč"},
            {"DKK", "kr."},
            {"DOP", "RD$"},
            {"DZD", "DZD"},
            {"EEK", "kr"},
            {"EGP", "ج.م.‏ "},
            {"ETB", "ETB"},
            {"EUR", "€"},
            {"GBP", "£"},
            {"GEL", "Lari"},
            {"GTQ", "Q"},
            {"HKD", "HK$"},
            {"HNL", "L."},
            {"HRK", "kn"},
            {"HUF", "Ft"},
            {"IDR", "Rp"},
            {"ILS", "₪"},
            {"INR", "रु"},
            {"IQD", "د.ع.‏ "},
            {"IRR", "ريال "},
            {"ISK", "kr."},
            {"JMD", "J$"},
            {"JOD", "د.ا.‏ "},
            {"JPY", "¥"},
            {"KES", "S"},
            {"KGS", "сом"},
            {"KHR", "៛"},
            {"KRW", "₩"},
            {"KWD", "د.ك.‏ "},
            {"KZT", "Т"},
            {"LAK", "₭"},
            {"LBP", "ل.ل.‏ "},
            {"LKR", "රු."},
            {"LTL", "Lt"},
            {"LVL", "Ls"},
            {"LYD", "د.ل.‏ "},
            {"MAD", "د.م.‏ "},
            {"MKD", "ден."},
            {"MNT", "₮"},
            {"MOP", "MOP"},
            {"MVR", "ރ."},
            {"MXN", "$"},
            {"MYR", "RM"},
            {"NIO", "N"},
            {"NOK", "kr"},
            {"NPR", "रु"},
            {"NZD", "$"},
            {"OMR", "ر.ع.‏ "},
            {"PAB", "B/."},
            {"PEN", "S/."},
            {"PHP", "PhP"},
            {"PKR", "Rs"},
            {"PLN", "zł"},
            {"PYG", "Gs"},
            {"QAR", "ر.ق.‏ "},
            {"RON", "lei"},
            {"RSD", "Din."},
            {"RUB", "р."},
            {"RWF", "RWF"},
            {"SAR", "ر.س.‏ "},
            {"SEK", "kr"},
            {"SGD", "$"},
            {"SYP", "ل.س.‏ "},
            {"THB", "฿"},
            {"TJS", "т.р."},
            {"TMT", "m."},
            {"TND", "د.ت.‏ "},
            {"TRY", "TL"},
            {"TTD", "TT$"},
            {"TWD", "NT$"},
            {"UAH", "₴"},
            {"USD", "$"},
            {"UYU", "$U"},
            {"UZS", "so'm"},
            {"VEF", "Bs. F."},
            {"VND", "₫"},
            {"XOF", "XOF"},
            {"YER", "ر.ي.‏ "},
            {"ZAR", "R"},
            {"ZWL", "Z$"}
        };

        /// <summary>
        /// Returns a list of known currencies
        /// </summary>
        /// <returns></returns>
        public static List<CurrencyModel> GetCurrencies()
        {
            var currencyList = new List<CurrencyModel>();
            foreach (var currency in Currencies)
            {
                currencyList.Add(new CurrencyModel
                {
                    ShortName = currency.Key,
                    Symbol = currency.Value
                });
            }
            return currencyList;
        }

        public class CurrencyModel
        {
            public string ShortName { get; set; }
            public string Symbol { get; set; }
        }
    }
}