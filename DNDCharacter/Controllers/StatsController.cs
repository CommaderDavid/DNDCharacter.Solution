using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;
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
            // TEST CODE-----------------------------------------
            ViewBag.CampCharId = new SelectList(_db.CampaignCharacter, "CampaignCharacterId");
            System.Console.WriteLine(campaignCharacter.CampaignCharacterId);
            //TEST CODE-------------------------------------------------
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stat stat, int StatId)
        {

            //TEST CODE--------------------------
            string testCampCharId = Request.Form["CampCharId"];
            System.Console.WriteLine(testCampCharId);
            //--------------------------------------------
            _db.Stats.Add(stat);
            // _db.SaveChanges();

            // get the join table row
            // add the stat.StatId to that row's StatId property

            if (StatId != 0)
            {
                _db.CampaignCharacter.Add(new CampaignCharacter() { StatId = StatId });
            }
            _db.Entry(stat).State = EntityState.Modified;
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