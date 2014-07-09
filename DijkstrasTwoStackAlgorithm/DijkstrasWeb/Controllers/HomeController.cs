using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DijkstrasWeb.Models;
using DijkstraTwoStackAlgorithm;

namespace DijkstrasWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }


        public ActionResult Dijkstra()
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            model.Expression = "enter the math expression here";
            model.Result = 0.0;
            return View(model);
        }

        [HttpPost]
        public ActionResult Dijkstra(DijkstrasTwoStackAlgorithmModel dijkstra)
        {
            try
            {
                var algorithm = new Algorithm();

                var expression = dijkstra.Expression;
                var result = algorithm.Interpret(expression);

                var model = new DijkstrasTwoStackAlgorithmModel();
                
                model.Expression = expression;
                model.Result = result;

                dijkstra.Result = result;

                return View(dijkstra);
            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
