using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;

namespace Squirrel.ClassificationDefinitions
{
    //[Guid(GuidList.guidPythonLanguageService)]
	class LanguageInfo : IVsLanguageInfo
	{
		private readonly IServiceProvider _serviceProvider;

		public LanguageInfo(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public int GetLanguageName(out string bstrName)
		{
			// This is the same name the language service was registered with.
			bstrName = SquirrelConstants.LanguageName;
			return VSConstants.S_OK;
		}

		public int GetFileExtensions(out string pbstrExtensions)
		{
			// This is the same extension the language service was
			// registered as supporting.
			pbstrExtensions = SquirrelConstants.FileExtension; // ;区切り
			return VSConstants.S_OK;
		}

		public int GetColorizer(IVsTextLines pBuffer, out IVsColorizer ppColorizer)
		{
			ppColorizer = null;
			return VSConstants.E_FAIL;
		}

		public int GetCodeWindowManager(IVsCodeWindow pCodeWin, out IVsCodeWindowManager ppCodeWinMgr)
		{
			throw new NotImplementedException();
		}
	}
}
