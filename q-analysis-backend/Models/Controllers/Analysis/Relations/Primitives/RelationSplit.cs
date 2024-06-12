using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_math.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives
{
	public struct RelationSplit
	{
		public SplitKey Key { get; set; }
		public IRelation Relation { get; set; }
	}
}

