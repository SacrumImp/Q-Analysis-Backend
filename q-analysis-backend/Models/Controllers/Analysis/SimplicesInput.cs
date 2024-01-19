using System;
using System.Collections.Generic;
using q_analysis_math;
using q_analysis_math.Interfaces;

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
