using System.Collections.Generic;
using System.Linq;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives;
using q_analysis_math.Relations;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations
{
	public class FuzzySetsType1RelationInput: IRelationInput
	{

        public DomainInput Domain { get; }
        public TrapezoidInput Value { get; }
        public double[] ClippingPoints { get; }
        public double MatchProportion { get; }

        public FuzzySetsType1RelationInput(DomainInput domain, TrapezoidInput value, double[] clippingPoints, double matchProportion)
        {
            Domain = domain;
            Value = value;
            ClippingPoints = clippingPoints;
            MatchProportion = matchProportion;
        }

        public RelationSplit[] Split()
        {
            return ClippingPoints.Select(point =>
            {
                return new RelationSplit()
                {
                    Key = new SplitKey()
                    {
                        Keys = new List<AnalysisResultKey>()
                                {
                                    new AnalysisResultKey()
                                    {
                                        Name="ClippingPoint",
                                        Value=point,
                                    }
                                },
                    },
                    Relation = new FuzzySetsType1Relation(
                        Domain.GetStruct(),
                        Value?.GetStruct(),
                        point,
                        MatchProportion)
                };
            }).ToArray();
        }

        public bool IsValid()
        {
            return ClippingPoints.All(point => point >= 0 && point <= 1) &&
                MatchProportion >= 0 && MatchProportion <= 100 && (
                Value == null ||
                (Domain.LeftBoundary <= Value.LeftBottomPoint &&
                Value.LeftBottomPoint <= Value.LeftTopPoint &&
                Value.LeftTopPoint <= Value.RightTopPoint &&
                Value.RightTopPoint <= Value.RightBottomPoint &&
                Value.RightBottomPoint <= Domain.RightBoundary)); ;
        }
    }
}

