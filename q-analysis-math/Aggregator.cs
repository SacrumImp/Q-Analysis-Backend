using System.Collections.Generic;
using System.Linq;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_math
{
	public static class Aggregator
	{
		public static QAnalysisResult AggregateResults(List<QAnalysisResult> results)
		{
            var aggregatedValue = new QAnalysisResult();
            if (results.Count == 0) return aggregatedValue;

            var vectors = results.Select(result => result.Vector).ToList();
			aggregatedValue.Vector = AggregateQVector(vectors);
			var eccentricities = results.Select(result => result.Eccentricities).ToList();
			aggregatedValue.Eccentricities = AggregateEccentricities(eccentricities);
			return aggregatedValue;

        }

		private static QVector AggregateQVector(List<QVector> vectors)
		{
			return vectors.Last();
		}

        private static IReadOnlyList<Eccentricity> AggregateEccentricities(List<IReadOnlyList<Eccentricity>> eccentricities)
        {
			return eccentricities.Last();
        }
    }
}

