using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;

namespace DNDCharacter.Controllers
{
    public class CharactersController : Controller
    {
        private readonly DNDCharacterContext _db;

        public CharactersController(DNDCharacterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Character> model = _db.Characters.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(_db.Campaigns, "CampaignId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Character character, int CampaignId)
        {
            _db.Characters.Add(character);
            if (CampaignId != 0)
            {
                _db.CampaignCharacter.Add(new CampaignCharacter() { CampaignId = CampaignId, CharacterId = character.CharacterId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Character thisCharacter = _db.Characters
              .Include(character => character.Campaigns)
                .ThenInclude(join => join.Campaign)
              .FirstOrDefault(character => character.CharacterId == id);
            return View(thisCharacter);
        }

        public ActionResult AddCampaign(int id)
        {
            Character thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
            ViewBag.CampaignId = new SelectList(_db.Campaigns, "CampaignId", "Name");
            return View(thisCharacter);
        }

        [HttpPost]
        public ActionResult AddCampaign(Character character, int CampaignId)
        {
            if (CampaignId != 0)
            {
                _db.CampaignCharacter.Add(new CampaignCharacter() { CampaignId = CampaignId, CharacterId = character.CharacterId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Character thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
            ViewBag.CampaignId = new SelectList(_db.Campaigns, "CampaignId", "Name");
            return View(thisCharacter);
        }

        [HttpPost]
        public ActionResult Edit(Character character, int campaignId)
        {
            bool duplicate = _db.CampaignCharacter.Any(campChar => campChar.CampaignId == campaignId && campChar.CharacterId == character.CharacterId);
            if (campaignId != 0 && !duplicate)
            {
                _db.CampaignCharacter.Add(new CampaignCharacter() { CampaignId = campaignId, CharacterId = character.CharacterId });
            }
            _db.Entry(character).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Character thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
            return View(thisCharacter);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Character thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
            _db.Characters.Remove(thisCharacter);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCampaign(int joinId)
        {
            CampaignCharacter joinEntry = _db.CampaignCharacter.FirstOrDefault(entry => entry.CampaignCharacterId == joinId);
            _db.CampaignCharacter.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}