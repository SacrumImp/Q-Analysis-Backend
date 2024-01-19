using System;

namespace q_analysis_math.Interfaces
{
    public interface IRelation
    {
        // Определение значения связи
        public bool GetRelationValue();
        // Определение наличия связи
        public bool IsConnected(IRelation relation);

    }
}
