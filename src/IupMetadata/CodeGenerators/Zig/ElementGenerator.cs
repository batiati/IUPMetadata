using Humanizer;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IupMetadata.CodeGenerators.Zig
{
	internal static class ElementGenerator
	{
		public static void Generate(string basePath, IupClass item)
		{
			var template = Templates.element;
			template = template.Replace("{{ElementDocumentation}}", Generator.GetDocumentation(item.Documentation));
			template = template.Replace("{{EnumsDecl}}", GetEnumDecl(item));
			template = template.Replace("{{CallbacksDecl}}", GetCallbacksDecl(item));
			template = template.Replace("{{Name}}", item.Name);
			template = template.Replace("{{ClassName}}", item.ClassName);
			template = template.Replace("{{InitializerBlock}}", GetInitializerBlock(item));
			template = template.Replace("{{BodyBlock}}", GetBodyBlock(item));
			template = template.Replace("{{BodyTraits}}", GetBodyTraits(item));
			template = template.Replace("{{InitializerTraits}}", GetInitializerTraits(item));

			var fileName = item.Name.Underscore();
			var path = Path.Combine(basePath, $"elements\\{fileName}.zig");
			File.WriteAllText(path, template);

			Generator.Fmt(path);
		}

		private static string GetCallbacksDecl(IupClass item)
		{
			string getZigType(DataType dataType) => dataType switch
			{
				DataType.Void => "void",
				DataType.Int => "i32",
				DataType.RefInt => "*i32",
				DataType.Boolean => "bool",
				DataType.Float => "f32",
				DataType.Double => "f64",
				DataType.Char => "u8",
				DataType.String => "[:0]const u8",
				DataType.Handle => "iup.Element",
				DataType.VoidPtr => "*iup.Unknow",
				DataType.Canvas => "*iup.Canvas",
				_ => throw new NotImplementedException()
			};

			var builder = new StringBuilder();
			foreach (var callback in item.Callbacks)
			{
				var args = new StringBuilder();
				for (int i = 0; i < callback.Arguments.Length; i++)
				{
					args.Append($", arg{i}: {getZigType(callback.Arguments[i])}");
				}

				builder.Append($@"

				{Generator.GetDocumentation(callback.Documentation)}
				pub const On{callback.Name}Fn = fn(self: *Self{args}) anyerror!{getZigType(callback.ReturnType)};");
			}

			return builder.ToString();
		}

		private static string GetInitializerBlock(IupClass item)
		{
			var builder = new StringBuilder();
			foreach (var attribute in item.Attributes)
			{
				builder.AppendLine(GetBodySetBlock(attribute, isInitializer: true));
			}

			foreach (var callback in item.Callbacks)
			{
				builder.AppendLine(GetCallbackSetBlock(callback, isInitializer: true));
			}

			return builder.ToString();
		}

		private static string GetBodyBlock(IupClass item)
		{
			var builder = new StringBuilder();
			foreach (var attribute in item.Attributes)
			{
				builder.AppendLine(GetBodyGetBlock(attribute));
				builder.AppendLine(GetBodySetBlock(attribute, isInitializer: false));
			}

			foreach (var callback in item.Callbacks)
			{
				builder.AppendLine(GetCallbackSetBlock(callback, isInitializer: false));
			}

			return builder.ToString();
		}

		private static string GetBodySetBlock(IupAttribute attribute, bool isInitializer)
		{
			if (attribute.CreationOnly && !isInitializer) return string.Empty;
			if (attribute.ReadOnly) return string.Empty;

			var type = isInitializer ? "*Initializer" : "*Self";
			var ret = isInitializer ? "Initializer" : "void";
			var self = isInitializer ? "self.ref" : "self";
			var @return = isInitializer ? "return self.*;" : "";

			var decl = attribute.DataType switch
			{
				DataType.Int => $@"

				pub fn set{attribute.Name}(self: {type}, arg: i32) {ret} {{
					c.setIntAttribute({self}, ""{attribute.AttributeName}"", arg);
					{@return}
				}}

				",

				DataType.String => $@"

				pub fn set{attribute.Name}(self: {type}, arg: [:0]const u8) {ret} {{
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", arg);
					{@return}
				}}

				",

				DataType.Boolean => $@"

				pub fn set{attribute.Name}(self: {type}, arg: bool) {ret} {{
					c.setBoolAttribute({self}, ""{attribute.AttributeName}"", arg);
					{@return}
				}}

				",

				DataType.Void => $@"

				pub fn {attribute.Name.Camelize()}(self: {type}) {ret} {{
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", null);
					{@return}
				}}

				",

				DataType.Size => $@"

				pub fn set{attribute.Name}(self: {type}, width: ?i32, height: ?i32) {ret} {{
					var buffer: [128]u8 = undefined;
					var value = Size.intIntToString(&buffer, width, height);
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", value);
					{@return}
				}}

				",

				DataType.Margin => $@"

				pub fn set{attribute.Name}(self: {type}, horiz: i32, vert: i32) {ret} {{
					var buffer: [128]u8 = undefined;
					var value = Margin.intIntToString(&buffer, horiz, vert);
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", value);
					{@return}
				}}

				",

				DataType.LinColPos => @$"

				pub fn set{attribute.Name}(self: {type}, lin: i32, col: i32) {ret} {{
					var buffer: [128]u8 = undefined;
					var value = iup.LinColPos.intIntToString(&buffer, lin, col, ',');
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", value);
					{@return}
				}}

				",

				DataType.XYPos => @$"

				pub fn set{attribute.Name}(self: {type}, x: i32, y: i32) {ret} {{
					var buffer: [128]u8 = undefined;
					var value = iup.XYPos.intIntToString(&buffer, x, y, ',');
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", value);
					{@return}
				}}

				",

				DataType.Range => @$"

				pub fn set{attribute.Name}(self: {type}, begin: i32, end: i32) {ret} {{
					var buffer: [128]u8 = undefined;
					var value = iup.Range.intIntToString(&buffer, begin, end, ',');
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", value);
					{@return}
				}}

				",

				DataType.DialogSize => $@"

				pub fn set{attribute.Name}(self: {type}, width: ?iup.ScreenSize, height: ?iup.ScreenSize) {ret} {{
					var buffer: [128]u8 = undefined;
					var str = iup.DialogSize.screenSizeToString(&buffer, width, height);
					c.setStrAttribute({self}, ""{attribute.AttributeName}"", str);
					{@return}
				}}

				",

				DataType.Enum when attribute.EnumAsInteger == true => $@"

				pub fn set{attribute.Name}(self: {type}, arg: ?{attribute.Name}) {ret} {{
					if (arg) |value| {{
						c.setIntAttribute({self}, ""{attribute.AttributeName}"", @enumToInt(arg));
					}} else {{
						c.clearAttribute({self}, ""{attribute.AttributeName}"");
					}}
					{@return}
				}}
				",

				DataType.Enum => $@"

				pub fn set{attribute.Name}(self: {type}, arg: ?{attribute.Name}) {ret} {{
					if (arg) |value| switch (value) {{
						{string.Join("\n", attribute.EnumValues.Select(x => $@".{x.Name} => c.setStrAttribute({self}, ""{attribute.AttributeName}"", ""{x.StrValue}""),"))}
					}} else {{
						c.clearAttribute({self}, ""{attribute.AttributeName}"");
					}}
					{@return}
				}}
				",

				DataType.Handle when attribute.HandleName != null => $@"

				pub fn set{attribute.Name}(self: {type}, arg: *iup.{attribute.HandleName}) {ret} {{
					c.setHandleAttribute({self}, ""{attribute.AttributeName}"", arg);
					{@return}
				}}

				",

				_ => ""
			};

			if (string.IsNullOrEmpty(decl)) return string.Empty;

			var builder = new StringBuilder();
			builder.Append(Generator.GetDocumentation(attribute.Documentation));
			builder.Append(decl);

			return builder.ToString();
		}

		private static string GetBodyGetBlock(IupAttribute attribute)
		{
			if (attribute.CreationOnly) return string.Empty;
			if (attribute.WriteOnly) return string.Empty;

			var decl = attribute.DataType switch
			{
				DataType.Int => $@"

				pub fn get{attribute.Name}(self: *Self) i32 {{
					return c.getIntAttribute(self, ""{attribute.AttributeName}"");
				}}

				",

				DataType.String => $@"

				pub fn get{attribute.Name}(self: *Self) [:0]const u8 {{
					return c.getStrAttribute(self, ""{attribute.AttributeName}"");
				}}

				",

				DataType.Boolean => $@"

				pub fn get{attribute.Name}(self: *Self) bool {{
					c.getBoolAttribute(self, ""{attribute.AttributeName}"");
				}}

				",

				DataType.Size => $@"

				pub fn get{attribute.Name}(self: *Self) Size {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return Size.parse(str);
				}}

				",

				DataType.Margin => $@"

				pub fn get{attribute.Name}(self: *Self) Margin {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return Margin.parse(str);
				}}

				",

				DataType.DialogSize => $@"

				pub fn get{attribute.Name}(self: *Self) iup.DialogSize {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return iup.DialogSize.parse(str);
				}}
				",

				DataType.LinColPos => @$"

				pub fn get{attribute.Name}(self: *Self) iup.LinColPos {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return iup.LinColPos.parse(str, ',');
				}}

				",

				DataType.XYPos => @$"

				pub fn get{attribute.Name}(self: *Self) iup.XYPos {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return iup.XYPos.parse(str, ',');
				}}

				",

				DataType.Range => @$"

				pub fn get{attribute.Name}(self: *Self) iup.Range {{
					var str = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					return iup.Range.parse(str, ',');
				}}

				",

				DataType.Handle when attribute.HandleName != null => $@"

				pub fn get{attribute.Name}(self: *Self) ?*iup.{attribute.HandleName} {{
					if (c.getHandleAttribute(self, ""{attribute.AttributeName}"")) |handle| {{
						return @ptrCast(*iup.{attribute.HandleName}, handle);
					}} else {{
						return null;
					}}
				}}

				",

				DataType.Enum when attribute.EnumAsInteger == true => $@"

				pub fn get{attribute.Name}(self: *Self) {attribute.Name} {{
					var ret = c.getIntAttribute(self, ""{attribute.AttributeName}"");
					return @intToEnum({attribute.Name}, ret);
				}}

				",

				DataType.Enum => $@"

				pub fn get{attribute.Name}(self: *Self) ?{attribute.Name} {{
					var ret = c.getStrAttribute(self, ""{attribute.AttributeName}"");
					{string.Join("", attribute.EnumValues.Select(x => $@"
					if (std.ascii.eqlIgnoreCase(""{x.StrValue}"", ret)) return .{x.Name};"))}
					return null;
				}}

				",

				_ => ""
			};

			if (string.IsNullOrEmpty(decl)) return string.Empty;

			var builder = new StringBuilder();
			builder.Append(Generator.GetDocumentation(attribute.Documentation));
			builder.Append(decl);

			return builder.ToString();
		}

		private static string GetCallbackSetBlock(IupCallback callback, bool isInitializer)
		{
			var type = isInitializer ? "*Initializer" : "*Self";
			var ret = isInitializer ? "Initializer" : "void";
			var self = isInitializer ? "self.ref" : "self";
			var @return = isInitializer ? "return self.*;" : "";

			return $@"

				{Generator.GetDocumentation(callback.Documentation)}
				pub fn set{callback.Name}Callback(self: {type}, callback: ?On{callback.Name}Fn) {ret} {{
					const Handler = traits.CallbackHandler(Self, On{callback.Name}Fn, ""{callback.AttributeName}"");
					Handler.setCallback({self}, callback);
					{@return}
				}}
			";
		}

		private static string GetInitializerTraits(IupClass item)
		{
			StringBuilder builder = new StringBuilder();

			if (item.ChildrenCount != 0)
			{
				builder.AppendLine(@"

					pub fn setChildren(self: *Initializer, tuple: anytype) Initializer {
						if (self.last_error) |_| return self.*;

						Self.appendChildren(self.ref, tuple) catch |err| {
							self.last_error = err;
						};

						return self.*;
					}
				");
			}

			return builder.ToString();
		}

		private static string GetBodyTraits(IupClass item)
		{
			StringBuilder builder = new StringBuilder();

			if (item.ChildrenCount != 0)
			{
				builder.AppendLine(@"

					///
					/// Adds a tuple of children
					pub fn appendChildren(self: *Self, tuple: anytype) !void {
						try traits.container.Body(Self).appendChildren(self, tuple);
					}

					///
					/// Appends a child on this container
					/// child must be an Element or
					pub fn appendChild(self: *Self, child: anytype) !void {
						try traits.container.Body(Self).appendChild(self, child);
					}

					///
					/// Returns a iterator for children elements.
					pub fn children(self: *Self) ChildrenIterator {
						return ChildrenIterator.init(self);
					}

				");
			}

			if (item.NativeType == NativeType.Dialog)
			{
				builder.AppendLine(@"

					pub fn showXY(self: *Self, x: iup.DialogPosX, y: iup.DialogPosY) !void {
						const ret = c.IupShowXY(@ptrCast(*c.Ihandle, self), @enumToInt(x) , @enumToInt(y));
						if (ret == c.IUP_ERROR) {
							debug.print(""{} ret={}\n"", .{ Error.OpenFailed, ret });
							return Error.OpenFailed;
						}
					}

					pub fn popup(self: *Self, x: iup.DialogPosX, y: iup.DialogPosY) void {
						_ = c.IupPopup(c.getHandle(self), @enumToInt(x) , @enumToInt(y));
					}

					pub fn hide(self: *Self) !void {
						_ = c.IupHide(c.getHandle(self));
					}
				");
			}
			else
			{
				builder.AppendLine(@"

					///
					///
					pub fn getDialog(self: *Self) ?*iup.Dialog {
						if (c.IupGetDialog(c.getHandle(self))) |handle| {
							return c.fromHandle(iup.Dialog, handle);
						} else {
							return null;
						}
					}
				");
			}

			if (item.ClassName == "text" || item.ClassName == "multiline")
			{
				builder.Append(@"

					///
					/// Converts a (lin, col) character positioning into an absolute position. lin and col starts at 1, pos starts at 0. For single line controls pos is always ""col - 1"". (since 3.0)
					pub fn convertLinColToPos(self: *Self, lin : i32, col : i32) ?i32 {
						return traits.container.Body(Self).convertLinColToPos(self, lin, col);
					}

					///
					///
					pub fn convertPosToLinCol(self: *Self, pos: i32) ?iup.LinColPos {
						return traits.container.Body(Self).convertPosToLinCol(self, pos);
					}

				");
			}

			builder.Append(@"

				///
				/// Returns the the child element that has the NAME attribute equals to the given value on the same dialog hierarchy.
				/// Works also for children of a menu that is associated with a dialog.
				pub fn getDialogChild(self: *Self, byName: [:0]const u8) ?Element {
					var child = c.IupGetDialogChild(c.getHandle(self), c.toCStr(byName)) orelse return null;
					var className = c.fromCStr(c.IupGetClassName(child));

					return Element.fromClassName(className, child);
				}

				///
				/// Updates the size and layout of all controls in the same dialog.
				/// To be used after changing size attributes, or attributes that affect the size of the control. Can be used for any element inside a dialog, but the layout of the dialog and all controls will be updated. It can change the layout of all the controls inside the dialog because of the dynamic layout positioning.
				pub fn refresh(self: *Self) void {
					try traits.container.Body(Self).refresh(self);
				}

			");

			return builder.ToString();
		}

		private static string GetEnumDecl(IupClass item)
		{
			var builder = new StringBuilder();
			foreach (var attribute in item.Attributes)
			{
				if (attribute.EnumValues == null || attribute.EnumValues.Length == 0) continue;

				builder.AppendLine(Generator.GetDocumentation(attribute.Documentation));
				builder.AppendLine($@"pub const {attribute.Name} = enum{(attribute.EnumAsInteger ? "(i32)" : "")} {{");

				foreach (var value in attribute.EnumValues)
				{
					builder.AppendLine($"{value.Name}{(value.IntValue != null ? $" = {value.IntValue}" : "")},");
				}

				builder.AppendLine($@"}};");
			}

			return builder.ToString();
		}
	}
}