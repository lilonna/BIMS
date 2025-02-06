using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;

namespace BIMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly BIMSContext _context;
         private readonly IConfiguration _config;


        public UsersController(BIMSContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
       

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var bIMSContext = _context.Users.Include(u => u.Gender);
            return View(await bIMSContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            string adminEmail = _config["AdminCredentials:Email"];
            string adminPassword = _config["AdminCredentials:Password"];
            if (email == adminEmail && password == adminPassword)
            {
                // Successful login
                return RedirectToAction("Index", "Admin");
            }

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessage"] = "Email and Password are required.";
                return View();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsActive && !u.IsDeleted);

            if (user == null || user.Password != password) // Check email and password
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return View();
            }

            // Store user information in session
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserName", user.FirstName);

            TempData["SuccessMessage"] = $"Welcome, {user.FirstName}!";
            return RedirectToAction("Index", "Home");

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["LogoutSuccess"] = "You have successfully logged out!";
            return RedirectToAction("Index", "Home");
        }

        


        // GET: Users/Register
        public IActionResult Register()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");

            return View();
        }

        // POST: Users/Regist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user, string password)
        {
          

            if (string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessage"] = "Password is required.";
                return View(user);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Store the plain password 
                    user.Password = password;

                    // Additional user setup
                    user.CreatedDate = DateOnly.FromDateTime(DateTime.Now); // Ensure compatibility
                    user.IsActive = true;
                    user.IsDeleted = false;

                    // Save user
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Registration successful. Please login.";
                    return RedirectToAction(nameof(Login));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                }
            }

            TempData["ErrorMessage"] = "Registration failed. Please correct the errors.";


            // Ensure GenderId and other fields are populated
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", user.GenderId);

            return View(user);
        }





        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenderId,FirstName,MiddleName,LastName,Email,PhoneNumber,CreatedDate,IsActive,IsDeleted")] User user)
        {
            if (user.Email == null)
            {
                TempData["ErrorMessage"] = "email is required!";
                ModelState.AddModelError("Email", "email is required");
            }
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "User created successfully!";
               

                return RedirectToAction(nameof(Index));

                
            }
            TempData["ErrorMessage"] = "User not created successfully!";
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", user.GenderId);
            return View(user);
            



        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", user.GenderId);
            return View(user);
        }

        // POST: Users/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenderId,FirstName,MiddleName,LastName,Email,PhoneNumber,CreatedDate,IsActive,IsDeleted")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", user.GenderId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
