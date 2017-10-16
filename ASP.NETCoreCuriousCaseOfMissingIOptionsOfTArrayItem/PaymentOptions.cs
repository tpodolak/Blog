using System.Collections.Generic;

namespace ASP.NETCoreCuriousCaseOfMissingIOptionsOfTArrayItem
{
    public class PaymentMethod
    {
        public string Name { get; set; }

        public List<string> ExcludedCurrencies { get; set; }
    }
}