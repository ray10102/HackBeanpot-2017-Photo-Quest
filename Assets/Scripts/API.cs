using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using UnityEngine;

public class API : MonoBehaviour
{

    private static string API_KEY = "dcaa30c5d92dff8ce64608f8a93ebc08"; //Indico API Key
    private static string BASE_URL = "https://apiv2.indico.io";
    private static string IMAGE_REC = API.BASE_URL + "/imagerecognition";

    void Start()
    {

    }


    struct ItemRes
    {
        public string key { get; set; }
        public double percent { get; set; }
        public ItemRes(string key, double percent)
        {
            this.key = key;
            this.percent = percent;
        }
    }
    /**
	 * This method accesses the Indico API and compares the image (base64) given in the parameter
	 * and returns the keywords of the highest percentage image.
	 * TODO: Add the parameter for the base64 image.
	 **/
    public static string[] recongize(string picture)
    {
        // Create Web Request
        WebRequest req = WebRequest.Create(IMAGE_REC);
        req.Headers.Add("X-Apikey", API.API_KEY); // Add API_KEY to request
        req.Method = "POST";
        using (var writer = new StreamWriter(req.GetRequestStream()))
        {
            string json = "{\"data\": \"" + picture + "\" }";
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
        var httpResponse = (HttpWebResponse)req.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            // Get the results and store into JSONObject...
            var results = streamReader.ReadToEnd();
            JSONObject obj = new JSONObject(results)["results"];

            // Put every item into an array (I changed my mind, multiple arrays isn't better, Ray.)
            List<ItemRes> allItems = new List<ItemRes>();
            foreach (var x in obj.keys) allItems.Add(new ItemRes(x, obj[x].f));

            // Bubble sort because time...
            for (int i = allItems.Count; i >= 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (allItems.ElementAt(j).percent > allItems.ElementAt(j + 1).percent)
                    {
                        var temp = allItems.ElementAt(j);
                        allItems[j] = allItems.ElementAt(j + 1);
                        allItems[j + 1] = temp;
                    }
                }
            }
            // All all possible options to comma sepearted list [so we can just go stringvar.Contains("cat")
            List<string> final = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string sts = allItems.ElementAt(allItems.Count - 1 - i).key;
                string[] pieces = sts.Split(new char[] { ',' });
                foreach (string s in pieces) final.Add(s.Trim());
            }
            foreach (string s in final) Debug.Log(s);
            return final.ToArray();
        }
    }

}