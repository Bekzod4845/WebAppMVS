using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVS.Data;
using WebAppMVS.Interfaces;
using WebAppMVS.Models;

namespace WebAppMVS.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> culbs = await _clubRepository.GetAll();
            return View(culbs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            // ReSharper disable once Mvc.ViewNotResolved
            return View(club);
        }

        public IActionResult Create()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return  View(club);
            }

            _clubRepository.Add(club);

            return RedirectToAction("Index");
        }
    }
}