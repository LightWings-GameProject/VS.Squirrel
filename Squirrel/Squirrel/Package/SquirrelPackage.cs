////////////////////////////////////////////////////////////////////////////////
//
// Light Wings GameProject
//
// (C) 2009 Light Wings GameProject.
//
// https://github.com/LightWings-GameProject
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using Squirrel.ClassificationDefinitions;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Utilities;

namespace Squirrel
{
	/// <summary>
	/// This is the class that implements the package exposed by this assembly.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The minimum requirement for a class to be considered a valid package for Visual Studio
	/// is to implement the IVsPackage interface and register itself with the shell.
	/// This package uses the helper classes defined inside the Managed Package Framework (MPF)
	/// to do it: it derives from the Package class that provides the implementation of the
	/// IVsPackage interface and uses the registration attributes defined in the framework to
	/// register itself and its components with the shell. These attributes tell the pkgdef creation
	/// utility what data to put into .pkgdef file.
	/// </para>
	/// <para>
	/// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
	/// </para>
	/// </remarks>
	[PackageRegistration(UseManagedResourcesOnly = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
	[Guid(SquirrelPackage.PackageGuidString)]
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
	// 下記追加
	[ProvideLanguageService(typeof(LanguageInfo), SquirrelConstants.LanguageName, 106, RequestStockColors = true, ShowSmartIndent = true, ShowCompletion = true, DefaultToInsertSpaces = true, HideAdvancedMembersByDefault = true, EnableAdvancedMembersOption = true, ShowDropDownOptions = true)]
	[ProvideLanguageExtension(typeof(LanguageInfo), SquirrelConstants.FileExtension)]
	public sealed class SquirrelPackage : Package
	{
		/// <summary>
		/// SquirrelPackage GUID string.
		/// </summary>
		public const string PackageGuidString = "0c0ce455-2b0b-49e8-b151-244f2ba3ff32";

		/// <summary>
		/// Initializes a new instance of the <see cref="SquirrelPackage"/> class.
		/// </summary>
		public SquirrelPackage()
		{
			// Inside this method you can place any initialization code that does not require
			// any Visual Studio service because at this point the package object is created but
			// not sited yet inside Visual Studio environment. The place to do all the other
			// initialization is the Initialize method.
		}

		#region Package Members

		/// <summary>
		/// Initialization of the package; this method is called right after the package is sited, so this is the place
		/// where you can put all the initialization code that rely on services provided by VisualStudio.
		/// </summary>
		protected override void Initialize()
		{
            base.Initialize();

			var services = (IServiceContainer)this;
			services.AddService(typeof(IOptionsService), OptionsService.CreateService, promote: true);
			services.AddService(typeof(Service), Service.CreateService, promote: true);

			// コンテンツタイプを列挙する
			Trace.Listeners.Clear();
			Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Trace.WriteLine("[Tag Start]:");
			foreach (var c in ((IComponentModel)GetGlobalService(typeof(SComponentModel))).GetService<IContentTypeRegistryService>().ContentTypes)
			{
				Trace.WriteLine("[Tag]:(" + c.DisplayName + ")");
			}
		}

		#endregion
	}
}
