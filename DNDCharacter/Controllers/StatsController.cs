using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;

namespace DNDCharacter.Controllers
{
    public class StatsController : Controller
    {
        private readonly DNDCharacterContext _db;

        public StatsController(DNDCharacterContext db)
        {
            _db = db;
        }

        public ActionResult Create(Stat stat, int CampaignCharacterId)
        {
            _db.Stats.Add(stat);
            if (CampaignCharacterId != 0)
            {

            }
            _db.SaveChanges();
            return RedirectToAction();
        }

        public ActionResult Details(int id)
        {
            Stat thisStat = _db.Stats
              .Include(stat => stat.Character)
              .ThenInclude(join => join.Character)
              .FirstOrDefault(stat => stat.StatId == id);

            return View(thisStat);
        }
    }
}