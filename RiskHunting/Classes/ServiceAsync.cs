using System;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RiskHunting
{
	public static class ServiceAsync
	{
		public static Task<RiskHunting.antiqueService.NLParserCompletedEventArgs> LoginAsyncTask(this RiskHunting.antiqueService.AntiqueService client, string content) 
		{ 
			var tcs = CreateSource<RiskHunting.antiqueService.NLParserCompletedEventArgs>(null); 
//			client.NLParserCompleted += (sender, e) => TransferCompletion(tcs, e, () => e, null); 
			client.NLParserCompleted += objAntique_NLParserCompleted;
			client.NLParserAsync(content);
			return tcs.Task; 
		}

		static void objAntique_NLParserCompleted(object sender, 
			RiskHunting.antiqueService.NLParserCompletedEventArgs e)
		{
			Console.WriteLine (e.Result);

		}

		static TaskCompletionSource<T> CreateSource<T>(object state) 
		{ 
			return new TaskCompletionSource<T>( 
				state, TaskCreationOptions.None); 
		}

//		static void TransferCompletion<T>( 
//			TaskCompletionSource<T> tcs, AsyncCompletedEventArgs e, 
//			Func<T> getResult, Action unregisterHandler) 
//		{ 
//			if (e.UserState == tcs) 
//			{ 
//				if (e.Cancelled) tcs.TrySetCanceled(); 
//				else if (e.Error != null) tcs.TrySetException(e.Error); 
//				else tcs.TrySetResult(getResult()); 
//				if (unregisterHandler != null) unregisterHandler();
//			} 
//		}
	}
}

