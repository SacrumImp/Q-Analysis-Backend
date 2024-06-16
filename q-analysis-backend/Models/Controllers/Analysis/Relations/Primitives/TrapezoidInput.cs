using q_analysis_math.Relations.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives
{
	public class TrapezoidInput<T>
	{
        public T LeftBottomPoint { get; }
        public T LeftTopPoint { get; }
        public T RightBottomPoint { get; }
        public T RightTopPoint { get; }

        public TrapezoidInput(T leftBottomPoint, T leftTopPoint, T rightBottomPoint, T rightTopPoint)
        {
            LeftBottomPoint = leftBottomPoint;
            LeftTopPoint = leftTopPoint;
            RightBottomPoint = rightBottomPoint;
            RightTopPoint = rightTopPoint;
        }

        public Trapezoid<T> GetStruct()
        {
            return new Trapezoid<T>(LeftBottomPoint, LeftTopPoint, RightBottomPoint, RightTopPoint);
        }
    }
}

