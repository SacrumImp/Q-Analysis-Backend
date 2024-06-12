namespace q_analysis_math.Relations.Primitives
{
	public readonly struct Domain
	{
        public double LeftBoundary { get; }
        public double RightBoundary { get; }

        public Domain(double leftBoundary, double rightBoundary)
        {
            LeftBoundary = leftBoundary;
            RightBoundary = rightBoundary;
        }
    }
}

