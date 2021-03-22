using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrowCmsClient.Models;

namespace TrowCmsClient.Controllers
{
    public class PagesController : Controller
    {
        // GET pages
        public async Task<IActionResult> Index()
        {
            List<Page> pages = new List<Page>();

            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync("https://localhost:44348/api/pages"); //enter the TrowCmsAPI url here
                string response = await request.Content.ReadAsStringAsync();
                pages = JsonConvert.DeserializeObject<List<Page>>(response);
            }

            return View(pages);
        }

        // GET pages/edit/7
        public async Task<IActionResult> Edit(int id)
        {
            Page page = new Page();

            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync($"https://localhost:44348/api/pages/{id}"); //enter the TrowCmsAPI url with {id} here
                string response = await request.Content.ReadAsStringAsync();

                page = JsonConvert.DeserializeObject<Page>(response);
            }

            return View(page);
        }

        // POST pages/edit/7
        [HttpPost]
        public async Task<IActionResult> Edit(Page page)
        {
            page.Slug = page.Title.Replace(" ", "-").ToLower();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");
                using var request = await httpClient.PutAsync($"https://localhost:44348/api/pages/{page.Id}", content); //enter the TrowCmsAPI url with {id} here
                string response = await request.Content.ReadAsStringAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        //GET pages/create
        public IActionResult Create() => View();

        // POST pages/edit/7
        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            page.Slug = page.Title.Replace(" ", "-").ToLower();
            page.Sorting = 100;

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");
                using var request = await httpClient.PostAsync($"https://localhost:44348/api/pages", content);
                string response = await request.Content.ReadAsStringAsync();
            }

            return RedirectToAction("Index");
        }

        // GET /pages/delete/7
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.DeleteAsync($"https://localhost:44348/api/pages/{id}");
            }

            return RedirectToAction("Index");
        }
    }
}
