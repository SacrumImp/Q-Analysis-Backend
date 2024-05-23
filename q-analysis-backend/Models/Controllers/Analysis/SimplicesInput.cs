using System.Collections.Generic;

namespace q_analysis_backend.Models.Controllers.Analysis
{
	public class SimplicesInput
	{

        public int EccentricityCalculationMethod { get; set; }
        public IReadOnlyList<SimplexInput> Simplices { get; set; }

        public SimplicesInput()
        {
        }

    }
}
