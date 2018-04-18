// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("TestApp")]


#if VS_BUILD
[assembly: ComVisible(false)]	// false at assembly level, to be overridden by individual class
#endif

[assembly: ClassInterface(ClassInterfaceType.None)]
[assembly: CLSCompliant(true)] // Common Language Specification (CLS) compliant.

#if (VS_BUILD)
[assembly: AssemblyVersion("1.11.0.0")]
#endif
