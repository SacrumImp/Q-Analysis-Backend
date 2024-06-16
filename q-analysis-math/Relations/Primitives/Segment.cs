namespace q_analysis_math.Relations.Primitives
{
	public struct Segment
	{
        public double LeftBoundary { get; set; }
        public double RightBoundary { get; set; }

        public Segment(double leftBoundary, double rightBoundary)
		{
			LeftBoundary = leftBoundary;
			RightBoundary = rightBoundary;
		}
	}
}

