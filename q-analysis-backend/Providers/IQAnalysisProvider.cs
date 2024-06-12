using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis.Input.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_backend.Providers.Primitives;
using q_analysis_math;

namespace q_analysis_backend.Providers
{
	public interface IQAnalysisProvider
	{
        public QAnalysisSplitResult PerformQCalculations(SplitKey key, Simplex[] simplices, EccentricityCalculationMethod method);

        public AnalysisResult AggregateResults(List<QAnalysisSplitResult> qAnalysisResults);
    }
}

