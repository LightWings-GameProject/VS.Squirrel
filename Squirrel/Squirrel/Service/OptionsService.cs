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
using Microsoft.VisualStudio.Settings;

namespace Squirrel.ClassificationDefinitions
{
	class OptionsService : IOptionsService
	{
		private readonly WritableSettingsStore _settingsStore;

		public static object CreateService(IServiceContainer container, Type serviceType)
		{
			if (serviceType.IsEquivalentTo(typeof(IOptionsService)))
			{
				return new OptionsService(container);
			}
			return null;
		}

		public OptionsService(IServiceProvider serviceProvider)
		{
			var settingsManager = SettingsManagerCreator.GetSettingsManager(serviceProvider);
			_settingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
		}

		public void DeleteCategory(string category)
		{
			//var path = GetCollectionPath(category);
			//try
			//{
			//	_settingsStore.DeleteCollection(path);
			//}
			//catch (ArgumentException)
			//{
			//	// Documentation is a lie - raises ArgumentException if the
			//	// collection does not exist.
			//}
		}

		public string LoadString(string name, string category)
		{
			//var path = GetCollectionPath(category);
			//if (!_settingsStore.CollectionExists(path))
			//{
			//	return null;
			//}
			//if (!_settingsStore.PropertyExists(path, name))
			//{
			//	return null;
			//}
			return "";// _settingsStore.GetString(path, name, "");
		}

		public void SaveString(string name, string category, string value)
		{
			//var path = GetCollectionPath(category);
			//if (value == null)
			//{
			//	if (_settingsStore.CollectionExists(path))
			//	{
			//		_settingsStore.DeleteProperty(path, name);
			//	}
			//}
			//else
			//{
			//	if (!_settingsStore.CollectionExists(path))
			//	{
			//		_settingsStore.CreateCollection(path);
			//	}
			//	_settingsStore.SetString(path, name, value);
			//}
		}
	}
}
