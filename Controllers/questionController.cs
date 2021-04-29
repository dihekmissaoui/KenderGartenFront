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
    public class questionController : Controller
    {
        // GET: question
        public ActionResult Index()
        {
            List<questionForum> getQuestion = new List<questionForum>();


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8085");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/api/question/").Result;
            IEnumerable<questionForum> result;
            if (response.IsSuccessStatusCode)
            {
                var ForumResponse = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  

                result = JsonConvert.DeserializeObject<List<questionForum>>(ForumResponse);
            }
            else
            { result = null; }
            return View(result);
        }

        // GET: question/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            questionForum question = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/question/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<questionForum>();

                question = readTask.Result;
            }
            return View(question);
        }

        // GET: question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: question/Create
        [HttpPost]
        public ActionResult Create(questionForum ques)
        {
           HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            try 
            {

                // TODO: Add insert logic here
                client.PostAsJsonAsync<questionForum>("/api/question/",ques).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: question/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            questionForum question = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/question/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<questionForum>();

                question = readTask.Result;
            }
            return View(question);
        }

        // POST: question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, questionForum ques)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8085");
            //HTTP POST
            var putTask = client.PutAsJsonAsync<questionForum>("/api/question/" + id.ToString(), ques);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: question/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            questionForum question = null;
            client.BaseAddress = new Uri("http://localhost:8085");
            var responseTask = client.GetAsync("/api/question/" + id.ToString());

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<questionForum>();

                question = readTask.Result;
            }
            return View(question);
        }

        // POST: question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:8085");
                HttpResponseMessage response = Client.DeleteAsync("/api/question/" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }
    }
}
