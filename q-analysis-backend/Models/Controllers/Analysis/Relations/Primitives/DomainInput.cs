using q_analysis_math.Relations.Primitives;

namespace q_analysis_backend.Models.Controllers.Analysis.Relations.Primitives
{
	public class DomainInput
	{
        public double LeftBoundary { get; }
        public double RightBoundary { get; }

        public DomainInput(double leftBoundary, double rightBoundary)
        {
            LeftBoundary = leftBoundary;
            RightBoundary = rightBoundary;
        }

        public Domain GetStruct()
        {
            return new Domain(LeftBoundary, RightBoundary);
        }
    }
}

