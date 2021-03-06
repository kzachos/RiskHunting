﻿using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;
using System.Linq;


namespace RiskHunting
{
	
	public partial class CreateIdeas_SameRisk : BasePage
	{

		const string Tag1 = "<li class=\"checkbox\">";
		const string Tag2 = "<span class=\"name\">";
		const string Tag3 = "</span>";
		const string Tag4 = "<asp:CheckBox id=\"CheckBox";
		const string Tag5 = "\" runat=\"server\"></asp:CheckBox>";
		const string Tag6 = "</li>";
		const string Tag7 = "<li class=\"labelcontent2\">";
		const string Tag8 = "<asp:Label runat=\"server\" TextMode=\"MultiLine\" Width=\"100%\" >";
		const string Tag9 = "</asp:Label>";
		const string Tag10 = "</li>";

		const string SpanStartTagMenu = "<span class=menu>";
		const string SpanStartTagName = "<span class=name>";
		const string SpanStartTagArrow = "<span class=arrow>";
		const string SpanEndTag = "</span>";
		const string LiStartTagMenu = "<li class=menu>";
		const string LiEndTag = "</li>";
		const string aStartTag = "<a href=\"javascript:doLoad('AddResolutionIdea.aspx?from=CreateIdeas_SameRisk.aspx&content=";
		const string aMidTag = "');\">";
		const string aEndTag = "</a>";

		int total;

		List<NLResponseToken> NLResponse;

//		protected string Expression = AppResources.CreativityPrompts_BaseForm + " ";

		protected string processPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources", "_toProcess");

		protected IList<string> CreativityPromptsFeed;
		protected string sourceId;
		protected Risk currentRisk;
		protected string currentRiskDescription;

//		private readonly RiskHunting.antiqueService.AntiqueService _service = 
//			new RiskHunting.antiqueService.AntiqueService();
//		private readonly Stopwatch _watch = new Stopwatch();
//
//		protected override void OnInit(EventArgs e)
//		{
//			base.OnInit(e);
//
//			if (Session ["CurrentRiskDescription"] != null) {
//				this.currentRiskDescription = Session ["CurrentRiskDescription"].ToString ();
//
//				var task = new PageAsyncTask (BeginRequest, EndRequest, 
//					           null, null);
//				RegisterAsyncTask (task);
//			}
//		}
//
//		protected override void OnLoad(EventArgs e)
//		{
//			base.OnLoad(e);
//
//			if (IsPostBack)
//				return;
//
//
//			_watch.Start();
//		}
//
//		protected override void OnPreRenderComplete(EventArgs e)
//		{
//			base.OnPreRenderComplete(e);
//
//			if (IsPostBack)
//				return;
//
//			_watch.Stop();
//			Debug.WriteLine("Time: " + _watch.Elapsed);
//			Debug.WriteLine("this.NLResponse: " + this.NLResponse.Count);
//
//		}
//
//		IAsyncResult BeginRequest(Object sender, EventArgs e, 
//			AsyncCallback cb, object state)
//		{ 
//			return _service.BeginNLParser(this.currentRiskDescription, cb, null);
//		}
//
//		void EndRequest(IAsyncResult asyncResult)
//		{
//			var answer = _service.EndNLParser(asyncResult);
//			Debug.WriteLine(answer);
//			this.NLResponse = new List<NLResponseToken> ();
//			this.NLResponse = Util.DeserializeNLResponse (answer);
//
//		}

