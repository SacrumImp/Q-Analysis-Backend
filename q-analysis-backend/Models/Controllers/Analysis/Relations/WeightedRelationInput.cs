using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_math.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations
{
	public class WeightedRelationInput: IRelationInput
	{
        public double SliceValue { get; }
        public double Value { get; }

        public WeightedRelationInput(double value, double sliceValue)
        {
            Value = value;
            SliceValue = sliceValue;
        }

        public RelationSplit[] Split()
        {
            return new RelationSplit[]
            {
                new RelationSplit()
                {
                    Key = new SplitKey() {
                        Keys = new List<AnalysisResultKey>()
                                {
                                    new AnalysisResultKey()
                                    {
                                        Name="SliceValue",
                                        Value=SliceValue
                                    }
                                }
                    },
                    Relation = new WeightedRelation(Value, SliceValue)
                }
            };
        }

        public bool IsValid()
        {
            return Value >= 0;
        }
    }
}

