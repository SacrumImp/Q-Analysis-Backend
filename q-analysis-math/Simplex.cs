using q_analysis_math.Relations;

namespace q_analysis_math
{
    public class Simplex
    {
        public int Index { get; }

        public IRelation[] Relations { get; }

        public int Dimension
        {
            get
            {
                var dimension = -1;
                foreach (IRelation relation in Relations)
                {
                    dimension += relation.HasRelationValue() ? 1 : 0;
                }
                return dimension;
            }
        }

        public Simplex(int index, IRelation[] relations)
        {
            Index = index;
            Relations = relations;
        }
    }
}
