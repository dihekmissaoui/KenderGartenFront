using KenderGartenFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KenderGartenFront.Controllers
{
    public class PostController : Controller
    {  // GET: Post
        public ActionResult Index()
        {


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8081/api/post/").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Post>>().Result;
            }
            else
            {
                ViewBag.result = " erreur";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44345/");
            client.PostAsJsonAsync<Post>("http://localhost:8081/api/post/", post).ContinueWith((posTask) => posTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");

        }

}
}