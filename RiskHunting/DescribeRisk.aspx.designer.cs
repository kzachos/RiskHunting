using System;
using System.Web;
using System.Web.UI;

namespace RiskHunting
{
	
	public partial class DescribeRisk
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;

		protected System.Web.UI.ScriptManager ScriptManager1;

		protected System.Web.UI.Timer Timer1;

		protected System.Web.UI.UpdatePanel UpdatePanel1;

		protected System.Web.UI.WebControls.Label AutoSaveLabel;

		protected System.Web.UI.HtmlControls.HtmlGenericControl errorMsg;

		protected System.Web.UI.HtmlControls.HtmlSelect RiskName;

		protected World.Code.WebControls.WatermarkedTextBox RiskDescription;

		protected World.Code.WebControls.WatermarkedTextBox RiskAuthor;

		protected World.Code.WebControls.WatermarkedTextBox RiskAuthorFIN;

		protected System.Web.UI.HtmlControls.HtmlSelect RiskDepartment;

		protected System.Web.UI.HtmlControls.HtmlSelect RiskBodyParts;  

		protected System.Web.UI.HtmlControls.HtmlSelect RiskInjury;

		protected World.Code.WebControls.WatermarkedTextBox RiskPersonInvolved;

		protected System.Web.UI.WebControls.Button submit;

		protected System.Web.UI.HtmlControls.HtmlGenericControl previousrisks;

		protected System.Web.UI.HtmlControls.HtmlGenericControl deleteRiskDiv;

		protected System.Web.UI.HtmlControls.HtmlGenericControl alert_message_success;

		protected System.Web.UI.HtmlControls.HtmlGenericControl alert_message_error;

		protected System.Web.UI.WebControls.Button previousrisksButton;

		protected System.Web.UI.HtmlControls.HtmlGenericControl creativeGuidance;

		protected System.Web.UI.HtmlControls.HtmlGenericControl successMessage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl errorMessage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl rightbutton;

		protected System.Web.UI.HtmlControls.HtmlSelect DateIncidentOccurredDay;

		protected System.Web.UI.HtmlControls.HtmlSelect DateIncidentOccurredMonth;

		protected System.Web.UI.HtmlControls.HtmlSelect LocationLetter;

		protected System.Web.UI.HtmlControls.HtmlSelect LocationNumber;

		protected System.Web.UI.HtmlControls.HtmlSelect DateIncidentOccurredYear;

		protected System.Web.UI.HtmlControls.HtmlGenericControl PINcodeDiv;

		protected System.Web.UI.WebControls.Label LabelAuthor;

		protected System.Web.UI.WebControls.Label LabelAuthorFIN;

		protected System.Web.UI.WebControls.Label LabelDescription;

		protected System.Web.UI.WebControls.Label LabelIncidentCategory;

		protected System.Web.UI.WebControls.Label LabelPersonInvolved;

		protected System.Web.UI.WebControls.Label LabelDepartment;

		protected System.Web.UI.WebControls.Label LabelLocation;

		protected System.Web.UI.WebControls.Label LabelInjuryType;

		protected System.Web.UI.WebControls.Label LabelDateOfIncident;

		protected System.Web.UI.WebControls.Label LabelUploadPicture;

		protected System.Web.UI.WebControls.Label LabelRequired1;

		protected System.Web.UI.WebControls.Label LabelRequired2;

		protected System.Web.UI.WebControls.Label LabelRequired3;

		protected System.Web.UI.WebControls.Button imageButton;

		protected System.Web.UI.WebControls.Button reset;

		protected System.Web.UI.WebControls.Button delete;

		protected System.Web.UI.WebControls.Button createIdeasButton;

		protected System.Web.UI.WebControls.Label LabelNavigationBarLeft;

		protected System.Web.UI.WebControls.Label LabelNavigationBarRight;

		protected System.Web.UI.WebControls.Label LabelNavigationBarTitle;

		protected global::System.Web.UI.HtmlControls.HtmlAnchor linkEnglishLang;

		protected global::System.Web.UI.HtmlControls.HtmlAnchor linkItalianLang;
		}
}

