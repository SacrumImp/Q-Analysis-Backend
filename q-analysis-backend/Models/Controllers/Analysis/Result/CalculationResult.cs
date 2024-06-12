using System.Collections.Generic;
using q_analysis_math.Structures;

namespace q_analysis_backend.Models.Controllers.Analysis.Result
{
	public struct CalculationResult
	{
        public int Dimension { get; set; }
		public string VectorElements { get; set; }
		public IReadOnlyList<Eccentricity> Eccentricities { get; set; }

        public CalculationResult() { }
	}
}

