namespace q_analysis_math.Relations.Primitives
{
	public readonly struct Trapezoid
	{

        public double LeftBottomPoint { get; }
        public double LeftTopPoint { get; }
        public double RightBottomPoint { get; }
        public double RightTopPoint { get; }

        public Trapezoid(double leftBottomPoint, double leftTopPoint, double rightBottomPoint, double rightTopPoint)
        {
            LeftBottomPoint = leftBottomPoint;
            LeftTopPoint = leftTopPoint;
            RightBottomPoint = rightBottomPoint;
            RightTopPoint = rightTopPoint;
        }

    }
}

