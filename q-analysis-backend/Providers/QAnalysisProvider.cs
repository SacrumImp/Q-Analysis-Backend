using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis;
using q_analysis_math;
using q_analysis_math.EccentricityCalculator;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_backend.Providers
{
	public class QAnalysisProvider: IQAnalysisProvider
    {
		public QAnalysisProvider()
		{
		}

        public IReadOnlyList<Eccentricity> GetEccentricities(Simplex[] simplices, QVector vector, EccentricityCalculationMethod method)
        {
			IEccentricityCalculator calculator;
            switch(method)
			{
				case EccentricityCalculationMethod.Casti:
					calculator = new CastiEccentricityCalculator();
					break;
				case EccentricityCalculationMethod.Duckstein:
					calculator = new DucksteinEccentricityCalculator();
					break;
                default:
                    calculator = new CastiEccentricityCalculator();
                    break;

            }
			var eccentricities = new List<Eccentricity>();
			foreach(Simplex simplex in simplices)
			{
				var eccentricity = calculator.CalculateEccentricities(simplex, vector);
				eccentricities.Add(eccentricity);
			}
			return eccentricities;

        }

        public QVector GetQVector(Simplex[] simplices)
		{
			var vector = QCalculator.PrepareQVector(simplices);
			return vector;
		}
    }
}

