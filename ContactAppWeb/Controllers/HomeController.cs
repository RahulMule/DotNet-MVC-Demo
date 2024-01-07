using ContactAppWeb.Data;
using ContactAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ContactAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactDataContext _context;

        public HomeController(ILogger<HomeController> logger, ContactDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Contact contact)
		{
            if(ModelState.IsValid)
			{
				_context.Contacts.Add(contact);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
            return View(contact);
           
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
		}
		[HttpPost]
		public IActionResult Edit(Contact contact)
		{
			if (ModelState.IsValid)
			{
				_context.Contacts.Update(contact);
				_context.SaveChanges();
				return RedirectToAction("Index");

			}
			return View(contact);

		}
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(contact);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
