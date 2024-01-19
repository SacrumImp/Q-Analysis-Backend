using System;
using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis;
using q_analysis_math;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;

namespace q_analysis_backend.Providers
{
	public interface IQAnalysisProvider
	{
        public QVector GetQVector(Simplex[] simplexes);

        public IReadOnlyList<Eccentricity> GetEccentricities(Simplex[] simplices, QVector vector, EccentricityCalculationMethod method);
    }
}

