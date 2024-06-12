namespace q_analysis_math.Relations
{
    public class WeightedRelation: IRelation
    {

        public double SliceValue { get; }
        public double Value { get; }

        public WeightedRelation(double value, double sliceValue)
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
