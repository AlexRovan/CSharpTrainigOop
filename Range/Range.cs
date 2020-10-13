using System;
using System.Collections.Generic;
using System.Text;

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
            return number > From && number < To;
        }

        public Range GetRangeIntersection(double From, double To)
        {
            if (this.To <= From || this.From >= To)
            {
                return null;
            }

            if (this.From < From && this.To < To)
            {
                return new Range(From, this.To);
            }

            if (this.From > From && this.To > To)
            {
                return new Range(this.From, To);
            }

            if (this.From > From && this.To < To)
            {
                return new Range(this.From, this.To);
            }

            return new Range(From, To);
        }

        public Range[] GetRangeSum(double From, double To)
        {

            if (this.From <= From && this.To >= From)
            {
                if (this.To <= To)
                {
                    return new[] { new Range(this.From, To) };
                }

                return new[] { new Range(this.From, this.To) };
            }

            if (this.From >= From && To >= this.From)
            {
                if (To <= this.To)
                {
                    return new[] { new Range(From, this.To) };
                }

                return new[] { new Range(From, To) };
            }

            return new[] { new Range(this.From, this.To), new Range(From, To) };
        }

        public Range[] GetRangeDifference(double From, double To)
        {
            if (this.From == From && this.To == To)
            {
                return null;
            }

            if (this.From <= From && this.To >= From)
            {
                if (this.To <= To)
                {
                    return new[] { new Range(this.From, From) };
                }

                return new[] { new Range(this.From, From), new Range(To, this.To) };
            }

            if (this.From >= From && To >= this.From)
            {
                if (To <= this.To)
                {
                    return new[] { new Range(To, this.To) };
                }

                return new[] { new Range(From, this.From), new Range(this.To, To) };
            }

            return new[] { new Range(this.From, this.To) };
        }
    }
}
