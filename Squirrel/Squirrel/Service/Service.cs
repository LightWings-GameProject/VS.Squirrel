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
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.ClassificationDefinitions
{
	public sealed class Service : IDisposable
	{
		private readonly Lazy<LanguagePreferences> _langPrefs;

		public static object CreateService(IServiceContainer container, Type serviceType)
		{
			if (serviceType.IsEquivalentTo(typeof(Service)))
			{
				// register our PythonToolsService which provides access to core PTVS functionality
				try
				{
					return new Service(container);
				}
				catch(Exception)
				{
				}
				//catch (Exception ex) when (!ex.IsCriticalException())
				//{
				//	ex.ReportUnhandledException(container, typeof(PythonToolsService), allowUI: false);
				//	throw;
				//}
			}
			return null;
		}

		internal Service(IServiceContainer container)
		{
			//_container = container;

			_langPrefs = new Lazy<LanguagePreferences>(() => new LanguagePreferences(this, typeof(LanguageInfo).GUID));
			//_interpreterOptionsService = new Lazy<IInterpreterOptionsService>(CreateInterpreterOptionsService);
			//
			//_optionsService = (IPythonToolsOptionsService)container.GetService(typeof(IPythonToolsOptionsService));
			//
			//_idleManager = new IdleManager(container);
			//_advancedOptions = new Lazy<AdvancedEditorOptions>(CreateAdvancedEditorOptions);
			//_debuggerOptions = new Lazy<DebuggerOptions>(CreateDebuggerOptions);
			//_experimentalOptions = new Lazy<Options.ExperimentalOptions>(CreateExperimentalOptions);
			//_diagnosticsOptions = new Lazy<DiagnosticsOptions>(CreateDiagnosticsOptions);
			//_generalOptions = new Lazy<GeneralOptions>(CreateGeneralOptions);
			//_suppressDialogOptions = new Lazy<SuppressDialogOptions>(() => new SuppressDialogOptions(this));
			//_interactiveOptions = new Lazy<PythonInteractiveOptions>(() => CreateInteractiveOptions("Interactive"));
			//_debugInteractiveOptions = new Lazy<PythonInteractiveOptions>(() => CreateInteractiveOptions("Debug Interactive Window"));
			//_logger = new PythonToolsLogger(ComponentModel.GetExtensions<IPythonToolsLogger>().ToArray());
			//_entryService = (AnalysisEntryService)ComponentModel.GetService<IAnalysisEntryService>();
			//_diagnosticsProvider = new DiagnosticsProvider(container);
			//
			//_idleManager.OnIdle += OnIdleInitialization;
			//
			//EditorServices.SetPythonToolsService(this);
		}

		public void Dispose()
		{
			// This will probably never be called by VS, but we use it in unit
			// tests to avoid leaking memory when we reinitialize state between
			// each test.

			if (_langPrefs.IsValueCreated)
			{
				_langPrefs.Value.Dispose();
			}

			//if (_interpreterOptionsService.IsValueCreated)
			//{
			//	_interpreterOptionsService.Value.DefaultInterpreterChanged -= UpdateDefaultAnalyzer;
			//	(_interpreterOptionsService.Value as IDisposable)?.Dispose();
			//}

			//_idleManager.Dispose();

			//foreach (var window in _codeWindowManagers.Values.ToArray())
			//{
			//	window.RemoveAdornments();
			//}
			//_codeWindowManagers.Clear();
		}
	}
}
