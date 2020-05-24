using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssignmentAsp.Models;
using AssignmentAsp.Data;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) { _context = context; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> MachineLearning() 
        { 
            ViewData["Message"] = "Your application description page.";
            if (!User.Identity.IsAuthenticated) 
            { 
                foreach (var post in _context.MachineLearningCompaniesFeedback)
                    { 
                    post.canIncreaseLike = true;
                    post.canIncreaseHate = true;
                } 
                await _context.SaveChangesAsync(); 
            }
            var allDiscussions = from result in _context.MachineLearningCompaniesFeedback orderby result.PostDate descending select result;
            return View(await allDiscussions.ToListAsync());
            //return View(await _context.MachineLearningCompaniesFeedback.ToListAsync()); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
