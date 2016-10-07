using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.EnterpriseServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Serviced")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Intertech Training")]
[assembly: AssemblyProduct("Serviced")]
[assembly: AssemblyCopyright("Copyright © Intertech Training 2005")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM componenets.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("381dff53-3d38-44f9-870b-8ad0e6c35151")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyKeyFile(@"c:\work\ExtremeASPNet\AAAD.snk")]

[assembly: ApplicationName("Serviced")]
[assembly: ApplicationAccessControl(false)]
[assembly: ApplicationActivation(ActivationOption.Library)]

[assembly: SecurityRole("Executive")]
[assembly: SecurityRole("Director")]
[assembly: SecurityRole("Manager")]
[assembly: SecurityRole("Grunt")]