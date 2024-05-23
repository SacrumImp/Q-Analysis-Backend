using System;
using q_analysis_math.Relations.Primitives;

namespace q_analysis_math.Relations
{
	public class FuzzySetsType1Relation: IRelation
	{

        public Domain Domain { get; }
        public Trapezoid? Trapezoid { get; }
        public double ClippingPoint { get; }
        public double MatchProportion { get; }

        private double SegmentLeftBoundary {
            get
            {
                if (!Trapezoid.HasValue) return 0;
                if (Trapezoid.Value.LeftBottomPoint == Trapezoid.Value.LeftTopPoint) return Trapezoid.Value.LeftBottomPoint;
                return ClippingPoint * Math.Abs(Trapezoid.Value.LeftTopPoint - Trapezoid.Value.LeftBottomPoint)
                    + Math.Min(Trapezoid.Value.LeftTopPoint, Trapezoid.Value.LeftBottomPoint);
            }
        }

        private double SegmentRigthBoundary
        {
            get
            {
                if (!Trapezoid.HasValue) return 0;
                if (Trapezoid.Value.RightBottomPoint == Trapezoid.Value.RightTopPoint) return Trapezoid.Value.RightBottomPoint;
                return ClippingPoint * Math.Abs(Trapezoid.Value.RightBottomPoint - Trapezoid.Value.RightTopPoint)
                    + Math.Min(Trapezoid.Value.RightBottomPoint, Trapezoid.Value.RightTopPoint);
            }
        }

        public FuzzySetsType1Relation(Domain domain, Trapezoid trapezoid, double clippingPoints)
		{
            Domain = domain;
            Trapezoid = trapezoid;
            ClippingPoint = clippingPoints;
		}

        public bool HasRelationValue()
        {
            return Trapezoid.HasValue;
        }

        public bool IsConnected(IRelation relation)
        {
            if (relation is FuzzySetsType1Relation fuzzyType1relation)
            {
                if (!HasRelationValue() || !fuzzyType1relation.HasRelationValue()) return false;
                var commonPart = Math.Min(SegmentRigthBoundary, fuzzyType1relation.SegmentRigthBoundary) - Math.Max(SegmentLeftBoundary, fuzzyType1relation.SegmentLeftBoundary);
                var maxSegment = Math.Max(SegmentRigthBoundary - SegmentLeftBoundary, fuzzyType1relation.SegmentRigthBoundary - fuzzyType1relation.SegmentLeftBoundary);
                return (maxSegment / commonPart) > MatchProportion;
            }
            else
            {
                throw new InvalidOperationException("Incompatible relation types.");
            }
        }

        public bool IsValid()
        {
            if (!HasRelationValue()) return true;
            return ClippingPoint >= 0 && ClippingPoint <= 1 &&
                MatchProportion >= 0 && MatchProportion <= 1 &&
                Domain.LeftBoundary <= Trapezoid.Value.LeftBottomPoint &&
                Trapezoid.Value.LeftBottomPoint <= Trapezoid.Value.LeftTopPoint &&
                Trapezoid.Value.LeftTopPoint <= Trapezoid.Value.RightTopPoint &&
                Trapezoid.Value.RightTopPoint <= Trapezoid.Value.RightBottomPoint &&
                Trapezoid.Value.RightBottomPoint <= Domain.RightBoundary;
        }

    }
}

