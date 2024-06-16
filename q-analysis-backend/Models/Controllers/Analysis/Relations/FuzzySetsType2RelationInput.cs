using System.Collections.Generic;
using System.Linq;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives;
using q_analysis_math.Relations;
using q_analysis_math.Relations.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations
{
	public class FuzzySetsType2RelationInput: IRelationInput
	{

        public DomainInput Domain { get; }
        public TrapezoidInput<Segment> Value { get; }
        public double[] ClippingPoints { get; }
        public double MatchProportion { get; }

        public FuzzySetsType2RelationInput(DomainInput domain, TrapezoidInput<Segment> value, double[] clippingPoints, double matchProportion)
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
                    Relation = new FuzzySetsType2Relation(
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
                (Domain.LeftBoundary <= Value.LeftBottomPoint.LeftBoundary &&
                Value.LeftBottomPoint.LeftBoundary <= Value.LeftTopPoint.RightBoundary &&
                Value.LeftBottomPoint.LeftBoundary <= Value.LeftBottomPoint.RightBoundary &&
                Value.LeftBottomPoint.RightBoundary <= Value.LeftTopPoint.RightBoundary &&
                Value.LeftBottomPoint.LeftBoundary <= Value.LeftTopPoint.LeftBoundary &&
                Value.LeftTopPoint.LeftBoundary <= Value.LeftTopPoint.RightBoundary &&
                Value.LeftTopPoint.RightBoundary < Value.RightTopPoint.LeftBoundary &&
                Value.RightTopPoint.LeftBoundary <= Value.RightBottomPoint.RightBoundary &&
                Value.RightTopPoint.LeftBoundary <= Value.RightTopPoint.RightBoundary &&
                Value.RightTopPoint.RightBoundary <= Value.RightBottomPoint.RightBoundary &&
                Value.RightTopPoint.LeftBoundary <= Value.RightBottomPoint.LeftBoundary &&
                Value.RightBottomPoint.LeftBoundary <= Value.RightBottomPoint.RightBoundary &&
                Value.RightBottomPoint.RightBoundary <= Domain.RightBoundary));
        }
    }
}

