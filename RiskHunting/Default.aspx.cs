
using System;
using System.Web.UI;
using System.IO;

namespace RiskHunting
{


	public partial class Default : Page
	{
	
		protected void Page_Init(object sender, EventArgs e)
		{
			Response.Redirect("DescribeRisk.aspx");
		}
			


	}
}

