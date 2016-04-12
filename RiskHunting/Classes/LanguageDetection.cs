using System;
using System.Collections.Generic;
using RestSharp;

namespace RiskHunting
{
	public class Detection
	{
		public string language { get; set; }
		public bool isReliable { get; set; }
		public float confidence { get; set; }
	}

	public class ResultData
	{
		public List<Detection> detections { get; set; }
	}

	public class Result
	{
		public ResultData data { get; set; }
	}

	public static class LanguageDetection
	{
		public static Detection DetectLanguage (string query)
		{
			var client = new RestClient("http://ws.detectlanguage.com");
			var request = new RestRequest("/0.2/detect", Method.POST);

			request.AddParameter("key", "ff553f19676b9aaf59ec8422febdf321");
			request.AddParameter("q", query);

			IRestResponse response = client.Execute(request);

			RestSharp.Deserializers.JsonDeserializer deserializer = new RestSharp.Deserializers.JsonDeserializer();

			var result = deserializer.Deserialize<Result>(response);

			return result.data.detections[0];
		}
	}
}

