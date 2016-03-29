using System;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace RiskHunting
{
	
	public partial class AddResolutionIdea : BasePage
	{

		const string Tag1a = "<div id=\"topbar2\">";
		const string Tag2a = "<div id=\"leftbutton\">";
		const string Tag3a = "<a href=\"javascript:doLoad('";
		const string Tag3b = "";
		const string Tag3c = "');\" >";
		string Tag4a = AppResources.AddIdea_NavigationBar_Left;
		const string Tag5a = "</a>";
		const string Tag6a = "</div>";
		const string Tag7a = "<div id=\"multiselectionbuttons\">";
		string Tag8a = AppResources.AddIdea_NavigationBar_Title;
		const string Tag9a = "</div>";
		const string Tag10a = "</div>";

		protected string sourcesPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources");
		protected const string SOURCESPECIFICATION = "SourceSpecification";
		protected const string PROBLEM = "Problem";
		protected const string SOLUTION = "Solution";
		protected const string ADDITIONAL = "Additional";
		protected const string PROCESSFOLDER = "_toProcess";

		protected string processPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources", "_toProcess");

		protected const string SOURCE_TYPE = Constants.CASEREF;
		protected const string CASE_TYPE = "Risk";

		protected string requestContent, requestFrom, sourceId;

		protected Risk currentRisk;


		protected void Page_Init(object sender, EventArgs e)
		{
			Util.AccessLog(Util.ScreenType.AddIdea);
			alert_message_error.Visible = false;
			if (Sessions.RiskState != String.Empty)
				this.sourceId = Sessions.RiskState;
			RetrieveCurrentRisk ();

			AddNewIdea.Text = AppResources.AddIdea_Form_Button_AddIdea.ToUpper();
			this.requestContent = DetermineContent ();
			if (!this.requestContent.Equals (String.Empty)) {
				PopulateIdea ();
			} else
				AddIdeaDescription.WatermarkText = AppResources.AddIdea_Form_Watermark_EnterIdea;
			this.requestFrom = DetermineFrom ();
			TopbarProblemIdeas.InnerHtml = GenerateHtml (this.requestFrom);
		}
			
		private string DetermineContent()
		{
			string id = String.Empty;
			if (Request.QueryString["content"] != null)
			{
				id = Request.QueryString["content"];
			}
			return id;
		}

		private string DetermineFrom()
		{
			string f = String.Empty;
			if (Request.QueryString["from"] != null)
			{
				f = Request.QueryString["from"];
			}
			return f;
		}

		void PopulateIdea ()
		{
			if (this.requestContent.Contains (AppResources.CreativityPrompts_BaseForm))
				AddIdeaDescription.Text = Util.GenerateAdaptedIdeaFromCreativityPrompt (this.requestContent.Replace (AppResources.CreativityPrompts_BaseForm + " ", String.Empty));
			else
				AddIdeaDescription.Text = this.requestContent;
		}

		public virtual void addClicked(object sender, EventArgs args)
		{
			if (Page.IsValid)
			{
				if (AddIdeaDescription.Text.Equals (String.Empty) ||
					AddIdeaDescription.Text.Equals (AppResources.AddIdea_Form_Watermark_EnterIdea)) {

					errorMessage.InnerHtml = AppResources.AddIdea_Notification_AddIdea;
					alert_message_error.Visible = true;

				} else {
					Util.AccessLog(Util.ScreenType.AddIdea, Util.FeatureType.AddIdea_AddIdeaButton);

					this.currentRisk.State = RiskQueryState.IdeasGenerated;
					this.currentRisk.Recommendations.Add (AddIdeaDescription.Text);

					GenerateXml (Constants.SOURCESPECIFICATION);
					GenerateXml (Constants.PROBLEM);
					GenerateXml (Constants.SOLUTION);

					string url = this.requestFrom.Replace ("@", "?");
					if (!this.requestFrom.Equals (String.Empty)) {
						if (this.requestFrom.Contains ("@"))
							url += "&";
						else
							url += "?";
						//						if (this.requestFrom.Contains ("Superheroes"))
						//						{
						//							if (Session [ "CURRENT_PERSONA"] != null)
						//							{
						//								url += "pb=" + Session [ "CURRENT_PERSONA"].ToString();
						//							}
						//						}
						//						else
						url += "pb=sameAddedIdeaSuccess";
					}
					url = url.Replace ("@", "?");
					Response.Redirect (url);
				}
			}
		}

		private string GenerateHtml(string from)
		{
			string tag = String.Empty;
			tag += Tag1a + Tag2a + Tag3a + from;
			if (!from.Equals (String.Empty)) {
				if (from.Contains ("@"))
					tag += "&";
				else
					tag += "?";
				tag += "pb=same";
			}
			tag += Tag3c + Tag4a + Tag5a + 
				Tag6a + Tag7a + Tag8a + Tag9a + Tag10a;
			tag = tag.Replace("@","?");
			return tag;
		}


		#region Xml generation

		void RetrieveCurrentRisk ()
		{
			if (!this.sourceId.Equals (String.Empty)) {
				string location = String.Empty;

				location = Path.Combine (processPath, "SourceSpecification", Constants.CASEREF + this.sourceId + "_" + "SourceSpecification" + ".xml");
				XmlProc.SourceSpecificationSerialized.SourceSpecification ss = XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Load (location);

				location = Path.Combine (processPath, "Problem", Constants.CASEREF + this.sourceId + "_" + "Problem" + ".xml");
				XmlProc.ProblemSerialized.LanguageSpecificSpecification problem = XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Load (location);

				location = Path.Combine (processPath, "Solution", Constants.CASEREF + this.sourceId + "_" + "Solution" + ".xml");
				XmlProc.SolutionSerialized.LanguageSpecificSpecification solution = XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Load (location);

				this.currentRisk = new Risk (ss, problem, solution);
			} else {
				Response.Redirect ("DescribeRisk.aspx?pb=" + Constants.SESSION_EXPIRED_LABEL);
			}
		}

		private void GenerateXml(string componentType)
		{
			string Ref;
			string xmlUri, xmlUri2;
			if (componentType.Equals("SourceSpecification"))
			{
				XmlProc.SourceSpecificationSerialized.SourceSpecification ss = Util.CreateSourceSpecificationXml(this.currentRisk);
				//				Console.WriteLine ("this.sourceId (GenerateXml): " + this.sourceId.ToString ());
				Ref = SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, CASE_TYPE, SOURCESPECIFICATION, Ref);
				xmlUri2 = Path.Combine (sourcesPath, PROCESSFOLDER, SOURCESPECIFICATION, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Save(ss, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Save(ss, xmlUri2);
			}
			else if (componentType.Equals("Problem"))
			{
				XmlProc.ProblemSerialized.LanguageSpecificSpecification problem = Util.CreateProblemXml(this.currentRisk);
				Ref = SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, CASE_TYPE, PROBLEM, Ref);
				xmlUri2 = Path.Combine (sourcesPath, PROCESSFOLDER, PROBLEM, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Save(problem, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Save(problem, xmlUri2);
			}
			else if (componentType.Equals("Solution"))
			{
				XmlProc.SolutionSerialized.LanguageSpecificSpecification solution = Util.CreateSolutionXml(this.currentRisk);
				Ref = SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, CASE_TYPE, SOLUTION, Ref);
				xmlUri2 = Path.Combine (sourcesPath, PROCESSFOLDER, SOLUTION, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Save(solution, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Save(solution, xmlUri2);
			}

		}

		#endregion
	}
}

