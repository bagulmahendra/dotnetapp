using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreAppPostgreSQL.Models;
using System.Net.Http;
using Newtonsoft.Json;
using AspNetCoreAppPostgreSQL.Data;
using Microsoft.Extensions.Options;

namespace AspNetCoreAppPostgreSQL.Controllers
{
    public class SecurityController : Controller
    {
        private readonly API _api;


        public SecurityController(  IOptions<API> api)
        {
            
            _api = api.Value;
        }

        // GET: Security
        public async Task<IActionResult> Index()
        {

            List<Security> securityList = new List<Security>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_api.Url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    securityList = JsonConvert.DeserializeObject<List<Security>>(apiResponse);
                }
            }

            return View(securityList);
        }

        // GET: Security/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Security security = new Security();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_api.Url+"/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    security = JsonConvert.DeserializeObject<Security>(apiResponse);
                }
            }
            
            if (security == null)
            {
                return NotFound();
            }

            return View(security);
        }

        // GET: Security/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Security/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SecurityId,ProductType,Issuer,Currency,DealID")] Security security)
        {
            if (ModelState.IsValid)
            {
                
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.PostAsync(_api.Url , new StringContent(JsonConvert.SerializeObject(security),
                        System.Text.Encoding.UTF8, "application/json")))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); 
                    }
                }              
                return RedirectToAction(nameof(Index));
            }
            return View(security);
        }

        // GET: Security/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Security security = new Security();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_api.Url + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    security = JsonConvert.DeserializeObject<Security>(apiResponse);
                }
            }

            if (security == null)
            {
                return NotFound();
            }
            return View(security);
        }

        // POST: Security/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SecurityId,ProductType,Issuer,Currency,DealID")] Security security)
        {
            if (id != security.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.PutAsync(_api.Url, new StringContent(JsonConvert.SerializeObject(security),
                        System.Text.Encoding.UTF8, "application/json")))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(security);
        }

        // GET: Security/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Security security = new Security();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_api.Url + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    security = JsonConvert.DeserializeObject<Security>(apiResponse);
                }
            }
            if (security == null)
            {
                return NotFound();
            }

            return View(security);
        }

        // POST: Security/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync(_api.Url + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        
    }
}
