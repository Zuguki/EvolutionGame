using System;
using System.Globalization;

public static class TupleExtentions
{
    public static string ToCustomString(this (float, float) item) =>
        $"{Math.Round(item.Item1, 1)}/{Math.Round(item.Item2, 1)}";
}