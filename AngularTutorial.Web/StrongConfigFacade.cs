using System;
using System.Configuration;

namespace AngularTutorial.Web
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public static class ConfigurationFacade
	{
		public static string SmtpHost
		{
			get { return ConfigurationManager.AppSettings["SmtpHost"]; }
		}

		public static string SmtpFromAddress
		{
			get { return ConfigurationManager.AppSettings["SmtpFromAddress"]; }
		}

		public static string FeedbackToAddress
		{
			get { return ConfigurationManager.AppSettings["FeedbackToAddress"]; }
		}

		public static string webpagesVersion
		{
			get { return ConfigurationManager.AppSettings["webpages:Version"]; }
		}

		public static bool webpagesEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["webpages:Enabled"]); }
		}
	}
}
