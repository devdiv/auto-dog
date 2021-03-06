// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

#region Using directives

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("AutoDog.Editor")]
[assembly: AssemblyDescription("WPF-based extensible text editor")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: CLSCompliant(true)]

[assembly: ThemeInfo(
	ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
	//(used if a resource is not found in the page,
	// or application resource dictionaries)
	ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
	//(used if a resource is not found in the page,
	// app, or any theme specific resource dictionaries)
)]

[assembly: XmlnsPrefix("https://github.com/devdiv/TestExecutePro.Eidtor", "avalonedit")]

[assembly: XmlnsDefinition("https://github.com/devdiv/TestExecutePro.Eidtor", "AutoDog.Editor")]
[assembly: XmlnsDefinition("https://github.com/devdiv/TestExecutePro.Eidtor", "AutoDog.Editor.Editing")]
[assembly: XmlnsDefinition("https://github.com/devdiv/TestExecutePro.Eidtor", "AutoDog.Editor.Rendering")]
[assembly: XmlnsDefinition("https://github.com/devdiv/TestExecutePro.Eidtor", "AutoDog.Editor.Highlighting")]
[assembly: XmlnsDefinition("https://github.com/devdiv/TestExecutePro.Eidtor", "AutoDog.Editor.Search")]