		protected void Page_Init(object sender, EventArgs e)
		{
			if (Sessions.PersonaState != String.Empty) 
				Session.Remove (Sessions.personaState);
			if (Sessions.PersonasState != null) 
				Session.Remove (Sessions.personasState);
			generatePrompts.Visible = true;
			alert_message_success.Visible = false;
			alert_message_error.Visible = false;
			describeRiskDiv.Visible = false;
			if (Sessions.RiskState != String.Empty)
				this.sourceId = Sessions.RiskState;

			var processGuidanceText = Util.GenerateProcessGuidance ("creativeGuidance");
			creativeGuidance.InnerText = processGuidanceText.Equals(String.Empty)?AppResources.ProcessGuidance_PastRisk_Default:processGuidanceText;

			InitLabels ();


			if (Sessions.CreativityPromptsState != null) {
//				if (Session ["CURRENT_PROBLEM_DESC"] != null) 
//					Session.Remove ("CURRENT_PROBLEM_DESC");
				CreativityPromptsFeed = Sessions.CreativityPromptsState;
				if (DetermineFrom().Equals(String.Empty))
					CreativityPromptsFeed.Shuffle ();
				PopulateData ();
			} else {
//				if (Session ["CURRENT_PROBLEM_DESC"] != null)
//					NLResponse = (List<NLResponseToken>)Session ["CURRENT_PROBLEM_DESC"];
//				else {
//					NLResponse = new List<NLResponseToken> ();
				RetrieveCurrentRisk ();

				CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

				var query = this.currentRisk.Content;
				if (Convert.ToString (Session ["liveStatus"]) == "on") {
					var lang = LanguageDetection.DetectLanguage (query);
					if (!lang.language.Equals("en")) 
					{
						if (Convert.ToString (Session ["liveStatus"]) == "on") {
							var t = TranslatorGoogle.TranslateText (query, "en");
//							Translator tr = new Translator ();	
//							var task = tr.TranslateString (query, "en");
							RetrieveNLData (t, lang.language, currentCulture);
						}
						else
							RetrieveNLData (query, lang.language, currentCulture);
					}
					else 
						RetrieveNLData (query, lang.language, currentCulture);
				} else 
					RetrieveNLData (query, "en", currentCulture);
				

			}


				
			if (Page.IsPostBack) {
				Console.WriteLine ("Page_Init - Page.IsPostBack");
				content2.Controls.Clear ();

//				this.NLResponse = new List<NLResponseToken> ();
//				if (Session ["CurrentRiskDescription"] != null) {
//					this.currentRiskDescription = Session ["CurrentRiskDescription"].ToString ();
////					var client = new RiskHunting.antiqueService.AntiqueService ();
////					var result = await client.LoginAsyncTask (this.currentRiskDescription);
////					RetrieveNLDataAsync (this.currentRiskDescription);
//					PrepareData ();
//					PopulateData ();
//				}
//				else {
//					this.currentRiskDescription = String.Empty;
//					PrepareData ();
//					PopulateData ();
//				}



			} else {
				Console.WriteLine ("Page_Init - NOT Page.IsPostBack");
				Util.AccessLog(Util.ScreenType.CreateIdea_SameRisk);
			}

		}



		protected void Page_Load(object sender, EventArgs e)
		{

			if (Sessions.RiskState != String.Empty)
				this.sourceId = Sessions.RiskState;

			if (!Page.IsPostBack) {


				Console.WriteLine ("Page_Load - NOT Page.IsPostBack");

			} 
			//			else
			//				PopulateData ();
			//				if (Session ["CREATIVITY_PROMPTS"] != null)
			//					CreativityPromptsFeed = (IList<string>)Session ["CREATIVITY_PROMPTS"];
		}

		private string DetermineFrom()
		{
			string c = String.Empty;
			if (Request.QueryString["pb"] != null)
			{
				c = Request.QueryString["pb"];
				NameValueCollection filtered = new NameValueCollection(Request.QueryString);
				filtered.Remove("pb");			
			}
			return c;
		}

		private void InitLabels ()
		{
			LabelHint.Text = AppResources.ProcessGuidance_Hint;
			LabelNavigationBarLeft.Text = AppResources.CreateIdeas_NavigationBar_Left;
			LabelNavigationBarRight.Text = AppResources.CreateIdeas_NavigationBar_Right;
			LabelNavigationBarTitle.Text = AppResources.CreateIdeas_NavigationBar_Title;
			LabelSubNavigationBarLeft.Text = AppResources.CreateIdeas_SubNavigationBar_Left;
			LabelSubNavigationBarMiddle.Text = AppResources.CreateIdeas_SubNavigationBar_Middle;
			GenerateAgain.Text = AppResources.CreateIdeas_SameRisk_Button_GenerateAgain.ToUpper();
			ReturnDescribeRisk.Text = AppResources.CreateIdeas_SameRisk_Button_ReturnDescribeRisk.ToUpper();
		}

			
		#region Service Call


//		async void RetrieveNLDataAsync(string content)
//		{
//			var output = await GetValueAsync(content);
//			Console.WriteLine ("Result for " + this.currentRiskDescription + ": " + output);
//
////			var client = new RiskHunting.antiqueService.AntiqueService ();
////			client.NLParserCompleted += objAntique_NLParserCompleted;
////			client.NLParserAsync (content); 
//
//
//		}
//
//		async Task<string> GetValueAsync(string content)
//		{
//
//			var client = new RiskHunting.antiqueService.AntiqueService ();
//			client.NLParserAsync (content); 
//			client.NLParserCompleted += (o, e) => {
//				this.currentRiskDescription = e.Result;
//			};
//			return this.currentRiskDescription;
//		}

//			var client = new RiskHunting.antiqueService.AntiqueService ();
//			var output = client.NLParser (content);
//			return output;

//		void objAntique_NLParserCompleted(object sender, 
//			RiskHunting.antiqueService.NLParserCompletedEventArgs e)
//		{
//			Console.WriteLine ("Result for " + this.currentRiskDescription + ": " + e.Result);
//			this.NLResponse = Util.DeserializeNLResponse (e.Result);
//
//		}


