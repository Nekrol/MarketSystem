namespace ProductSite
{
    public static  class Utils
    {
        public static int RoundUpRating(float? rate)
        {
            if (rate != null)
            {
                return Convert.ToInt32(Math.Round(Convert.ToDecimal(rate), 1));
            }
            return 0;
        }
    }
}
