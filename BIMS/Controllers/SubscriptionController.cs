using BIMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly BIMSContext _context;

        public SubscriptionController(BIMSContext context)
        {
            _context = context;
        }

        public IActionResult ChoosePlan()
        {
            var options = _context.SubscriptionOptions
                                  .Include(o => o.SubscriptionPlan)
                                  .Where(o => o.SubscriptionPlan.IsActive)
                                  .ToList();

            return View(options);
        }

        [HttpPost]
        public IActionResult PayWithChapa(int subscriptionOptionId)
        {
            var option = _context.SubscriptionOptions.Include(o => o.SubscriptionPlan)
                            .FirstOrDefault(o => o.Id == subscriptionOptionId);

            if (option == null)
                return NotFound();

            // store in temp for success redirect
            TempData["SubscriptionOptionId"] = option.Id;

            // Redirect to chapa
            var chapaRedirectUrl = $"https://api.chapa.co/pay?amount={option.Price}&callback_url=https://yourdomain.com/Subscription/PaymentSuccess";
            return Redirect(chapaRedirectUrl);
        }

        public async Task<IActionResult> PaymentSuccess()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var optionId = Convert.ToInt32(TempData["SubscriptionOptionId"]);

            var option = await _context.SubscriptionOptions.Include(o => o.SubscriptionPlan)
                            .FirstOrDefaultAsync(o => o.Id == optionId);

            var subscription = new Subscription
            {
                UserId = userId.Value,
                SubscriptionOptionId = option.Id,
                PaymentDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(option.DurationInMonths),
                IsActive = true,
                ChapaTxnRef = "YOUR-TXN-REF"
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Shops");
        }
    }

}
