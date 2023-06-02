using BlogManagementWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BlogManagementWeb.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _SubscriptionService;
        private readonly IBlogService _BlogService;
        public SubscriptionController(ISubscriptionService SubscriptionService, IBlogService blogService)
        {

            _SubscriptionService = SubscriptionService;
            _BlogService = blogService;
        }
        public async Task<IActionResult> Index()
        {

            var subs = await _SubscriptionService.GetSubscriptionsAsync();
            var blogs = _BlogService.GetblogsAsync();
            ViewBag.Blogs = blogs;
            return View(subs);
        }
        //public ActionResult Subscribe()
        //{
             
           

            

        //    return View();
        //}


        [HttpPost]
        public async Task<IActionResult> Subscribe(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                var createdSub = await _SubscriptionService.CreateSubscriptionAsync(subscription);
                return RedirectToAction(nameof(Index), new { id = createdSub.Id });
            }

            return View(subscription);
        }
        public async Task<IActionResult> UnSubscribe(int id)
        {
            var blog = await _SubscriptionService.GetSubscriptionByIdAsync(id);
            return View(blog);
        }

        [HttpPost]
        [ActionName("UnSubscribe")]
        public async Task<IActionResult> UnSubscribed(int id)
        {
            await _SubscriptionService.DeleteSubscriptionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
