using System;
namespace q_analysis_backend.Extentions
{
	public class EnumExtentions
	{
		public EnumExtentions()
		{
		}

        public static TEnum GetEnumValueOrDefault<TEnum>(int value, TEnum defaultValue) where TEnum : struct, Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
            else
            {
                return defaultValue;
            }
        }
    }
}

