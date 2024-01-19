using System.Collections.Generic;
using q_analysis_math.Structures;

namespace q_analysis_backend.Models.Controllers.Analysis
{
	public class CalculationResult
	{
        public int Dimension { get; set; }
		public string VectorElements { get; set; }
		public IReadOnlyList<Eccentricity> eccentricities { get; set; }

        public CalculationResult()
		{
		}
	}
}

