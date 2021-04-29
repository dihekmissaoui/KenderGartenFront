using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        [HttpGet]
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8081/api/Events/ShowAllEvents").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
            }
            else
            {
                ViewBag.result = " erreur";
            }

            Response.AddHeader("Refresh", "5");
            return View();
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            string a = "http://localhost:8081/api/Events/" + id;
            string c = "http://localhost:8081/api/commentevents/Details/" + id;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44345/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(a).Result;
            HttpResponseMessage res = Client.GetAsync(c).Result;
            HttpResponseMessage r = Client.GetAsync(c).Result;
            if (res.IsSuccessStatusCode && response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
                ViewBag.result2 = res.Content.ReadAsAsync<IEnumerable<CommentEvents>>().Result;
                ViewBag.result3 = r.Content.ReadAsAsync<IEnumerable<User>>().Result;
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
        public ActionResult Create(Main Re)
        {
            try
            {
                var rects = new
                {
                    react = Re.React.react,
                    users = new { id = 2 },
                    events = new { idEvents = Re.events.id_events }
                };
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44345/");
                client.PostAsJsonAsync("http://localhost:8081/api/ReactEvents/AddReact", rects).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return View();
                //   System.Diagnostics.Debug.Write("WORK02");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public ActionResult CreateCom()
        {
            return View("CreateCom");
        }
        [HttpPost]
        public ActionResult CreateCom(Main comment)
        {
            var com = new
            {
                dateCommentEvents = comment.commentEvents.dateCommentEvents,
                events = new { idEvents = comment.events.id_events },
                users = new { id = 2 },
                commentaire = comment.commentEvents.commentaire
            };
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44345/");
            client.PostAsJsonAsync("http://localhost:8081/api/commentevents/Add", com).ContinueWith((posTask) => posTask.Result.EnsureSuccessStatusCode());

            return View("View");

            // Response.Redirect("~/Views/Main"); // Or whatever your page url



        }
        [HttpGet]
        public ActionResult CreateEvents()
        {
            return View("CreateEvents");
        }

        [HttpPost]
        public ActionResult CreateEvents(Main E)
        {
            try
            {
                var ev = new
                {
                    id_events = E.events.id_events,
                    participates = 0,
                    nameEvents = E.events.name_events,
                    dateEvents = E.events.date_events,
                    not_interested = 0,
                    descriptionEvents = E.events.description_events,
                    interested = 0
                };
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44345/");
                client.PostAsJsonAsync("http://localhost:8081/api/Events/", ev).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                return View();
                //   System.Diagnostics.Debug.Write("WORK02");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }
        
        public ActionResult Delete(int id)
        {
            string a = "http://localhost:8081/api/Events/" + id;

            using (HttpClient client = new HttpClient())
            {
                string Url = "http://localhost:8081/api/Events/";
                var uri = new Uri(Url);
                var response = client.DeleteAsync(a).Result;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}