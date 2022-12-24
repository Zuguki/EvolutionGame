public static class TimeController
{
    public static int DaysCount { get; set; } = 0;
    public static int MonthCount { get; set; } = 0;
    public static int YearsCount { get; set; } = 0;

    public static int Day { get; set; } = 0;
    public static int Month => Day % 365;
    public static int Year => Month % 12;

    public static int GetDaysLeft => DaysCount + MonthCount * 365 + YearsCount * 12 * 365 - Day;
}