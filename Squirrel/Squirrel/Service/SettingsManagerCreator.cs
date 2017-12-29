﻿using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell.Settings;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Squirrel.ClassificationDefinitions
{
	public static class SettingsManagerCreator
	{
		public static SettingsManager GetSettingsManager(DTE dte)
		{
			return GetSettingsManager(new ServiceProvider(((IOleServiceProvider)dte)));
		}

		public static SettingsManager GetSettingsManager(IServiceProvider provider)
		{
			SettingsManager settings = null;
			string devenvPath = null;
			if (provider == null)
			{
				provider = ServiceProvider.GlobalProvider;
			}

			if (provider != null)
			{
				try
				{
					settings = new ShellSettingsManager(provider);
				}
				catch (NotSupportedException)
				{
					var dte = (DTE)provider.GetService(typeof(DTE));
					if (dte != null)
					{
						devenvPath = dte.FullName;
					}
				}
			}

			if (settings == null)
			{
				if (!File.Exists(devenvPath))
				{
					// Running outside VS, so we need to guess which SKU of VS
					// is being used. This will work correctly if any one SKU is
					// installed, but may select the wrong SKU if multiple are
					// installed. As a result, custom environments may not be
					// available when building or testing Python projects.
					string devenvRoot = null;
					using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
					using (var key = root.OpenSubKey(string.Format(@"Software\Microsoft\VisualStudio\{0}\Setup\VS", AssemblyVersionInfo.VSVersion)))
					{
						if (key != null)
						{
							devenvRoot = key.GetValue("ProductDir") as string;
						}
					}
					if (Directory.Exists(devenvRoot))
					{
						foreach (var subPath in new[] {
							"Common7\\IDE\\devenv.exe",
							"Common7\\IDE\\vwdexpress.exe",
							"Common7\\IDE\\wdexpress.exe"
						})
						{
							devenvPath = Path.Combine(devenvRoot, subPath);
							if (File.Exists(devenvPath))
							{
								break;
							}
							devenvPath = null;
						}
					}
				}
				if (!File.Exists(devenvPath))
				{
					throw new InvalidOperationException("Cannot find settings store for Visual Studio " + AssemblyVersionInfo.VSVersion);
				}
#if DEBUG
				settings = ExternalSettingsManager.CreateForApplication(devenvPath, "Exp");
#else
                settings = ExternalSettingsManager.CreateForApplication(devenvPath);
#endif
			}

			return settings;
		}
	}
}
