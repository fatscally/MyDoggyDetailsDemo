using System;

public class AgeCalculator
{
    /// <summary>
    /// Calculates detailed age breakdown from date of birth to today.
    /// Returns years, months, weeks, days (remaining after years/months).
    /// </summary>
    public static AgeResult CalculateAge(DateTime dateOfBirth)
    {
        return CalculateAge(dateOfBirth, DateTime.Today);
    }

    /// <summary>
    /// Calculates detailed age breakdown from date of birth to a specific date.
    /// </summary>
    public static AgeResult CalculateAge(DateTime dateOfBirth, DateTime referenceDate)
    {
        if (dateOfBirth > referenceDate)
        {
            throw new ArgumentException("Date of birth cannot be in the future.");
        }

        // Make sure we work with dates only (strip time)
        dateOfBirth = dateOfBirth.Date;
        referenceDate = referenceDate.Date;

        int years = 0;
        int months = 0;
        int days = 0;

        // First calculate full years and months
        DateTime current = dateOfBirth;

        // Count full years
        while (current.AddYears(years + 1) <= referenceDate)
        {
            years++;
        }

        // Move to the date after full years
        current = dateOfBirth.AddYears(years);

        // Count full months
        while (current.AddMonths(months + 1) <= referenceDate)
        {
            months++;
        }

        // Move to the date after full years + months
        current = dateOfBirth.AddYears(years).AddMonths(months);

        // Remaining days
        days = (referenceDate - current).Days;

        // Now calculate total weeks + remaining days (alternative view)
        int totalDays = (referenceDate - dateOfBirth).Days;
        int weeks = totalDays / 7;
        int remainingDays = totalDays % 7;

        return new AgeResult
        {
            Years = years,
            Months = months,
            Days = days,                    // days after full years+months
            TotalWeeks = weeks,
            TotalWeeksRemainingDays = remainingDays,
            TotalDays = totalDays,
            BirthDate = dateOfBirth,
            ReferenceDate = referenceDate
        };
    }
}

public class AgeResult
{
    public int Years { get; set; }
    public int Months { get; set; }
    public int Days { get; set; }                    // remaining days after years+months
    public int TotalWeeks { get; set; }
    public int TotalWeeksRemainingDays { get; set; }
    public int TotalDays { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime ReferenceDate { get; set; }

    public override string ToString()
    {
        return $"{Years} year{(Years == 1 ? "" : "s")}, " +
               $"{Months} month{(Months == 1 ? "" : "s")}, " +
               $"{Days} day{(Days == 1 ? "" : "s")}\n" +
               $"or {TotalWeeks} week{(TotalWeeks == 1 ? "" : "s")} " +
               $"and {TotalWeeksRemainingDays} day{(TotalWeeksRemainingDays == 1 ? "" : "s")}\n" +
               $"(total {TotalDays} days)";
    }
}