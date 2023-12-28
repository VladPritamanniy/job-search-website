namespace JobHub.Web.Helpers
{
    public static class DateTimeConverterHelper
    {
        public static string ToString(DateTime date)
        {
            TimeSpan timeDifference = DateTime.Now - date;

            if (timeDifference.TotalMinutes < 1)
            {
                return "Щойно";
            }
            else if (timeDifference.TotalHours < 1)
            {
                int minutesAgo = (int)Math.Round(timeDifference.TotalMinutes);
                return $"{minutesAgo} {GetCorrectDeclension(minutesAgo, "хвилин", "хвилина", "хвилини")} тому";
            }
            else if (timeDifference.TotalDays < 1)
            {
                int hoursAgo = (int)Math.Round(timeDifference.TotalHours);
                return $"{hoursAgo} {GetCorrectDeclension(hoursAgo, "годин", "година", "години")} тому";
            }
            else if (timeDifference.TotalDays < 7)
            {
                int daysAgo = (int)Math.Round(timeDifference.TotalDays);
                return $"{daysAgo} {GetCorrectDeclension(daysAgo, "днів", "день", "дні")} тому";
            }
            else if (timeDifference.TotalDays < 30)
            {
                int weeks = (int)Math.Round(timeDifference.TotalDays / 7);
                return $"{weeks} {GetCorrectDeclension(weeks, "неділь", "неділя", "неділі")} тому";
            }
            else
            {
                int months = (int)Math.Round(timeDifference.TotalDays / 30);
                return $"{months} {GetCorrectDeclension(months, "місяців", "місяць", "місяці")} тому";
            }
        }

        private static string GetCorrectDeclension(int number, string form1, string form2, string form3)
        {
            number = Math.Abs(number) % 100;
            int lastDigit = number % 10;

            if (number > 10 && number < 20)
            {
                return form1;
            }

            if (lastDigit > 1 && lastDigit < 5)
            {
                return form3;
            }

            if (lastDigit == 1)
            {
                return form2;
            }

            return form1;
        }
    }
}
