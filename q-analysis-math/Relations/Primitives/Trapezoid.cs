namespace q_analysis_math.Relations.Primitives
{
	public readonly struct Trapezoid<T>
	{

        public T LeftBottomPoint { get; }
        public T LeftTopPoint { get; }
        public T RightBottomPoint { get; }
        public T RightTopPoint { get; }

        public Trapezoid(T leftBottomPoint, T leftTopPoint, T rightBottomPoint, T rightTopPoint)
        {
            LeftBottomPoint = leftBottomPoint;
            LeftTopPoint = leftTopPoint;
            RightBottomPoint = rightBottomPoint;
            RightTopPoint = rightTopPoint;
        }

    }
}

