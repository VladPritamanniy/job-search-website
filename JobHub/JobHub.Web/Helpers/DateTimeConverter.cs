namespace JobHub.Web.Helpers
{
    public static class DateTimeConverter
    {
        public static string ToString(DateTime date)
        {
            TimeSpan timeDifference = DateTime.Now - date;
            if (timeDifference.TotalHours < 1)
            {
                return $"{(int)Math.Round(timeDifference.TotalMinutes)} хвилин тому";
            }
            else if (timeDifference.TotalDays < 1)
            {
                return $"{(int)Math.Round(timeDifference.TotalHours)} годин тому";
            }
            else if (timeDifference.TotalDays < 7)
            {
                return $"{(int)Math.Round(timeDifference.TotalDays)} днів тому";
            }
            else if (timeDifference.TotalDays < 30)
            {
                int weeks = (int)Math.Round((timeDifference.TotalDays / 7));
                return $"{weeks} {(weeks == 1 ? "неділя" : "неділі")} тому";
            }
            else
            {
                int months = (int)Math.Round((timeDifference.TotalDays / 30));
                return $"{months} {(months == 1 ? "місяць" : "місяці")} тому";
            }

        }
    }
}
