using System.Collections.Generic;

namespace q_analysis_math.Structures
{
    public struct QAnalysisAggregateResult
    {
        public int Dimension { get; set; }
        public string Vector { get; set; }
        public IReadOnlyList<Eccentricity> Eccentricities { get; set; }
    }
}

