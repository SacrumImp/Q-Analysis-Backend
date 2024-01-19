using System;
using q_analysis_math.Interfaces;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_math.EccentricityCalculator
{
    public class CastiEccentricityCalculator: IEccentricityCalculator
    {
        public CastiEccentricityCalculator()
        {
        }

        public Eccentricity CalculateEccentricities(Simplex simplex, QVector vector)
        {
            var largestQ = vector.GetMaxQForSimplex(simplex.Index);

            double? eccentricityValue;
            if (!largestQ.HasValue)
            {
                eccentricityValue = null;
            }
            else
            {
                eccentricityValue = (double)(simplex.Dimension - largestQ) / (double)(largestQ + 1);
            }

            return new Eccentricity(simplex.Index, eccentricityValue);
        }
    }
}
