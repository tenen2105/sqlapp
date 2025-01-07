using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models; // Add this
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ActivityService _service;

        public List<Activity> Activities { get; set; } = new List<Activity>();

        public IndexModel()
        {
            _service = new ActivityService();
        }

        public void OnGet()
        {
            Activities = _service.GetActivities();
        }
    }
}
