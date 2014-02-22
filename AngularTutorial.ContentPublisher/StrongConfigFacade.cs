using System;
using System.Configuration;

namespace AngularTutorial.ContentPublisher
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public static class ConfigurationFacade
	{
		public static string XmlPath
		{
			get { return ConfigurationManager.AppSettings["XmlPath"]; }
		}
	}
}
