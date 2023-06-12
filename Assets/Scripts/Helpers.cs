using System;
using System.Globalization;

public static class Helpers
{
    public static string ToCustomString(this (float, float) item) =>
        $"{Math.Round(item.Item1, 1)}/{Math.Round(item.Item2, 1)}";

    public static float? ToFloatDef(this string str, float? def = null)
    {
        var split = str.Split(' ');
        if (split.Length >= 1)
            return float.TryParse(split[0], out var value) ? value : def;
        return def;
    }

    public static int? ToIntDef(this string str, int? def = null) =>
        int.TryParse(str, out var value) ? value : def;
    
    public static long? ToLongDef(this string str, long? def = null) =>
        long.TryParse(str, out var value) ? value : def;
}