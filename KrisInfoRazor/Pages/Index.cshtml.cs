﻿using KrisInfoRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace KrisInfoRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<KrisInfoResponse> Messages { get; set; }
        public async Task<IActionResult> OnGet()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.krisinformation.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/v3/news?days=90");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                var responseBody = await response.Content.ReadAsStringAsync();
                // Gör om strängen till vår egen skapade datatyp - KrisInfoResponse
                Messages = JsonConvert.DeserializeObject<List<KrisInfoResponse>>(responseBody);
            }
            return Page();
        }
    }
}