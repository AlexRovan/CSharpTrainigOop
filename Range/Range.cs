using System;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(range.To, To));
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From || From > range.To)
            {
                return new[] { new Range(range.From, range.To), new Range(From, To) };
            }

            return new[] { new Range(Math.Min(From, range.From), Math.Max(range.To, To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (range.To < From || range.From > To)
            {
                return new[] { new Range(From, To) };
            }

            if (range.From <= From && range.To >= To)
            {
                return new Range[] { };
            }

            if (range.From < From && range.To < To)
            {
                return new[] { new Range(range.To, To) };
            }

            if (From < range.From && To < range.To)
            {
                return new[] { new Range(From, range.From) };
            }

            return new[] { new Range(From, range.From), new Range(range.To, To) };
        }
    }
}