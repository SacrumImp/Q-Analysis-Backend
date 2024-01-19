using System;
using System.Collections.Generic;
using q_analysis_math.QVectorStructures;
using q_analysis_math.Structures;


namespace q_analysis_math.EccentricityCalculator
{
    public interface IEccentricityCalculator
    {

        public Eccentricity CalculateEccentricities(Simplex simplex, QVector vector);

    }
}
