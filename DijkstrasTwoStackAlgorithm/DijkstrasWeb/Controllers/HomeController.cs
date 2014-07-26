using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DijkstrasWeb.Models;
using DijkstraTwoStackAlgorithm;
using DijkstraTwoStackAlgorithm.Interfaces;

namespace DijkstrasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlgorithm _algorithm;     // Instance of algorithm
        private readonly IExpressionBuilder _builder;

        public HomeController(IExpressionBuilder builder, IAlgorithm algorithm)
        {
            if (builder == null)
                throw new ArgumentNullException("builder", "No valid ExpressionBuilder class supplied to Home Controller.");
            if (algorithm == null)
                throw new ArgumentNullException("algorithm", "No valid Algorithm class supplied to Home Controller.");

            _builder = builder;
            _algorithm = algorithm;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Dijkstra's Two Stack Algorithm";

            return View();
        }


        [HttpPost]
        public ActionResult NumberButtonClick(char value, string expression)
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            _builder.SetExpression(expression);
            var result = _builder.AddDigit(value);
            if (!result.Success)
            {
                model.Message = result.ErrorMessage;
            }

            model.Expression = _builder.GetExpression();
            return Json(model);
        }

        [HttpPost]
        public ActionResult OperatorButtonClick(char value, string expression)
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            _builder.SetExpression(expression);
            var result = _builder.AddOperator(value);
            if (!result.Success)
            {
                model.Message = result.ErrorMessage;
            }

            model.Expression = _builder.GetExpression();
            return Json(model);
        }

        [HttpPost]
        public ActionResult RightBraceButtonClick(char value, string expression)
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            _builder.SetExpression(expression);
            var result = _builder.AddRightBrace(value);
            if (!result.Success)
            {
                model.Message = result.ErrorMessage;
            }

            model.Expression = _builder.GetExpression();
            return Json(model);
        }

        [HttpPost]
        public ActionResult CancelButtonClick(char value, string expression)
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            _builder.SetExpression(expression);
            var result = _builder.RemoveLastCharacter();
            if (!result.Success)
            {
                model.Message = result.ErrorMessage;
            }

            model.Expression = _builder.GetExpression();
            return Json(model);
        }

        [HttpPost]
        public ActionResult ClearButtonClick(char value, string expression)
        {
            var model = new DijkstrasTwoStackAlgorithmModel();
            return Json(model);
        }


        [HttpPost]
        public ActionResult EqualsButtonClick(string expression)
        {
            var result = _algorithm.Calculate(expression);

            var model = new DijkstrasTwoStackAlgorithmModel
            {
                Expression = expression, 
                Answer = result
            };

            return Json(model);
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
