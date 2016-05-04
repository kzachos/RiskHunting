using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;

using System.IO;

using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;
using TranslationsResource = Google.Apis.Translate.v2.Data.TranslationsResource;
using System.Collections.ObjectModel;

namespace RiskHunting
{
	public static class TranslatorGoogle
	{
//		public async Task Translate()
//		{
//			// Create the translation service.
//			var service = new TranslateService(new BaseClientService.Initializer()
//				{
//					ApiKey = "AIzaSyAtalMTpm93zFP-mitQCupbtUw62xewftE", // your API key, that you get from Google Developer Console
//					ApplicationName = "Risk Hunting App" // your application name, that you get form Google Developer Console
//				});
//
//
//			String text_to_translate = "Hello!";    
//			String target_language_shortname = "fr";
//
//			string[] srcText = new[] { text_to_translate };
//			var response = await service.Translations.List(srcText, target_language_shortname).ExecuteAsync();
//			String translated_text = response.Translations[0].TranslatedText;
//
//		}

		public static string TranslateText(string Text, string targetlan)
		{
			try
			{
				LanguagesListResponse ls = new LanguagesListResponse();
				Google.Apis.Translate.v2.Data.LanguagesResource ss = new Google.Apis.Translate.v2.Data.LanguagesResource();
				ss.Language = targetlan;

				// GetLanguageCode
				string googlekey = "AIzaSyDyv6EMiTbVnpqWfj0qCu-IHEizkUhudmA";

				var service = new TranslateService(new BaseClientService.Initializer()
					{
						ApiKey = googlekey,
						ApplicationName = "RHApp"
					});
				//new TranslateService { Key = googlekey };
				ICollection<string> data = new Collection<string>();
				string[] srcText = new[] { Text };
				TranslationsListResponse response = service.Translations.List(srcText, targetlan).Execute();
				var translations = new List<string>();

				// We need to change this code...
				// currently this code 
				foreach (Google.Apis.Translate.v2.Data.TranslationsResource translation in response.Translations)
				{
					translations.Add(translation.TranslatedText);
				}
				var result = translations[0];
				process_translation(ref result);
				return result;
			}
			catch (Exception ex)
			{
				return Text;
			}
		}

		static void process_translation(ref String s)
		{
			s = System.Web.HttpUtility.HtmlDecode(s);
			s = s.Replace("_", " ");
			s = s.Replace(" ,", ",");
			s = s.Replace(" .", ".");

			s = s.Replace(" /", "/"); s = s.Replace("/ ", "/");
			s = s.Replace("“ ", "“"); s = s.Replace(" ”", "”");
			s = s.Replace("( ", "("); s = s.Replace(" )", ")");
			s = s.Replace("# ", "#"); s = s.Replace(" #", "#");
			s = s.Replace(" '", "'"); s = s.Replace("' ", "'");

			s = s.Replace("??", ""); // remove ??, a Google Translate bug

			s = s.Replace("«", "\""); s = s.Replace("»", "\"");

//			process_quotationmarks(ref s);

			// normal quotation marks
			s = s.Replace("\"-", "\" -"); // "- to " -
			s = s.Replace("-\"", "- \""); // -" to - "

			s = s.Replace("\"–", "\" –"); // "- to " –
			s = s.Replace("–\"", "– \""); // –" to - "

			// left quotation marks
			s = s.Replace("“-", "“ -"); // “- to “ -
			s = s.Replace("-“", "- “"); // -“ to - “

			s = s.Replace("“–", "“ –"); // “- to “ –
			s = s.Replace("–“", "– “"); // –" to - “

			// right quotation marks
			s = s.Replace("”-", "” -"); // ”- to ” -
			s = s.Replace("-”", "- ”"); // -” to - ”

			s = s.Replace("”–", "” –"); // ”- to ” –
			s = s.Replace("–”", "– ”"); // –” to - ”

		}


		static void process_quotationmarks(ref String s)
		{
			int no_qm = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '\"') no_qm++;
				if (s[i] == '“') no_qm++;
				if (s[i] == '”') no_qm++;
				if (s[i] == '«') no_qm++;
				if (s[i] == '»') no_qm++;

			}
			if (no_qm % 2 == 0) // process quotation mark only if there is an even number of them in the description
			{
				s = s.Replace(" \"", "\""); s = s.Replace("\" ", "\"");
				int left_or_right = -1;
				for (int i = 0; i < s.Length; i++)
				{
					if (s[i] == '\"')
					{
						if (left_or_right == -1) // put a space to the left
						{
							if (i > 0) // the description does not begin with "
							{
//								if ((is_newline_char(s[i - 1]) == false) && (s[i - 1] != ' ')) // the line does not begin with "
								if (!s[i - 1].Equals('\n') && (s[i - 1] != ' '))
								{
									s = s.Insert(i, " ");
									i++;
								}
							}
						}
						else // put a space to the right
						{
							if (i < s.Length - 1) // if the document the not end with "
							{
//								if (is_newline_char(s[i + 1]) == false) // if the line does not end with "
								if (!s[i + 1].Equals('\n'))
								{
									if (Char.IsLetter(s[i + 1]) || Char.IsDigit(s[i + 1])) // if the next character is a letter or digit
									{
										s = s.Insert(i + 1, " ");
									}
								}
							}
						}
						left_or_right = left_or_right * -1;
					}
					if ((s[i] == '«') || (s[i] == '»')) left_or_right = left_or_right * -1;
				}
				s = s.Replace("\"( ", "\" (");
				s = s.Replace("( \"", "(\"");
				s = s.Replace("\"(", "\" (");
			}
		}

		static void process_dash(ref String s)
		{
			s = s.Replace(" -", "-"); s = s.Replace("- ", "-");
			s.Replace(" –", "–"); s = s.Replace("– ", "–");
		}
	}


}
