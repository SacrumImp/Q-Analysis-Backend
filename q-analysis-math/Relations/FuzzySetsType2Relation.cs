using System;
using q_analysis_math.Relations.Primitives;

namespace q_analysis_math.Relations
{
	public class FuzzySetsType2Relation: IRelation
	{

        public Domain Domain { get; }
        public Trapezoid<Segment>? Value { get; }
        public double ClippingPoint { get; }
        public double MatchProportion { get; }

        private double InnerSegmentLeftBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.LeftBottomPoint.RightBoundary == Value.Value.LeftTopPoint.RightBoundary) return Value.Value.LeftBottomPoint.RightBoundary;
                return ClippingPoint * Math.Abs(Value.Value.LeftTopPoint.RightBoundary - Value.Value.LeftBottomPoint.RightBoundary)
                    + Math.Min(Value.Value.LeftTopPoint.RightBoundary, Value.Value.LeftBottomPoint.RightBoundary);
            }
        }

        private double InnerSegmentRightBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.RightBottomPoint.LeftBoundary == Value.Value.RightTopPoint.LeftBoundary) return Value.Value.RightBottomPoint.LeftBoundary;
                return ClippingPoint * Math.Abs(Value.Value.RightBottomPoint.LeftBoundary - Value.Value.RightTopPoint.LeftBoundary)
                    + Math.Min(Value.Value.RightBottomPoint.LeftBoundary, Value.Value.RightTopPoint.LeftBoundary);
            }
        }

        private double OuterSegmentLeftBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.LeftBottomPoint.LeftBoundary == Value.Value.LeftTopPoint.LeftBoundary) return Value.Value.LeftBottomPoint.LeftBoundary;
                return ClippingPoint * Math.Abs(Value.Value.LeftTopPoint.LeftBoundary - Value.Value.LeftBottomPoint.LeftBoundary)
                    + Math.Min(Value.Value.LeftTopPoint.LeftBoundary, Value.Value.LeftBottomPoint.LeftBoundary);
            }
        }

        private double OuterSegmentRightBoundary
        {
            get
            {
                if (!Value.HasValue) return 0;
                if (Value.Value.RightBottomPoint.RightBoundary == Value.Value.RightTopPoint.RightBoundary) return Value.Value.RightBottomPoint.RightBoundary;
                return ClippingPoint * Math.Abs(Value.Value.RightBottomPoint.RightBoundary - Value.Value.RightTopPoint.RightBoundary)
                    + Math.Min(Value.Value.RightBottomPoint.RightBoundary, Value.Value.RightTopPoint.RightBoundary);
            }
        }

        public FuzzySetsType2Relation(Domain domain, Trapezoid<Segment>? value, double clippingPoints, double matchProportion)
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
            if (relation is FuzzySetsType2Relation fuzzyType2relation)
            {
                if (!HasRelationValue() || !fuzzyType2relation.HasRelationValue()) return false;
                var commonPart = Math.Min(InnerSegmentRightBoundary, fuzzyType2relation.InnerSegmentRightBoundary) - Math.Max(InnerSegmentLeftBoundary, fuzzyType2relation.InnerSegmentLeftBoundary);
                commonPart += CalculateUncertaintySegments(fuzzyType2relation);
                var maxSegment = Math.Max(OuterSegmentRightBoundary - OuterSegmentLeftBoundary, fuzzyType2relation.OuterSegmentRightBoundary - fuzzyType2relation.OuterSegmentLeftBoundary);
                return (maxSegment / commonPart) * 100 > MatchProportion;
            }
            else
            {
                throw new InvalidOperationException("Incompatible relation types.");
            }
        }

        private double CalculateUncertaintySegments(FuzzySetsType2Relation fuzzyType2relation)
        {
            //TODO: Change logic to some distribution or else
            var commonPart = Math.Min(InnerSegmentRightBoundary, fuzzyType2relation.InnerSegmentRightBoundary) - Math.Max(InnerSegmentLeftBoundary, fuzzyType2relation.InnerSegmentLeftBoundary);

            var leftPoint1 = (OuterSegmentLeftBoundary + InnerSegmentLeftBoundary) / 2;
            var rightPoint1 = (OuterSegmentRightBoundary + InnerSegmentRightBoundary) / 2;
            var leftPoint2 = (fuzzyType2relation.OuterSegmentLeftBoundary + fuzzyType2relation.InnerSegmentLeftBoundary) / 2;
            var rightPoint2 = (fuzzyType2relation.OuterSegmentRightBoundary + fuzzyType2relation.InnerSegmentRightBoundary) / 2;
            var commonExtendedPart = Math.Min(rightPoint1, rightPoint2) - Math.Max(leftPoint1, leftPoint2);

            return commonExtendedPart - commonPart;
        }

    }
}

