# IUP Metadata and Code Generators 

## WIP - Work in Progress

[IUP Toolkit](https://webserver2.tecgraf.puc-rio.br/iup/) is a solid and well-proven portable GUI toolkit that exposes a simple raw C API, so it can be used via [FFI](https://en.wikipedia.org/wiki/Foreign_function_interface).

More information can be found at
https://webserver2.tecgraf.puc-rio.br/iup/

This project aims to collect rich metadata information about IUP's elements, enabling code-gen tools to create type-checked bindings for **any** programing language.

## Type-checked

As IUP's API is largely based on key-value string attributes, this metadata can be useful to improve the developer experience through a fully typed and idiomatic API by removing the need for string based actions.

Metadata:

```Json
  {
    "ClassName": "dialog",
    "Name": "Dialog",
    "Attributes": [
      {
        "AttributeName": "TITLE",
        "Name": "Title",
        "DataType": "String",
      },
      {
        "AttributeName": "DIALOGFRAME",
        "Name": "DialogFrame",
        "DataType": "Boolean",
      }
    ]
  },
  {
    "ClassName": "button",
    "Name": "Button",
    "Attributes": [
      {
        "AttributeName": "PADDING",
        "Name": "Padding",
        "DataType": "String",
        "DataFormat": "Size",
        "Default": "0x0"
      },
      {
        "AttributeName": "IMAGEPOSITION",
        "Name": "ImagePosition",
        "DataType": "String",
        "DataFormat": "Enum",
        "EnumValues": [
          {
            "Name": "Left",
            "StrValue": "LEFT",
          },
          {
            "Name": "Right",
            "StrValue": "RIGHT",
          },
          {
            "Name": "Bottom",
            "StrValue": "BOTTOM",
          },
          {
            "Name": "Top",
            "StrValue": "TOP",
          }
        ],
        "Default": "LEFT",
      }
    ]
  }
```

Original IUP API in C:

```C
Ihandle* dlg = IupDialog(NULL);
IupSetAttribute(dlg, "TITLE", "Find");
IupSetAttribute(dlg, "DIALOGFRAME", "Yes");

Ihandle* bt_close = IupButton("Close", NULL);
IupSetCallback(bt_close, "IMAGEPOSITION", "LEFT");
IupSetAttribute(bt_close, "PADDING", "10x2");
```

Type-checked Zig API generated from metadata:

```Zig
var dlg = Dialog.init();
dlg.setTitle("Find");
dlg.setDialogFrame(true);

var bt_close = Button.init();
bt_close.setTitle("Close");
bt_close.setImagePosition(.Left);
bt_close.setPadding(10, 2);
```

## Documentation

Additionally, this project also provides documentation snippets extracted directly from the official HTML page, allowing the generated code to use the target programing language documentation conventions and IDE convenience tools.

```Json
	{
	"Documentation": "SIZE (non inheritable): Dialogs size. Additionally the following values can also be defined for width and/or height: \"FULL\": Defines the dialogs width (or height) equal to the screen's width (or height) \"HALF\": Defines the dialogs width (or height) equal to half the screen's width (or height) \"THIRD\": Defines the dialogs width (or height) equal to 1/3 the screen's width (or height) \"QUARTER\": Defines the dialogs width (or height) equal to 1/4 of the screen's width (or height) \"EIGHTH\": Defines the dialogs width (or height) equal to 1/8 of the screen's width (or height)",
	"AttributeName": "SIZE",
	"Name": "Size",
	"DataType": "String",
	"DataFormat": "DialogSize",
	}
```

Automatically generated documentation in Zig code:

```Zig
/// 
/// SIZE (non inheritable): Dialogs size.
/// Additionally the following values can also be defined for width and/or
/// height: "FULL": Defines the dialogs width (or height) equal to the screen's
/// width (or height) "HALF": Defines the dialogs width (or height) equal to
/// half the screen's width (or height) "THIRD": Defines the dialogs width (or
/// height) equal to 1/3 the screen's width (or height) "QUARTER": Defines the
/// dialogs width (or height) equal to 1/4 of the screen's width (or height)
/// "EIGHTH": Defines the dialogs width (or height) equal to 1/8 of the
/// screen's width (or height)
pub fn setSize(self: *Self, width: ?iup.ScreenSize, height: ?iup.ScreenSize) void {
	// ...
}

```

## JSON Metadata

All metadata are available in JSON format and can be consumed by any tool independently of this project.

Download: [iup.json](https://github.com/batiati/IUPMetadata/raw/master/iup.json)

## IUP for Zig

For more information about using IUP on [Zig](https://ziglang.org/), please visit [IUP for Zig](https://github.com/batiati/IUPforZig) repository.

## Pending work

- [ ] Review DataType and formating for several attributes.
- [ ] Improve Zig Code Generator (support for indexed items in list items for example)
- [ ] Fix UPPERCASE converter algorithm (for example `SCROLLTOPOS` is rendered as `ScrollTopOs` instead of `ScrollToPos`)
- [ ] Add C# Code Generator
- [ ] Improve documentation extractor
- [ ] Add Linux support for metadata extraction

## License

* The IUP Metadata Project is a free and unencumbered software released into the public domain. Plese visit [unlicense.org](https://unlicense.org/) for more details.

* IUP is a [Tecgraf](http://www.tecgraf.puc-rio.br)/[PUC-Rio](http://www.puc-rio.br) project licensed under the terms of the [MIT license](http://www.opensource.org/licenses/mit-license.html). Please visit https://www.tecgraf.puc-rio.br/iup/ for more details.