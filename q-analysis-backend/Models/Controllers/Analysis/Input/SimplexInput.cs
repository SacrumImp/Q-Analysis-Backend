using q_analysis_backend.Models.Controllers.Analysis.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Input
{
	public class SimplexInput
	{
        public int Index { get; set; }

        public IRelationInput[] Relations { get; set; }

        public SimplexInput()
        {

        }
	}
}

