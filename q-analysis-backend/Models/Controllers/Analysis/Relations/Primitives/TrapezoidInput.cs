using q_analysis_math.Relations.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives
{
	public class TrapezoidInput
	{
        public double LeftBottomPoint { get; }
        public double LeftTopPoint { get; }
        public double RightBottomPoint { get; }
        public double RightTopPoint { get; }

        public TrapezoidInput(double leftBottomPoint, double leftTopPoint, double rightBottomPoint, double rightTopPoint)
        {
            LeftBottomPoint = leftBottomPoint;
            LeftTopPoint = leftTopPoint;
            RightBottomPoint = rightBottomPoint;
            RightTopPoint = rightTopPoint;
        }

        public Trapezoid GetStruct()
        {
            return new Trapezoid(LeftBottomPoint, LeftTopPoint, RightBottomPoint, RightTopPoint);
        }
    }
}

