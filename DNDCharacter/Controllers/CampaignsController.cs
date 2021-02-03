using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DNDCharacter.Models;

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
    }
}