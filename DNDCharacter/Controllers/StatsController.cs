using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DNDCharacter.Controllers
{
    public class StatsController : Controller
    {
        private readonly DNDCharacterContext _db;

        public StatsController(DNDCharacterContext db)
        {
            _db = db;
        }

        public ActionResult Create(CampaignCharacter campaignCharacter)
        {
            // you have the CampaignId, CharacterId, CampaignCharacterId
            ViewBag.CampCharId = campaignCharacter.CampaignCharacterId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stat stat)
        {
            int CampCharId = System.Int32.Parse(Request.Form["CampCharId"]);
            _db.Stats.Add(stat);
            _db.SaveChanges();

            CampaignCharacter thisCampaignCharacter = _db.CampaignCharacter
                .FirstOrDefault(charCamp => charCamp.CampaignCharacterId == CampCharId);

            thisCampaignCharacter.StatId = stat.StatId;

            _db.Entry(thisCampaignCharacter).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Characters");
        }

        public ActionResult Details(int id)
        {
            Stat thisStat = _db.Stats
                .Include(stat => stat.Character)
                .ThenInclude(join => join.Character)
                .FirstOrDefault(stat => stat.StatId == id);

            return View(thisStat);
        }

        public ActionResult Edit(int id)
        {
            Stat thisStat = _db.Stats
                .Include(stat => stat.Character)
                .ThenInclude(join => join.Character)
                .FirstOrDefault(stat => stat.StatId == id);
            return View(thisStat);
        }

        [HttpPost]
        public ActionResult Edit(Stat stat)
        {
            _db.Entry(stat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Characters");
        }
    }
}