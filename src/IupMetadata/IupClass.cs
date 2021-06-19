namespace IupMetadata
{
	public record IupClass
	{
		#region Properties

		public string Documentation { get; set; }

		public string ClassName { get; set; }

		public string Name { get; set; }

		public string ParentClassName { get; set; }

		public int ChildrenCount { get; set; }

		public NativeType NativeType { get; set; }

		public IupAttribute[] Attributes { get; set; }

		public IupCallback[] Callbacks { get; set; }

		#endregion Properties
	}
}