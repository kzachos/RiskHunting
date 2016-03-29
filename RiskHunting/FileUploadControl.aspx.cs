using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RiskHunting
{
	public partial class FileUploadControl : BasePage
    {
		protected string sourceId;
		protected string filePath;
		protected Risk currentRisk;
		protected string processPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources", "_toProcess");
		protected string sourcesPath = Path.Combine (SettingsTool.GetApplicationPath(), "xmlFiles", "Sources");
		protected string imagesPath = Path.Combine ("xmlFiles", "Sources", Constants.CASE_TYPE, Constants.IMAGESFOLDER);

        protected void Page_Load(object sender, EventArgs e)
        {

			alert_message_success.Visible = false;
			alert_message_error.Visible = false;
			previewDiv.Visible = false;
			ButtonsDiv.Visible = false;

			InitLabels ();

			if (Sessions.RiskState != String.Empty) {
				this.sourceId = Sessions.RiskState;
				RetrieveCurrentRisk ();
				if (!this.currentRisk.ImageUri.Equals (string.Empty)) {
					string subPath = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.IMAGESFOLDER, this.sourceId);
					bool exists = Directory.Exists (subPath);
					if (exists) {
						DirectoryInfo di = new DirectoryInfo (subPath);
						var firstFileName = di.EnumerateFiles ()
							.Select (f => f.Name)
							.FirstOrDefault ();
						if (firstFileName != null) {
							var imageFormat = Util.GetImageFormat (Path.Combine (subPath, firstFileName));
							if (!imageFormat.Equals (Util.ImageFormat.unknown)) {
								var imageUri = Path.Combine (imagesPath, this.sourceId, firstFileName);
								Image1.ImageUrl = imageUri;
								previewDiv.Visible = true;
								ButtonsDiv.Visible = true;
							} 
						}
					}
				}
			} else {
				alert_message_success.Visible = false;
				errorMessage.InnerText = AppResources.UploadImage_Notification_RequiredFields;
				alert_message_error.Visible = true;
				FileUpload1.Visible = false;
				UploadImage.Visible = false;
			}

        }

		private void InitLabels ()
		{
			LabelNavigationBarLeft.Text = AppResources.UploadImage_NavigationBar_Left;
			LabelNavigationBarTitle.Text = AppResources.UploadImage_NavigationBar_Title;
			LabelImagePreview.Text = AppResources.UploadImage_Form_Label_ImagePreview;
			UploadImage.Text = AppResources.UploadImage_Button_UploadImage.ToUpper();
			Cancel.Text = AppResources.UploadImage_Form_Button_DeleteImage.ToUpper();
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

		#region Xml generation
		private void GenerateXml(string componentType)
		{
			string Ref;
			string xmlUri, xmlUri2;
			if (componentType.Equals("SourceSpecification"))
			{
				XmlProc.SourceSpecificationSerialized.SourceSpecification ss = Util.CreateSourceSpecificationXml(this.currentRisk);
				//				Console.WriteLine ("this.sourceId (GenerateXml): " + this.sourceId.ToString ());
				Ref = Constants.SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.SOURCESPECIFICATION, Ref);
				xmlUri2 = Path.Combine (sourcesPath, Constants.PROCESSFOLDER, Constants.SOURCESPECIFICATION, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Save(ss, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.SourceSpecificationSerialized.SourceSpecification>.Save(ss, xmlUri2);
			}
			else if (componentType.Equals("Problem"))
			{
				XmlProc.ProblemSerialized.LanguageSpecificSpecification problem = Util.CreateProblemXml(this.currentRisk);
				Ref = Constants.SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.PROBLEM, Ref);
				xmlUri2 = Path.Combine (sourcesPath, Constants.PROCESSFOLDER, Constants.PROBLEM, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Save(problem, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.ProblemSerialized.LanguageSpecificSpecification>.Save(problem, xmlUri2);
			}
			else if (componentType.Equals("Solution"))
			{
				XmlProc.SolutionSerialized.LanguageSpecificSpecification solution = Util.CreateSolutionXml(this.currentRisk);
				Ref = Constants.SOURCE_TYPE + this.sourceId + "_" + componentType + ".xml";
				xmlUri = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.SOLUTION, Ref);
				xmlUri2 = Path.Combine (sourcesPath, Constants.PROCESSFOLDER, Constants.SOLUTION, Ref);
				XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Save(solution, xmlUri);
				XmlProc.ObjectXMLSerializer<XmlProc.SolutionSerialized.LanguageSpecificSpecification>.Save(solution, xmlUri2);
			}

		}

		#endregion
			
		/// <summary>
		/// Button click event to upload the selcted file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void uploadClicked(object sender, EventArgs e)
		{
			if (FileUpload1.HasFile)
			{
				string subPath = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.IMAGESFOLDER, this.sourceId);
				bool exists = Directory.Exists(subPath);
				if (!exists)
					Directory.CreateDirectory (subPath);
				else {
					if (!Util.IsDirectoryEmpty (subPath)) {
						System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(subPath);
						foreach (FileInfo file in downloadedMessageInfo.GetFiles())
						{
							file.Delete(); 
						}
						foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
						{
							dir.Delete(true); 
						}
					}
				}

				previewDiv.Visible = true;
				ButtonsDiv.Visible = true;
//				string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
				string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName); 
				var Ref = this.sourceId + extension;
				var imageUri = Path.Combine (imagesPath, this.sourceId, Ref);
				FileUpload1.SaveAs(imageUri);
				/*Uploaded file path*/
				this.filePath = imageUri;
				/*******************************************/
				/*Code to save the file path into data base*/
				/*******************************************/

				Image1.ImageUrl = this.filePath;

				this.currentRisk.ImageUri = imageUri;
				GenerateXml (Constants.SOURCESPECIFICATION);
				GenerateXml (Constants.PROBLEM);
				GenerateXml (Constants.SOLUTION);

				alert_message_success.Visible = true;
				successMessage.InnerText = AppResources.UploadImage_Notification_SuccessUpload;
				alert_message_error.Visible = false;

			}
			else
			{
				alert_message_success.Visible = false;
				errorMessage.InnerText = AppResources.UploadImage_Notification_SelectFile;
				alert_message_error.Visible = true;
			}
		}

		protected void saveClicked(object sender, EventArgs e)
		{
			string subPath = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.IMAGESFOLDER, this.sourceId);
			bool exists = Directory.Exists(subPath);
			if (exists) {
				DirectoryInfo di = new DirectoryInfo (subPath);
				var firstFileName = di.EnumerateFiles ()
					.Select (f => f.Name)
					.FirstOrDefault ();
				var imageFormat = Util.GetImageFormat (Path.Combine (subPath, firstFileName));
				if (!imageFormat.Equals (Util.ImageFormat.unknown)) {
					this.currentRisk.ImageUri = firstFileName;
					GenerateXml (Constants.SOURCESPECIFICATION);
					GenerateXml (Constants.PROBLEM);
					GenerateXml (Constants.SOLUTION);

					Response.Redirect ("DescribeRisk.aspx");
				} else {
					alert_message_success.Visible = false;
					errorMessage.InnerText = AppResources.UploadImage_Notification_IncorrectFormat;
					alert_message_error.Visible = true;
				}
			} else {
				alert_message_success.Visible = false;
				errorMessage.InnerText = AppResources.UploadImage_Notification_FailedUpload;
				alert_message_error.Visible = true;
			}


		}

		protected void cancelClicked(object sender, EventArgs e)
		{
			string subPath = Path.Combine (sourcesPath, Constants.CASE_TYPE, Constants.IMAGESFOLDER, this.sourceId);
			bool exists = Directory.Exists(subPath);
			if (exists) {
				DirectoryInfo di = new DirectoryInfo (subPath);
				var firstFileName = di.EnumerateFiles ()
					.Select (f => f.Name)
					.FirstOrDefault ();
				var imageFormat = Util.GetImageFormat (Path.Combine (subPath, firstFileName));
				if (!imageFormat.Equals (Util.ImageFormat.unknown)) {
//					System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(subPath);
//					foreach (FileInfo file in downloadedMessageInfo.GetFiles())
//					{
//						file.Delete(); 
//					}
//					foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
//					{
//						dir.Delete(true); 
//					}
					File.Delete (Path.Combine (subPath, firstFileName));
					Directory.Delete(subPath, true);
//					Response.Redirect ("DescribeRisk.aspx");

					this.currentRisk.ImageUri = String.Empty;
					GenerateXml (Constants.SOURCESPECIFICATION);
					GenerateXml (Constants.PROBLEM);
					GenerateXml (Constants.SOLUTION);

					alert_message_success.Visible = true;
					successMessage.InnerText = AppResources.UploadImage_Notification_SuccessDelete;
					alert_message_error.Visible = false;
					ButtonsDiv.Visible = false;
					previewDiv.Visible = false;
				}
				else {
					alert_message_success.Visible = false;
					errorMessage.InnerText = AppResources.UploadImage_Notification_FailedDelete;
					alert_message_error.Visible = true;
				}
			} 
		}


    }
}