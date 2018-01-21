using DNTPersianUtils.Core;

namespace Amlak.Core.SSOT
{
    public static class PriceExtensions
    {
        public static string TomansThousand(this decimal _price)
        {
            var priceToman = (_price / 10);
            var priceString = string.Format("{0:n0}", priceToman);
            var priceStringPersian = priceString.ToPersianNumbers();

            return priceStringPersian;
        }

        public static string TomansThousand(this int _price)
        {
            var priceToman = (_price / 10);
            var priceString = string.Format("{0:n0}", priceToman);
            var priceStringPersian = priceString.ToPersianNumbers();

            return priceStringPersian;
        }


        public static string TomansThousand(this long _price)
        {
            var priceToman = (_price / 10);
            var priceString = string.Format("{0:n0}", priceToman);
            var priceStringPersian = priceString.ToPersianNumbers();

            return priceStringPersian;
        }
    }
}
