namespace IupMetadata
{
	public record IupAttribute
	{
		#region Properties

		public string Documentation { get; set; }

		public string AttributeName { get; set; }

		public string Name { get; set; }

		public bool CreationOnly { get; set; }

		public bool ReadOnly { get; set; }

		public bool WriteOnly { get; set; }

		public NumberedAttribute NumberedAttribute { get; set; }

		public bool AtChildrenOnly { get; set; }

		public bool NonInheritable { get; set; }

		public DataType DataType { get; set; }

		public DataFormat DataFormat { get; set; }

		public string HandleName { get; set; }

		public EnumValue[] EnumValues { get; set; }

		public string Default { get; set; }

		public bool IsNullable { get; set; }

		public bool Deprecated { get; set; }

		#endregion Properties
	}
}