		void RetrieveNLData (string query, string lang, CultureInfo currentCulture)
		{
			if (Convert.ToString (Session ["liveStatus"]) == "on") {
				string errorMsg;
				if(Util.ServiceExists(Constants.ANTIQUE_URI, false, out errorMsg)) {
					RiskHunting.antiqueService.AntiqueService antique = new RiskHunting.antiqueService.AntiqueService ();
					try
					{

						System.Net.ServicePointManager.Expect100Continue = false;
						var output = antique.NLParser (query);
						this.NLResponse = Util.DeserializeNLResponse (output);

						if (Sessions.CreativityPromptsState != null)
							Session.Remove(Sessions.creativityPromptsState);
						//			Session ["CURRENT_PAST_RISK_DESC"] = NLResponse;
					}
					catch (Exception ex)
					{
					}
					finally {
						PrepareData (lang, currentCulture);
						PopulateData ();
					}
				}
				else
				{
					generatePrompts.Visible = false;
					hint_box.Visible = false;
					alert_message_success.Visible = false;
					errorMessage.InnerText = AppResources.PastRisk_Notification_FailedGeneratePrompts;
					alert_message_error.Visible = true;
				}
			} else {
				PrepareData (lang, currentCulture);
				PopulateData ();
			}
		}

		#endregion

		List<string> GenerateGenericCreativityPrompts(string lang, CultureInfo currentCulture)
		{
			List<NLResponseToken> NLResponseTrimmed = new List<NLResponseToken> () ;
			foreach(var item in NLResponse)
			{
				var parsedTermValue = Regex.Replace(item.TermValue, @"[\[\]\(\)']+", "").Trim();
				if (!parsedTermValue.Equals (String.Empty) && parsedTermValue.Length > 1) {
					NLResponseToken itemNew = item;
					if (item.Pos == "NP")
						itemNew.TermValue = "the " + parsedTermValue.Replace('.', ',');
					else
						itemNew.TermValue = parsedTermValue.Replace('.', ',');
					NLResponseTrimmed.Add (itemNew);
				}
			}

			if (!currentCulture.ToString ().Contains ("en"))
			{
				var ids = NLResponseTrimmed.Select(c => c.ID).ToArray();
				var pos = NLResponseTrimmed.Select(c => c.Pos).ToArray();
				var termValues = NLResponseTrimmed.Select(c => c.TermValue).ToArray();

				var termValuesString = string.Empty;
				for (int i = 0; i < termValues.Length; i ++)
				{						
					termValuesString += termValues[i] + ". ";
				}
				if (!termValuesString.Equals(String.Empty)) {
					var NLResponseNew = new List<NLResponseToken>();

					var t = TranslatorGoogle.TranslateText (termValuesString, lang);
//					Translator tr = new Translator();	
//					var task = await tr.TranslateString (termValuesString, lang);
					var res = t.Trim().Split(new char[] {'.'});
					var c = 0;
					for (int j = 0; j < res.Length; j++)
					{
						if (!res[j].Trim().Equals (String.Empty)) {
							NLResponseToken itemNew = new NLResponseToken ();
							itemNew.ID = ids[j];
							itemNew.Pos = pos[j];
							itemNew.TermValue = res [j].Trim ();
							NLResponseNew.Add (itemNew);
						}
					}
					NLResponseTrimmed.Clear();
					NLResponseTrimmed = NLResponseNew;

				}

			}
				
			int count = 0;
			List<string> ps = new List<string> ();
			NLResponseTrimmed.Shuffle ();

			if (NLResponseTrimmed.Count > 5)
				for (int i = 0; i < 4; i++) {
					//			foreach (var item in NLResponseTrimmed) {
					var item = NLResponseTrimmed [i];
					if (!item.TermValue.Equals (String.Empty)) {
						GenericCreativityPrompts g = new GenericCreativityPrompts (item.TermValue, item.Pos, currentCulture);
						foreach (string s in  g.genericCPs) {
							//							Console.WriteLine (s);
							ps.Add (s);
							count++;
						}
					}
				}
			else
				foreach (var item in NLResponseTrimmed) {
					if (!item.TermValue.Equals (String.Empty)) {
						GenericCreativityPrompts g = new GenericCreativityPrompts (item.TermValue, item.Pos, currentCulture);
						foreach (string s in  g.genericCPs) {
							//							Console.WriteLine (s);
							ps.Add (s);
							count++;
						}
					}
				}
			Console.WriteLine ("ps.Count: " + ps.Count);

			return ps;
		}

