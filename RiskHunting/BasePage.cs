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
			if (!string.IsNullOrEmpty(Request["liveStatus"]))
			{
				Session["liveStatus"] = Request["liveStatus"];
			}
			string liveStatus = Convert.ToString(Session["liveStatus"]);
			string currentStatus = string.Empty;

			if (liveStatus.ToLower().CompareTo("off") == 0 )
			{
				Session["liveStatus"] = "off";
				currentStatus = "off";
			}
			if (liveStatus.ToLower().CompareTo("on") == 0 || string.IsNullOrEmpty(currentStatus))
			{
				Session["liveStatus"] = "on";
				currentStatus = "on";
			}

			if (!string.IsNullOrEmpty(Request["lang"]))
			{
				Session["lang"] = Request["lang"];
			}
			string lang = Convert.ToString(Session["lang"]);
			string culture = string.Empty;

			if (lang.ToLower().CompareTo("en") == 0 )
			{
				culture = "en-GB";
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