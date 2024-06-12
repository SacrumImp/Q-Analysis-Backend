using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;
using System.Collections.Generic;

namespace q_analysis_backend.Providers.Primitives
{
	public struct QAnalysisSplitResult
    {
        public SplitKey Key { get; set; }
        public QVector Vector { get; set; }
        public IReadOnlyList<Eccentricity> Eccentricities { get; set; }
    }
}

