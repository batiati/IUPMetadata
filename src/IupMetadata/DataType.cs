namespace IupMetadata
{
	public enum DataType
	{
		#region Documentation

		/// <summary>
		/// Unknown
		/// </summary>

		#endregion Documentation

		Unknown,

		#region Documentation

		/// <summary>
		/// Call-style attribute, with no value
		/// </summary>

		#endregion Documentation

		Void,

		#region Documentation

		/// <summary>
		/// C-style null terminated string attribute
		/// </summary>

		#endregion Documentation

		String,

		#region Documentation

		/// <summary>
		/// C-style 32bits boolean
		/// </summary>

		#endregion Documentation

		Boolean,

		#region Documentation

		/// <summary>
		/// C-style 32bits signed integer
		/// </summary>

		#endregion Documentation

		Int,

		#region Documentation

		/// <summary>
		/// C-style 32bits signed float
		/// </summary>

		#endregion Documentation

		Float,

		#region Documentation

		/// <summary>
		/// C-style 64bits signed float
		/// </summary>

		#endregion Documentation

		Double,

		#region Documentation

		/// <summary>
		/// By ref (address of) a 32bits signed integer
		/// </summary>

		#endregion Documentation

		RefInt,

		#region Documentation

		/// <summary>
		/// 8bits char
		/// </summary>

		#endregion Documentation

		Char,

		#region Documentation

		/// <summary>
		/// Pointer to a IUP element
		/// See HandleType property if a well-known class, otherwise it can be any IUP element.
		/// </summary>

		#endregion Documentation

		Handle,

		#region Documentation

		/// <summary>
		/// C-style *void pointer
		/// </summary>

		#endregion Documentation

		VoidPtr,

		#region Documentation

		/// <summary>
		/// IUP's *ICanvas structure
		/// </summary>

		#endregion Documentation

		Canvas,
	}
}