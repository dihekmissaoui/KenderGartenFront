using KenderGartenFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KenderGartenFront.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index()
        {
            List<Forum> getForum = new List<Forum>();


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/api/forum/").Result;
            IEnumerable<Forum> result;
            if (response.IsSuccessStatusCode)
            {
                var ForumResponse = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  

                result = JsonConvert.DeserializeObject<List<Forum>>(ForumResponse);
            }
            else
            { result = null; }
            return View(result);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            int counts=0;
            HttpClient client = new HttpClient();
            Forum forum = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            //HTTP GET("SpringMVC/servlet/GetActivities")
            var responseTask = client.GetAsync("/api/forum/" + id.ToString());
            var responseTask2 = client.GetAsync("/api/forum/getlikes/" + id.ToString());
            var results = responseTask2.Result;
            var result = responseTask.Result;
            if (results.IsSuccessStatusCode)
            {
                var readTasks = results.Content.ReadAsAsync<int>();

                counts = readTasks.Result;
                ViewBag.countLike = counts;
            }


            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Forum>();

                forum = readTask.Result;
            }
            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        public object Create(Forum forum)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            try
            {
                // TODO: Add insert logic here
                client.PostAsJsonAsync<Forum>("/api/forum/", forum).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            Forum forum = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/forum/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Forum>();

                forum = readTask.Result;
            }
            return View(forum);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Forum f)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            //HTTP POST
            var putTask = client.PutAsJsonAsync<Forum>("/api/forum/" + id.ToString(), f);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            Forum forum = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/forum/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Forum>();

                forum = readTask.Result;
            }
            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:8085");
                HttpResponseMessage response = Client.DeleteAsync("/api/forum/" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }

        public object Likes(likes forum, int id)
        {
            HttpClient client = new HttpClient();
            Forum fs = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            //HTTP GET("SpringMVC/servlet/GetActivities")
            var responseTask = client.GetAsync("/api/forum/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Forum>();

                fs = readTask.Result;
            }


            try
            {
                // TODO: Add insert logic here
                forum.forum_id = id;
                client.PostAsJsonAsync<likes>("/api/forum/likes", forum).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

               





                return RedirectToAction("Index");
            }
            catch
            {
                return View(fs);
            }
        }











    }
}
