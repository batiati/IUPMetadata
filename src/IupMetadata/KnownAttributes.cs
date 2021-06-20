using System;
using System.Linq;

namespace IupMetadata
{
	public class KnownAttributes
	{
		#region InnerTypes

		public enum AttributeGroup
		{
			None,
			Common,
			Visual,
		}

		private class AttributeType
		{
			public string ClassName { get; set; }

			public string AttributeName { get; set; }

			public AttributeGroup Group { get; set; }

			public DataType DataType { get; set; }

			public DataFormat DataFormat { get; set; }

			public EnumValue[] EnumValues { get; set; }

			public bool IsNullable { get; set; }

			public string HandleName { get; set; }
		}

		#endregion InnerTypes

		#region Fields

		#region Documentation

		/// <summary>
		/// This data is populated by inspecting IUPs source code and describing here aspects about DataType, formating and accepted values (enums)
		/// </summary>

		#endregion Documentation

		private static readonly AttributeType[] Values = new[]
		{
			//TODO:: Needs review, most attributes are just declared here without propper DataType
			//Attributes with DataType set are already reviewed

			new AttributeType { AttributeName = "FRAMETIME", ClassName="expander", DataType=DataType.Int,},
			new AttributeType { AttributeName = "ANIMATION", ClassName="expander", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "SLIDE", "CURTAIN", "NO" }, }, // Used by 2 controls: AnimatedLabel, Expander
			new AttributeType { AttributeName = "FRAME", ClassName="expander", DataType = DataType.Boolean }, // Used by 2 controls: Expander, FlatFrame

			new AttributeType { AttributeName = "FRAME", ClassName="flatframe", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues=new EnumValue[] { "YES", "NO", "CROSSTITLE" }, }, // Used by 2 controls: Expander, FlatFrame

			new AttributeType { AttributeName = "START", ClassName="thread", DataType=DataType.Boolean, },
			new AttributeType { AttributeName = "START", ClassName="animatedlabel", DataType=DataType.Void, },

			new AttributeType { AttributeName = "TYPE", ClassName="val", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "HORIZONTAL", "VERTICAL" } }, // Used by 3 controls: Dial, Param, Val
			new AttributeType { AttributeName = "TYPE", ClassName="dial", DataType= DataType.Double}, // Used by 3 controls: Dial, Param, Val

			new AttributeType { AttributeName = "DIALOGTYPE", ClassName="messagedlg", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues= new EnumValue[] { "ERROR", "WARNING", "INFORMATION", "QUESTION" } },

			new AttributeType { AttributeName = "SEPARATOR", ClassName="DatePick", DataType=DataType.String}, // Used by 4 controls: AnimatedLabel, DatePick, Label, Link

