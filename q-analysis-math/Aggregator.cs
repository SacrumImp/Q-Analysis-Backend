using System.Collections.Generic;
using System.Linq;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_math
{
	public static class Aggregator
	{
		public static QAnalysisAggregateResult AggregateResults(List<QAnalysisResult> results)
		{
            var aggregatedValue = new QAnalysisAggregateResult();
            if (results.Count == 0) return aggregatedValue;

            var vectors = results.Select(result => result.Vector).ToList();
            var maxDimension = vectors.Max(vector => vector.Dimension);
			aggregatedValue.Dimension = maxDimension;
            aggregatedValue.Vector = AggregateQVector(maxDimension, vectors);

			var eccentricities = results.Select(result => result.Eccentricities).ToList();
			aggregatedValue.Eccentricities = AggregateEccentricities(eccentricities);
			return aggregatedValue;
        }

		private static string AggregateQVector(int dimension, List<QVector> vectors)
		{
			var vectorElements = new double[dimension];
            for (int i = 0; i < dimension; i++)
			{
				vectorElements[i] = vectors.Average(vector => vector.VectorElements[i]);
			}
			return $"({string.Join(",", vectorElements)})";
		}

        private static IReadOnlyList<Eccentricity> AggregateEccentricities(List<IReadOnlyList<Eccentricity>> eccentricities)
        {
			var aggregatedEccentricities = new List<Eccentricity>();
			var eccentricitiesCount = eccentricities.First().Count;
            for (int i = 0; i < eccentricitiesCount; i++)
			{
				var isTotallyDisconected = eccentricities.Any(eccentricity => eccentricity[i].IsTotallyDisconnected);
				if (isTotallyDisconected)
				{
					aggregatedEccentricities.Add(new Eccentricity(i, null));
					continue;
                }
                aggregatedEccentricities.Add(new Eccentricity(i, eccentricities.Average(eccentricity => eccentricity[i].Value)));
            }
			return aggregatedEccentricities;
        }
    }
}

