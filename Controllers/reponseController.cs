using KenderGartenFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KenderGartenFront.Controllers
{
    public class reponseController : Controller
    {
        // GET: reponse
        public ActionResult Index()
        {

            List<reponseForum> getForum = new List<reponseForum>();


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/api/reponse/").Result;
            IEnumerable<reponseForum> result;
            if (response.IsSuccessStatusCode)
            {
                var ForumResponse = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  

                result = JsonConvert.DeserializeObject<List<reponseForum>>(ForumResponse);
            }
            else
            { result = null; }
            return View(result);
        }

        // GET: reponse/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            reponseForum rep = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/reponse/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<reponseForum>();

                rep = readTask.Result;
            }
            return View(rep);
        }

        // GET: reponse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reponse/Create
        [HttpPost]
        public ActionResult Create(reponseForum rep,int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            try
            {

                // TODO: Add insert logic here
                client.PostAsJsonAsync<reponseForum>("/api/reponse/add/" + id.ToString(), rep).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index","question");
            }
            catch
            {
                return View();
            }
        }

        // GET: reponse/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            reponseForum rep = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/reponse/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<reponseForum>();

                rep = readTask.Result;
            }
            return View(rep);
        }

        // POST: reponse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reponseForum reps)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            //HTTP POST
            var putTask = client.PutAsJsonAsync<reponseForum>("/api/reponse/" + id.ToString(), reps);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: reponse/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
           reponseForum rep = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/reponse/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<reponseForum>();

                rep = readTask.Result;
            }
            return View(rep);
        }

        // POST: reponse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:8085");
                HttpResponseMessage response = Client.DeleteAsync("/api/reponse/delete/" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }





















    }
}
