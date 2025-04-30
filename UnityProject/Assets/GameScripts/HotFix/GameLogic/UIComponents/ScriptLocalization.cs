using TEngine.Localization;
using UnityEngine;

namespace GameLogic
{
	public static class ScriptLocalization
	{

		public static string Country 		{ get{ return LocalizationManager.GetTranslation ("Country"); } }
		public static string Flag 		{ get{ return LocalizationManager.GetTranslation ("Flag"); } }
		public static string Language 		{ get{ return LocalizationManager.GetTranslation ("Language"); } }
	}

    public static class ScriptTerms
	{

		public const string Country = "Country";
		public const string Flag = "Flag";
		public const string Language = "Language";
	}
}