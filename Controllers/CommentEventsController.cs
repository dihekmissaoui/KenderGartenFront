using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CommentEventsController : Controller
    {
        // GET: CommentEvents
        [HttpGet]
        public ActionResult CommentList (int id)
        {
            string a = "http://localhost:8081/api/commentevents/Details/" + id;

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(a).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<CommentEvents>>().Result;
            }
            else
            {
                ViewBag.result = " erreur";
            }
            return View();
        }
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(CommentEvents comment)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44345/");
            client.PostAsJsonAsync<CommentEvents>("http://localhost:8081/api/commentevents/Add", comment).ContinueWith((posTask) => posTask.Result.EnsureSuccessStatusCode());

            return View();
           // Response.Redirect("~/default.aspx"); // Or whatever your page url



        }
    }
}