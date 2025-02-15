using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace BIMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly BIMSContext _context;
         private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public UsersController(BIMSContext context, IConfiguration config, UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
               
               
                   
                    // Store admin details in session
                    HttpContext.Session.SetString("UserId", "0");
                    HttpContext.Session.SetString("UserRole", "Admin");
                    HttpContext.Session.SetString("UserName", "Administrator");



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

            HttpContext.Session.SetInt32("UserId", user.Id); // Store as int
            HttpContext.Session.SetString("UserName", user.FirstName); // Store the name as a string


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
            // Check if the admin is logged in
            if (HttpContext.Session.GetString("UserRole") == "Admin")
            {
                ViewData["Roles"] = new SelectList(new List<string> { "User", "DeliveryPerson" });
            }
            else
            {
                ViewData["Roles"] = null;
            }


            return View();
        }

        // POST: Users/Regist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user, string password, string? role)
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
                    // Hash the password
                    //var passwordHasher = new PasswordHasher<User>();
                    //user.PasswordHash = passwordHasher.HashPassword(user, password);
                    // Store the plain password 
                    user.UserName = user.Email;
                    user.Password = password;

                    // Additional user setup
                    user.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
                    user.IsActive = true;
                    user.IsDeleted = false;
                    if (!string.IsNullOrEmpty(role))
                    {
                        var roleExists = await _roleManager.RoleExistsAsync(role);
                        TempData["DebugRole"] = $"Selected Role: {role}, Exists: {roleExists}";
                        if (!roleExists)
                        {
                            TempData["ErrorMessage"] = "Role does not exist.";
                            return View(user);
                        }
                    }

                    // Create the user using Identity Framework
                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        TempData["ErrorMessage"] = string.Join(", ", createResult.Errors.Select(e => e.Description));
                        return View(user);
                    }
                   
                    // Assign Role
                    if (HttpContext.Session.GetString("UserRole") == "Admin")
                    {
                        var roleResult = await _userManager.AddToRoleAsync(user, "DeliveryPerson");
                        if (!roleResult.Succeeded)
                        {
                            TempData["ErrorMessage"] = "Failed to assign role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description));
                            return View(user);
                        }

                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                    // Redirect logic
                    if (HttpContext.Session.GetString("UserRole") == "Admin")
                    {
                        TempData["SuccessMessage"] = "Registration successful from admin!";
                        return RedirectToAction("Index", "Admin");
                    }

                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                }
            }

            TempData["ErrorMessage"] = "Registration failed. Please correct the errors.";

            // Reload ViewData
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", user.GenderId);
            if (HttpContext.Session.GetString("UserRole") == "Admin")
            {
                ViewData["Roles"] = new SelectList(new List<string> { "User", "DeliveryPerson" });
            }
            else
            {
                ViewData["Roles"] = null;
            }

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