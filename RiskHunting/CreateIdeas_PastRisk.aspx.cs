﻿using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace RiskHunting
{
	
	public partial class CreateIdeas_PastRisk : BasePage
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
		const string aStartTag = "<a href=\"javascript:doLoad('AddResolutionIdea.aspx?from=CreateIdeas_PastRisk.aspx@id=";
		const string aMidTag1 = "&content=";
		const string aMidTag2 = "');\">";
		const string aEndTag = "</a>";

		int total;

		List<NLResponseToken> NLResponse;

//		protected string Expression = AppResources.CreativityPrompts_BaseForm + " ";

		protected string processPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources", "_toProcess");

		protected IList<string> CreativityPromptsFeed;
		protected string sourceId;
		protected Risk currentRisk;
		protected string currentRiskDescription;

		protected void Page_Init(object sender, EventArgs e)
		{
			this.currentRiskDescription = String.Empty;
			generatePrompts.Visible = true;
			alert_message_success.Visible = false;
			alert_message_error.Visible = false;
			if (Sessions.RiskState != String.Empty)
				sourceId = Sessions.RiskState;

			InitLabels ();
			if (Convert.ToInt32 (DetermineID ()) > 200000)
				GenerateContentNew ();
			else
				GenerateContent ();

			if (Sessions.CreativityPromptsPastRiskState != null) {
//				if (Session ["CURRENT_PAST_RISK_DESC"] != null) 
//					Session.Remove ("CURRENT_PAST_RISK_DESC");
				CreativityPromptsFeed = Sessions.CreativityPromptsPastRiskState;
				if (DetermineFrom().Equals(String.Empty))
					CreativityPromptsFeed.Shuffle ();
				else if (DetermineFrom ().Equals ("sameAddedIdeaSuccess")) {
					alert_message_success.Visible = true;
					successMessage.InnerText = AppResources.PastRisk_Notification_SuccessAdd;
					alert_message_error.Visible = false;
				} 
				PopulateData ();
			} else {
//				if (Session ["CURRENT_PAST_RISK_DESC"] != null)
//					NLResponse = (List<NLResponseToken>)Session ["CURRENT_PAST_RISK_DESC"];
//				else {
//					NLResponse = new List<NLResponseToken> ();
				RetrieveCurrentRisk ();
			
				CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

				var descr = this.currentRiskDescription;
//				var lang = LanguageDetection.DetectLanguage (descr);
//				if (!lang.language.Equals("en")) 
//				{
//					Translator tr = new Translator();	
//					var task = tr.TranslateString (descr, "en");
//					RetrieveNLData (task.Result, lang.language, currentCulture);
//				}
//				else 
					RetrieveNLData (descr, currentCulture);
				
//				}
			}

			var processGuidanceText = Util.GenerateProcessGuidance ("creativeGuidance");
			creativeGuidance.InnerText = processGuidanceText.Equals(String.Empty)?AppResources.ProcessGuidance_PastRisk_Default:processGuidanceText;

			if (Page.IsPostBack) {
				Console.WriteLine ("Page_Init - Page.IsPostBack");
				Util.AccessLog(Util.ScreenType.CreateIdea_PastRisk);
				content2.Controls.Clear ();
				if (Convert.ToInt32 (DetermineID ()) > 200000)
					GenerateContentNew ();
				else
					GenerateContent ();
//				hint_box.Visible = false;
			} else {
				Console.WriteLine ("Page_Init - NOT Page.IsPostBack");
//				GenerateContent ();
			}
		}



		protected void Page_Load(object sender, EventArgs e)
		{

			if (Sessions.RiskState != String.Empty)
				sourceId = Sessions.RiskState;
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
			LabelNavigationBarLeft.Text = AppResources.PastRisk_NavigationBar_Left;
			LabelNavigationBarTitle.Text = AppResources.PastRisk_NavigationBar_Title;
			GenerateAgain.Text = AppResources.PastRisk_Form_Button_NewPrompts.ToUpper();
		}

		#region Creativity Prompts


		void RetrieveNLData (string descr, CultureInfo currentCulture)
		{
			if (Convert.ToString (Session ["liveStatus"]) == "on") {
				string errorMsg;
				if(Util.ServiceExists(Constants.ANTIQUE_URI, false, out errorMsg)) {
					RiskHunting.antiqueService.AntiqueService antique = new RiskHunting.antiqueService.AntiqueService ();
					try
					{
						System.Net.ServicePointManager.Expect100Continue = false;
						var output = antique.NLParser (descr);
						this.NLResponse = Util.DeserializeNLResponse (output);
						if (Sessions.CreativityPromptsPastRiskState != null)
							Session.Remove(Sessions.creativityPromptsPastRiskState);
						//			Session ["CURRENT_PAST_RISK_DESC"] = NLResponse;
					}
					catch (Exception ex)
					{
					}
					finally {
						PrepareData (currentCulture);
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
				PrepareData (currentCulture);
				PopulateData ();
			}
		}


		List<string> GenerateGenericCreativityPrompts(CultureInfo currentCulture)
		{
			List<NLResponseToken> NLResponseTrimmed = new List<NLResponseToken> () ;
			foreach(var item in NLResponse)
			{
				var parsedTermValue = Regex.Replace(item.TermValue, @"[\[\]\(\)']+", "").Trim();
//				var regexItem = new Regex("^[a-zA-Z]*$");
				if (!parsedTermValue.Equals (String.Empty) && parsedTermValue.Length > 1) {
					NLResponseToken itemNew = item;
					if (item.Pos == "NP")
						itemNew.TermValue = "the " + parsedTermValue.Replace('.', ',');
					else
						itemNew.TermValue = parsedTermValue.Replace('.', ',');
					NLResponseTrimmed.Add (itemNew);
//					Response.Write (itemNew.TermValue + "<br>");
				}
			}

//			Response.Write ("<br><br>");

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

					var t = TranslatorGoogle.TranslateText (termValuesString, currentCulture.ToString ().Split(new char[] {'-'})[0]);
//					Translator tr = new Translator();	
//					var task = await tr.TranslateString (termValuesString, currentCulture.ToString ().Split(new char[] {'-'})[0]);
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
//							Response.Write (itemNew.TermValue + "<br>");
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

			string[] valuesNP = {};
			string[] valuesNP1 = {"presenza", "carrello", "ostruzione"};

			string[] valuesNP2 = {"contenitore", "stabilizzatore", "cartone", "contenitore", "peso", "operatore"};
			string[] valuesVP2 = {"essere in cartone pesante", "aprire si rompe verso il basso per il peso eccessivo del materiale", "essere sempre un rischio di collisione con l'operatore"};

			string[] valuesNP3 = {"sentiero per pedoni", "ponti", "bilanciatore"};

			string[] valuesNP4 = {"sentiero per pedoni"};

			string[] valuesNP5 = {"parte", "ponti", "percorso"};

			string[] valuesNPGeneric = {"oggetto", "materiale"};

			if (Convert.ToInt32 (DetermineID ()) == 201297)
				valuesNP = valuesNP1;
			else if (Convert.ToInt32 (DetermineID ()) == 200366)
				valuesNP = valuesNP2;
			else if (Convert.ToInt32 (DetermineID ()) == 201391)
				valuesNP = valuesNP3;
			else if (Convert.ToInt32 (DetermineID ()) == 200807)
				valuesNP = valuesNP4;
			else if (Convert.ToInt32 (DetermineID ()) == 200692)
				valuesNP = valuesNP5;
			else
				valuesNP = valuesNPGeneric;
			
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

			if (Convert.ToInt32 (DetermineID ()) == 200366)
				foreach (var item in valuesVP2) {
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

		void PrepareData (CultureInfo currentCulture)
		{
			if (!Page.IsPostBack) {
				if (Convert.ToString(Session["liveStatus"]) == "on")
					CreativityPromptsFeed = GenerateGenericCreativityPrompts (currentCulture);
				else
					CreativityPromptsFeed = GenerateGenericCreativityPromptsStatic ();
				CreativityPromptsFeed.Shuffle ();

				Console.WriteLine ("****** PrepareData *******");
				foreach (var item in CreativityPromptsFeed) {
					Console.WriteLine (item);
				}
				Console.WriteLine ("CreativityPromptsFeed.Count: " + CreativityPromptsFeed.Count);
			} else {

				if (Sessions.CreativityPromptsPastRiskState != null)
					CreativityPromptsFeed = Sessions.CreativityPromptsPastRiskState;
				else {
					Console.WriteLine ("no CREATIVITY_PROMPTS");
				}
			}

		}

		void PopulateData ()
		{
			if (!Page.IsPostBack) {
				Console.WriteLine ("****** PopulateData *******");
				this.total = CreativityPromptsFeed.Count < Constants.MaxPromptsAtATime ? CreativityPromptsFeed.Count : Constants.MaxPromptsAtATime -1;
				int counter = 0;
				if (this.total > 0)
				{
					content2.InnerHtml += "<br><br><span class=\"maintitle\">" + AppResources.PastRisk_Form_Label_CreativeGuidance + "</span>";
					for (int i = 0; i < this.total; i++) {
						content2.InnerHtml += GenerateHtml (CreativityPromptsFeed [i]);
//						GenerateHtml3 (CreativityPromptsFeed [i], String.Empty, counter++);
						Console.WriteLine (CreativityPromptsFeed [i]);
					}
					Sessions.CreativityPromptsPastRiskState = CreativityPromptsFeed;
				}
				else
					GenerateHtml3 ("No prompts available", String.Empty);
			} else {
				Console.WriteLine ("PopulateData");
				if (Sessions.CreativityPromptsPastRiskState != null) {
					this.total = CreativityPromptsFeed.Count < Constants.MaxPromptsAtATime ? CreativityPromptsFeed.Count : Constants.MaxPromptsAtATime;
					int counter = 0;
					content2.InnerHtml += "<br><br><span class=\"maintitle\">" + AppResources.PastRisk_Form_Label_CreativeGuidance + "</span>";
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
			//			Session ["CREATIVITY_PROMPTS_PAST_RISK"] = CreativityPromptsFeed;
			//			GenerateAgain.Text = "MORE PROMPTS";
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
			
		public virtual void morePromptsClicked(object sender, EventArgs args)
		{
			if (Sessions.CreativityPromptsPastRiskState != null) {
				Util.AccessLog(Util.ScreenType.CreateIdea_PastRisk, Util.FeatureType.CreateIdea_PastRisk_GenerateNewPromptsButton);

				content2.Controls.Clear ();
				if (Convert.ToInt32 (DetermineID ()) > 200000)
					GenerateContentNew ();
				else
					GenerateContent ();
				CreativityPromptsFeed = Sessions.CreativityPromptsPastRiskState;
				CreativityPromptsFeed.Shuffle ();
				PopulateData ();
			}
		}

		#endregion

		#region Risk Resolutions

		private void GenerateContent ()
		{
			string id = DetermineID ();
			string responseUri = DetermineResponseUri ();

			if (!responseUri.Equals (String.Empty)) {
				XmlProc.ResponseSerialized.MatchedSources response = XmlProc.ObjectXMLSerializer<XmlProc.ResponseSerialized.MatchedSources>.Load (responseUri);

				List<XmlProc.ResponseSerialized.MatchedSourcesMatchedSource> matchedSources = (List<XmlProc.ResponseSerialized.MatchedSourcesMatchedSource>)response.MatchedSource;

				int counter = 0;
				foreach (XmlProc.ResponseSerialized.MatchedSourcesMatchedSource matchedSource in matchedSources) {
					if (matchedSource.SourceId == id) {
						//                        currentIndex = matchedSourcesIds.IndexOfValue(id);
						//SortedList elements = SeperateStringByChar(matchedSource.Content);

						//						title.InnerHtml = String.Empty;
						this.currentRiskDescription = Util.ExtractAttributeContentFromString (matchedSource.Content, "Content");
//						RiskDescription.Text = Util.ExtractAttributeContentFromString(matchedSource.Content, "Content");
						string resText = String.Empty;
						var recommendation = Util.ExtractAttributeContentFromString2 (matchedSource.Content, "Recommendation").Trim();
						if (recommendation.Contains (";")) {
							string[] recommendationArray = recommendation.Split (';');
							for (int i = 0; i < recommendationArray.Length; i++) {
								resText += GenerateHtml (recommendationArray [i]);
							}
						} else {
							if (!recommendation.Trim().Equals (String.Empty))
								resText += GenerateHtml (recommendation);
						}

//							GenerateHtml2 (recommendation, String.Empty, counter++);
						//								content2.InnerHtml += GenerateHtml3 (recommendation, String.Empty, 0);

						var correctiveActions = Util.ExtractAttributeContentFromString2 (matchedSource.Content, "Corrective Actions");
						if (!correctiveActions.Trim().Equals (String.Empty))
							resText += GenerateHtml (correctiveActions);
//							GenerateHtml2 (correctiveActions, String.Empty, counter++);
						//								content2.InnerHtml += GenerateHtml3 (correctiveActions, String.Empty, 0);

						string ignoreWord = "None";
						var countermeasures = Util.ExtractAttributeContentFromString2 (matchedSource.Content, "Countermeasures");
						if (!countermeasures.Equals (String.Empty) 
							&& !countermeasures.Trim().ToLower().Contains (ignoreWord.ToLower())
						)
							resText += GenerateHtml (countermeasures);
//							GenerateHtml2 (countermeasures, String.Empty, counter++);
						//								content2.InnerHtml += GenerateHtml2 (countermeasures, String.Empty, 0);

						//							var c = new CheckBox ();
						//							c.ID = "CheckBox0";
						//							c.CheckedChanged += new EventHandler (CheckBox1_CheckedChanged);

						if (!resText.Equals(String.Empty))
							content2.InnerHtml += "<br><span class=\"maintitle\">" + AppResources.PastRisk_Form_Label_PreviousResolutions + "</span>";
						content2.InnerHtml += resText;
						break;

					}
				}

			}
//			Console.WriteLine ("content.Controls: " + content.Controls.Count);
		}

		private void GenerateContentNew ()
		{
			string id = DetermineID ();
			string responseUri = DetermineResponseUri ();

			if (!responseUri.Equals (String.Empty)) {
				XmlProc.ResponseSerialized.MatchedSources response = XmlProc.ObjectXMLSerializer<XmlProc.ResponseSerialized.MatchedSources>.Load (responseUri);

				List<XmlProc.ResponseSerialized.MatchedSourcesMatchedSource> matchedSources = (List<XmlProc.ResponseSerialized.MatchedSourcesMatchedSource>)response.MatchedSource;

				int counter = 0;
				foreach (XmlProc.ResponseSerialized.MatchedSourcesMatchedSource matchedSource in matchedSources) {
					if (matchedSource.SourceId == id) {
						//                        currentIndex = matchedSourcesIds.IndexOfValue(id);
						//SortedList elements = SeperateStringByChar(matchedSource.Content);

						//						title.InnerHtml = String.Empty;
						this.currentRiskDescription = Util.ExtractAttributeContentFromString (matchedSource.Content, "Content");
						//						RiskDescription.Text = Util.ExtractAttributeContentFromString(matchedSource.Content, "Content");
						string resText = String.Empty;
						var recommendation = Util.ExtractAttributeContentFromString2 (matchedSource.Content, "Action Plan").Trim();
						if (recommendation.Contains (";")) {
							string[] recommendationArray = recommendation.Split (';');
							for (int i = 0; i < recommendationArray.Length; i++) {
								resText += GenerateHtml (recommendationArray [i]);
							}
						} else {
							if (!recommendation.Trim().Equals (String.Empty))
								resText += GenerateHtml (recommendation);
						}


						if (!resText.Equals(String.Empty))
							content2.InnerHtml += "<br><span class=\"maintitle\">" + AppResources.PastRisk_Form_Label_PreviousResolutions + "</span>";
						content2.InnerHtml += resText;
						break;

					}
				}

			}
			//			Console.WriteLine ("content.Controls: " + content.Controls.Count);
		}


		private string DetermineID()
		{
			string id = String.Empty;
			if (Request.QueryString["id"] != null)
			{
				id = Request.QueryString["id"];
				Sessions.PastRiskState = id;
			}
			else
			{
				if (Sessions.PastRiskState != String.Empty)
					id = Sessions.PastRiskState;
			}
			return id;
		}

		private string DetermineResponseUri()
		{
			string responseUri = String.Empty;
			if (Sessions.ResponseUriState != String.Empty)
				responseUri = Sessions.ResponseUriState;
			else
			{
				if (Request.QueryString["path"] != null)
					responseUri = Request.QueryString["path"];
			}
			return responseUri;
		}

		private void GenerateHtml2 (string main, string second, int id)
		{
			content2.Controls.Add (new LiteralControl (Tag1)); 
			content2.Controls.Add (new LiteralControl (Tag2));
			content2.Controls.Add (new LiteralControl (main));
			content2.Controls.Add (new LiteralControl (Tag3));

//			if (categoryIDList != null && categoryIDList.Count > 0) {
//				if (categoryIDList.ContainsKey (id.ToString ())) {
//					CheckBox chk = (CheckBox)categoryIDList.GetByIndex (id);
//					content2.Controls.Add (chk);
//				} else
//					content2.Controls.Add (CreateCheckboxControl (id.ToString (), main));
//			}
//			else
			content2.Controls.Add (CreateCheckboxControl (id.ToString (), main));

			content2.Controls.Add (new LiteralControl (Tag6));
			content2.Controls.Add (new LiteralControl (Tag7));
			content2.Controls.Add (new LiteralControl (Tag8));
			content2.Controls.Add (new LiteralControl (second));
			content2.Controls.Add (new LiteralControl (Tag9));
			content2.Controls.Add (new LiteralControl (Tag10));
		}

		#endregion

		private string GenerateHtml(string idea)
		{
			return LiStartTagMenu +
				aStartTag + DetermineID() + aMidTag1 + Microsoft.Security.Application.AntiXss.JavaScriptEncode(idea, false) + aMidTag2 +
				SpanStartTagName + idea + SpanEndTag +
				SpanStartTagArrow + SpanEndTag + aEndTag + LiEndTag;
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

		void UpdateRisk ()
		{
			RetrieveCurrentRisk ();
			bool entryAdded = false;
//			for (int i = 0; i < content.Controls.Count; i++) {
//				var ctrl = content.Controls [i];
//				if (ctrl is CheckBox) {
//					bool result = ((CheckBox)ctrl).Checked;
//					if (result)
//					if ((!this.currentRisk.Recommendations.Contains (RetrieveCheckboxText (((CheckBox)ctrl).ClientID)))
//						&& (!((CheckBox)ctrl).ToolTip.Trim ().Equals(String.Empty))) {
//						this.currentRisk.Recommendations.Add (((CheckBox)ctrl).ToolTip.Trim ());
//						entryAdded = true;
//						Console.WriteLine ("Selected: " + ((CheckBox)ctrl).ToolTip.Trim ());
//					}
//				}
//			}
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
			
		public virtual void submitClicked(object sender, EventArgs args)
		{
			Console.WriteLine ("submitButtonClicked");
			if (!this.sourceId.Equals (String.Empty)) {

				UpdateRisk ();
				//				Response.Redirect("Solution_ResolutionIdeas.aspx");
			}
			if (Sessions.CreativityPromptsPastRiskState != null) {
				CreativityPromptsFeed = Sessions.CreativityPromptsPastRiskState;
//				CreativityPromptsFeed.Shuffle ();
				PopulateData ();
			}

		}

		public virtual void backClicked(object sender, EventArgs args)
		{
			Console.WriteLine ("backButtonClicked");
			if (Sessions.CreativityPromptsPastRiskState != null)
				Session.Remove (Sessions.creativityPromptsPastRiskState);
			Response.Redirect("CreateIdeas_PastRisks.aspx");


		}

	}
}

