using System;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using System.Collections.Generic;

namespace q_analysis_backend.Models.Controllers.Analysis.Primitives
{
	public struct SplitKey : IEquatable<SplitKey>
    {
		public List<AnalysisResultKey> Keys { get; set; }

        public bool Equals(SplitKey other)
        {
            if (Keys == null && other.Keys != null || Keys != null && other.Keys == null)
                return false;
            if (Keys != null && other.Keys != null)
            {
                if (Keys.Count != other.Keys.Count)
                    return false;
                for (int i = 0; i < Keys.Count; i++)
                {
                    if (!Keys[i].Equals(other.Keys[i]))
                        return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is SplitKey && Equals((SplitKey)obj);
        }

        public override int GetHashCode()
        {
            if (Keys == null)
                return 0;

            int hash = 17;
            foreach (var key in Keys)
            {
                hash = hash * 23 + key.GetHashCode();
            }
            return hash;
        }
    }
}

