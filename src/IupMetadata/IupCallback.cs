namespace IupMetadata
{
	public record IupCallback
	{
		#region Properties

		public string Documentation { get; set; }

		public string AttributeName { get; set; }

		public string Name { get; set; }

		public DataType[] Arguments { get; set; }

		public DataType ReturnType { get; set; }

		#endregion Properties
	}
}