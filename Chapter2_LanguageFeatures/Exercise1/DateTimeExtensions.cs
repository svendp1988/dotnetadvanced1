namespace Exercise1
{
    public static class DateTimeExtensions
    {
        public static string ToCentury(this DateTime dateTime)
        {
            var year = dateTime.Year;
            return ((int)(year / 100) + ((year % 100 == 0) ? 0 : 1)).ToString();
        }
    }
}
