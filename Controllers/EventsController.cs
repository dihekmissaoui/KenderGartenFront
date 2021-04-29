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
    public class EventsController : Controller
    {
        // GET: Events
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
        public ActionResult Create()
        {
            return View("Create");
        }
      
        [HttpPost]
        public ActionResult Create(Events E)
        {
            try
            {
                var ev = new
                {
                    id_events = E.id_events ,
                    participates = 0,
                    nameEvents = E.name_events,
                    dateEvents = E.date_events,
                    not_interested = 0,
                    descriptionEvents = E.description_events,
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

        [HttpGet]
        public ActionResult View (int id)
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
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string a = "http://localhost:8081/api/Events/" + id;

            using (HttpClient client = new HttpClient())
            {
                string Url = "http://localhost:8081/api/post/";
                var uri = new Uri(Url);
                var response = client.DeleteAsync(a).Result;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}