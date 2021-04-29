using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ReactEventsController : Controller
    {
        
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create( ReactEvents Re)
        {
            try {
                var rects = new
                {
                    react = Re.react,
                    users = new { id = Re.users.id },
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
      
    }
}