		List<string> GenerateGenericCreativityPromptsStatic()
		{
//			List<NLResponseToken> NLResponseTrimmed = new List<NLResponseToken> () ;
//			foreach(var item in NLResponse)
//			{
//				if (!item.TermValue.Equals (String.Empty))
//					NLResponseTrimmed.Add (item);
//			}
//
//			NLResponseTrimmed.Shuffle ();

			int count = 0;
			List<string> ps = new List<string> ();
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;


			string[] valuesNP1 = {"box"};
			string[] valuesNP = {"scatole", "corridoio"};
			string[] valuesVP = {};

			foreach (var item in valuesNP) {
				if (!item.Equals (String.Empty)) {
					GenericCreativityPrompts g = new GenericCreativityPrompts (item, "NP", currentCulture);
					foreach (string s in  g.genericCPs) {
						//							Console.WriteLine (s);
						ps.Add (s);
						count++;
					}
				}
			}

			foreach (var item in valuesVP) {
				if (!item.Equals (String.Empty)) {
					GenericCreativityPrompts g = new GenericCreativityPrompts (item, "VP", currentCulture);
					foreach (string s in  g.genericCPs) {
						//							Console.WriteLine (s);
						ps.Add (s);
						count++;
					}
				}
			}
			Console.WriteLine ("ps.Count: " + ps.Count);
			return ps;
		}

		void PrepareData (string lang, CultureInfo currentCulture)
		{
			if (!Page.IsPostBack) {
				if (Convert.ToString(Session["liveStatus"]) == "on")
					CreativityPromptsFeed = GenerateGenericCreativityPrompts (lang, currentCulture);
				else
					CreativityPromptsFeed = GenerateGenericCreativityPromptsStatic ();

				Console.WriteLine ("****** PrepareData *******");
				foreach (var item in CreativityPromptsFeed) {
					Console.WriteLine (item);
				}

				CreativityPromptsFeed.Shuffle ();

//				Random rnd = new Random();
//				int index = rnd.Next(1, 1000);
//				string resourcesPath = Path.Combine (SettingsTool.GetApplicationPath(), "Resources");
//				using (StreamWriter sw = new StreamWriter (Path.Combine (resourcesPath, "CreativityPrompts_" + index + ".csv")))
//					foreach (var it in CreativityPromptsFeed) {
//						var newit = it.Replace (',', ' ');
//						sw.WriteLine (String.Format ("{0}", newit));
//					}


				Console.WriteLine ("CreativityPromptsFeed.Count: " + CreativityPromptsFeed.Count);
			} else {

				if (Sessions.CreativityPromptsState != null)
					CreativityPromptsFeed = Sessions.CreativityPromptsState;
				else {
					Console.WriteLine ("no CREATIVITY_PROMPTS");
				}
			}

		}

