using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis.Relations;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_math;
using q_analysis_math.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Input
{
	public class SimplicesInput
	{

        public int EccentricityCalculationMethod { get; set; }
        public IReadOnlyList<SimplexInput> Simplices { get; set; }

        public SimplicesInput()
        {
        }

        public Dictionary<SplitKey, Simplex[]> GetStructures()
        {
            var structures = new Dictionary<SplitKey, Simplex[]>();
            for (int i = 0; i < Simplices.Count; i++)
            {
                var splitedSimplex = new Dictionary<SplitKey, Simplex>();
                foreach (IRelationInput relation in Simplices[i].Relations)
                {
                    var splitedRelation = relation.Split();
                    foreach (var split in splitedRelation)
                    {
                        if (splitedSimplex.ContainsKey(split.Key))
                        {
                            splitedSimplex[split.Key].AddRelation(split.Relation);
                        }
                        else
                        {
                            var newSplit = new Simplex(Simplices[i].Index, new List<IRelation> { split.Relation });
                            splitedSimplex.Add(split.Key, newSplit);
                        }
                    }
                }
                foreach (KeyValuePair<SplitKey, Simplex> split in splitedSimplex)
                {
                    if (!structures.ContainsKey(split.Key))
                    {
                        structures.Add(split.Key, new Simplex[Simplices.Count]);
                    }
                    structures[split.Key][i] = split.Value;
                }

            }
            return structures;
        }

    }
}
