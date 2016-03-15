using System;
using System.Globalization;

namespace RiskHunting
{
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo ();

		void SetLocale ();
	}
}

