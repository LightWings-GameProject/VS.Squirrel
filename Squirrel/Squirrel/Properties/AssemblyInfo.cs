using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Squirrel")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Squirrel")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// 下記追加
class AssemblyVersionInfo
{
//#if DEV14
//	public const string VSMajorVersion = "14";
//	public const string VSName = "2015";
//#elif DEV15
	public const string VSMajorVersion = "15";
	public const string VSName = "2017";
//#else
//	#error Unrecognized VS Version.
//#endif

	public const string VSVersion = VSMajorVersion + ".0";

	// These version strings are automatically updated at build.
	public const string StableVersionPrefix = "3.0.0";
	public const string StableVersion = "3.0.0.2017";
	public const string Version = "3.0.1000.00";
}