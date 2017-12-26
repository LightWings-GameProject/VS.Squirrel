using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.ClassificationDefinitions
{
	class LanguagePreferences : IVsTextManagerEvents2, IDisposable
	{
		public LanguagePreferences(Service service, Guid languageGuid)
		{
		}

		public int OnRegisterMarkerType(int iMarkerType)
		{
            return VSConstants.S_OK;
		}

		public int OnRegisterView(IVsTextView pView)
		{
            return VSConstants.S_OK;
		}

		public int OnUnregisterView(IVsTextView pView)
		{
            return VSConstants.S_OK;
		}

		public int OnUserPreferencesChanged2(VIEWPREFERENCES2[] pViewPrefs, FRAMEPREFERENCES2[] pFramePrefs, LANGPREFERENCES2[] pLangPrefs, FONTCOLORPREFERENCES2[] pColorPrefs)
		{
			//int hr = VSConstants.S_OK;
			//if (pLangPrefs != null && pLangPrefs.Length > 0 && pLangPrefs[0].guidLang == this._preferences.guidLang) {
			//    _preferences.IndentStyle = pLangPrefs[0].IndentStyle;
			//    _preferences.fAutoListMembers = pLangPrefs[0].fAutoListMembers;
			//    _preferences.fAutoListParams = pLangPrefs[0].fAutoListParams;
			//    _preferences.fHideAdvancedAutoListMembers = pLangPrefs[0].fHideAdvancedAutoListMembers;
			//    if (_preferences.fDropdownBar != (_preferences.fDropdownBar = pLangPrefs[0].fDropdownBar)) {
			//        foreach(var window in _service.CodeWindowManagers) {
			//            hr = window.ToggleNavigationBar(_preferences.fDropdownBar != 0);
			//            if (ErrorHandler.Failed(hr)) {
			//                break;
			//            }
			//        }
			//    }
			//}
			return VSConstants.S_OK;
		}

		public int OnReplaceAllInFilesBegin()
		{
			throw new NotImplementedException();
		}

		public int OnReplaceAllInFilesEnd()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
