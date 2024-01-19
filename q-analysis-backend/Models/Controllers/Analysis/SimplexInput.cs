using System;
using q_analysis_math;
using q_analysis_math.Interfaces;

namespace q_analysis_backend.Models.Controllers.Analysis
{
	public class SimplexInput
	{
        public int Index { get; set; }

        public IRelation[] Relations { get; set; }

        public SimplexInput()
        {

        }

        public Simplex GetSimplex
        {
            get
            {
                return new Simplex(Index, Relations);
            }
        }
	}
}

