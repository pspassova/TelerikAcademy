using Calculator.Models;
using Calculator.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult BitCalculator(int quantity = 1, UnitType type = UnitType.Bit, int kilo = 1024)
        {
            ViewBag.SelectedType = type;
            ViewBag.SelectedKilo = kilo;
            ViewBag.Quantity = quantity;

            double baseValue = this.GetBaseValue(kilo, type);
            IEnumerable<DataViewModel> units = this.GetValues(kilo, quantity, baseValue);

            return View(units);
        }

        [NonAction]
        private IEnumerable<DataViewModel> GetValues(int quantity, int baseValue, double baseType)
        {
            return new List<DataViewModel>()
            {
                new DataViewModel(){ Type = UnitType.Bit, Value = quantity / (Math.Pow(baseValue, 0)/ baseType) * 8},
                new DataViewModel(){ Type = UnitType.Byte, Value = quantity / (Math.Pow(baseValue, 0)/baseType)},
                new DataViewModel(){ Type = UnitType.Kilobit, Value = quantity / (Math.Pow(baseValue, 1)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Kilobyte, Value = quantity / (Math.Pow(baseValue, 1)/baseType)},
                new DataViewModel(){ Type = UnitType.Megabit, Value = quantity / (Math.Pow(baseValue, 2)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Megabyte, Value = quantity / (Math.Pow(baseValue, 2)/baseType)},
                new DataViewModel(){ Type = UnitType.Gigabit, Value = quantity / (Math.Pow(baseValue, 3)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Gigabyte, Value = quantity / (Math.Pow(baseValue, 3)/baseType)},
                new DataViewModel(){ Type = UnitType.Terabit, Value = quantity / (Math.Pow(baseValue, 4)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Terabyte, Value = quantity / (Math.Pow(baseValue, 4)/baseType)},
                new DataViewModel(){ Type = UnitType.Petabit, Value =  quantity / (Math.Pow(baseValue, 5)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Petabyte, Value = quantity / (Math.Pow(baseValue, 5)/baseType)},
                new DataViewModel(){ Type = UnitType.Exabit, Value = quantity / (Math.Pow(baseValue, 6)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Exabyte, Value = quantity / (Math.Pow(baseValue, 6)/baseType)},
                new DataViewModel(){ Type = UnitType.Zettabit, Value = quantity / (Math.Pow(baseValue, 7)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Zettabyte, Value = quantity / (Math.Pow(baseValue, 7)/baseType)},
                new DataViewModel(){ Type = UnitType.Yottabit, Value = quantity / (Math.Pow(baseValue, 8)/baseType) * 8},
                new DataViewModel(){ Type = UnitType.Yottabyte, Value = quantity / (Math.Pow(baseValue, 8)/baseType)},
            };
        }

        [NonAction]
        private double GetBaseValue(int baseValue, UnitType type)
        {
            IEnumerable<DataViewModel> entities = new List<DataViewModel>()
            {
                new DataViewModel(){ Type = UnitType.Bit, Value = (Math.Pow(baseValue, 0)/8)},
                new DataViewModel(){ Type = UnitType.Byte, Value =  (Math.Pow(baseValue, 0))},
                new DataViewModel(){ Type = UnitType.Kilobit, Value =  (Math.Pow(baseValue, 1)/8)},
                new DataViewModel(){ Type = UnitType.Kilobyte, Value = (Math.Pow(baseValue, 1))},
                new DataViewModel(){ Type = UnitType.Megabit, Value = (Math.Pow(baseValue, 2)/8)},
                new DataViewModel(){ Type = UnitType.Megabyte, Value = (Math.Pow(baseValue, 2))},
                new DataViewModel(){ Type = UnitType.Gigabit, Value = (Math.Pow(baseValue, 3)/8)},
                new DataViewModel(){ Type = UnitType.Gigabyte, Value = (Math.Pow(baseValue, 3))},
                new DataViewModel(){ Type = UnitType.Terabit, Value = (Math.Pow(baseValue, 4)/8)},
                new DataViewModel(){ Type = UnitType.Terabyte, Value = (Math.Pow(baseValue, 4))},
                new DataViewModel(){ Type = UnitType.Petabit, Value =  (Math.Pow(baseValue, 5)/8)},
                new DataViewModel(){ Type = UnitType.Petabyte, Value = (Math.Pow(baseValue, 5))},
                new DataViewModel(){ Type = UnitType.Exabit, Value = (Math.Pow(baseValue, 6)/8)},
                new DataViewModel(){ Type = UnitType.Exabyte, Value = (Math.Pow(baseValue, 6))},
                new DataViewModel(){ Type = UnitType.Zettabit, Value = (Math.Pow(baseValue, 7)/8)},
                new DataViewModel(){ Type = UnitType.Zettabyte, Value = (Math.Pow(baseValue, 7))},
                new DataViewModel(){ Type = UnitType.Yottabit, Value = (Math.Pow(baseValue, 8)/8)},
                new DataViewModel(){ Type = UnitType.Yottabyte, Value = (Math.Pow(baseValue, 8))},
            };
            double value = entities.FirstOrDefault(e => e.Type == type).Value;

            return value;
        }
    }
}