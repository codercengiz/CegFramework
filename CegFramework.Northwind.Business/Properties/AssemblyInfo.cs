using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CegFramework.Core.Aspects.Postsharp.ExceptionAspects;
using CegFramework.Core.Aspects.Postsharp.LogAspects;
using CegFramework.Core.Aspects.Postsharp.PerformanceAspects;
using CegFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("CegFramework.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CegFramework.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(DatabaseLogger),AttributeTargetTypes = "CegFramework.Northwind.Business.Concrete.Managers.*")] //we are logging all managers class
[assembly: ExceptionLogAspect(typeof(DatabaseLogger),AttributeTargetTypes = "CegFramework.Northwind.Business.Concrete.Managers.*")] //we are logging all managers class
[assembly: PerformanceCounterAspect(AttributeTargetTypes = "CegFramework.Northwind.Business.Concrete.Managers.*")] //we are logging all managers class


// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f923e3db-a4cf-4d34-9579-ac73e716019c")]

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
