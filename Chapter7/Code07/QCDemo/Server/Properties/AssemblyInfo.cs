#region Using directives

using System.Reflection;
using System.Runtime.CompilerServices;


#endregion

using System.EnterpriseServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Server")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Intertech Training")]
[assembly: AssemblyProduct("Server")]
[assembly: AssemblyCopyright("Copyright @ Intertech Training 2005")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

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
[assembly: AssemblyKeyFile(@"c:\work\ExtremeASPNet\AAAD.snk")]

[assembly: ApplicationName("Q-able App")]
[assembly: ApplicationAccessControl(false)]
[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationQueuing(Enabled = true, QueueListenerEnabled = true)]

//Use this for DllHost.exe
//[assembly: ApplicationActivation(ActivationOption.Server)]
//or this for hosting in the process of the creator
//[assembly: ApplicationActivation(ActivationOption.Library)]