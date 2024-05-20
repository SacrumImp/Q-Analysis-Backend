﻿using q_analysis_math.Interfaces;


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

        public bool HasRelationValue()
        {
            return Value > SliceValue;
        }

        public bool IsConnected(IRelation relation)
        {
            return HasRelationValue() && relation.HasRelationValue();
        }
    }
}
