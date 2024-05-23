using System;

namespace q_analysis_math.Relations
{
    public interface IRelation
    {
        public bool HasRelationValue();
        public bool IsConnected(IRelation relation);
        public bool IsValid();

    }
}
