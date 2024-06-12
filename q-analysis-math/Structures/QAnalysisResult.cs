using System.Collections.Generic;
using q_analysis_math.QVectorStructures;

namespace q_analysis_math.Structures
{
	public struct QAnalysisResult
	{
		public QVector Vector { get; set; }
        public IReadOnlyList<Eccentricity> Eccentricities { get; set; }
    }
}

