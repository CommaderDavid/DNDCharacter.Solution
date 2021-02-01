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
    }
}