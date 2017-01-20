using System.Web.Mvc;

namespace SumatorMVC.Controllers
{
    public class SumatorController : Controller
    {
        public ActionResult Sumator(double? sum)
        {
            this.ViewBag.Sum = sum;
            return this.View();
        }

        public ActionResult Sum(double? firstNumber, double? secondNumber)
        {
            return this.RedirectToAction("Sumator", new
            {
                sum = firstNumber + secondNumber
            });
        }
    }
}