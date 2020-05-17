using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBLL.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        public AnalysisService() { }

        public async Task<string> AnalyseImage(string path)
        {
            var client = new RestClient("https://app.nanonets.com/api/v2/ImageCategorization/LabelFile/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("r897kyXgQXladm0EN-eVSahtZib22UtP:")));
            request.AddHeader("accept", "Multipart/form-data");
            request.AddParameter("modelId", "f12ed3b7-2a8c-44bc-a132-49c89e790e35");
            request.AddFile("file", path);
            IRestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content);
            
            double probability = Convert.ToDouble(responseData["result"][0]["prediction"][0]["probability"].ToString());

            if (probability < 0.5)
                return null;

            string analyzedName = responseData["result"][0]["prediction"][0]["label"].ToString();

            return analyzedName;
        }
    }
}
