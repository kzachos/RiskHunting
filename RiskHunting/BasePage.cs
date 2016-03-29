using System;
using System.Threading;
using System.Globalization;

namespace RiskHunting
{
	/// <summary>
	/// Purpose: This class created as a base class. Whenever you want to implement multi-language for any page then should be inherited
	/// Create by: chien.vh@gmail.com
	/// Skype: chien.vh
	/// Date: 05/03/2013
	/// </summary>
	public class BasePage : System.Web.UI.Page
	{
		protected override void InitializeCulture()
		{
			if (!string.IsNullOrEmpty(Request["lang"]))
			{
				Session["lang"] = Request["lang"];
			}
			string lang = Convert.ToString(Session["lang"]);
			string culture = string.Empty;

			if (lang.ToLower().CompareTo("en") == 0 )
			{
				culture = "en-US";
			}
			if (lang.ToLower().CompareTo("it") == 0 || string.IsNullOrEmpty(culture))
			{
				culture = "it-IT";
			}
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

			base.InitializeCulture();
		}
	}
}