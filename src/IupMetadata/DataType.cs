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
		/// C-style null terminated string "TODAY" or "yyyy/MM/dd"
		/// </summary>

		#endregion Documentation

		Date,

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
		/// C-style null terminated string formatted as "widht x height", int, optional each value
		/// </summary>

		#endregion Documentation

		Size,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "horiz x vert", int, both required
		/// </summary>

		#endregion Documentation

		Margin,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "ScaleWidth x ScaleHeight"
		/// Where ScaleWidth -> "FULL", "HALF", "THIRD", "QUARTER", "EIGHTH" or absolute width integer value
		/// Where ScaleHeight -> "FULL", "HALF", "THIRD", "QUARTER", "EIGHTH" or absolute height integer value
		/// </summary>

		#endregion Documentation

		DialogSize,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "HAlignment : VAlignment"
		/// Where HAlignment -> "ALEFT", "ACENTER", "ARIGHT"
		/// Where VAlignment -> "ATOP", "ACENTER", "ABOTTOM"
		/// </summary>

		#endregion Documentation

		Alignment,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "lin,col", int, both required
		/// </summary>

		#endregion Documentation

		LinColPos,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "x,y", int, both required
		/// </summary>

		#endregion Documentation

		XYPos,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "begin,end", int, both required
		/// </summary>

		#endregion Documentation

		Range,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formatted as "begin,end", float, both required
		/// </summary>

		#endregion Documentation

		FloatRange,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formated with three or four values "255 255 255" representing the RGB or RGBA components
		/// </summary>

		#endregion Documentation

		Rgb,

		#region Documentation

		/// <summary>
		/// C-style null terminated string formated with four coordinates "x, y, x + width, y + height", int, all required
		/// </summary>

		#endregion Documentation

		Rect,

		#region Documentation

		/// <summary>
		/// C-style null terminated string "NONE", "All" or formated  as "startlin,startcol:endlin,endcol", int all required.
		/// </summary>

		#endregion Documentation

		Selection,

		#region Documentation

		/// <summary>
		/// C-style null terminated string "NEXT", "PREVIOUS" or a handleName
		/// </summary>

		#endregion Documentation

		MdiActivate,

		#region Documentation

		/// <summary>
		/// One of defined values in EnumValues
		/// Can be a null terminated string or a 32bits int
		/// </summary>

		#endregion Documentation

		Enum,

		#region Documentation

		/// <summary>
		/// IUP's *ICanvas structure
		/// </summary>

		#endregion Documentation

		Canvas,
	}
}