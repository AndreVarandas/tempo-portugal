using System;
using System.Collections.Generic;
using IPMA.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPMA.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty] public string District { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }

        public IndexModel(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Districts = _htmlHelper.GetEnumSelectList<Districts>();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Districts = _htmlHelper.GetEnumSelectList<Districts>();

                return Page();
            }

            var district = (Districts) Enum.Parse(typeof(Districts), District);

            return RedirectToPage("Forecasts/Detail", new {district});
        }
    }
}