using System;
using System.Configuration;

namespace AngularTutorial.Web
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public static class ConfigurationFacade
	{
		public static string webpagesVersion
		{
			get { return ConfigurationManager.AppSettings["webpages:Version"]; }
		}

		public static bool webpagesEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["webpages:Enabled"]); }
		}

		public static bool ClientValidationEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["ClientValidationEnabled"]); }
		}

		public static bool UnobtrusiveJavaScriptEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]); }
		}

		public static string TableOfContentsCacheKey
		{
			get { return ConfigurationManager.AppSettings["TableOfContentsCacheKey"]; }
		}
	}
}
