using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Result
{
	public struct AnalysisResult
	{
		public List<AnalysisResultKey> Keys { get; set; } = new();
		public bool IsAggregated { get; set; } = false;
        public CalculationResult Result { get; set; }

        public AnalysisResult() { }
    }
}

