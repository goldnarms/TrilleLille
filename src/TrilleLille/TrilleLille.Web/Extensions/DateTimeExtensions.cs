﻿using System;
using System.Globalization;

namespace TrilleLille.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToPolarTime(this DateTime dato)
        {
            return string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", dato.Year.ToString("00"), dato.Month.ToString("00"), dato.Day.ToString("00"), dato.Hour.ToString("00"), dato.Minute.ToString("00"), dato.Second.ToString("00"));
        }

        public static double AntallSekunder(this DateTime dato)
        {
            return new TimeSpan(dato.Hour, dato.Minute, dato.Second).TotalSeconds;
        }

        public static DateTime KonverterTilDato(this string tekst)
        {
            DateTime dato;
            if (DateTime.TryParseExact(tekst, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "yyyyMMdd H:mm:ss.F", CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "yyyyMMdd HH:mm:ss.F", CultureInfo.InvariantCulture,
                DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "yyyy-MM-dd H:mm:ss.F", CultureInfo.InvariantCulture,
                DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            if (DateTime.TryParseExact(tekst, "yyyy-MM-dd HH:mm:ss.F", CultureInfo.InvariantCulture,
                DateTimeStyles.AllowTrailingWhite, out dato)) return dato;
            return dato;
        }
    }
}
