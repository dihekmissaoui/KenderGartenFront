using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
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

            Response.AddHeader("Refresh", "5");
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Delete(int id)
        {
            string a = "http://localhost:8081/api/post/" + id;

            using (HttpClient client = new HttpClient())
            {
                string Url = "http://localhost:8081/api/post/";
                var uri = new Uri(Url);
                var response = client.DeleteAsync(a).Result;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            string a = "http://localhost:8081/api/post/" + id;
            Post p = new Post() ;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(a).Result;

            if (response.IsSuccessStatusCode)
            {
                 p = response.Content.ReadAsAsync<Post>().Result;
            }
      
            return View(p);
        }

     
        public ActionResult Edit(Post post)
        {

            //   post.date = post.date.ToString("yyyyMMdd");
     
            string a = "http://localhost:8081/api/post/" + post.id;

            using (HttpClient client = new HttpClient())
            {

                //   var result = client.PutAsync(a, new StringContent(post.v)).Result;
                var json = new JavaScriptSerializer().Serialize(post);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PutAsync(a, content).Result;
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Create(Post post)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44345/");
            client.PostAsJsonAsync<Post>("http://localhost:8081/api/post/", post).ContinueWith((posTask) => posTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
              Response.Redirect("~/default.aspx"); // Or whatever your page url



        }

        [HttpGet]
        public ActionResult TrendingPosts()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8081/api/post/trendingPosts").Result;
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
        public ActionResult GetById(int id)
        {
            string a = "http://localhost:8081/api/post/" + id;

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8081/api/post/trendingPosts").Result;
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

    }
}