		void PopulateData ()
		{
			if (!Page.IsPostBack) {
				Console.WriteLine ("****** PopulateData *******");
				this.total = CreativityPromptsFeed.Count < Constants.MaxPromptsAtATime ? CreativityPromptsFeed.Count : Constants.MaxPromptsAtATime;
				int counter = 0;
				if (this.total > 0) {
					for (int i = 0; i < this.total; i++) {
						content2.InnerHtml += GenerateHtml (CreativityPromptsFeed [i]);
//						GenerateHtml3 (CreativityPromptsFeed [i], String.Empty, counter++);
						Console.WriteLine (CreativityPromptsFeed [i]);
					}
					Sessions.CreativityPromptsState = CreativityPromptsFeed;
				} else {
					generatePrompts.Visible = false;
					hint_box.Visible = true;
					alert_message_success.Visible = false;
					creativeGuidance.InnerText = AppResources.CreateIdeas_SameRisk_Notification_FailedGeneratePrompts;
					alert_message_error.Visible = false;
					describeRiskDiv.Visible = true;
//					GenerateHtml3 ("No prompts available", String.Empty);
				}
			} else {
				Console.WriteLine ("PopulateData");
				if (Sessions.CreativityPromptsState != null) {
					this.total = CreativityPromptsFeed.Count < Constants.MaxPromptsAtATime ? CreativityPromptsFeed.Count : Constants.MaxPromptsAtATime;
					int counter = 0;
					for (int i = 0; i < this.total; i++) {
						content2.InnerHtml += GenerateHtml (CreativityPromptsFeed [i]);
//						GenerateHtml3 (CreativityPromptsFeed [i], String.Empty, counter++);
						Console.WriteLine (CreativityPromptsFeed [i]);
					}
				}
				else {
					Console.WriteLine ("no CREATIVITY_PROMPTS");
				}
			}
			//			Session ["CREATIVITY_PROMPTS_TOTAL"] = this.total;
			//			Session ["CREATIVITY_PROMPTS"] = CreativityPromptsFeed;
			//			GenerateAgain.Text = "MORE PROMPTS";
		}


		private CheckBox CreateCheckboxControl(string id, string content)
		{
			var k = new CheckBox();
			k.ID = id;
			k.AutoPostBack = false;
			k.ToolTip = content;
			//			k.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);

			return k;
		}

		private void CheckState()
		{
			foreach (var ctrl in content2.Controls)
			{
				Console.WriteLine ("type: " + ctrl.GetType ().ToString());
				if (ctrl is CheckBox)
				if (((CheckBox) ctrl).Checked)
					Console.WriteLine ("Checked");
				else
					Console.WriteLine ("UnChecked");
			}
		}

		private void GenerateHtml3 (string main, string second, int id)
		{
			content2.Controls.Add (new LiteralControl (Tag1)); 
			content2.Controls.Add (new LiteralControl (Tag2));
			content2.Controls.Add (new LiteralControl (main));
			content2.Controls.Add (new LiteralControl (Tag3));

			content2.Controls.Add (CreateCheckboxControl (id.ToString (), main));

			content2.Controls.Add (new LiteralControl (Tag6));
			content2.Controls.Add (new LiteralControl (Tag7));
			content2.Controls.Add (new LiteralControl (Tag8));
			content2.Controls.Add (new LiteralControl (second));
			content2.Controls.Add (new LiteralControl (Tag9));
			content2.Controls.Add (new LiteralControl (Tag10));
		}

		private void GenerateHtml3 (string main, string second)
		{
			content2.Controls.Add (new LiteralControl (Tag1)); 
			content2.Controls.Add (new LiteralControl (Tag2));
			content2.Controls.Add (new LiteralControl (main));
			content2.Controls.Add (new LiteralControl (Tag3));

			content2.Controls.Add (new LiteralControl (Tag6));
			content2.Controls.Add (new LiteralControl (Tag7));
			content2.Controls.Add (new LiteralControl (Tag8));
			content2.Controls.Add (new LiteralControl (second));
			content2.Controls.Add (new LiteralControl (Tag9));
			content2.Controls.Add (new LiteralControl (Tag10));
		}

		private string GenerateHtml(string idea)
		{
			return LiStartTagMenu +
				aStartTag + Microsoft.Security.Application.AntiXss.JavaScriptEncode(idea, false) + aMidTag +
				SpanStartTagName + idea + SpanEndTag +
				SpanStartTagArrow + SpanEndTag + aEndTag + LiEndTag;
		}

