using q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations
{
	public interface IRelationInput
	{
        public RelationSplit[] Split();
        public bool IsValid();
    }
}