			new AttributeType { AttributeName = "STATE", ClassName="expander", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "OPEN", "CLOSED" }, },
			new AttributeType { AttributeName = "STATE", ClassName="tree", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "EXPANDED", "COLLAPSED" }, },
			new AttributeType { AttributeName = "STATE", ClassName="flattree", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "EXPANDED", "COLLAPSED" }, },
			new AttributeType { AttributeName = "STATE", ClassName="progressdlg", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ABORTED", "PROCESSING", "UNDEFINED", "IDLE" }, },

			new AttributeType { ClassName="gridbox", AttributeName = "EXPANDCHILDREN", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "YES", "HORIZONTAL", "VERTICAL" , "NONE" } },

			new AttributeType { AttributeName = "VALUE_HANDLE", ClassName="radio", DataType = DataType.Handle, HandleName = "Toggle"}, // Used by 4 controls: FlatTabs, Radio, Tabs, ZBox

			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "ColorDlg", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "Dialog", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "FileDlg", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "FontDlg", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "MessageDlg", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "ProgressDlg", Group = AttributeGroup.Common, DataType = DataType.String, DataFormat=DataFormat.DialogSize },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "VBox", Group = AttributeGroup.Common, DataType = DataType.Int, },
			new AttributeType { AttributeName = "SIZE", IsNullable = true, ClassName = "HBox", Group = AttributeGroup.Common, DataType = DataType.Int, },

			new AttributeType { AttributeName = "DECORATION", DataType=DataType.Boolean}, // Used by 2 controls: BackgroundBox, FlatFrame
			new AttributeType { AttributeName = "DECOROFFSET", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 2 controls: BackgroundBox, FlatFrame
			new AttributeType { AttributeName = "DECORSIZE", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 2 controls: BackgroundBox, FlatFrame
			new AttributeType { AttributeName = "IMINACTIVE", DataType=DataType.String}, // Used by 2 controls: Button, Toggle
			new AttributeType { AttributeName = "TODAY", DataType=DataType.String, DataFormat=DataFormat.Date,}, // Used by 2 controls: Calendar, DatePick
			new AttributeType { AttributeName = "FORMAT", DataType=DataType.String}, // Used by 2 controls: Clipboard, DatePick
			new AttributeType { AttributeName = "TEXT", DataType=DataType.String}, // Used by 2 controls: Clipboard, Gauge
			new AttributeType { AttributeName = "SHOW_PREVIEW", DataType=DataType.Boolean}, // Used by 2 controls: ColorBar, FileDlg
			new AttributeType { AttributeName = "FRAMECOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 2 controls: Expander, FlatFrame
			new AttributeType { AttributeName = "FRAMEWIDTH", DataType=DataType.Int}, // Used by 2 controls: Expander, FlatFrame
			new AttributeType { AttributeName = "FORECOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 2 controls: Expander, FlatTabs
			new AttributeType { AttributeName = "HIGHCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 2 controls: Expander, FlatTabs
			new AttributeType { AttributeName = "EXTRABUTTONS", DataType=DataType.Int}, // Used by 2 controls: Expander, FlatTabs
			new AttributeType { AttributeName = "DIRECTORY", DataType=DataType.String}, // Used by 2 controls: FileDlg, Param
			new AttributeType { AttributeName = "NOCHANGEDIR", DataType=DataType.Boolean}, // Used by 2 controls: FileDlg, Param
			new AttributeType { AttributeName = "NOOVERWRITEPROMPT", DataType=DataType.Boolean}, // Used by 2 controls: FileDlg, Param
			new AttributeType { AttributeName = "NUMLIN", DataType = DataType.Int}, // Used by 2 controls: GridBox, MultiBox
			new AttributeType { AttributeName = "NUMCOL", DataType = DataType.Int}, // Used by 2 controls: GridBox, MultiBox
			new AttributeType { AttributeName = "KEY", DataType = DataType.Int}, // Used by 2 controls: Item, SubMenu
			new AttributeType { AttributeName = "LINECOUNT", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "LINEVALUE", DataType = DataType.String}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "LOADRTF", DataType = DataType.String}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "LOADRTFSTATUS", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] {"OK", "FAILED" },  }, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "NOHIDESEL", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "PASSWORD", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "OVERWRITE", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SAVERTF", DataType = DataType.String}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SAVERTFSTATUS", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] {"OK", "FAILED" },}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "REMOVEFORMATTING", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] {"ALL", "SELECTION" },}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPIN", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINALIGN", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "LEFT", "RIGHT" }, }, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINAUTO", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPININC", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINMAX", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINMIN", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINVALUE", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "SPINWRAP", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "TABSIZE", DataType = DataType.Int}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "CHANGECASE",DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues=new EnumValue[] { "UPPER" , "LOWER" , "TOGGLE", "TITLE" } }, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "ADDFORMATTAG", DataType = DataType.String}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "ADDFORMATTAG_HANDLE", DataType = DataType.Handle, HandleName = "User"}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "APPENDNEWLINE", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "FORMATTING", DataType = DataType.Boolean}, // Used by 2 controls: Multiline, Text
			new AttributeType { AttributeName = "BUTTON1", DataType = DataType.String}, // Used by 2 controls: Param, ParamBox
			new AttributeType { AttributeName = "BUTTON2", DataType = DataType.String}, // Used by 2 controls: Param, ParamBox
			new AttributeType { AttributeName = "BUTTON3", DataType = DataType.String}, // Used by 2 controls: Param, ParamBox
			new AttributeType { AttributeName = "DIRECTION", DataType= DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] {"NORTH", "SOUTH", "WEST", "EAST" }, }, // Used by 2 controls: SBox, Split
			new AttributeType { AttributeName = "FIRST_CONTROL_HANDLE", DataType = DataType.Handle}, // Used by 3 controls: AnimatedLabel, DropButton, Normalizer
			new AttributeType { AttributeName = "NEXT_CONTROL_HANDLE", DataType = DataType.Handle}, // Used by 3 controls: AnimatedLabel, DropButton, Normalizer
			new AttributeType { AttributeName = "ELLIPSIS", DataType = DataType.Boolean}, // Used by 3 controls: AnimatedLabel, Label, Link
			new AttributeType { AttributeName = "IMPRESS", DataType = DataType.String}, // Used by 3 controls: Button, Item, Toggle
			new AttributeType { AttributeName = "FLATCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 3 controls: ColorBar, Dial, Gauge
			new AttributeType { AttributeName = "SHOWDROPDOWN", DataType = DataType.Boolean}, // Used by 3 controls: DatePick, DropButton, List
			new AttributeType { AttributeName = "SHOWGRIP", DataType = DataType.Boolean}, // Used by 3 controls: DetachBox, SBox, Split
			new AttributeType { AttributeName = "TEXTHLCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "SHOWBORDER", DataType = DataType.Boolean}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "PRESSED", DataType = DataType.Boolean}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "HIGHLIGHTED", DataType = DataType.Boolean}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "FRONTIMAGEHIGHLIGHT"}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "FRONTIMAGEPRESS"}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "BACKIMAGEHIGHLIGHT"}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "BACKIMAGEINACTIVE"}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "BACKIMAGEPRESS"}, // Used by 3 controls: DropButton, FlatButton, FlatToggle
			new AttributeType { AttributeName = "TITLEIMAGE", DataType=DataType.String}, // Used by 3 controls: Expander, FlatFrame, Item
			new AttributeType { AttributeName = "DIALOGTYPE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "SAVE", "DIR", "OPEN" }, },
			new AttributeType { AttributeName = "IGNORERADIO", DataType = DataType.Boolean}, // Used by 3 controls: FlatButton, FlatToggle, Toggle
			new AttributeType { AttributeName = "CGAP", DataType=DataType.Int}, // Used by 3 controls: HBox, Spin, VBox
			new AttributeType { AttributeName = "HOMOGENEOUS", DataType=DataType.Boolean}, // Used by 3 controls: HBox, Spin, VBox
			new AttributeType { AttributeName = "GAP", DataType=DataType.Int}, // Used by 3 controls: HBox, Spin, VBox
			new AttributeType { AttributeName = "NGAP", DataType=DataType.Int}, // Used by 3 controls: HBox, Spin, VBox
			new AttributeType { AttributeName = "NCGAP", DataType=DataType.Int}, // Used by 3 controls: HBox, Spin, VBox
			new AttributeType { AttributeName = "ORIGINALSCALE", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "RESHAPE", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "SCALED", DataType=DataType.Boolean}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "HOTSPOT", DataType=DataType.String, DataFormat=DataFormat.Range,}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "HEIGHT", DataType=DataType.Int}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "DPI", DataType=DataType.Int}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "CHANNELS", DataType=DataType.Int}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "CLEARCACHE", DataType=DataType.Void}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "AUTOSCALE", DataType=DataType.Boolean}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "BPP", DataType=DataType.Int}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "WIDTH", DataType=DataType.Int}, // Used by 3 controls: Image, ImageRgb, ImageRgba
			new AttributeType { AttributeName = "VALUEMASKED", DataType=DataType.String}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "CARET", DataType=DataType.String, DataFormat=DataFormat.LinColPos,}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "CARETPOS", DataType=DataType.Int}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "APPEND", DataType=DataType.String}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "CUEBANNER", DataType=DataType.String}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "CLIPBOARD", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "COPY", "CUT", "PASTE", "CLEAR", "UNDO", "REDO" } }, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "READONLY", DataType=DataType.Boolean}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "SELECTEDTEXT", DataType=DataType.String}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "SELECTION", DataType=DataType.String, DataFormat=DataFormat.Selection}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "SELECTIONPOS", DataType=DataType.String, DataFormat=DataFormat.Range,}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "SCROLLTOPOS", DataType=DataType.Int}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "NC", DataType=DataType.Int}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "INSERT"}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKCASEI", DataType=DataType.Boolean}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKDECIMALSYMBOL", DataType=DataType.String}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKFLOAT", DataType=DataType.String, DataFormat=DataFormat.FloatRange, IsNullable=true}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKINT", DataType=DataType.String, DataFormat=DataFormat.Range, IsNullable=true}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKNOEMPTY", DataType=DataType.Boolean}, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "MASKREAL", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] {"SIGNED", "UNSIGNED", }, IsNullable = true }, // Used by 3 controls: List, Multiline, Text
			new AttributeType { AttributeName = "CANVASBOX", DataType=DataType.Boolean}, // Used by 4 controls: BackgroundBox, FlatFrame, FlatScrollBox, ScrollBox
			new AttributeType { AttributeName = "STATUS", DataType=DataType.Int}, // Used by 4 controls: ColorDlg, FileDlg, FontDlg, ParamBox
			new AttributeType { AttributeName = "STATUS", ClassName="filedlg", DataType=DataType.Int, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { new EnumValue("Normal", 0), new EnumValue("NewFile", 1), new EnumValue("Cancelled", -1) } }, // Used by 4 controls: ColorDlg, FileDlg, FontDlg, ParamBox
			new AttributeType { AttributeName = "FRONTIMAGEINACTIVE"}, // Used by 4 controls: DropButton, FlatButton, FlatLabel, FlatToggle
			new AttributeType { AttributeName = "FRONTIMAGE", DataType=DataType.String }, // Used by 4 controls: DropButton, FlatButton, FlatLabel, FlatToggle
			new AttributeType { AttributeName = "TEXTORIENTATION", DataType = DataType.Double}, // Used by 4 controls: DropButton, FlatButton, FlatLabel, FlatToggle
			new AttributeType { AttributeName = "TEXTCLIP"}, // Used by 4 controls: DropButton, FlatButton, FlatLabel, FlatToggle
			new AttributeType { AttributeName = "BORDERHLCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 4 controls: DropButton, FlatButton, FlatToggle, FlatVal
			new AttributeType { AttributeName = "BORDERPSCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 4 controls: DropButton, FlatButton, FlatToggle, FlatVal
			new AttributeType { AttributeName = "IMAGEPRESS"}, // Used by 4 controls: DropButton, FlatButton, FlatToggle, FlatVal
			new AttributeType { AttributeName = "ARROWIMAGES", DataType=DataType.Int}, // Used by 4 controls: DropButton, FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "RADIO", DataType=DataType.Boolean}, // Used by 4 controls: FlatButton, FlatToggle, Menu, Toggle
			new AttributeType { AttributeName = "MASK", DataType=DataType.String}, // Used by 4 controls: List, Multiline, Param, Text
			new AttributeType { AttributeName = "AUTOHIDE", DataType=DataType.Boolean}, // Used by 4 controls: List, Multiline, Split, Text
			new AttributeType { AttributeName = "MULTILINE", DataType=DataType.Boolean}, // Used by 4 controls: Multiline, Param, Tabs, Text
			new AttributeType { AttributeName = "MARKUP", DataType=DataType.Boolean}, // Used by 5 controls: AnimatedLabel, Button, Label, Link, Toggle
			new AttributeType { AttributeName = "WORDWRAP", DataType=DataType.Boolean}, // Used by 5 controls: AnimatedLabel, Label, Link, Multiline, Text
			new AttributeType { AttributeName = "BACKCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 5 controls: BackgroundBox, Expander, FlatFrame, FlatTree, Gauge
			new AttributeType { AttributeName = "FLAT", DataType=DataType.Boolean}, // Used by 5 controls: Button, ColorBar, Dial, Gauge, Toggle
			new AttributeType { AttributeName = "BARSIZE", DataType=DataType.Int}, // Used by 5 controls: DetachBox, Expander, FlatSeparator, SBox, Split
			new AttributeType { AttributeName = "IMAGEHIGHLIGHT", DataType=DataType.String}, // Used by 5 controls: DropButton, Expander, FlatButton, FlatToggle, FlatVal
			new AttributeType { AttributeName = "TEXTELLIPSIS", DataType=DataType.Boolean}, // Used by 5 controls: DropButton, FlatButton, FlatLabel, FlatList, FlatToggle
			new AttributeType { AttributeName = "TEXTALIGNMENT", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ARIGHT", "ALEFT", "ACENTER" } }, // Used by 5 controls: DropButton, FlatButton, FlatLabel, FlatList, FlatToggle
			new AttributeType { AttributeName = "TEXTWRAP", DataType=DataType.Boolean}, // Used by 5 controls: DropButton, FlatButton, FlatLabel, FlatList, FlatToggle
			new AttributeType { AttributeName = "IMAGEINACTIVE"}, // Used by 5 controls: DropButton, FlatButton, FlatLabel, FlatToggle, FlatVal
			new AttributeType { AttributeName = "TEXTPSCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 5 controls: DropButton, FlatButton, FlatList, FlatToggle, FlatTree
			new AttributeType { AttributeName = "VISIBLECOLUMNS", DataType = DataType.Int, IsNullable = true}, // Used by 5 controls: DropButton, FlatList, List, Multiline, Text
			new AttributeType { AttributeName = "FILTER", ClassName = "text", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "LOWERCASE", "NUMBER", "UPPERCASE" }, IsNullable = true },
			new AttributeType { AttributeName = "FILTER", ClassName = "multiline", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "LOWERCASE", "NUMBER", "UPPERCASE" }, IsNullable = true },
			new AttributeType { AttributeName = "FILTER", ClassName = "filedlg", DataType = DataType.String },
			new AttributeType { AttributeName = "FILTER", ClassName = "param", DataType = DataType.String },
			new AttributeType { AttributeName = "SCROLLTO", DataType = DataType.Int}, // Used by 5 controls: FlatScrollBox, List, Multiline, ScrollBox, Text
			new AttributeType { AttributeName = "AUTOREDRAW", DataType=DataType.Boolean}, // Used by 5 controls: FlatTree, List, Multiline, Text, Tree
			new AttributeType { AttributeName = "MAX", DataType=DataType.Double}, // Used by 5 controls: FlatVal, Gauge, Param, ProgressBar, Val
			new AttributeType { AttributeName = "MIN", DataType=DataType.Double}, // Used by 5 controls: FlatVal, Gauge, Param, ProgressBar, Val
			new AttributeType { AttributeName = "MARGIN", DataType=DataType.String, DataFormat=DataFormat.Margin }, // Used by 5 controls: GridBox, HBox, MultiBox, Spin, VBox
			new AttributeType { AttributeName = "NCMARGIN", DataType=DataType.String, DataFormat=DataFormat.Margin}, // Used by 5 controls: GridBox, HBox, MultiBox, Spin, VBox
			new AttributeType { AttributeName = "NMARGIN", DataType=DataType.String, DataFormat=DataFormat.Margin}, // Used by 5 controls: GridBox, HBox, MultiBox, Spin, VBox
			new AttributeType { AttributeName = "CMARGIN", DataType=DataType.String, DataFormat=DataFormat.Margin}, // Used by 5 controls: GridBox, HBox, MultiBox, Spin, VBox
			new AttributeType { AttributeName = "FLAT_ALPHA"}, // Used by 5 controls: Item, SubMenu, Tabs, Toggle, Tree
			new AttributeType { AttributeName = "IMAGEPOSITION", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "LEFT", "RIGHT", "BOTTOM", "TOP" } }, // Used by 6 controls: Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle
			new AttributeType { AttributeName = "MAXBOX", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MAXIMIZEATDIALOG", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MAXIMIZEATPARENT", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MAXIMIZED", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MAXIMIZEDIALOG", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDIACTIVATE",  DataType=DataType.String, DataFormat=DataFormat.MdiActivate}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDIACTIVE", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDIARRANGE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "TILEHORIZONTAL", "TILEVERTICAL", "CASCADE", "ICON" } }, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDICHILD", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDICLIENT", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDICLOSEALL", DataType=DataType.Void}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDIFRAME", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDIMENU", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MDINEXT", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MENU", DataType=DataType.Handle, HandleName = "Menu"}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MENUBOX", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "LAYERALPHA", DataType=DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "NOFLUSH", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "PARENTDIALOG", DataType=DataType.Handle, HandleName = "Dialog"}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "OPACITY", DataType=DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "OPACITYIMAGE", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "NATIVEPARENT", DataType=DataType.Handle}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "NACTIVE", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MINBOX", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MODAL", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "MINIMIZED", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SHAPEIMAGE", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SAVEUNDER", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "PLACEMENT", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "MAXIMIZED", "MINIMIZED", "FULL", }, IsNullable = true }, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SHOWMINIMIZENEXT", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SHOWNOACTIVATE", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SHOWNOFOCUS", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SHRINK", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "SIMULATEMODAL", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "STARTFOCUS", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "FULLSCREEN", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "HELPBUTTON", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "HIDETASKBAR", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "ICON", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "DIALOGFRAME", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "DIALOGHINT", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "COMPOSITED", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "DEFAULTENTER", DataType=DataType.Handle, HandleName = "Button"}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "DEFAULTESC", DataType=DataType.Handle, HandleName = "Button"}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "CUSTOMFRAME", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "CUSTOMFRAMECAPTIONHEIGHT", DataType=DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "CUSTOMFRAMECAPTIONLIMITS", DataType=DataType.String, DataFormat=DataFormat.Range, IsNullable = true}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "CUSTOMFRAMEDRAW", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "CUSTOMFRAMESIMULATE", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "ACTIVEWINDOW", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "BORDERSIZE", DataType = DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "BACKGROUND", DataType=DataType.String, DataFormat=DataFormat.Rgb, }, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "BRINGFRONT", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TASKBARBUTTON", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "SHOW", "HIDE" }, IsNullable = true }, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TASKBARPROGRESS", DataType = DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TASKBARPROGRESSSTATE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "NOPROGRESS", "INDETERMINATE", "ERROR", "PAUSED", "NORMAL" }  }, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TASKBARPROGRESSVALUE", DataType = DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TOPMOST", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAY", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYIMAGE", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYTIP", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYTIPBALLOON", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYTIPBALLOONTITLE", DataType=DataType.String}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYTIPBALLOONTITLEICON", DataType=DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TRAYTIPDELAY", DataType=DataType.Int}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "TOOLBOX", DataType=DataType.Boolean}, // Used by 6 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "FITTOBACKIMAGE", DataType=DataType.Boolean}, // Used by 6 controls: DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, FlatVal
			new AttributeType { AttributeName = "BORDERCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 6 controls: DropButton, FlatButton, FlatList, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "BORDERWIDTH", DataType=DataType.Int}, // Used by 6 controls: DropButton, FlatButton, FlatList, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "PSCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 6 controls: DropButton, FlatButton, FlatList, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "CONTROL", DataType = DataType.Boolean}, // Used by 7 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, Param, ProgressDlg
			new AttributeType { AttributeName = "COLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 7 controls: DetachBox, FlatSeparator, FlatTree, FontDlg, SBox, Split, Tree
			new AttributeType { AttributeName = "FOCUSFEEDBACK", DataType = DataType.Boolean}, // Used by 7 controls: DropButton, FlatButton, FlatList, FlatTabs, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "HASFOCUS", DataType = DataType.Boolean}, // Used by 7 controls: DropButton, FlatButton, FlatList, FlatTabs, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "HLCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 7 controls: DropButton, FlatButton, FlatList, FlatToggle, FlatTree, FlatVal, Tree
			new AttributeType { AttributeName = "BACKIMAGE", DataType=DataType.String}, // Used by 9 controls: BackgroundBox, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "BACKIMAGEZOOM", DataType = DataType.Boolean}, // Used by 9 controls: BackgroundBox, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatToggle, FlatTree, FlatVal
			new AttributeType { AttributeName = "CSPACING", DataType = DataType.Int, IsNullable = true}, // Used by 9 controls: Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, FlatTree, List, Tree
			new AttributeType { AttributeName = "SPACING", DataType = DataType.Int, IsNullable = true}, // Used by 9 controls: Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, FlatTree, List, Tree

			new AttributeType { AttributeName = "RESIZE", DataType = DataType.Boolean}, // Used by 9 controls: ColorDlg, Dialog, FileDlg, FontDlg, MessageDlg, ProgressDlg
			new AttributeType { AttributeName = "RESIZE", ClassName = "imagergb", DataType=DataType.String, DataFormat=DataFormat.Size},
			new AttributeType { AttributeName = "RESIZE", ClassName = "imagergba", DataType=DataType.String, DataFormat=DataFormat.Size},
			new AttributeType { AttributeName = "RESIZE", ClassName = "image", DataType=DataType.String, DataFormat=DataFormat.Size},

			new AttributeType { AttributeName = "COUNT", DataType = DataType.Int}, // Used by 10 controls: ColorBar, FlatList, FlatTabs, FlatTree, List, Multiline, ProgressDlg, Tabs, Text, Tree
			new AttributeType { AttributeName = "ALIGNMENT", DataType=DataType.String, DataFormat=DataFormat.Alignment}, // Used by 16 controls: AnimatedLabel, Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, HBox, Label, Link, Multiline, Spin, Text, Toggle, VBox, ZBox
			new AttributeType { ClassName = "Param", AttributeName = "CONTROL"},
			new AttributeType { AttributeName = "CHILDOFFSET", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 13 controls: BackgroundBox, ColorDlg, Dialog, FileDlg, FlatFrame, FlatScrollBox, FlatTabs, FontDlg, Frame, MessageDlg, ProgressDlg, ScrollBox, Tabs
			new AttributeType { AttributeName = "PADDING", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 14 controls: AnimatedLabel, Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, Gauge, Label, Link, List, Multiline, Text, Toggle
			new AttributeType { AttributeName = "CPADDING", DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 14 controls: AnimatedLabel, Button, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, Gauge, Label, Link, List, Multiline, Text, Tree
			new AttributeType { AttributeName = "ORIENTATION",DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "HORIZONTAL", "VERTICAL" }, }, // Used by 14 controls: ColorBar, DetachBox, Dial, FlatSeparator, FlatVal, Gauge, GridBox, HBox, MultiBox, ProgressBar, Spin, Split, Val, VBox
			new AttributeType { AttributeName = "IMAGE", DataType=DataType.String}, // Used by 18 controls: AnimatedLabel, Button, Clipboard, DropButton, Expander, FlatButton, FlatLabel, FlatList, FlatToggle, FlatTree, FlatVal, Item, Label, Link, List, SubMenu, Toggle, Tree
			new AttributeType { AttributeName = "HDC_WMPAINT"}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWANTIALIAS", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWBGCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWDRIVER", DataType=DataType.String }, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWFONT", DataType=DataType.String}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWLINEWIDTH", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWMAKEINACTIVE", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWSIZE", DataType=DataType.String, DataFormat=DataFormat.Size}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWSTYLE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "FILL", "STROKE_DASH", "STROKE_DOT", "STROKE_DASH_DOT", "STROKE_DASH_DOT_DOT", "DRAW_STROKE" } }, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTALIGNMENT", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ACENTER", "ARIGHT", "ALEFT" } }, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTCLIP", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTELLIPSIS", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTLAYOUTCENTER", DataType = DataType.Boolean }, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTORIENTATION", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWTEXTWRAP", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DRAWUSEDIRECT2D", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DX", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "DY", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "BACKINGSTORE", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "LINEX", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "LINEY", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "POSX", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "POSY", DataType = DataType.Double}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "SB_RESIZE"}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "WHEELDROPFOCUS", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "YAUTOHIDE", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "YHIDDEN", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "XAUTOHIDE", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "XHIDDEN", DataType = DataType.Boolean}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "XMAX", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "XMIN", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "YMAX", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "YMIN", DataType = DataType.Int}, // Used by 18 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, ScrollBox
			new AttributeType { AttributeName = "HTTRANSPARENT", DataType = DataType.Boolean}, // Used by 21 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, Label, Link, ScrollBox
			new AttributeType { AttributeName = "FGCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 21 controls: AnimatedLabel, Button, Dial, DropButton, FlatButton, FlatLabel, FlatList, FlatToggle, FlatTree, FlatVal, Frame, Gauge, Label, Link, List, Multiline, ProgressBar, Tabs, Text, Toggle, Tree
			new AttributeType { AttributeName = "SCROLLBAR", DataType = DataType.Boolean}, // Used by 21 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, Dial, DropButton, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, Gauge, List, Multiline, ScrollBox, Text
			new AttributeType { AttributeName = "TITLE", DataType = DataType.String}, // Used by 23 controls: AnimatedLabel, Button, ColorDlg, Dialog, DropButton, Expander, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatToggle, FlatTree, FontDlg, Frame, Item, Label, Link, MessageDlg, Param, ProgressDlg, SubMenu, Toggle, Tree
			new AttributeType { AttributeName = "HWND", DataType=DataType.Handle}, // Used by 24 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, MessageDlg, ProgressDlg, ScrollBox
			new AttributeType { AttributeName = "CURSOR", DataType = DataType.String}, // Used by 25 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Link, MessageDlg, ProgressDlg, ScrollBox
			new AttributeType { AttributeName = "BORDER", DataType = DataType.Boolean}, // Used by 26 controls: BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text
			new AttributeType { AttributeName = "CLIENTOFFSET", DataType=DataType.String, DataFormat=DataFormat.Size}, // Used by 27 controls: BackgroundBox, CBox, ColorDlg, DetachBox, Dialog, Expander, FileDlg, FlatFrame, FlatScrollBox, FlatTabs, FontDlg, Frame, GridBox, HBox, MessageDlg, MultiBox, ParamBox, ProgressDlg, Radio, SBox, ScrollBox, Spin, SpinBox, Split, Tabs, VBox, ZBox
			new AttributeType { AttributeName = "CLIENTSIZE", DataType=DataType.String, DataFormat=DataFormat.Size}, // Used by 27 controls: BackgroundBox, CBox, ColorDlg, DetachBox, Dialog, Expander, FileDlg, FlatFrame, FlatScrollBox, FlatTabs, FontDlg, Frame, GridBox, HBox, MessageDlg, MultiBox, ParamBox, ProgressDlg, Radio, SBox, ScrollBox, Spin, SpinBox, Split, Tabs, VBox, ZBox
			new AttributeType { AttributeName = "VALUE", DataType = DataType.String}, // Used by 27 controls: Calendar, ColorDlg, DatePick, Dial, FileDlg, FlatButton, FlatList, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Item, List, MessageDlg, Multiline, Param, ProgressBar, Radio, Split, Tabs, Text, Toggle, Tree, Val, ZBox
			new AttributeType { AttributeName = "DROPFILESTARGET", DataType = DataType.Boolean}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DROPTARGET", DataType = DataType.Boolean}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DROPTYPES", DataType = DataType.String}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGCURSOR", DataType = DataType.String}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGCURSORCOPY", DataType = DataType.String}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGDROP", DataType = DataType.Boolean}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGSOURCE", DataType = DataType.Boolean}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGSOURCEMOVE", DataType = DataType.Boolean}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGSTART", DataType=DataType.String, DataFormat=DataFormat.XYPos}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "DRAGTYPES", DataType = DataType.String}, // Used by 31 controls: AnimatedLabel, BackgroundBox, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressDlg, ScrollBox, Text, Tree
			new AttributeType { AttributeName = "CONTROLID", DataType = DataType.Int}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TOUCH", DataType = DataType.Boolean}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPBALLOON", DataType = DataType.Boolean}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPBALLOONTITLE", DataType = DataType.String}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPBALLOONTITLEICON", DataType = DataType.Boolean}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "BGCOLOR", DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 43 controls: AnimatedLabel, BackgroundBox, Button, Canvas, ColorBar, ColorBrowser, ColorDlg, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Image, ImageRgb, ImageRgba, Item, Label, Link, List, Menu, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, SubMenu, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "ITEMTIP", DataType = DataType.String}, // Used by 2 controls: FlatList, FlatTree
			new AttributeType { AttributeName = "HLCOLORALPHA", DataType = DataType.Int}, // Used by 2 controls: FlatList, FlatTree
			new AttributeType { AttributeName = "ICONSPACING", DataType = DataType.Int}, // Used by 2 controls: FlatList, FlatTree
			new AttributeType { AttributeName = "DRAGDROPLIST", DataType = DataType.Boolean}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "APPENDITEM", DataType = DataType.String}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "INSERTITEM", DataType = DataType.String}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "IMAGENATIVEHANDLE", DataType = DataType.Handle}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "MULTIPLE", DataType = DataType.Boolean}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "REMOVEITEM", DataType = DataType.String}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "VALUESTRING", DataType = DataType.String}, // Used by 2 controls: FlatList, List
			new AttributeType { AttributeName = "SCROLLTOCHILD", DataType = DataType.String}, // Used by 2 controls: FlatScrollBox, ScrollBox
			new AttributeType { AttributeName = "SCROLLTOCHILD_HANDLE", DataType = DataType.Handle}, // Used by 2 controls: FlatScrollBox, ScrollBox
			new AttributeType { AttributeName = "SHOWCLOSE", DataType = DataType.Boolean}, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TABIMAGE", DataType = DataType.String}, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TABORIENTATION", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "HORIZONTAL", "VERTICAL" } }, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TABTITLE", DataType = DataType.String}, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TABTYPE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "BOTTOM", "LEFT" , "RIGHT" , "TOP" } }, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TABVISIBLE", DataType = DataType.Boolean}, // Used by 2 controls: FlatTabs, Tabs
			new AttributeType { AttributeName = "TOGGLEVALUE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ON", "OFF", "NOTDEF" } }, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "TOGGLEVISIBLE", DataType = DataType.Boolean}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "TITLEFONT", DataType = DataType.String}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "TITLEFONTSIZE", DataType = DataType.Int}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "TITLEFONTSTYLE", DataType = DataType.String}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "TOTALCHILDCOUNT", DataType = DataType.Int}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "SHOWRENAME", DataType = DataType.Boolean}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "SHOWTOGGLE", DataType = DataType.Boolean}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "RENAME", DataType = DataType.Void}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "RENAMECARET", DataType = DataType.String}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "RENAMESELECTION", DataType = DataType.String}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "ROOTCOUNT", DataType = DataType.Int}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "IDVALUE", DataType = DataType.Int}, // Used by 3 controls: FlatList, Image, List
			new AttributeType { AttributeName = "CHILDSIZEALL", DataType = DataType.Boolean}, // Used by 3 controls: FlatTabs, Tabs, ZBox
			new AttributeType { AttributeName = "VALUEPOS", DataType = DataType.Int}, // Used by 3 controls: FlatTabs, Tabs, ZBox
			new AttributeType { AttributeName = "USERDATA", DataType = DataType.VoidPtr}, // Used by 3 controls: FlatTree, ParamBox, Tree
			new AttributeType { AttributeName = "STEP", DataType = DataType.Double}, // Used by 3 controls: FlatVal, Param, Val
			new AttributeType { AttributeName = "SHOWDRAGDROP", DataType = DataType.Boolean}, // Used by 4 controls: FlatList, FlatTree, List, Tree
			new AttributeType { AttributeName = "TOPITEM", DataType = DataType.Int}, // Used by 4 controls: FlatList, FlatTree, List, Tree
			new AttributeType { AttributeName = "VISIBLELINES", DataType = DataType.Int, IsNullable = true}, // Used by 4 controls: FlatList, List, Multiline, Text
			new AttributeType { AttributeName = "LAYOUTDRAG", DataType = DataType.Boolean}, // Used by 4 controls: FlatScrollBox, SBox, ScrollBox, Split
			new AttributeType { AttributeName = "VALUE_HANDLE", DataType = DataType.Handle}, // Used by 4 controls: FlatTabs, Radio, Tabs, ZBox
			new AttributeType { AttributeName = "NORMALIZESIZE", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "HORIZONTAL", "VERTICAL", "BOTH", "NONE" } }, // Used by 4 controls: GridBox, HBox, Spin, VBox
			new AttributeType { AttributeName = "EXPANDCHILDREN", DataType = DataType.Boolean}, // Used by 3 controls: HBox, Spin, VBox

			new AttributeType { AttributeName = "EXPANDALL", DataType = DataType.Void}, // Used by 2 controls: FlatTree, Tree

			//iupBaseRegisterCommonAttrib
			new AttributeType { AttributeName = "WID", Group = AttributeGroup.Common, DataType = DataType.Int}, // Used by 63 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Image, ImageRgb, ImageRgba, Item, Label, Link, List, Menu, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Separator, Space, Spin, SpinBox, Split, SubMenu, Tabs, Text, Timer, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "NAME", Group = AttributeGroup.Common, DataType=DataType.String}, // Used by 59 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Item, Label, Link, List, Menu, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Separator, Space, Spin, SpinBox, Split, SubMenu, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "FLOATING", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "YES", "IGNORE", "NO" }}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "EXPAND", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "YES", "HORIZONTAL", "VERTICAL", "HORIZONTALFREE", "VERTICALFREE", "NO" }}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "NORMALIZERGROUP", Group = AttributeGroup.Common, DataType = DataType.String}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "EXPANDWEIGHT", Group = AttributeGroup.Common, DataType = DataType.Double}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "HANDLENAME", Group = AttributeGroup.Common, DataType = DataType.String}, // Used by 60 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Image, ImageRgb, ImageRgba, Item, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, SubMenu, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "NTHEME", Group = AttributeGroup.Common, DataType = DataType.String}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "THEME", Group = AttributeGroup.Common, DataType = DataType.String}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "CANFOCUS", Group = AttributeGroup.Common, DataType = DataType.Boolean}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "PROPAGATEFOCUS", Group = AttributeGroup.Common, DataType = DataType.Boolean}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "SIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size, IsNullable = true }, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "RASTERSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size, IsNullable = true }, // Used by 58 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Image, ImageRgb, ImageRgba, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "CHARSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size, IsNullable = true}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "NATURALSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size, IsNullable = true }, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "USERSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size, IsNullable = true }, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "POSITION", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.XYPos, }, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "MAXSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "MINSIZE", Group = AttributeGroup.Common, DataType=DataType.String, DataFormat=DataFormat.Size,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "FONT", Group = AttributeGroup.Common, DataType = DataType.String,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "FONTFACE", Group = AttributeGroup.Common, DataType = DataType.String,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "FONTSIZE", Group = AttributeGroup.Common, DataType = DataType.String,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "FONTSTYLE", Group = AttributeGroup.Common, DataType = DataType.String,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "HFONT", Group = AttributeGroup.Common, DataType = DataType.String,}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox

			//iupBaseRegisterVisualAttrib
			new AttributeType { AttributeName = "VISIBLE", Group = AttributeGroup.Visual, DataType = DataType.Boolean}, // Used by 55 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "ACTIVE", Group = AttributeGroup.Visual, DataType = DataType.Boolean}, // Used by 57 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, CBox, ColorBar, ColorBrowser, ColorDlg, DatePick, DetachBox, Dial, Dialog, DropButton, Expander, FileDlg, Fill, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, GridBox, HBox, Item, Label, Link, List, MessageDlg, MultiBox, Multiline, ParamBox, ProgressBar, ProgressDlg, Radio, SBox, ScrollBox, Space, Spin, SpinBox, Split, SubMenu, Tabs, Text, Toggle, Tree, Val, VBox, ZBox
			new AttributeType { AttributeName = "ZORDER", Group = AttributeGroup.Visual, DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "TOP", "BOTTOM" } }, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "Y", Group = AttributeGroup.Visual, DataType = DataType.Int}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "X", Group = AttributeGroup.Visual, DataType = DataType.Int}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "SCREENPOSITION", Group = AttributeGroup.Visual, DataType=DataType.String, DataFormat=DataFormat.XYPos}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIP", Group = AttributeGroup.Visual, DataType = DataType.String}, // Used by 40 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, Param, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPVISIBLE", Group = AttributeGroup.Visual, DataType = DataType.Boolean}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPDELAY", Group = AttributeGroup.Visual, DataType = DataType.Int}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPBGCOLOR", Group = AttributeGroup.Visual, DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPFGCOLOR", Group = AttributeGroup.Visual, DataType=DataType.String, DataFormat=DataFormat.Rgb,}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val
			new AttributeType { AttributeName = "TIPRECT", Group = AttributeGroup.Visual, DataType=DataType.String, DataFormat=DataFormat.Rect}, // Used by 39 controls: AnimatedLabel, BackgroundBox, Button, Calendar, Canvas, ColorBar, ColorBrowser, ColorDlg, DatePick, Dial, Dialog, DropButton, FileDlg, FlatButton, FlatFrame, FlatLabel, FlatList, FlatScrollBox, FlatSeparator, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Frame, Gauge, Label, Link, List, MessageDlg, Multiline, ProgressBar, ProgressDlg, ScrollBox, Tabs, Text, Toggle, Tree, Val

			new AttributeType { AttributeName = "SEPARATOR", ClassName = "label", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "HORIZONTAL", "VERTICAL" } },

			new AttributeType { AttributeName = "PREVIOUS"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "NEXT"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARKWHENTOGGLE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MOVENODE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "PARENT"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "IMAGELEAF"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "INSERTLEAF"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "INSERTBRANCH"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "INDENTATION"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "KIND"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARK"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARKED"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARKEDNODES"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARKMODE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "MARKSTART"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "LAST"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "LASTADDNODE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "ADDLEAF"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "ADDBRANCH"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "ADDEXPANDED"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "DELNODE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "DEPTH"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "COPYNODE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "CHILDCOUNT"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "DRAGDROPTREE"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "DROPEQUALDRAG"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "IMAGEBRANCHCOLLAPSED"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "IMAGEBRANCHEXPANDED"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "IMAGEEXPANDED"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "HIDEBUTTONS"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "HIDELINES"}, // Used by 2 controls: FlatTree, Tree
			new AttributeType { AttributeName = "FIRST"}, // Used by 2 controls: FlatTree, Tree

			new AttributeType { AttributeName = "PAGESTEP"}, // Used by 2 controls: FlatVal, Val

			new AttributeType { AttributeName = "DASHED"}, // Used by 2 controls: Gauge, ProgressBar

			new AttributeType { AttributeName = "FLATSCROLLBAR"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "FLOATINGDELAY"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_BACKCOLOR"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_FORECOLOR"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_HIGHCOLOR"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGEBOTTOM"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGEBOTTOMHIGHLIGHT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGEBOTTOMINACTIVE"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGEBOTTOMPRESS"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGELEFT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGELEFTHIGHLIGHT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGELEFTINACTIVE"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGELEFTPRESS"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGERIGHT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGERIGHTHIGHLIGHT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGERIGHTINACTIVE"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGERIGHTPRESS"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGETOP"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGETOPHIGHLIGHT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGETOPINACTIVE"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_IMAGETOPPRESS"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SB_PRESSCOLOR"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SHOWARROWS"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SCROLLBARSIZE"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SHOWFLOATING"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree
			new AttributeType { AttributeName = "SHOWTRANSPARENT"}, // Used by 3 controls: FlatList, FlatScrollBox, FlatTree

			new AttributeType { AttributeName = "ANIMATION_HANDLE", ClassName = "animatedlabel", DataType = DataType.Handle},
			new AttributeType { AttributeName = "FRAMECOUNT", ClassName = "animatedlabel"},
			new AttributeType { AttributeName = "RUNNING", ClassName = "animatedlabel"},
			new AttributeType { AttributeName = "STOP", ClassName = "animatedlabel"},
			new AttributeType { AttributeName = "STOPWHENHIDDEN", ClassName = "animatedlabel"},

			new AttributeType { AttributeName = "IMPRESSBORDER", ClassName = "button"},
			new AttributeType { AttributeName = "FOCUSONCLICK", ClassName = "button"},

			new AttributeType { AttributeName = "WEEKNUMBERS", ClassName = "calendar"},

			new AttributeType { AttributeName = "WMFAVAILABLE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "TEXTAVAILABLE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "FORMATAVAILABLE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "FORMATDATA", ClassName = "clipboard"},
			new AttributeType { AttributeName = "FORMATDATASIZE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "FORMATDATASTRING", ClassName = "clipboard"},
			new AttributeType { AttributeName = "IMAGEAVAILABLE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "EMFAVAILABLE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "ADDFORMAT", ClassName = "clipboard"},
			new AttributeType { AttributeName = "NATIVEIMAGE", ClassName = "clipboard"},
			new AttributeType { AttributeName = "SAVEEMF", ClassName = "clipboard"},
			new AttributeType { AttributeName = "SAVEWMF", ClassName = "clipboard"},

			new AttributeType { AttributeName = "PREVIEW_SIZE", ClassName = "colorbar"},
			new AttributeType { AttributeName = "PRIMARY_CELL", ClassName = "colorbar"},
			new AttributeType { AttributeName = "SECONDARY_CELL", ClassName = "colorbar"},
			new AttributeType { AttributeName = "SHADOWED", ClassName = "colorbar"},
			new AttributeType { AttributeName = "SQUARED", ClassName = "colorbar"},
			new AttributeType { AttributeName = "SHOW_SECONDARY", ClassName = "colorbar"},
			new AttributeType { AttributeName = "NUM_CELLS", ClassName = "colorbar"},
			new AttributeType { AttributeName = "NUM_PARTS", ClassName = "colorbar"},
			new AttributeType { AttributeName = "CELL", ClassName = "colorbar"},
			new AttributeType { AttributeName = "FOCUSSELECT", ClassName = "colorbar"},
			new AttributeType { AttributeName = "TRANSPARENCY", ClassName = "colorbar"},

			new AttributeType { AttributeName = "HSI", ClassName = "colorbrowser"},
			new AttributeType { AttributeName = "RGB", ClassName = "colorbrowser"},

			new AttributeType { AttributeName = "SHOWALPHA", ClassName = "colordlg"},
			new AttributeType { AttributeName = "SHOWCOLORTABLE", ClassName = "colordlg"},
			new AttributeType { AttributeName = "SHOWHELP", ClassName = "colordlg"},
			new AttributeType { AttributeName = "SHOWHEX", ClassName = "colordlg"},
			new AttributeType { AttributeName = "COLORTABLE", ClassName = "colordlg"},
			new AttributeType { AttributeName = "ALPHA", ClassName = "colordlg"},
			new AttributeType { AttributeName = "VALUEHEX", ClassName = "colordlg"},
			new AttributeType { AttributeName = "VALUEHSI", ClassName = "colordlg"},

			new AttributeType { AttributeName = "ZEROPRECED", ClassName = "datepick"},
			new AttributeType { AttributeName = "CALENDARWEEKNUMBERS", ClassName = "datepick"},
			new AttributeType { AttributeName = "ORDER", ClassName = "datepick"},
			new AttributeType { AttributeName = "MONTHSHORTNAMES", ClassName = "datepick"},

			new AttributeType { AttributeName = "OLDBROTHER_HANDLE", ClassName = "detachbox", DataType = DataType.Handle},
			new AttributeType { AttributeName = "OLDPARENT_HANDLE", ClassName = "detachbox", DataType = DataType.Handle},
			new AttributeType { AttributeName = "RESTORE", ClassName = "detachbox"},
			new AttributeType { AttributeName = "RESTOREWHENCLOSED", ClassName = "detachbox"},
			new AttributeType { AttributeName = "DETACH", ClassName = "detachbox"},

			new AttributeType { AttributeName = "DENSITY", ClassName = "dial"},
			new AttributeType { AttributeName = "UNIT", ClassName = "dial"},

			new AttributeType { AttributeName = "ARROWPADDING", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWSIZE", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWACTIVE", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWALIGN", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWCOLOR", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWIMAGE", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWIMAGEHIGHLIGHT", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWIMAGEINACTIVE", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "ARROWIMAGEPRESS", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "DROPCHILD", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "DROPCHILD_HANDLE", ClassName = "dropbutton", DataType = DataType.Handle},
			new AttributeType { AttributeName = "DROPONARROW", ClassName = "dropbutton"},
			new AttributeType { AttributeName = "DROPPOSITION", ClassName = "dropbutton"},

			new AttributeType { AttributeName = "AUTOSHOW", ClassName = "expander"},
			new AttributeType { AttributeName = "BARPOSITION", ClassName = "expander"},
			new AttributeType { AttributeName = "STATEREFRESH", ClassName = "expander"},
			new AttributeType { AttributeName = "NUMFRAMES", ClassName = "expander"},
			new AttributeType { AttributeName = "OPENCOLOR", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEOPEN", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEOPENHIGHLIGHT", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRA1", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRA2", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRA3", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAHIGHLIGHT1", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAHIGHLIGHT2", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAHIGHLIGHT3", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAPRESS1", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAPRESS2", ClassName = "expander"},
			new AttributeType { AttributeName = "IMAGEEXTRAPRESS3", ClassName = "expander"},
			new AttributeType { AttributeName = "TITLEIMAGEHIGHLIGHT", ClassName = "expander"},
			new AttributeType { AttributeName = "TITLEIMAGEOPEN", ClassName = "expander"},
			new AttributeType { AttributeName = "TITLEIMAGEOPENHIGHLIGHT", ClassName = "expander"},
			new AttributeType { AttributeName = "TITLEEXPAND", ClassName = "expander"},

			new AttributeType { AttributeName = "NOPLACESBAR", ClassName = "filedlg"},
			new AttributeType { AttributeName = "MULTIPLEFILES", ClassName = "filedlg"},
			new AttributeType { AttributeName = "MULTIVALUEPATH", ClassName = "filedlg"},
			new AttributeType { AttributeName = "SHOWHIDDEN", ClassName = "filedlg"},
			new AttributeType { AttributeName = "PREVIEWWIDTH", ClassName = "filedlg"},
			new AttributeType { AttributeName = "PREVIEWDC", ClassName = "filedlg"},
			new AttributeType { AttributeName = "PREVIEWHEIGHT", ClassName = "filedlg"},
			new AttributeType { AttributeName = "ALLOWNEW", ClassName = "filedlg", DataType = DataType.Boolean},
			new AttributeType { AttributeName = "EXTDEFAULT", ClassName = "filedlg", DataType = DataType.String},
			new AttributeType { AttributeName = "EXTFILTER", ClassName = "filedlg", DataType = DataType.String},
			new AttributeType { AttributeName = "FILE", ClassName = "filedlg"},
			new AttributeType { AttributeName = "FILEEXIST", ClassName = "filedlg"},
			new AttributeType { AttributeName = "FILTERINFO", ClassName = "filedlg"},
			new AttributeType { AttributeName = "FILTERUSED", ClassName = "filedlg"}
			,
			new AttributeType { AttributeName = "TOGGLE", ClassName = "flatbutton"},

			new AttributeType { AttributeName = "TITLEIMAGEPOSITION", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLEIMAGESPACING", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLELINE", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLELINECOLOR", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLELINEWIDTH", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLEPADDING", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLETEXTALIGNMENT", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLETEXTCLIP", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLETEXTELLIPSIS", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLETEXTORIENTATION", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLETEXTWRAP", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLEALIGNMENT", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLEBGCOLOR", ClassName = "flatframe"},
			new AttributeType { AttributeName = "TITLECOLOR", ClassName = "flatframe"},
			new AttributeType { AttributeName = "FRAMESPACE", ClassName = "flatframe"},

			new AttributeType { AttributeName = "ITEMBGCOLOR", ClassName = "flatlist"},
			new AttributeType { AttributeName = "ITEMFGCOLOR", ClassName = "flatlist"},
			new AttributeType { AttributeName = "ITEMFONT", ClassName = "flatlist"},
			new AttributeType { AttributeName = "ITEMFONTSIZE", ClassName = "flatlist"},
			new AttributeType { AttributeName = "ITEMFONTSTYLE", ClassName = "flatlist"},

			new AttributeType { AttributeName = "STYLE", ClassName = "flatseparator"},

			new AttributeType { AttributeName = "TABACTIVE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABBACKCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABCHANGEONCHECK", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABFONT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABFONTSIZE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABFONTSTYLE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABFORECOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABHIGHCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSALIGNMENT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSBACKCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSFONT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSFONTSIZE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSFONTSTYLE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSFORECOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSHIGHCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSIMAGEPOSITION", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSIMAGESPACING", ClassName = "flattabs"},
			new AttributeType { AttributeName = "SHOWLINES", ClassName = "flattabs"},
			new AttributeType { AttributeName = "FIXEDWIDTH", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAACTIVE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAALIGNMENT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRABORDERCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRABORDERWIDTH", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRATIP", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRATITLE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRATOGGLE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAVALUE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAFONT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAFORECOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAHIGHCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAIMAGE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAIMAGEHIGHLIGHT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAIMAGEINACTIVE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAIMAGEPRESS", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRAPRESSCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXTRASHOWBORDER", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXPANDBUTTON", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXPANDBUTTONPOS", ClassName = "flattabs"},
			new AttributeType { AttributeName = "EXPANDBUTTONSTATE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEHIGHCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEIMAGE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEIMAGEHIGHLIGHT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEIMAGEINACTIVE", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEIMAGEPRESS", ClassName = "flattabs"},
			new AttributeType { AttributeName = "CLOSEPRESSCOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSLINECOLOR", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSPADDING", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSTEXTALIGNMENT", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSTEXTCLIP", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSTEXTELLIPSIS", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSTEXTORIENTATION", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABSTEXTWRAP", ClassName = "flattabs"},
			new AttributeType { AttributeName = "TABTIP", ClassName = "flattabs"},

			new AttributeType { AttributeName = "CHECKALIGN", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKBGCOLOR", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKFGCOLOR", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKHLCOLOR", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGE", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEHIGHLIGHT", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEINACTIVE", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGENOTDEF", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGENOTDEFHIGHLIGHT", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGENOTDEFINACTIVE", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGENOTDEFPRESS", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEON", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEONHIGHLIGHT", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEONINACTIVE", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEONPRESS", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKIMAGEPRESS", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKPSCOLOR", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKRIGHT", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKSIZE", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "CHECKSPACING", ClassName = "flattoggle"},
			new AttributeType { AttributeName = "SELECTEDNOTIFY", ClassName = "flattoggle"},

			new AttributeType { AttributeName = "LINECOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONBGCOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONBRDCOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONSIZE", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONFGCOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONMINUSIMAGE", ClassName = "flattree"},
			new AttributeType { AttributeName = "BUTTONPLUSIMAGE", ClassName = "flattree"},
			new AttributeType { AttributeName = "EXTRATEXT", ClassName = "flattree"},
			new AttributeType { AttributeName = "EXTRATEXTWIDTH", ClassName = "flattree"},
			new AttributeType { AttributeName = "EMPTYTOGGLE", ClassName = "flattree"},
			new AttributeType { AttributeName = "TOGGLEBGCOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "TOGGLEFGCOLOR", ClassName = "flattree"},
			new AttributeType { AttributeName = "TOGGLESIZE", ClassName = "flattree"},

			new AttributeType { AttributeName = "HANDLERSIZE", ClassName = "flatval"},
			new AttributeType { AttributeName = "SLIDERBORDERCOLOR", ClassName = "flatval"},
			new AttributeType { AttributeName = "SLIDERCOLOR", ClassName = "flatval"},
			new AttributeType { AttributeName = "SLIDERSIZE", ClassName = "flatval"},

			new AttributeType { AttributeName = "SHOWCOLOR", ClassName = "fontdlg"},

			new AttributeType { AttributeName = "SUNKEN", ClassName = "frame"},

			new AttributeType { AttributeName = "SHOW_TEXT", ClassName = "gauge"},

			new AttributeType { AttributeName = "SIZECOL", ClassName = "gridbox"},
			new AttributeType { AttributeName = "SIZELIN", ClassName = "gridbox"},
			new AttributeType { AttributeName = "NCGAPCOL", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "NCGAPLIN", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "NUMDIV", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "NGAPCOL", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "NGAPLIN", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "GAPCOL", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "GAPLIN", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "HOMOGENEOUSCOL", ClassName = "gridbox"},
			new AttributeType { AttributeName = "HOMOGENEOUSLIN", ClassName = "gridbox"},
			new AttributeType { AttributeName = "FITTOCHILDREN", ClassName = "gridbox"},
			new AttributeType { AttributeName = "ALIGNMENTCOL", ClassName = "gridbox"},
			new AttributeType { AttributeName = "ALIGNMENTLIN", ClassName = "gridbox"},
			new AttributeType { AttributeName = "CGAPCOL", ClassName = "gridbox", DataType = DataType.Int},
			new AttributeType { AttributeName = "CGAPLIN", ClassName = "gridbox", DataType = DataType.Int},

			new AttributeType { AttributeName = "AUTOTOGGLE", ClassName = "item", DataType = DataType.Boolean },
			new AttributeType { AttributeName = "VALUE", ClassName = "item", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ON", "OFF" } }, // Used by 27 controls: Calendar, ColorDlg, DatePick, Dial, FileDlg, FlatButton, FlatList, FlatTabs, FlatToggle, FlatTree, FlatVal, FontDlg, Gauge, Item, List, MessageDlg, Multiline, Param, ProgressBar, Radio, Split, Tabs, Text, Toggle, Tree, Val, ZBox

			new AttributeType { AttributeName = "URL", ClassName = "link", DataType = DataType.String},

			new AttributeType { AttributeName = "VISIBLE_ITEMS", ClassName = "list"},
			new AttributeType { AttributeName = "EDITBOX", ClassName = "list"},
			new AttributeType { AttributeName = "DROPEXPAND", ClassName = "list"},
			new AttributeType { AttributeName = "DROPDOWN", ClassName = "list"},
			new AttributeType { AttributeName = "SHOWIMAGE", ClassName = "list"},

			new AttributeType { AttributeName = "BUTTONRESPONSE", ClassName = "messagedlg", DataType = DataType.Int},
			new AttributeType { AttributeName = "BUTTONS", ClassName = "messagedlg", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "OKCANCEL", "RETRYCANCEL", "YESNO", "YESNOCANCEL", "OK" } },
			new AttributeType { AttributeName = "BUTTONDEFAULT", ClassName = "messagedlg", DataType = DataType.Int },
			new AttributeType { AttributeName = "AUTOMODAL", ClassName = "messagedlg", DataType = DataType.Boolean},

			new AttributeType { AttributeName = "CGAPVERT", ClassName = "multibox"},
			new AttributeType { AttributeName = "CGAPHORIZ", ClassName = "multibox"},
			new AttributeType { AttributeName = "CHILDMAXSIZE", ClassName = "multibox"},
			new AttributeType { AttributeName = "CHILDMINSPACE", ClassName = "multibox"},
			new AttributeType { AttributeName = "GAPVERT", ClassName = "multibox"},
			new AttributeType { AttributeName = "GAPHORIZ", ClassName = "multibox"},
			new AttributeType { AttributeName = "NGAPVERT", ClassName = "multibox"},
			new AttributeType { AttributeName = "NGAPHORIZ", ClassName = "multibox"},
			new AttributeType { AttributeName = "NCGAPVERT", ClassName = "multibox"},
			new AttributeType { AttributeName = "NCGAPHORIZ", ClassName = "multibox"},

			new AttributeType { AttributeName = "NORMALIZE", ClassName = "normalizer"},
			new AttributeType { AttributeName = "DELCONTROL", ClassName = "normalizer"},
			new AttributeType { AttributeName = "DELCONTROL_HANDLE", ClassName = "normalizer", DataType = DataType.Handle},
			new AttributeType { AttributeName = "ADDCONTROL", ClassName = "normalizer"},
			new AttributeType { AttributeName = "ADDCONTROL_HANDLE", ClassName = "normalizer", DataType = DataType.Handle},

			new AttributeType { AttributeName = "ANGLE", ClassName = "param"},
			new AttributeType { AttributeName = "AUXCONTROL", ClassName = "param"},
			new AttributeType { AttributeName = "DATATYPE", ClassName = "param"},
			new AttributeType { AttributeName = "FALSE", ClassName = "param"},
			new AttributeType { AttributeName = "NOFRAME", ClassName = "param"},
			new AttributeType { AttributeName = "PARTIAL", ClassName = "param"},
			new AttributeType { AttributeName = "LABEL", ClassName = "param"},
			new AttributeType { AttributeName = "INTERVAL", ClassName = "param"},
			new AttributeType { AttributeName = "INDENT", ClassName = "param"},
			new AttributeType { AttributeName = "INDEX", ClassName = "param"},
			new AttributeType { AttributeName = "PRECISION", ClassName = "param"},
			new AttributeType { AttributeName = "TRUE", ClassName = "param"},

			new AttributeType { AttributeName = "LABELALIGN", ClassName = "parambox"},
			new AttributeType { AttributeName = "PARAMCOUNT", ClassName = "parambox"},
			new AttributeType { AttributeName = "MODIFIABLE", ClassName = "parambox"},

			new AttributeType { AttributeName = "MARQUEE", ClassName = "progressbar"},

			new AttributeType { AttributeName = "MINCLOCK", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "MINPERCENT", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "INC", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "PERCENT", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "PROGRESSHEIGHT", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "DESCRIPTION", ClassName = "progressdlg"},
			new AttributeType { AttributeName = "TOTALCOUNT", ClassName = "progressdlg"},

			new AttributeType { AttributeName = "MINMAX", ClassName = "split"},

			new AttributeType { AttributeName = "TABPADDING", ClassName = "tabs"},

			new AttributeType { AttributeName = "YIELD", ClassName = "thread"},
			new AttributeType { AttributeName = "LOCK", ClassName = "thread"},
			new AttributeType { AttributeName = "JOIN", ClassName = "thread"},
			new AttributeType { AttributeName = "ISCURRENT", ClassName = "thread"},
			new AttributeType { AttributeName = "EXIT", ClassName = "thread"},

			new AttributeType { AttributeName = "RUN", ClassName = "timer"},
			new AttributeType { AttributeName = "TIME", ClassName = "timer"},

			new AttributeType { AttributeName = "RIGHTBUTTON", ClassName = "toggle"},
			new AttributeType { AttributeName = "3STATE", ClassName = "toggle"},
			new AttributeType { AttributeName = "VALUE", ClassName = "toggle", DataType=DataType.String, DataFormat=DataFormat.Enum, EnumValues = new EnumValue[] { "ON", "OFF", "NOTDEF" } },

			new AttributeType { AttributeName = "ADDROOT", ClassName = "tree"},
			new AttributeType { AttributeName = "CTRL", ClassName = "tree"},
			new AttributeType { AttributeName = "EMPTYAS3STATE", ClassName = "tree"},
			new AttributeType { AttributeName = "SHIFT", ClassName = "tree"},
			new AttributeType { AttributeName = "STARTING", ClassName = "tree"},
			new AttributeType { AttributeName = "INFOTIP", ClassName = "tree"},

			new AttributeType { AttributeName = "CLEARATTRIBUTES", ClassName = "user"},

			new AttributeType { AttributeName = "INVERTED", ClassName = "val"},
			new AttributeType { AttributeName = "SHOWTICKS", ClassName = "val"},
			new AttributeType { AttributeName = "TICKSPOS", ClassName = "val"},
		};

		#endregion Fields

		#region Methods

		#region Documentation

		/// <summary>
		/// Adds metadata information from manually inspected IUP's source souce, like typed data type and formatting
		/// </summary>

		#endregion Documentation

		public static void Enrich(IupClass item)
		{
			foreach (var attribute in item.Attributes)
			{
				var match = Values.FirstOrDefault(x => x.ClassName != null && x.ClassName.Equals(item.ClassName, StringComparison.InvariantCultureIgnoreCase) && x.AttributeName.Equals(attribute.AttributeName, StringComparison.InvariantCultureIgnoreCase));
				if (match == null)
				{
					match = Values.FirstOrDefault(x => x.ClassName == null && x.AttributeName.Equals(attribute.AttributeName, StringComparison.InvariantCultureIgnoreCase));
				}

				if (match != null)
				{
					attribute.DataType = match.DataType;
					attribute.DataFormat = match.DataFormat;
					attribute.HandleName = match.HandleName;
					attribute.EnumValues = match.EnumValues;
					attribute.IsNullable = match.IsNullable;
				}
			}
		}

		#endregion Methods
	}
}