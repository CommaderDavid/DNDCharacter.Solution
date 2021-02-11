using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DNDCharacter.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly DNDCharacterContext _db;

        public CampaignsController(DNDCharacterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Campaign> model = _db.Campaigns.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campaign campaign)
        {
            _db.Campaigns.Add(campaign);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Campaign thisCampaign = _db.Campaigns
                .Include(campaign => campaign.Characters)
                .ThenInclude(join => join.Character)
                .FirstOrDefault(campaign => campaign.CampaignId == id);
            return View(thisCampaign);
        }

        [HttpPost]
        public ActionResult Details(Character character)
        {
            _db.Entry(character).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details");
        }

        public ActionResult Edit(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            return View(thisCampaign);
        }

        [HttpPost]
        public ActionResult Edit(Campaign campaign)
        {
            _db.Entry(campaign).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            return View(thisCampaign);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            _db.Campaigns.Remove(thisCampaign);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}