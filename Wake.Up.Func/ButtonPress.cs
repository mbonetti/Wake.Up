using IoTHubTrigger = Microsoft.Azure.WebJobs.ServiceBus.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wake.Up.Func
{
    public static class ButtonPress
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("ButtonPress")]
        public static async Task Run([IoTHubTrigger("messages/events", Connection = "IoTHubConnectionString")]EventData message, TraceWriter log)
        {
            await client.PostAsync("https://prod-07.eastus.logic.azure.com:443/workflows/e6bb3915f050498e81b6f9e26e48aef4/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=rsZc2iVqZij_CsO4ZeMWRvjByX6_Dibp7PqXHtJQkOo", null);
        }
    }
}