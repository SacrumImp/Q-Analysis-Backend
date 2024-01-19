using System;
using q_analysis_math.Interfaces;


namespace q_analysis_math
{
    public class WeightedRelation: IRelation
    {

        public int SliceValue { get; }
        public int Value { get; }

        public WeightedRelation(int value, int sliceValue)
        {
            Value = value;
            SliceValue = sliceValue;
        }

        public bool GetRelationValue()
        {
            return Value > SliceValue;
        }

        public bool IsConnected(IRelation relation)
        {
            return GetRelationValue() && relation.GetRelationValue();
        }
    }
}
