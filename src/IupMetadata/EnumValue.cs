namespace IupMetadata
{
	public record EnumValue
	{
		#region Properties

		public string Name { get; private set; }

		public string StrValue { get; private set; }

		public long? IntValue { get; private set; }

		#endregion Properties

		#region Constructor

		public EnumValue(string name, long? intValue)
		{
			Name = name;
			IntValue = intValue;
			StrValue = null;
		}

		public EnumValue(string strValue)
		{
			Name = UpperCaseConverter.ToTitleCase(strValue);
			StrValue = strValue;
			IntValue = null;
		}

		#endregion Constructor

		#region Opertators

		public static implicit operator EnumValue(string strValue)
		{
			return new EnumValue(strValue);
		}

		#endregion Opertators
	}
}