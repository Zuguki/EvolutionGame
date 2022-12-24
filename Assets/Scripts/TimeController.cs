public class TimeController
{
    public int DaysCount {get; set; }
    public int MonthCount { get; set; }
    public int YearsCount { get; set; }

    public int Day { get; set; }
    public int Month => Day % 365;
    public int Year => Month % 12;

    public int GetDaysLeft => DaysCount + MonthCount * 365 + YearsCount * 12 * 365 - Day;
}