using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentAsp.Data;
using AssignmentAsp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssignmentAsp.Controllers
{
    public class MachineLearningCompaniesFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachineLearningCompaniesFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachineLearningCompaniesFeedbacks
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MachineLearningCompaniesFeedback.ToListAsync());
        }

        // GET: MachineLearningCompaniesFeedbacks/Details/5
        [Authorize(Roles = "Manager,RegisteredUser")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompaniesFeedback = await _context.MachineLearningCompaniesFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineLearningCompaniesFeedback == null)
            {
                return NotFound();
            }

            return View(machineLearningCompaniesFeedback);
        }

        // GET: MachineLearningCompaniesFeedbacks/Create
        [Authorize(Roles = "Manager,RegisteredUser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachineLearningCompaniesFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,RegisteredUser")]
        public async Task<IActionResult> Create([Bind("Id,PostDate,UserName,TopicTitle,SelectCompany,MessageContent,Like")] MachineLearningCompaniesFeedback machineLearningCompaniesFeedback)
        {
            MachineLearningCompaniesFeedback feedback = new MachineLearningCompaniesFeedback();

            if (ModelState.IsValid)
            {
                _context.Add(machineLearningCompaniesFeedback);
                feedback.PostDate = DateTime.Today;
                feedback.UserName = User.Identity.Name;
                feedback.Like = 0;
                await _context.SaveChangesAsync();
                return RedirectToAction("MachineLearning", "Home");
            }
            return View(feedback);
        }

        // GET: MachineLearningCompaniesFeedbacks/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompaniesFeedback = await _context.MachineLearningCompaniesFeedback.FindAsync(id);
            if (machineLearningCompaniesFeedback == null)
            {
                return NotFound();
            }
            return View(machineLearningCompaniesFeedback);
        }

        // POST: MachineLearningCompaniesFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostDate,UserName,TopicTitle,SelectCompany,MessageContent,Like")] MachineLearningCompaniesFeedback machineLearningCompaniesFeedback)
        {
            if (id != machineLearningCompaniesFeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineLearningCompaniesFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineLearningCompaniesFeedbackExists(machineLearningCompaniesFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MachineLearning", "Home");
            }
            return View(machineLearningCompaniesFeedback);
        }

        // GET: MachineLearningCompaniesFeedbacks/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompaniesFeedback = await _context.MachineLearningCompaniesFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineLearningCompaniesFeedback == null)
            {
                return NotFound();
            }

            return View(machineLearningCompaniesFeedback);
        }

        // POST: MachineLearningCompaniesFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineLearningCompaniesFeedback = await _context.MachineLearningCompaniesFeedback.FindAsync(id);
            _context.MachineLearningCompaniesFeedback.Remove(machineLearningCompaniesFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("MachineLearning", "Home");
        }

        private bool MachineLearningCompaniesFeedbackExists(int id)
        {
            return _context.MachineLearningCompaniesFeedback.Any(e => e.Id == id);
        }
        [Authorize(Roles = "Manager,RegisteredUser")]
        public async Task<IActionResult> IncreaseLike(int? id)
        {
            if (id == null) { return NotFound(); }
            var feedback = await _context.MachineLearningCompaniesFeedback.FindAsync(id); if (feedback == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && feedback.canIncreaseLike)
                    {
                        feedback.Agree++;
                        feedback.canIncreaseLike = false;
                        _context.Update(feedback);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineLearningCompaniesFeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MachineLearning", "Home");
            }
            return RedirectToAction("MachineLearning", "Home");
        }
        [Authorize(Roles = "Manager,RegisteredUser")]
        public async Task<IActionResult> IncreaseHate(int? id)
        {
            if (id == null) { return NotFound(); }
            var feedback = await _context.MachineLearningCompaniesFeedback.FindAsync(id); if (feedback == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && feedback.canIncreaseHate)
                    {
                        feedback.Disagree++;
                        feedback.canIncreaseHate = false;
                        _context.Update(feedback);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineLearningCompaniesFeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MachineLearning", "Home"); ;
            }
            return RedirectToAction("MachineLearning", "Home");
        }
    }
}
