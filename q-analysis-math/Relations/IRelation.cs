using System;

namespace q_analysis_math.Interfaces
{
    public interface IRelation
    {
        public bool HasRelationValue();
        public bool IsConnected(IRelation relation);

    }
}
