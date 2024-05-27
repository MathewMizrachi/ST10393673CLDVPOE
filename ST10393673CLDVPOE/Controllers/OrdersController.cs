using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10393673CLDVPOE.Data;
using ST10393673CLDVPOE.Models;

namespace ST10393673CLDVPOE.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.Include(o =>o.Product).Where(a => a.UserID == User.Identity.Name).ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            Orders order = new Orders();
            order.UserID = User.Identity.Name;
            order.OrderDate = DateTime.Now;
            ViewBag.Product = new SelectList(_context.Product.OrderBy(x => x.Name), "ProductID", "Name", null);

            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderDate,OrderStatus,Quantity,UserID")] Orders orders)
        {
            orders.UserID = User.Identity.Name;

            //setting selected product
            int product = Convert.ToInt32(Request.Form["Product"]);
            orders.Product = await _context.Product.FindAsync(product);

            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.Include(a => a.Product).Where(a => a.OrderID == id).FirstOrDefaultAsync();

            if (orders == null)
            {
                return NotFound();
            }

            ViewBag.Product = new SelectList(_context.Product.OrderBy(x => x.Name), "ProductID", "Name", orders.Product.ProductID);

            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderDate,OrderStatus,Quantity,UserID")] Orders orders)
        {
            if (id != orders.OrderID)
            {
                return NotFound();
            }

            orders.UserID = User.Identity.Name;

            //setting selected product
            int product = Convert.ToInt32(Request.Form["Product"]);
            orders.Product = await _context.Product.FindAsync(product);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderID))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
