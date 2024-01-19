using System;
namespace q_analysis_math.Structures
{
    public struct Eccentricity
    {

        public int SimplexIndex { get; }

        public double? Value { get; }

        public bool IsTotallyDisconnected
        {
            get
            {
                return !Value.HasValue;
            }
        }

        public Eccentricity(int index, double? value)
        {
            SimplexIndex = index;
            Value = value;
        }

    }
}
