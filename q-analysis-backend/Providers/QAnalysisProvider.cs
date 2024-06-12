using System.Collections.Generic;
using System.Linq;
using q_analysis_backend.Models.Controllers.Analysis.Input.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_backend.Providers.Primitives;
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

        public AnalysisResult AggregateResults(List<QAnalysisSplitResult> results)
        {
			var adaptedResults = results.Select(result =>
			{
				return new QAnalysisResult()
				{
					Vector = result.Vector,
					Eccentricities = result.Eccentricities,
				};
			}).ToList();
			var aggregatedResult = Aggregator.AggregateResults(adaptedResults);
			return new AnalysisResult()
			{
				IsAggregated = true,
				Result = new CalculationResult()
				{
					Dimension = aggregatedResult.Vector.Dimension,
					VectorElements = aggregatedResult.Vector.VectorElements,
					Eccentricities = aggregatedResult.Eccentricities,
				}
			};
        }

        public QAnalysisSplitResult PerformQCalculations(SplitKey key, Simplex[] simplices, EccentricityCalculationMethod method)
        {
            var vector = GetQVector(simplices);
            var eccentricities = GetEccentricities(simplices, vector, method);
			return new QAnalysisSplitResult
            {
				Key = key,
				Vector = vector,
				Eccentricities = eccentricities,
			};
        }

        private IReadOnlyList<Eccentricity> GetEccentricities(Simplex[] simplices, QVector vector, EccentricityCalculationMethod method)
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

        private QVector GetQVector(Simplex[] simplices)
		{
			var vector = QCalculator.PrepareQVector(simplices);
			return vector;
		}

    }
}

