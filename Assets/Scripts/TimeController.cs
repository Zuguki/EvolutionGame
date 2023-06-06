public static class TimeController
{
    private static int daysCount = 1;

    public static int DaysCount
    {
        get => daysCount;
        set
        {
            if (value > 365)
                daysCount = 365;
            else if (value < 1)
                daysCount = 1;
            else
                daysCount = value;
        }
    }
    public static int MonthCount { get; set; } = 0;
    public static int YearsCount { get; set; } = 0;

    public static int CurrentDay { get; set; } = 0;
    public static int Month => CurrentDay % 365;
    public static int Year => Month % 12;

    public static int DaysLeft => IterationCount - CurrentDay;

    public static int IterationCount => DaysCount + MonthCount * 365 + YearsCount * 12 * 365;
}