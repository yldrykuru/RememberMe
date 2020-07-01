using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RememberMe.Data;
using RememberMe.Models;
using RememberMe.Models.ViewModel;

namespace RememberMe.Controllers
{
    public class AnasayfaController : RememberMeController
    {
        public AnasayfaController(ApplicationDbContext context) : base(context)
        {
        }
        //Başlangıç saatim  01.07.2020 21.41
        public async Task<IActionResult> Index()
        {
            List<MissionsViewModel> ViewModel = new List<MissionsViewModel>();
            List<Mission> gorevler = await _context.missions.Where(x => x.Status == true).ToListAsync();
            foreach (Mission item in gorevler)
            {
                MissionsViewModel ViewData = new MissionsViewModel();
                ViewData.id = item.Id;
                ViewData.name = item.Content;
                ViewData.startdate = item.MissionDate.ToString("yyyy-MM-dd");
                ViewData.enddate = item.MissionDate.AddDays(1).ToString("yyyy-MM-dd");
                ViewData.starttime = "00:00";
                ViewData.endtime = "24:59";
                ViewData.url = "#";
                ViewData.color = "#FF0000";
                ViewModel.Add(ViewData);
            }
            ViewBag.Data = JsonSerializer.Serialize(ViewModel);
            return View();
        }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Mission gorev)
    {
        //Scaffolding yapabilirdim de çok fazla detay ekleyecek gerek görmedim düzenlemesi uzun sürer :-)
        //Hadi fonksiyonu asenkron yapam bu kadar minimalist projede ne işe yarayacaksa 
        if (!ModelState.IsValid)
            return BadRequest();
        gorev.Status = true;
        _context.Add(gorev);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }
}
}
