using q_analysis_math.QVectorStructures;


namespace q_analysis_math
{
    public static class QCalculator
    {

        public static QVector PrepareQVector(Simplex[] simplices)
        {
            var qVector = new QVector();
            for (int i = 0; i < simplices.Length; i++)
            {
                qVector.Add(simplices[i]);
            }
            return qVector;
        }

    }
}
