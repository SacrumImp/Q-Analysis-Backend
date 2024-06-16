namespace q_analysis_math.Relations.Primitives
{
	public readonly struct Segment
	{
        public double LeftBoundary { get; }
        public double RightBoundary { get; }

        public Segment(double leftBoundary, double rightBoundary)
		{
			LeftBoundary = leftBoundary;
			RightBoundary = rightBoundary;
		}
	}
}

