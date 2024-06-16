using System;
using q_analysis_math.Relations.Primitives;

namespace q_analysis_math.Relations
{
	public class FuzzySetsType1Relation: IRelation
	{

        public Domain Domain { get; }
        public Trapezoid<double>? Value { get; }
        public double ClippingPoint { get; }
        public double MatchProportion { get; }

        private double SegmentLeftBoundary {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.LeftBottomPoint == Value.Value.LeftTopPoint) return Value.Value.LeftBottomPoint;
                return ClippingPoint * Math.Abs(Value.Value.LeftTopPoint - Value.Value.LeftBottomPoint)
                    + Math.Min(Value.Value.LeftTopPoint, Value.Value.LeftBottomPoint);
            }
        }

        private double SegmentRightBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.RightBottomPoint == Value.Value.RightTopPoint) return Value.Value.RightBottomPoint;
                return ClippingPoint * Math.Abs(Value.Value.RightBottomPoint - Value.Value.RightTopPoint)
                    + Math.Min(Value.Value.RightBottomPoint, Value.Value.RightTopPoint);
            }
        }

        public FuzzySetsType1Relation(Domain domain, Trapezoid<double>? value, double clippingPoints, double matchProportion)
		{
            Domain = domain;
            Value = value;
            ClippingPoint = clippingPoints;
            MatchProportion = matchProportion;
        }

        public bool HasRelationValue()
        {
            return Value.HasValue;
        }

        public bool IsConnected(IRelation relation)
        {
            if (relation is FuzzySetsType1Relation fuzzyType1relation)
            {
                if (!HasRelationValue() || !fuzzyType1relation.HasRelationValue()) return false;
                var commonPart = Math.Min(SegmentRightBoundary, fuzzyType1relation.SegmentRightBoundary) - Math.Max(SegmentLeftBoundary, fuzzyType1relation.SegmentLeftBoundary);
                var maxSegment = Math.Max(SegmentRightBoundary - SegmentLeftBoundary, fuzzyType1relation.SegmentRightBoundary - fuzzyType1relation.SegmentLeftBoundary);
                return (maxSegment / commonPart) * 100 > MatchProportion;
            }
            else
            {
                throw new InvalidOperationException("Incompatible relation types.");
            }
        }

    }
}

