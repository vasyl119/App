using Microsoft.AspNetCore.Mvc;
using App.DB.Models;
using App.DB;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Buffers;

namespace App.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly Context Context = null!;
        public DatabaseController(Context ctx) => Context = ctx;

        public IActionResult List(DatabaseViewModel<Measurement> model)
        {
            if (TempData.ContainsKey("sortbydate"))
            {
                Console.WriteLine((bool)TempData["sortbydate"]!);
                if ((bool)TempData["sortbydate"]! == true)
                    model.Entities = Context.Measurements.Include(x => x.Values).OrderBy(x => x.MeasureDate).ToList();
                else
                    model.Entities = Context.Measurements.Include(x => x.Values).OrderByDescending(x => x.MeasureDate).ToList();
            }
            else
                model.Entities = Context.Measurements.Include(x=>x.Values).ToList();

            return View(model);
        }

        public RedirectToActionResult SortByDate(DatabaseViewModel<Measurement> model)
        {
            TempData["sortbydate"] = true;
            return RedirectToAction("List","Database", model);
        }

        public RedirectToActionResult SortByDateDesc(DatabaseViewModel<Measurement> model)
        {
            TempData["sortbydate"] = false;
            return RedirectToAction("List", "Database", model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Measurement measurement)
        {
            foreach(var mv in measurement.Values)
                 mv.MeasurementID = measurement.ID;

            Context.Measurements.Add(measurement);
            Context.SaveChanges();
            return View();
        }

        [HttpGet]
        public FileResult Export(int id)
        {
            Measurement m = Context.Measurements.Where(x => x.ID == id).Include(x => x.Values).FirstOrDefault() ?? new Measurement();
            StringBuilder sb = new();

            sb.Append(m.MeasureDate + ";");
            sb.Append(m.Name + ";");
            sb.Append(m.Surename + ";");
            sb.Append(m.Subject + ";");
            sb.Append(m.SubjectNumber + ";\n");

            Console.WriteLine("hello");

            foreach (var mv in m.Values)
                sb.AppendLine(mv.Value + ";" + mv.Unit + ";");

            return File(Encoding.Unicode.GetBytes(sb.ToString()), "text/csv", $"Data{id}.csv");
        }

        public PartialViewResult AddMeasurementPartialView(int model)
        {
            return PartialView("Views/Database/Partials/_AddMeasurementPartial.cshtml", model);
        }
    }
}
