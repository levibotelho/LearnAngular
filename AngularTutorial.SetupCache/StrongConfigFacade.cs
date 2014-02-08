using System.Configuration;

namespace AngularTutorial.SetupCache
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public static class ConfigurationFacade
	{
		public static string TableOfContentsCacheKey
		{
			get { return ConfigurationManager.AppSettings["TableOfContentsCacheKey"]; }
		}
	}
}
