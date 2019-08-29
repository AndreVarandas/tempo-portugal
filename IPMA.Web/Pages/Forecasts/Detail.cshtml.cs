using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPMA.Core;
using IPMA.Core.Models;
using IPMA.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IPMA.Web.Pages.Forecasts
{
    public class Detail : PageModel
    {
        private readonly IIpma _ipma;

        public string LocationDisplayName { get; set; }
        public Forecast CurrentForecast { get; set; }
        public IEnumerable<Forecast> Forecasts { get; set; }

        public Detail(IIpma ipma)
        {
            _ipma = ipma;
        }
        
        public async Task<IActionResult> OnGetAsync(Districts district)
        {
            if (!Enum.IsDefined(typeof(Districts), district))
            {
                return RedirectToPage("./NotFound");
            }
            
            LocationDisplayName = district.GetDisplayName();
            var results = await _ipma.GetForecastForLocation(district);
            Forecasts = results.ToList();
            
            foreach (var forecast in Forecasts)
            {
                forecast.Weather = _ipma.GetWeatherDetailsForForecast(forecast);
                forecast.Wind = _ipma.GetWindDetailsForForecast(forecast);
                forecast.Icon = WeatherIcon.GetIconForWeather(forecast.WeatherTypeId);
            }

            CurrentForecast = Forecasts.First();
            Forecasts = Forecasts.Where(f => f != CurrentForecast); 
            
            return Page();
        }
    }
}