		public virtual void morePromptsClicked(object sender, EventArgs args)
		{
			if (Sessions.CreativityPromptsState != null) {
				Util.AccessLog(Util.ScreenType.CreateIdea_SameRisk, Util.FeatureType.CreateIdea_SameRisk_GenerateNewPromptsButton);

				content2.Controls.Clear ();
				CreativityPromptsFeed = Sessions.CreativityPromptsState;
				CreativityPromptsFeed.Shuffle ();
				PopulateData ();
			}
		}

		public virtual void submitClicked(object sender, EventArgs args)
		{
			Console.WriteLine ("submitClicked");
			if (!this.sourceId.Equals (String.Empty)) {
				UpdateRisk ();
//				Response.Redirect("Solution_ResolutionIdeas.aspx");
			}


		}


		void UpdateRisk ()
		{
			RetrieveCurrentRisk ();
			bool entryAdded = false;
			for (int i = 0; i < content2.Controls.Count; i++) {
				var ctrl = content2.Controls [i];
				if (ctrl is CheckBox) {
					bool result = ((CheckBox)ctrl).Checked;
					if (result)
					if ((!this.currentRisk.Recommendations.Contains (RetrieveCheckboxText (((CheckBox)ctrl).ClientID)))
						&& (!((CheckBox)ctrl).ToolTip.Trim ().Equals(String.Empty))) {
						this.currentRisk.Recommendations.Add (((CheckBox)ctrl).ToolTip.Trim ());
						entryAdded = true;
						Console.WriteLine ("Selected: " + ((CheckBox)ctrl).ToolTip.Trim ());
					}
				}
			}
			this.currentRisk.Recommendations.Remove (String.Empty);

			GenerateXml ();
			if (entryAdded) {
				successMessage.InnerHtml = AppResources.PastRisk_Notification_SuccessAdd;
				alert_message_success.Visible = true;
				alert_message_error.Visible = false;

			} else {
				errorMessage.InnerHtml = AppResources.PastRisk_Notification_FailedGeneratePrompts;
				alert_message_success.Visible = false;
				alert_message_error.Visible = true;

			}
		}

		void RetrieveCurrentRisk ()
		{
			if (!this.sourceId.Equals(String.Empty))
			{
				string location = String.Empty;

				location = Path.Combine (processPath, "SourceSpecification", Constants.CASEREF + this.sourceId + "_" + "SourceSpecification" + ".xml");
				XmlProc.SourceSpecificationSerialized.SourceSpecification ss = XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Load(location);

				location = Path.Combine (processPath, "Problem", Constants.CASEREF + this.sourceId + "_" + "Problem" + ".xml");
				XmlProc.ProblemSerialized.LanguageSpecificSpecification problem = XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Load(location);

				location = Path.Combine (processPath, "Solution", Constants.CASEREF + this.sourceId + "_" + "Solution" + ".xml");
				XmlProc.SolutionSerialized.LanguageSpecificSpecification solution = XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Load(location);

				this.currentRisk = new Risk (ss, problem, solution);
			} else {
				Response.Redirect ("DescribeRisk.aspx?pb=" + Constants.SESSION_EXPIRED_LABEL);
			}
		}

		private void GenerateXml()
		{
			string Ref;
			string xmlUri;

			XmlProc.SolutionSerialized.LanguageSpecificSpecification solution = Util.CreateSolutionXml (this.currentRisk);
			Ref = Constants.CASEREF + this.sourceId + "_" + "Solution" + ".xml";
			xmlUri = Path.Combine (processPath, "Solution", Ref);
			XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Save(solution, xmlUri);

		}

		public virtual void resolutionIdeasClicked(object sender, EventArgs args)
		{
			Response.Redirect("Solution_ResolutionIdeas.aspx");
		}

		public virtual void returnClicked(object sender, EventArgs args)
		{
			Response.Redirect("DescribeRisk.aspx");
		}

		private string RetrieveCheckboxText (string id)
		{
			string text = String.Empty;
			foreach (var ctrl in content2.Controls) {
				if (ctrl is CheckBox) {
					if (((CheckBox)ctrl).ClientID.Equals (id))
						text = ((CheckBox)ctrl).ToolTip.Trim();
				}
			}
			return text;
		}
	}
}


