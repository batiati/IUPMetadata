﻿// This code was generated by a tool. 
// IUP Metadata Code Generator
// https://github.com/batiati/IUPMetadata
// 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 

const std = @import("std");
const ascii = std.ascii;
const testing = std.testing;

const Impl = @import("../impl.zig").Impl; 
const CallbackHandler = @import("../callback_handler.zig").CallbackHandler;

const iup = @import("iup.zig");
const c = @import("c.zig");
const ChildrenIterator = iup.ChildrenIterator;

{{Imports}}

///
/// IUP contains several user interface elements.
/// The library’s main characteristic is the use of native elements.
/// This means that the drawing and management of a button or text box is done by the native interface system, not by IUP.
/// This makes the application’s appearance more similar to other applications in that system. On the other hand, the application’s appearance can vary from one system to another.
/// 
/// But this is valid only for the standard elements, many additional elements are drawn by IUP.
/// Composition elements are not visible, so they are independent from the native system.
/// 
/// Each element has an unique creation function, and all of its management is done by means of attributes and callbacks, using functions common to all the elements. This simple but powerful approach is one of the advantages of using IUP.
/// Elements are automatically destroyed when the dialog is destroyed.
pub const Element = union(enum) {

    {{UnionDecl}}
    Unknown: *c.Ihandle,

    pub fn fromType(comptime T: type, handle: anytype) Element {
        switch (T) {
            {{FromType}}
            else => @compileError("Type " ++ @typeName(T) ++ " cannot be converted to a Element"),
        }
    }

    pub fn fromRef(reference: anytype) Element {

        const referenceType = @TypeOf(reference);
        const typeInfo = @typeInfo(referenceType);

        if (comptime typeInfo == .Pointer) {
            const childType = typeInfo.Pointer.child;
            switch(childType) {
                {{FromRef}}         
                else => @compileError("Type " ++ @typeName(referenceType) ++ " cannot be converted to a Element"),
            }
        } else {
            @compileError("Reference to a element expected");
        }
    }

    pub fn fromClassName(className: []const u8, handle: anytype) Element {

        {{FromClassName}}
        return . { .Unknown = @ptrCast(*c.Ihandle, handle) };
    }   

    pub fn getHandle(self: Element) *c.Ihandle {
        
        switch (self) {
            {{GetHandle}}
            .Unknown => |value| return @ptrCast(*c.Ihandle, value),
        }
    }

    pub fn children(self: Element) ChildrenIterator {

        switch (self) {
            {{Children}}
            else => return ChildrenIterator.NoChildren,
        }
    }

    pub fn eql(self: Element, other: Element) bool {
        return @ptrToInt(self.getHandle()) == @ptrToInt(other.getHandle());
    }

    pub fn deinit(self: Element) void {
        switch (self) {
            {{Deinit}}
            else => unreachable
        }
    }

    pub fn setAttribute(self: Element, attribute: [:0]const u8, value: [:0]const u8) void {
        c.setStrAttribute(self.getHandle(), attribute, value);
    }

    pub fn getAttribute(self: Element, attribute: [:0]const u8) [:0]const u8 {
        return c.getStrAttribute(self.getHandle(), attribute);
    }

    pub fn setTag(self: Element, comptime T: type, attribute: [:0]const u8, value: ?*T) void {
        c.setPtrAttribute(T, self.getHandle(), attribute, value);
    }

    pub fn getTag(self: Element, comptime T: type, attribute: [:0]const u8) ?*T {
        return c.getPtrAttribute(T, self.getHandle(), attribute);
    }
};

test "retrieve element fromType" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var handle = try iup.Label.init().unwrap();
    defer handle.deinit();

    var fromType = Element.fromType(iup.Label, handle);
    try testing.expect(fromType == .Label);
    try testing.expect(@ptrToInt(fromType.Label) == @ptrToInt(handle));
}

test "retrieve element fromRef" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var handle = try iup.Label.init().unwrap();
    defer handle.deinit();

    var fromRef = Element.fromRef(handle);
    try testing.expect(fromRef == .Label);
    try testing.expect(@ptrToInt(fromRef.Label) == @ptrToInt(handle));
}

test "retrieve element fromClassName" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var handle = try iup.Label.init().unwrap();
    defer handle.deinit();

    var fromClassName = Element.fromClassName(Label.CLASS_NAME, handle);
    try testing.expect(fromClassName == .Label);
    try testing.expect(@ptrToInt(fromClassName.Label) == @ptrToInt(handle));
}

test "getHandle" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var handle = try iup.Label.init().unwrap();
    defer handle.deinit();

    var element = Element { .Label = handle };
    var value = element.getHandle();
    try testing.expect(@ptrToInt(handle) == @ptrToInt(value));
}

test "children" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var parent = try iup.HBox.init().unwrap();
    var child1 = try iup.HBox.init().unwrap();
    var child2 = try iup.HBox.init().unwrap();

    try parent.appendChild(child1);
    try parent.appendChild(child2);

    var element = Element { .HBox = parent };
    var children = element.children();

    if (children.next()) |ret1| {
        try testing.expect(ret1 == .HBox);
        try testing.expect(ret1.HBox == child1);
    } else {
        try testing.expect(false);
    }

    if (children.next()) |ret2| {
        try testing.expect(ret2 == .HBox);
        try testing.expect(ret2.HBox == child2);
    } else {
        try testing.expect(false);
    }

    var ret3 = children.next();
    try testing.expect(ret3 == null);
}

test "eql" {

    try iup.MainLoop.open();
    defer iup.MainLoop.close();

    var l1 = Element.fromRef(try iup.Label.init().unwrap());
    defer l1.deinit();

    var l2 = Element.fromRef(try iup.Label.init().unwrap());
    defer l2.deinit();

    var l1_copy = l1;

    try testing.expect(l1.eql(l1));
    try testing.expect(l2.eql(l2));
    try testing.expect(l1.eql(l1_copy));
    try testing.expect(!l1.eql(l2));
    try testing.expect(!l2.eql(l1));
}