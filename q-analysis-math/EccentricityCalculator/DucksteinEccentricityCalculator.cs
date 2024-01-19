

using System.Linq;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_math.EccentricityCalculator
{
	public class DucksteinEccentricityCalculator: IEccentricityCalculator
	{
		public DucksteinEccentricityCalculator()
		{
		}

        public Eccentricity CalculateEccentricities(Simplex simplex, QVector vector)
        {
            var qMax = vector.Dimension;

            double summ = 0;
            foreach (QVectorElement vectorElement in vector.Elements)
            {
                var sigma = vectorElement.QConnectedElements.FirstOrDefault(elem => elem.Any(elemSimplex => elemSimplex.Index == simplex.Index));
                if (sigma != null)
                {
                    summ += (double)vectorElement.ConnectionLevel / (double)sigma.Count;
                }
            }

            double eccentricityValue = 2 * summ / (qMax * (qMax + 1));

            return new Eccentricity(simplex.Index, eccentricityValue);
        }
    }
}

