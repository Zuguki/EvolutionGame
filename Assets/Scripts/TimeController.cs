public static class TimeController
{
    public static int DaysCount { get; set; } = 0;
    public static int MonthCount { get; set; } = 0;
    public static int YearsCount { get; set; } = 0;

    public static int CurrentDay { get; set; } = 0;
    public static int Month => CurrentDay % 365;
    public static int Year => Month % 12;

    public static int DaysLeft => IterationCount - CurrentDay;

    public static int IterationCount => DaysCount + MonthCount * 365 + YearsCount * 12 * 365;
}