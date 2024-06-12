using System;
using q_analysis_math.Relations.Primitives;

namespace q_analysis_math.Relations
{
	public class FuzzySetsType1Relation: IRelation
	{

        public Domain Domain { get; }
        public Trapezoid? Value { get; }
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

        private double SegmentRigthBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.RightBottomPoint == Value.Value.RightTopPoint) return Value.Value.RightBottomPoint;
                return ClippingPoint * Math.Abs(Value.Value.RightBottomPoint - Value.Value.RightTopPoint)
                    + Math.Min(Value.Value.RightBottomPoint, Value.Value.RightTopPoint);
            }
        }

        public FuzzySetsType1Relation(Domain domain, Trapezoid? value, double clippingPoints, double matchProportion)
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
                var commonPart = Math.Min(SegmentRigthBoundary, fuzzyType1relation.SegmentRigthBoundary) - Math.Max(SegmentLeftBoundary, fuzzyType1relation.SegmentLeftBoundary);
                var maxSegment = Math.Max(SegmentRigthBoundary - SegmentLeftBoundary, fuzzyType1relation.SegmentRigthBoundary - fuzzyType1relation.SegmentLeftBoundary);
                return (maxSegment / commonPart) * 100 > MatchProportion;
            }
            else
            {
                throw new InvalidOperationException("Incompatible relation types.");
            }
        }

    }
}

