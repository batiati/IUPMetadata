namespace IupMetadata
{
	public record IupHandle
	{
		public NativeType NativeType { get; set; }

		public string ElementName { get; set; }
	}

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

		public NativeType[] TargetChildren { get; set; }

		public bool NonInheritable { get; set; }

		public DataType DataType { get; set; }

		public DataFormat DataFormat { get; set; }

		public IupHandle Handle { get; set; }

		public EnumValue[] EnumValues { get; set; }

		public string Default { get; set; }

		public bool IsNullable { get; set; }

		public bool Deprecated { get; set; }

		#endregion Properties
	}
}