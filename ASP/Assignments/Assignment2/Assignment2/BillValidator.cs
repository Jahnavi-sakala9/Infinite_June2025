using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Assignment2
{
    public class BillValidator
    {
        private static readonly Regex EbRegex = new Regex(@"^EB\d{5}$"); // EB + 5 digits

        public static void ValidateConsumerNumberOrThrow(string consumerNumber)
        {
            if (!EbRegex.IsMatch(consumerNumber ?? ""))
                throw new System.FormatException("Invalid Consumer Number. Use format like EB00001.");
        }

        public static string ValidateUnitsConsumed(int units)
        {
            return (units < 0) ? "Given units is invalid" : null;
        }
    }
}
