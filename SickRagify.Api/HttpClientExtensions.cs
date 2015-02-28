using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SickRagify.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace SickRagify
{
	public static class HttpClientExtensions
	{
		public static dynamic GetDynamic (this HttpClient client, string command)
		{
			var task = client.GetDynamicAsync (command);
			task.Wait ();

			return task.Result;
		}

		public static async Task<dynamic> GetDynamicAsync (this HttpClient client, string command)
		{
			var response = await client.GetAsync (Settings.Instance.Url + command);
			AdjustContentType (response);

			var jsonString = await response.Content.ReadAsStringAsync ();

			return JObject.Parse (jsonString);
		}

		public static T GetAsync<T> (this HttpClient client, string command)
		{
			var response = client.GetResponseAsync<T> (command);
			return response.Data;
		}

		public static T Get<T> (this HttpClient client, string command)
		{
			var task = client.GetAsync<T> (command);
            

			return task;
		}

		public static T Get<T> (this HttpClient client, string command, params object[] parameters)
		{
			var task = client.GetAsync<T> (string.Format (command, parameters));
            

			return task;
		}

		public static DataResponse<T> GetResponseAsync<T> (this HttpClient client, string command)
		{


			var response = client.GetAsync (Settings.Instance.Url + command).Result;
			AdjustContentType (response);

			var jsonString = response.Content.ReadAsStringAsync ().Result;

			return JsonConvert.DeserializeObject<DataResponse<T>> (jsonString);
		}

		public static DataResponse<T> GetResponse<T> (this HttpClient client, string command)
		{
			var task = client.GetResponseAsync<T> (command);
			//task.Wait();

			return task;
		}

		public static DataResponse<T> GetResponse<T> (this HttpClient client, string command, params object[] parameters)
		{
			var task = client.GetResponseAsync<T> (string.Format (command, parameters));
            

			return task;
		}

		public static byte[] GetImageAsync (this HttpClient client, string command)
		{
			var response = client.GetAsync (Settings.Instance.Url + command).Result;
			byte[] img = response.Content.ReadAsByteArrayAsync ().Result;

			return img;
		}

		public static byte[] GetImage (this HttpClient client, string command)
		{
			var task = client.GetImageAsync (command);

			return task;
		}

		private static void AdjustContentType (HttpResponseMessage response)
		{
			response.Content.Headers.ContentType.CharSet = "UTF-8";
		}
	}
}