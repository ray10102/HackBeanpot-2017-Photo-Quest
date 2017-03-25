using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class API : MonoBehaviour {

	private static string API_KEY = "dcaa30c5d92dff8ce64608f8a93ebc08"; //Indico API Key
	private static string BASE_URL = "https://apiv2.indico.io";
	private static string IMAGE_REC = API.BASE_URL + "/imagerecognition";

	void Start(){
		API.recongize (); // Temoprary. Will be called after image is taken.
	}

	/**
	 * This method accesses the Indico API and compares the image (base64) given in the parameter
	 * and returns the keywords of the highest percentage image.
	 * TODO: Add the parameter for the base64 image.
	 **/
	public static string recongize(){
		// Create Web Request
		WebRequest req = WebRequest.Create (IMAGE_REC);
		req.Headers.Add ("X-Apikey", API.API_KEY); // Add API_KEY to request
		req.Method = "POST";
		using (var writer = new StreamWriter(req.GetRequestStream ())){
			string json = "{\"data\": \"http://i.imgur.com/i7DeHDP.jpg\"}";
			writer.Write (json);
			writer.Flush ();
			writer.Close ();
		}
		var httpResponse = (HttpWebResponse) req.GetResponse();
		using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
			var results = streamReader.ReadToEnd();
			JSONObject obj = new JSONObject (results)["results"];
			double high = 0;
			string item = "";
			foreach (var x in obj.keys){
				if (obj.GetField (x).n > high) {
					high = obj.GetField (x).n;
					item = x;
				}
			}
			Debug.Log (item);

			return item;
		}


	}
		
}