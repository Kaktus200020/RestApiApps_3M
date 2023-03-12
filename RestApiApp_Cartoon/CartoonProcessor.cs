using Newtonsoft.Json;
using RestApiApp_Cartoon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApiApp_Cartoon
{
    public static class CartoonProcessor
    {
        private static HttpClient client = new HttpClient();
        public static async Task<CartoonModel> LoadCartoon(int id = 1)
        {
            string url = $"https://rickandmortyapi.com/api/character/{id}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {

                string responseString = await response.Content.ReadAsStringAsync();
                CartoonModel cartoonModel = JsonConvert.DeserializeObject<CartoonModel>(responseString);
                return cartoonModel;
            }
        }
    }
}
