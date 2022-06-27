using ExamPrak7.DAL;
using ExamPrak7.Models;
using ExamPrak7.Utilize;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamPrak7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        public readonly AppDbContext _context;
        public readonly IWebHostEnvironment _env;
        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public ActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList();
            return View(teams);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (!ModelState.IsValid) return View();
            if (team.Image.CheckType("Image/"))
            {
                ModelState.AddModelError("Type", "Wrong Type");
                return View();
            }
            if (team.Image.CheckSize(1000))
            {
                ModelState.AddModelError("Size", "Wrong Size");
                return View();
            }
            if (team.Image != null)
            {
                team.ImageUrl = team.Image.SaveImg(Path.Combine(_env.WebRootPath, "images"));

            }
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Team team = _context.Teams.Find(id);
            if (team == null)
            {
                return BadRequest();
            }
            return View(team);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Team team)
        {
            if (id != team.Id)
            {
                return View();
            }
            Team DbTeam = _context.Teams.Find(id);
            if (team.Image.CheckType("images/"))
            {
                ModelState.AddModelError("Type", "Wrong Type");
                return View();
            }
            if (team.Image.CheckSize(1000))
            {
                ModelState.AddModelError("Size", "Wrong Size");
                return View();
            }
            if (team.Image != null)
            {
               
                Filemanager.DeleteFile(Path.Combine(_env.WebRootPath,"images" ,DbTeam.ImageUrl));
                DbTeam.ImageUrl = team.Image.SaveImg(Path.Combine(_env.WebRootPath, "images"));

            }
            DbTeam.Name = team.Name;
            DbTeam.Title = team.Title;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Team team = _context.Teams.Find(id);
            if (team == null)
            {
                return View();
            }
            Filemanager.DeleteFile(Path.Combine(_env.WebRootPath, team.ImageUrl));
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
