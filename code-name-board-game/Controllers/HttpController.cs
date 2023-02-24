using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace code_name_board_game.Controllers
{
    public static class HttpController
    {
        /// <summary>
        /// URI is currently on cat facts for testing. change to our api/cloud function when complete.
        /// </summary>
        /// <returns>string - responseBody</returns>
        public static async  Task<string> TestApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://eu-gb.functions.appdomain.cloud/api/v1/web/6475b84b-4d1f-4690-87cb-e01858b69887/gameboard/Test");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

        }

        
    }
}