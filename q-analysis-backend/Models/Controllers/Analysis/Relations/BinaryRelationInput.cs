using System.Collections.Generic;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_math.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations
{
    public class BinaryRelationInput: IRelationInput
    {
        public bool Value { get; }

        public BinaryRelationInput(bool value)
        {
            Value = value;
        }

        public RelationSplit[] Split()
        {
            return new RelationSplit[]
            {
                new RelationSplit()
                {
                    Key = new SplitKey() {
                        Keys = new List<AnalysisResultKey>()
                    },
                    Relation = new BinaryRelation(Value)
                }
            };
                
        }

        public bool IsValid()
        {
            return true;
        }
    }
}

