using System;
using q_analysis_math.Interfaces;


namespace q_analysis_math
{
    public class BinaryRelation: IRelation
    {

        public bool Value { get; }

        public BinaryRelation(bool value)
        {
            Value = value;
        }

        public bool GetRelationValue()
        {
            return Value;
        }

        public bool IsConnected(IRelation relation)
        {
            return GetRelationValue() && relation.GetRelationValue();
        }
    }
}
