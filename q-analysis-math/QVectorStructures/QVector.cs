using System;
using System.Linq;

namespace q_analysis_math.QVectorStructures
{
    public class QVector
    {
        public QVectorElement[] Elements { get; set; } = new QVectorElement[0];

        public int Dimension
        {
            get
            {
                return Elements.Length - 1;
            }
        }

        public string VectorElements
        {
            get
            {
                var values = Elements
                    .OrderByDescending(elem => elem.ConnectionLevel)
                    .Select(elem => elem.Value);
                return $"({string.Join(",", values)})";
            }
        }

        public int[][][] ConnectivityComponentsIndexes
        {
            get
            {
                return Elements
                    .OrderByDescending(elem => elem.ConnectionLevel)
                    .Select(elem => elem.ConnectivityComponentsIndexes)
                    .ToArray();
            }
        }

        public QVector()
        {

        }

        public void Add(Simplex simplex)
        {
            if (simplex.Dimension >= Elements.Length)
            {
                var oldArray = Elements;
                Elements = new QVectorElement[simplex.Dimension + 1];
                for (int i = 0; i < simplex.Dimension + 1; i++)
                {
                    Elements[i] = new QVectorElement(i);
                }
                Array.Copy(oldArray, Elements, oldArray.Length);
            }
            for (int i = simplex.Dimension; i >= 0; i--)
            {
                Elements[i].Add(simplex);
            }

        }

        public int? GetMaxQForSimplex(int index)
        {
            return Elements
                 .OrderByDescending(elem => elem.ConnectionLevel)
                 .FirstOrDefault(elem => elem.QConnectedElements.Any(connectedElems => connectedElems.Any(elem => elem.Index == index) && connectedElems.Count > 1))
                 ?.ConnectionLevel;
        }
    }
}
