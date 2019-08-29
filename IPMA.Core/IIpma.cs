using System.Collections.Generic;
using System.Threading.Tasks;
using IPMA.Core.Models;

namespace IPMA.Core
{
    public interface IIpma
    {
        Task<IEnumerable<DistrictIdentifier>> GetDistrictIdentifiers();
        Task<IEnumerable<WeatherType>> GetWeatherTypes();
        Task<IEnumerable<WindType>> GetWindTypes();
        WeatherType GetWeatherDetailsForForecast(Forecast forecast);
        WindType GetWindDetailsForForecast(Forecast forecast);
        Task<IEnumerable<Forecast>> GetForecastForLocation(Districts districts);
        Task<IEnumerable<Forecast>> GetForecastsForDay(string day);
        Forecast GetForecastFromForecasts(IEnumerable<Forecast> forecasts, Districts locationId);
    }
}