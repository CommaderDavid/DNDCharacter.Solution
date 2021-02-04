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
            return View();
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

        public ActionResult AddCategory(int id)
        {
            Character thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
            ViewBag.CampaignId = new SelectList(_db.Campaigns, "CampaignId", "Name");
            return View(thisCharacter);
        }

        [HttpPost]
        public ActionResult AddCategory(Character character, int CampaignId)
        {
            if (CampaignId != 0)
            {
                _db.CampaignCharacter.Add(new CampaignCharacter() { CampaignId = CampaignId, CharacterId = character.CharacterId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}