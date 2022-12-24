using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using Function1.Entity;

namespace Function1
{
    public static class Function1
    {
        //[FunctionName("Function1")]
        //public static async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Function, "get", "post",Route = "api/Function1/{filename:string}/{filesize:string}/{foldername:string}")] HttpRequest req,
        //    string filename,string filesize,string foldername,
        //    ILogger log)
        //{
        //    //log.LogInformation("C# HTTP trigger function processed a request.");

        //    //string name = req.Query["name"];

        //    //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    //dynamic data = JsonConvert.DeserializeObject(requestBody);
        //    //name = name ?? data?.name;

        //    //string responseMessage = string.IsNullOrEmpty(name)
        //    //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        //    //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

        //    var content = await new StreamReader(req.Body).ReadToEndAsync();

        //    JObject json = JObject.Parse(content);


        //    return new OkObjectResult(json);
        //}

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
             [HttpTrigger(AuthorizationLevel.Function, "get", "post",
             Route = "api/function1/{filename}/{filesize}/{foldername}")]
             HttpRequestMessage req, string filename, string filesize,string foldername, TraceWriter log)
        {
            // more code goes here...

            var file = new FakeFile()
            {
                FileName = filename,
                FileSize = filesize,
                FolderName = foldername
            };

            var jsonString = System.Text.Json.JsonSerializer.Serialize($"FileName :${file.FileName}FileFolder :{ file.FolderName}");

            


            return new OkObjectResult(jsonString);
        }
    }
}
