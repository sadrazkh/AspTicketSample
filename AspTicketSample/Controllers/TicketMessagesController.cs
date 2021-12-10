using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspTicketSample.Data;
using AspTicketSample.Data.Entities;

namespace AspTicketSample.Controllers
{
    public class TicketMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketMessages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TicketMessages.Include(t => t.Ticket).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TicketMessages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketMessage = await _context.TicketMessages
                .Include(t => t.Ticket)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketMessage == null)
            {
                return NotFound();
            }

            return View(ticketMessage);
        }

        // GET: TicketMessages/Create
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TicketMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MessageTime,Message,UserId,TicketId")] TicketMessage ticketMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketMessage.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketMessage.UserId);
            return View(ticketMessage);
        }

        // GET: TicketMessages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketMessage = await _context.TicketMessages.FindAsync(id);
            if (ticketMessage == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketMessage.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketMessage.UserId);
            return View(ticketMessage);
        }

        // POST: TicketMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MessageTime,Message,UserId,TicketId")] TicketMessage ticketMessage)
        {
            if (id != ticketMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketMessageExists(ticketMessage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketMessage.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketMessage.UserId);
            return View(ticketMessage);
        }

        // GET: TicketMessages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketMessage = await _context.TicketMessages
                .Include(t => t.Ticket)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketMessage == null)
            {
                return NotFound();
            }

            return View(ticketMessage);
        }

        // POST: TicketMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ticketMessage = await _context.TicketMessages.FindAsync(id);
            _context.TicketMessages.Remove(ticketMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketMessageExists(long id)
        {
            return _context.TicketMessages.Any(e => e.Id == id);
        }
    }
}
