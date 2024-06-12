using System;

namespace q_analysis_backend.Models.Controllers.Analysis.Primitives
{
    public struct AnalysisResultKey : IEquatable<AnalysisResultKey>
	{
		public string Name { get; set; }
		public double Value { get; set; }

		public AnalysisResultKey() { }

        public bool Equals(AnalysisResultKey other)
        {
            return Name.Equals(other.Name) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is AnalysisResultKey && Equals((AnalysisResultKey)obj);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            hash = hash * 23 + Value.GetHashCode();
            return hash;
        }
    }
}

