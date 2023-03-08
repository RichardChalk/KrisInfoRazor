using KrisInfoRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace KrisInfoRazor.Pages
{
    public class SingleMessageModel : PageModel
    {
        public KrisInfoResponse Message { get; set; }
        public async Task<IActionResult> OnGet(int messId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.krisinformation.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync($"/v3/news/{messId}");
            if (response.IsSuccessStatusCode)
            {
                // G�r om responsen till en str�ng
                var responseBody = await response.Content.ReadAsStringAsync();
                // G�r om str�ngen till v�r egen skapade datatyp - KrisInfoResponse
                Message = JsonConvert.DeserializeObject<KrisInfoResponse>(responseBody);
            }
            return Page();
        }
    }
}
