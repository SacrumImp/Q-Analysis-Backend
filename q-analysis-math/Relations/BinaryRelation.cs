namespace q_analysis_math.Relations
{
    public class BinaryRelation: IRelation
    {

        public bool Value { get; }

        public BinaryRelation(bool value)
        {
            Value = value;
        }

        public bool HasRelationValue()
        {
            return Value;
        }

        public bool IsConnected(IRelation relation)
        {
            return HasRelationValue() && relation.HasRelationValue();
        }

    }
}
